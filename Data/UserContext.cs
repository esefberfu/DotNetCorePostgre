using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DotNetCorePostgre.Context
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public String name { get; set; }

        public String surname { get; set; }

        public String created_at { get; set; }
    }
}
