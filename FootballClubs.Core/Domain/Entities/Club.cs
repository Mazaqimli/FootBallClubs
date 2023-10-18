using FootballClubs.Core.Domain.Enums;
using Microsoft.Identity.Client;
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
        public decimal TotalPower { get; set; }
        public TacticalPlan TacticalPlan { get; set; }
        public int LeagueId { get;  set; }
        public int CountryId { get;  set; }
        public Country Country{ get; set; }
        public League League{ get; set; }
        public Player Player { get; set; }
    }
}
