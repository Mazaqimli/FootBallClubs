﻿using FootballClubs.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.Core.Domain.Repositories
{
    public interface IClubRepository
    {
        void Add(Club cluq);
        void Update(Club club);
        void Delete (Club club); 

        Club Get(int id);
        List<Club> Get();
    }
}