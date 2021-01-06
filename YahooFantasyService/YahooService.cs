using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
            _yahooToken = GetTokenFromBlobStorage().Result;
            if (_yahooToken.TokenExpiration < DateTime.UtcNow)
            {
                _yahooToken = RefreshAuthToken().Result;
            }
        }

        private YahooAuthToken _yahooToken;
        private readonly YahooServiceSettings _settings;

        public YahooLeagueSettings GetSeasonWithSettings(int year, int seasonId)
        {
            var url = BuildYahooUrl("league", $"{NFLGameKeys[year]}.l.{seasonId}", "settings");
            var result = CallYahooFantasyApi(url);
            return new YahooLeagueSettings();
        }

        public YahooMatchup GetMatchups()
        {
            return new YahooMatchup();
        }

        public async Task<string> CallYahooFantasyApi(string url)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _yahooToken.AccessToken);
            var response = await client.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }

        private async Task<YahooAuthToken> RefreshAuthToken()
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
                var newToken = new YahooAuthToken
                {
                    AccessToken = token.AccessToken,
                    TokenExpiration = DateTime.UtcNow.AddSeconds(token.ExpiresIn)
                };
                WriteTokenToBlobStorage(newToken);
                return newToken;
            }
            return null;
        }
        private async Task<YahooAuthToken> GetTokenFromBlobStorage()
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(_settings.ConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_settings.BlobContainerName);
            BlobClient blobClient = containerClient.GetBlobClient(_settings.BlobName);

            if (blobClient.Exists())
            {
                using var stream = await blobClient.OpenReadAsync();
                using var sr = new StreamReader(stream);
                return JsonSerializer.Deserialize<YahooAuthToken>(sr.ReadToEnd());
            }
            return null;
        }

        private void WriteTokenToBlobStorage(YahooAuthToken token)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(_settings.ConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_settings.BlobContainerName);
            BlobClient blobClient = containerClient.GetBlobClient(_settings.BlobName);
            var text = JsonSerializer.Serialize(token);
            using var stream = new MemoryStream(Encoding.ASCII.GetBytes(text));
            blobClient.UploadAsync(stream, overwrite: true);
        }

        private string BuildYahooUrl(string resource, string key, string subResource = "") => $"{_settings.BaseUrl}/{resource}/{key}/{subResource}?format=json";

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
