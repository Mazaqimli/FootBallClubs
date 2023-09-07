using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.Core.Domain.Entities
{
    public class CountryClub
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Country Country { get; set; }
        public Club Club { get; set; }

    }
}
