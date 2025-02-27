﻿using OM.Application.Data.Repositories;
using OM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Infrastructure.Data.Repositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
