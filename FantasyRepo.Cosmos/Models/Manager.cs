using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRepo.Cosmos.Models
{
    public record Manager(
        string ManagerGuid,
        string ManagerId,
        string ManagerName,
        string CurrentFeloScore,
        string CurrentFeloTier);
}
