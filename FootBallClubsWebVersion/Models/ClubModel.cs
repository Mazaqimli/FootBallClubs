using FootballClubs.Core.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FootBallClubsWebVersion.Models
{
    public class ClubModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public TacticalPlan TacticalPlan { get; set; }
        [Required]
        [Range (1,100, ErrorMessage = "Club power should be bigger than 1")]
        public decimal TotalPower { get; set; }

        public int LeagueId { get; set; }
        public int CountryId { get; set; }
    }
}
