using DockerNetwork.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerNetwork
{
    public class TestContext : DbContext
    { 

        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<UserTag> UserTags { get; set; }
        public DbSet<UserProperty> UserPropertys { get; set; }
        public DbSet<BPfile> BPfiles { get; set; }

        
    }
}
