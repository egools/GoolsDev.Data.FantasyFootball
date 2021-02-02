using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasyService
{
    public static class JObjectExtensions
    {
        public static JToken AbsorbTokenProperties(this JToken targetToken, JToken baseTeam)
        {
            var baseTeamProps = baseTeam.SelectTokens("[*]").Select(j => j.FirstOrDefault());
            foreach (var baseTeamProp in baseTeamProps)
            {
                if (baseTeamProp is JProperty prop)
                    targetToken[prop.Name] = prop.Value;
            }
            return targetToken;
        }
    }
}
