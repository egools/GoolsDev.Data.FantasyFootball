using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRepo.Cosmos.Models
{
    public record Team(
        string TeamKey,
        string TeamName,
        TeamStanding TeamStanding
        );
}
