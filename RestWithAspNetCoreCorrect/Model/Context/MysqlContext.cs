using Microsoft.EntityFrameworkCore;
using RestWithAspNetCoreCorrect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetCore.Model.Context
{
    public class MysqlContext : DbContext
    {
        public MysqlContext()
        {

        }

        public MysqlContext(DbContextOptions<MysqlContext> options) : base(options){}

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
