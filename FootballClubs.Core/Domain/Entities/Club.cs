using FootballClubs.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.Core.Domain.Entities
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TotalPower { get; set; }
        public TacticalPlan Tactical { get; set; }

        public List<Country> Countries { get; set; }
    }
}
