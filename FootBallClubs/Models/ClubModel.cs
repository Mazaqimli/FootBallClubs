using FootballClubs.Core.Domain.Enums;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace FootBallClubs.Models
{
    public class ClubModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TotalPower { get; set; }
        public TacticalPlan TacticalPlan { get; set; }

        public int LeagueId { get; set; }
        public int CountryId { get; set; }

        public override string ToString()
        {
            return Name + " " + TotalPower;
        }

    }
}