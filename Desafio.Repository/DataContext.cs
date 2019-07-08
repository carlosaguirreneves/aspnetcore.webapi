using System;
using Desafio.Domain;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Contato> Contatos { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Contato>().Property(e => e.Canal)
                .HasConversion(v => v.ToString(), v => 
                    (CanalEnum)Enum.Parse(typeof(CanalEnum), v)
                );
        }
    }
}