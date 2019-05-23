using System;
using System.Collections.Generic;
using System.Linq;
using DarkBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace DarkBoard.DAO
{
    public class AlunoSalaDBO
    {
        public void Adiciona(AlunoSala comp)
        {
            using (var context = new SalaContext())
            {
                context.AlunoSala.Add(comp);
                context.SaveChanges();
            }
        }
        public IList<AlunoSala> Lista()
        {
            using (var contexto = new SalaContext())
            {
                return contexto.AlunoSala.ToList();
            }
        }


        public IList<Sala> BuscaPorSalas(int id)
        {
            using (var contexto = new SalaContext())
            {
                return (from p in contexto.Sala
                        join e in contexto.AlunoSala on p.Id equals e.CodSala
                        join q in contexto.Usuario on e.CodAluno equals q.Id
                        where q.Id == id
                        select p).ToList();
            }
        }

        public IList<Usuario> BuscaPorAlunos(int id)
        {
            using (var contexto = new SalaContext())
            {
                return (from p in contexto.Usuario
                        join e in contexto.AlunoSala on p.Id equals e.CodAluno
                        join q in contexto.Sala on e.CodSala equals q.Id
                        where q.Id == id
                        select p).ToList();
            }
        }
        public void Atualiza(AlunoSala AlunoSala)
        {
            using (var contexto = new SalaContext())
            {
                contexto.Entry(AlunoSala).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Remove(AlunoSala AlunoSala)
        {
            using (var contexto = new SalaContext())
            {
                contexto.Remove(contexto.AlunoSala.Single(a => a.CodAluno == AlunoSala.CodAluno && a.CodSala == a.CodSala));
                contexto.SaveChanges();
            }
        }
    }
}
