using Microsoft.EntityFrameworkCore;
using Software_Testing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Testing.Context
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options):base(options)
        {

        }
        public DbSet<Card> Cards { get; set; }
    }
}
