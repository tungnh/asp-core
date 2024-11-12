﻿using OM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Application.Data.Queries
{
    public interface IProductDetailQuery
    {
        Task<List<ProductDetail>> FindAllAsync();

    }
}
