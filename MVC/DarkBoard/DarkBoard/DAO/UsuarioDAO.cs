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
        public void Atualiza(Usuario Usuario)
        {
            using (var contexto = new SalaContext())
            {
                contexto.Entry(Usuario).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}