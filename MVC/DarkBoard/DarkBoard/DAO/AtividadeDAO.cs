using System;
using System.Collections.Generic;
using System.Linq;
using DarkBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace DarkBoard.DAO
{
    public class AtividadeDAO
    {
        public void Adiciona(Atividade comp)
        {
            using (var context = new SalaContext())
            {
                context.Atividade.Add(comp);
                context.SaveChanges();
            }
        }
        public IList<Atividade> Lista()
        {
            using (var contexto = new SalaContext())
            {
                return contexto.Atividade.ToList();
            }
        }

        public Atividade BuscaPorId(int codigo)
        {
            using (var contexto = new SalaContext())
            {
                return contexto.Atividade
                .Where(p => p.Id == codigo)
                .FirstOrDefault();
            }
        }

        public IList<Atividade> BuscaPorSala(int id)
        {
            using (var contexto = new SalaContext())
            {
                return contexto.Atividade
                .Where(p => p.CodSala == id)
                .ToList();
            }
        }
        public void Atualiza(Atividade Atividade)
        {
            using (var contexto = new SalaContext())
            {
                contexto.Entry(Atividade).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Remove(Atividade Atividade)
        {
            using (var contexto = new SalaContext())
            {
                contexto.Remove(contexto.Atividade.Single(a => a.Id == Atividade.Id));
                contexto.SaveChanges();
            }
        }
    }
}
