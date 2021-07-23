using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checks.Config
{
    public static class AplicationDbContextInMemory
    {
        public static AplicationDbContext Get()
        {
            var option = new DbContextOptionsBuilder<AplicationDbContext>().UseInMemoryDatabase(databaseName: $"aux-db").Options;

            return new AplicationDbContext(option);
        }
    }
}
