using System;
using System.Collections.Generic;
using System.Linq;
using DarkBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace DarkBoard.DAO
{
    public class UsuarioAtividadeDAO
    {
        public void Adiciona(UsuarioAtividade comp)
        {
            using (var context = new SalaContext())
            {
                context.UsuarioAtividade.Add(comp);
                context.SaveChanges();
            }
        }
        public IList<UsuarioAtividade> Lista()
        {
            using (var contexto = new SalaContext())
            {
                return contexto.UsuarioAtividade.ToList();
            }
        }


        public IList<Atividade> BuscaPorAtividades(int id)
        {
            using (var contexto = new SalaContext())
            {
                return (from p in contexto.Atividade
                        join e in contexto.UsuarioAtividade on p.Id equals e.CodAtividade
                        join q in contexto.Usuario on e.CodUsuario equals q.Id
                        where q.Id == id
                        select p).ToList();
            }
        }

        public IList<UsuarioAtividade> BuscaPorAtividade(int id)
        {
            using (var contexto = new SalaContext())
            {
                return contexto.UsuarioAtividade
                .Where(p => p.CodUsuario == id)
                .ToList();
            }
        }

        public IList<UsuarioAtividade> BuscaPorAlunos(int id)
        {
            using (var contexto = new SalaContext())
            {
                return contexto.UsuarioAtividade
                .Where(p => p.CodAtividade == id)
                .ToList();
            }
        }
        public void Atualiza(UsuarioAtividade UsuarioAtividade)
        {
            using (var contexto = new SalaContext())
            {
                contexto.Entry(UsuarioAtividade).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public static void RemoveAluno(int idAluno, int idSala)
        {
            using (var contexto = new SalaContext())
            {
                contexto.RemoveRange(from a in contexto.UsuarioAtividade
                                join c in contexto.Atividade on a.CodAtividade equals c.Id
                                where a.CodUsuario == idAluno
                                where c.CodSala == idSala
                                select a);
                contexto.SaveChanges();
            }
        }
    }
}
