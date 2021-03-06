﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication21.Models
{
	public class ApplicationContext : DbContext
    {
       
        public DbSet<User> Users { get; set; }
      //  public DbSet<Profile> Profiles { get; set; }
        public DbSet<Image> Images { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
