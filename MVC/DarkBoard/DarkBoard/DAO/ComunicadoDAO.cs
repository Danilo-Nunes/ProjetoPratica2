using System;
using System.Collections.Generic;
using System.Linq;
using DarkBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace DarkBoard.DAO
{
    public class ComunicadoDAO
    {
        public void Adiciona(Comunicado comp)
        {
            using (var context = new SalaContext())
            {
                context.Comunicado.Add(comp);
                context.SaveChanges();
            }
        }
        public IList<Comunicado> Lista()
        {
            using (var contexto = new SalaContext())
            {
                return contexto.Comunicado.ToList();
            }
        }

        public Comunicado BuscaPorId(int codigo)
        {
            using (var contexto = new SalaContext())
            {
                return contexto.Comunicado
                .Where(p => p.Id == codigo)
                .FirstOrDefault();
            }
        }

        public IList<Comunicado> BuscaPorSala(int id)
        {
            using (var contexto = new SalaContext())
            {
                return contexto.Comunicado
                .Where(p => p.CodSala == id)
                .ToList();
            }
        }
        public void Atualiza(Comunicado Comunicado)
        {
            using (var contexto = new SalaContext())
            {
                contexto.Entry(Comunicado).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Remove(Comunicado Comunicado)
        {
            using (var contexto = new SalaContext())
            {
                contexto.Remove(contexto.Comunicado.Single(a => a.Id == Comunicado.Id));
                contexto.SaveChanges();
            }
        }
    }
}
