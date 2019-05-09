using System;
using System.Collections.Generic;
using System.Linq;
using DarkBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace DarkBoard.DAO
{
    public class SalaDAO
    {
        public void Adiciona(Sala comp)
        {
            using (var context = new SalaContext())
            {
                context.Sala.Add(comp);
                context.SaveChanges();
            }
        }
        public IList<Sala> Lista()
        {
            using (var contexto = new SalaContext())
            {
                return contexto.Sala.ToList();
            }
        }

        public Sala BuscaPorId(int codigo)
        {
            using (var contexto = new SalaContext())
            {
                return contexto.Sala
                .Where(p => p.Id == codigo)
                .FirstOrDefault();
            }
        }

        public IList<Sala> BuscaPorProfessor(int id)
        {
            using (var contexto = new SalaContext())
            {
                return contexto.Sala
                .Where(p => p.CodProfessor == id)
                .ToList();
            }
        }
        public void Atualiza(Sala Sala)
        {
            using (var contexto = new SalaContext())
            {
                contexto.Entry(Sala).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Remove(Sala Sala)
        {
            using (var contexto = new SalaContext())
            {
                contexto.Remove(contexto.Sala.Single(a => a.Id == Sala.Id));
                contexto.SaveChanges();
            }
        }
    }
}
