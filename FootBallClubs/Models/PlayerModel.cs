using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallClubs.Models
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int ClubId { get; set; }

        public override string ToString()
        {
            return FullName;
        }
    }
}
