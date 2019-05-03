using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using DarkBoard.Models;

namespace DarkBoard.DAO
{
    public class SalaContext : DbContext
    {
        public DbSet<Usuario> Aluno { get; set; }
        public DbSet<Usuario> Professor { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=regulus;Initial Catalog=PR118207;User ID=pr118207;Password=pr118207");
        }
    }
}