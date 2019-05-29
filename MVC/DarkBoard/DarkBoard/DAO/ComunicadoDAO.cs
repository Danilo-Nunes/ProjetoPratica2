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
                .Where(p => p.CodSala == id).OrderByDescending(x => x.Id)
                .ToList();
            }
        }
        public int QtdPorUsuario(int id)
        {
            using (var contexto = new SalaContext())
            {
                return (from p in contexto.Comunicado
                        join x in contexto.ComunicadoAluno on p.Id equals x.CodComunicado
                        where x.CodAluno == id
                        where x.Visto == "N"
                        select p).Count();
            }
        }

        public IList<Comunicado> BuscaPorUsuario(int id)
        {
            using (var contexto = new SalaContext())
            {
                return (from p in contexto.Comunicado
                        join x in contexto.ComunicadoAluno on p.Id equals x.CodComunicado
                        where x.CodAluno == id
                        where x.Visto == "N"
                        select p).OrderByDescending(x => x.Id).ToList();
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

        public static void Remove(Comunicado Comunicado)
        {
            using (var contexto = new SalaContext())
            {
                contexto.Remove(contexto.Comunicado.Single(a => a.Id == Comunicado.Id));
                contexto.SaveChanges();
            }
        }

        public static void RemoveSala(int Sala)
        {
            using (var contexto = new SalaContext())
            {
                contexto.RemoveRange(from a in contexto.Comunicado
                                     where a.CodSala == Sala
                                     select a);
                contexto.SaveChanges();
            }
        }
    }
}
