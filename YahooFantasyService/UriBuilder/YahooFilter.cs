namespace YahooFantasyService
{
    public class YahooFilter
    {
        public YahooFilter(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Key}={Value}";
        }
    }

}
