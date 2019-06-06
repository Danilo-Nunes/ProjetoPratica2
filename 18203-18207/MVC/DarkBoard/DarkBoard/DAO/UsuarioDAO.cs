using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using DarkBoard.Models;

namespace DarkBoard.DAO
{
    public class UsuarioDAO
    {
        public void Adiciona(Usuario prof)
        {
            using (var context = new SalaContext())
            {
                context.Usuario.Add(prof);
                context.SaveChanges();
            }
        }
        public IList<Usuario> Lista()
        {
            using (var contexto = new SalaContext())
            {
                return contexto.Usuario.ToList();
            }
        }

        public Usuario BuscaPorId(int codigo)
        {
            using (var contexto = new SalaContext())
            {
                return contexto.Usuario
                .Where(p => p.Id == codigo)
                .FirstOrDefault();
            }
        }

        public Usuario BuscaPorNome(string usu)
        {
            using (var contexto = new SalaContext())
            {
                return contexto.Usuario
                .Where(p => p.NomeUsu == usu)
                .FirstOrDefault();
            }
        }

        public Usuario BuscaPorNomeCompleto(string usu)
        {
            using (var contexto = new SalaContext())
            {
                return contexto.Usuario
                .Where(p => p.Nome == usu)
                .FirstOrDefault();
            }
        }

        public Usuario BuscaPorSala(int id)
        {
            using (var contexto = new SalaContext())
            {
                return (from p in contexto.Usuario
                        join e in contexto.Sala on p.Id equals e.CodProfessor
                        where e.Id == id
                        select p).First();
            }
        }
        public void Atualiza(Usuario Usuario)
        {
            using (var contexto = new SalaContext())
            {
                contexto.Entry(Usuario).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public IList<Usuario> Pesquisa(string pesq)
        {
            using (var contexto = new SalaContext())
            {
                return (from p in contexto.Usuario
                             where (p.Nome.Contains(pesq))
                             select p).ToList();

                
            }
        }
    }
}