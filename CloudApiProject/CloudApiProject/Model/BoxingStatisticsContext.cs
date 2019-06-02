using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudApiProject.Model
{
    public class BoxingStatisticsContext: DbContext
    {
        public BoxingStatisticsContext(DbContextOptions<BoxingStatisticsContext> options):base(options)
        {

        }

      public  DbSet<Result> Results { get; set; }
      public  DbSet<Boxer> Boxers { get; set; }

    }
}
