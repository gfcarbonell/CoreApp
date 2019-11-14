using Core.Api.DataAccess.Contract.IDbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Api.DataAccess.DbContexts
{
    public class CoreDbContext : DbContext, ICoreDbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) :
               base(options)
        {

        }

        public CoreDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
