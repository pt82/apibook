﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApiBook.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Phonetype> Phone_Types { get; set; }



        public ApplicationContext()
         {
           // string connection = "server=localhost;user=root;password=123456;database=mybook;";
             //Database.EnsureCreated();

         }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
                   : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
              "server=localhost;user=root;password=123456;database=mybook;",
            new MySqlServerVersion(new Version(8, 0, 11))
         );
        }
        
    }
}
