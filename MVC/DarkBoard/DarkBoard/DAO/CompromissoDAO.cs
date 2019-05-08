using System;
using System.Collections.Generic;
using System.Linq;
using DarkBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace DarkBoard.DAO
{
    public class CompromissoDAO
    {
        public void Adiciona(Compromisso comp)
        {
            using (var context = new SalaContext())
            {
                context.Compromisso.Add(comp);
                context.SaveChanges();
            }
        }
        public IList<Compromisso> Lista()
        {
            using (var contexto = new SalaContext())
            {
                return contexto.Compromisso.ToList();
            }
        }

        public Compromisso BuscaPorId(int codigo)
        {
            using (var contexto = new SalaContext())
            {
                return contexto.Compromisso
                .Where(p => p.Id == codigo)
                .FirstOrDefault();
            }
        }

        public IList<Compromisso> BuscaPorUsuario(int id)
        {
            using (var contexto = new SalaContext())
            {
                return contexto.Compromisso
                .Where(p => p.CodUsuario == id)
                .ToList();
            }
        }
        public void Atualiza(Compromisso Compromisso)
        {
            using (var contexto = new SalaContext())
            {
                contexto.Entry(Compromisso).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}
