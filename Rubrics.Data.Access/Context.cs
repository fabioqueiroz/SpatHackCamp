using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Rubrics.Data.JoinModels;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Rubrics.Data.Access
{
    public class Context : DbContext
    {
        public IConfiguration Configuration { get; }

        public Context() : base()
        {

        }
        public Context(IConfiguration configuration) : base()
        {
            Configuration = configuration;
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public Context(DbContextOptions<Context> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    // local connection
                    .UseSqlServer("Data Source=LAPTOP-JEDG5RJB\\LAPSQLSERVER;Initial Catalog=Rubrics;Integrated Security=False;User Id=sa;Password=fabio1980;MultipleActiveResultSets=True");
                // Yusuf
                //.UseSqlServer("Data Source=YIU\\MYSERVER;Initial Catalog=Rubrics;Integrated Security=False;User Id=sa;Password=badat123;MultipleActiveResultSets=True");

                // Khaled
                //.UseSqlServer("Data Source=LAPTOP-SHIVRIL8\\KSQLSERVER;Initial Catalog=Rubrics;Integrated Security=False;User Id=sa;Password=1234;MultipleActiveResultSets=True");

            }
        }


        // tables for the database

        public DbSet<Student> Students { get; set; }
        public DbSet<Rubric> Rubrics { get; set; }
        public DbSet<TableGroup> TableGroups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<CategoryDescription> CategoryDescriptions { get; set; }
    }
}

