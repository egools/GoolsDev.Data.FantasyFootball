using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FantasyComponents
{
    [Table("Managers", Schema = "bmgc")]
    public class Manager
    {
        public int ManagerId { get; }
        public string OwnerName { get; }
        public int YearJoined { get; }
    }
}
