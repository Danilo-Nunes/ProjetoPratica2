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
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Compromisso> Compromisso { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<AlunoSala> AlunoSala { get; set; }
        public DbSet<Comunicado> Comunicado { get; set; }
        public DbSet<Atividade> Atividade { get; set; }
        public DbSet<UsuarioAtividade> UsuarioAtividade { get; set; }
        public DbSet<ComunicadoAluno> ComunicadoAluno { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=regulus;Initial Catalog=PR118207;User ID=PR118207;Password=PR118207");
        }
    }
}