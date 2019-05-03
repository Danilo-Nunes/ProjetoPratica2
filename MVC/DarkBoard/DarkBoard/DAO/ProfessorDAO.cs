using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using DarkBoard.Models;

namespace DarkBoard.DAO
{
    public class ProfessorDAO
    {
        public void Adiciona(Usuario prof)
        {
            using (var context = new SalaContext())
            {
                context.Professor.Add(prof);
                context.SaveChanges();
            }
        }
        public IList<Usuario> Lista()
        {
            using (var contexto = new SalaContext())
            {
                return contexto.Professor.ToList();
            }
        }

        public Usuario BuscaPorCodigo(int codigo)
        {
            using (var contexto = new SalaContext())
            {
                return contexto.Professor
                .Where(p => p.Codigo == codigo)
                .FirstOrDefault();
            }
        }
        public void Atualiza(Usuario Professor)
        {
            using (var contexto = new SalaContext())
            {
                contexto.Entry(Professor).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}