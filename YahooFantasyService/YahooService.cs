using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasyService
{
    public class YahooService
    {
        public YahooService(IOptions<YahooServiceSettings> options)
        {
            _settings = options.Value;
        }

        private YahooAuthToken _yahooToken;
        private readonly YahooServiceSettings _settings;

        public async Task<LeagueSettings> GetLeagueSettings(int year, int seasonId)
        {
            if(!NFLGameKeys.TryGetValue(year, out int gameKey))
            {
                throw new ArgumentException("NFL Game Key for given year does not exist.");
            }
            var leagueKey = $"{gameKey}.l.{seasonId}";
            var leagueResult = await GetLeagueData(leagueKey, new List<string> { "settings" });
            return leagueResult.League.Settings;
        }

        public async Task<YahooLeagueApiResult> GetLeagueData(string leagueKey, List<string> subResources = null)
        {
            var url = BuildYahooResourceUrl("league", leagueKey, subResources);
            var leagueResult = await CallYahooFantasyApi<YahooLeagueApiResult>(url);

            if (leagueResult is YahooErrorApiResult errorResult)
            {
                throw new ArgumentException(errorResult.Error.Description);
            }

            return leagueResult as YahooLeagueApiResult;
        }

        public async Task<YahooApiResultBase> CallYahooFantasyApi<T>(string url)
        {
            var client = new HttpClient();

            await RefreshAuthToken();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _yahooToken.AccessToken);
            var response = await client.GetAsync(url);
            var jsonResult = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                JObject o = JObject.Parse(jsonResult);
                var fantasyContent = o.SelectToken("fantasy_content").ToString();
                var resultBase = JsonConvert.DeserializeObject<T>(fantasyContent) as YahooApiResultBase;
                return resultBase;
            }
            else
            {
                var errorResult = JsonConvert.DeserializeObject<YahooErrorApiResult>(jsonResult);
                errorResult.StatusCode = response.StatusCode;
                return errorResult;
            }
        }

        private async Task RefreshAuthToken(bool retry = true)
        {
            if (_yahooToken is null || _yahooToken.TokenExpiration < DateTime.UtcNow)
            {
                var client = new HttpClient();
                var body = new Dictionary<string, string>
                {
                    { "grant_type", "refresh_token" },
                    { "redirect_uri", "oob" },
                    { "refresh_token", _settings.RefreshToken }
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _settings.AuthHeader);
                var response = await client.PostAsync(_settings.TokenUrl, new FormUrlEncodedContent(body));

                if (response.IsSuccessStatusCode)
                {
                    var token = JsonConvert.DeserializeObject<YahooTokenResponse>(await response.Content.ReadAsStringAsync());
                    _yahooToken = new YahooAuthToken
                    {
                        AccessToken = token.AccessToken,
                        TokenExpiration = DateTime.UtcNow.AddSeconds(token.ExpiresIn)
                    };
                }
                else
                {
                    if(retry)
                    {
                        await RefreshAuthToken(false);
                    }
                    else
                    {
                        var error = JObject.Parse(await response.Content.ReadAsStringAsync());
                        throw new HttpRequestException(error.Value<string>("error_description"), null, response.StatusCode);
                    }
                }
            }
        }

        private string BuildYahooResourceUrl(string resource, string key, List<string> subResources = null)
        {
            var subResourceCollection = subResources?.Any() ?? false
                ? ";out=" + string.Join(",", subResources)
                : string.Empty;

            return $"{_settings.BaseUrl}/{resource}/{key}{subResourceCollection}?format=json";
        }
        private string BuildYahooCollectionUrl(string collection, string resource, List<string> keys, List<string> subResources = null)
        {
            var resourceKeys = string.Join(",", keys);
            var subResourceCollection = subResources?.Any() ?? false
                ? ";out=" + string.Join(",", subResources)
                : string.Empty;
            return $"{_settings.BaseUrl}/{collection};{resource}_keys={resourceKeys}{subResourceCollection}?format=json";
        }

        public static IReadOnlyDictionary<int, int> NFLGameKeys => new Dictionary<int, int>
        {
            { 2004, 101 },
            { 2005, 124 },
            { 2006, 153 },
            { 2007, 175 },
            { 2008, 199 },
            { 2009, 222 },
            { 2010, 242 },
            { 2011, 257 },
            { 2012, 273 },
            { 2013, 314 },
            { 2014, 331 },
            { 2015, 348 },
            { 2016, 359 },
            { 2017, 371 },
            { 2018, 380 },
            { 2019, 390 },
            { 2020, 399 }
        };
    }
}
