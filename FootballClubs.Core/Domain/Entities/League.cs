using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.Core.Domain.Entities
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Club>Clubs { get; set; }
    }
}
