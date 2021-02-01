using System.Collections.Generic;

namespace YahooFantasyService
{
    public class YahooUriBuilder
    {
        private string _baseUrl;
        public YahooUriBuilder(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public string Build(List<YahooUriPart> resources) => $"{_baseUrl}/{string.Join("", resources)}?format=json";
    }
}
