using FootballClubs.Core.Domain.Entities;
using FootBallClubsWebVersion.Models;

namespace FootBallClubsWebVersion.Mappers
{
    public static class ClubMapper
    {
        public static ClubModel Map(Club c)
        {
            return new ClubModel
            {
                Id = c.Id,
                Name = c.Name,
                TacticalPlan = c.TacticalPlan,
                TotalPower = c.TotalPower,
                LeagueId = c.LeagueId,
                CountryId = c.CountryId
            };
        }
        public static Club Map(ClubModel m)
        {
            return new Club
            {
                Id = m.Id,
                Name = m.Name,
                TacticalPlan = m.TacticalPlan,
                TotalPower = m.TotalPower,
                LeagueId = m.LeagueId,
                CountryId = m.CountryId
            };
        }
    }
}
