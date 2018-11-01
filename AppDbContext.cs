using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace One
{
    public class AppDbContext : DbContext
    {
        private const string ConnectionString = @"Data Source=MyFirstEfCoreDb.db";

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionString);
        }        

        public DbSet<Author> Authors { get; set; }   
        public DbSet<Book> Books { get; set; }
    }
}