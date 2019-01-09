﻿using Microsoft.EntityFrameworkCore;
using System;

namespace MVCDemo.DataAccess
{
    public class MovieDBContext : DbContext
    {
        
        // with EF database-first, when our data model needs to change, we make changes to the SQL,
        //  then scaffold again overwriting our old C# classes. we do not manually change our C# classes

        // with EF code-first, when our data model needs to change, we make changes to the classes/dbcontext
        // then run migrations to update the datbase without destroying it


        // to run migrations - startup project needs "Microsoft.EntityFrameworkCore.Tools"
        // then run in PM Console, with "Default project" set to the project with your dbcontext in it
        // Add-Migration <some name describing change>
        // Update-Database

        //if we used EnsureCreated, we can't use migrations, need to start over

        public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options)
        { }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<CastMember> CastMember { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // using dataannotations for now
        }
    }
}
