using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YahooFantasyService
{
    public class YahooManager
    {
        [JsonConstructor]
        public YahooManager(JToken manager)
        {
            ManagerId = manager["manager_id"].ToString();
            Nickname = manager["nickname"].ToString();
            Guid = manager["guid"].ToString();
        }

        [JsonProperty(PropertyName = "manager_id")]
        public string ManagerId { get; set; }

        [JsonProperty(PropertyName = "nickname")]
        public string Nickname { get; set; }

        [JsonProperty(PropertyName = "guid")]
        public string Guid { get; set; }
    }




}
