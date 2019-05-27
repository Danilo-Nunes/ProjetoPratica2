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

        public AlunoSala BuscaPorId(int id)
        {
            using (var contexto = new SalaContext())
            {
                return (from c in contexto.AlunoSala
                        where c.Id == id
                        select c).FirstOrDefault();
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


        public IList<AlunoSala> BuscaPorAlunosAux(int id)
        {
            using (var contexto = new SalaContext())
            {
                return (from e in contexto.AlunoSala 
                        where e.CodSala == id
                        select e).ToList();
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

        public static void RemoveAluno(int idAluno, int idSala)
        {
            using (var contexto = new SalaContext())
            {
                contexto.RemoveRange(from a in contexto.AlunoSala
                                where a.CodAluno == idAluno
                                where a.CodSala == idSala
                                select a);
                contexto.SaveChanges();
            }
        }
    }
}
