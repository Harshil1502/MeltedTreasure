using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcCandle.Models;

namespace MvcCandle.Data
{
    public class MvcCandleContext : DbContext
    {
        public MvcCandleContext (DbContextOptions<MvcCandleContext> options)
            : base(options)
        {
        }

        public DbSet<MvcCandle.Models.Candle> Candle { get; set; }
    }
}
