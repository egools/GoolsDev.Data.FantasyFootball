using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
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

        public async Task<YahooLeagueApiResult> GetSeasonWithSettings(int year, int seasonId)
        {
            var url = BuildYahooResourceUrl("league", $"{NFLGameKeys[year]}.l.{seasonId}", new List<string> { "settings" });
            var jsonResult = await CallYahooFantasyApi(url);
            using JsonDocument doc = JsonDocument.Parse(jsonResult);
            var fantasyContent = doc.RootElement.GetProperty("fantasy_content").ToString();
            var resultBase = JsonSerializer.Deserialize<YahooLeagueApiResult>(fantasyContent);
            //TODO: parse league portion
            return null;
        }

        public YahooMatchup GetMatchups()
        {
            return new YahooMatchup();
        }

        public async Task<string> CallYahooFantasyApi(string url)
        {
            var client = new HttpClient();

            await RefreshAuthToken();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _yahooToken.AccessToken);
            var response = await client.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }

        private async Task RefreshAuthToken()
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

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var token = JsonSerializer.Deserialize<YahooTokenResponse>(await response.Content.ReadAsStringAsync());
                    _yahooToken = new YahooAuthToken
                    {
                        AccessToken = token.AccessToken,
                        TokenExpiration = DateTime.UtcNow.AddSeconds(token.ExpiresIn)
                    };
                }
            }
        }

        private string BuildYahooResourceUrl(string resource, string key, List<string> subResources)
        {
            var subResourceCollection = subResources.Any()
                ? ";out=" + string.Join(",", subResources)
                : string.Empty;

            return $"{_settings.BaseUrl}/{resource}/{key}{subResourceCollection}?format=json";
        }
        private string BuildYahooCollectionUrl(string collection, string resource, List<string> keys, List<string> subResources)
        {
            var resourceKeys = string.Join(",", keys);
            var subResourceCollection = subResources.Any()
                ? ";out=" + string.Join(",", subResources)
                : string.Empty;
            return $"{_settings.BaseUrl}/{collection};{resource}_keys={resourceKeys}{subResourceCollection}?format=json";
        }

    public static readonly IReadOnlyDictionary<int, int> NFLGameKeys = new ReadOnlyDictionary<int, int>(new Dictionary<int, int>
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
        });
}
}
