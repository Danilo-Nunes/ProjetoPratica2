using System;
using System.Collections.Generic;
using System.Linq;
using DarkBoard.DAO;
using DarkBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace DarkBoard.Models
{
    public class ComunicadoAlunoDAO
    {
        public void Atualiza(ComunicadoAluno ComunicadoAluno)
        {
            using (var contexto = new SalaContext())
            {
                contexto.Entry(ComunicadoAluno).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public ComunicadoAluno Busca(int id, int i)
        {
            using (var contexto = new SalaContext())
            {
                return (from p in contexto.ComunicadoAluno
                        where p.CodAluno == id
                        where p.CodComunicado == i
                        select p).First();
            }
        }

        public void Adiciona(ComunicadoAluno ca)
        {
            using (var contexto = new SalaContext())
            {
                contexto.ComunicadoAluno.Add(ca);
                contexto.SaveChanges();
            }
        }

        public static void RemoveAluno(int idAluno, int idSala)
        {
            using (var contexto = new SalaContext())
            {
                contexto.RemoveRange(from a in contexto.ComunicadoAluno
                                join c in contexto.Comunicado on a.CodComunicado equals c.Id
                                where a.CodAluno == idAluno
                                where c.CodSala == idSala
                                select a);
                contexto.SaveChanges();
            }
        }
    }
}