using System;
using System.Collections.Generic;
using System.Linq;
using DarkBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace DarkBoard.DAO
{
    public class UsuarioAtividadeDAO
    {

        public UsuarioAtividade BuscaPorId(int codigo)
        {
            using (var contexto = new SalaContext())
            {
                return contexto.UsuarioAtividade
                .Where(p => p.Id == codigo)
                .FirstOrDefault();
            }
        }

		public UsuarioAtividade BuscaPorIds(int aluno, int atividade)
		{
			using (var contexto = new SalaContext())
			{
				return (from ua in contexto.UsuarioAtividade
						where ua.CodUsuario == aluno
						where ua.CodAtividade == atividade
						select ua).FirstOrDefault();
			}
		}
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

        public IList<UsuarioAtividade> BuscaPorAtividadesAux(int id)
        {
            using (var contexto = new SalaContext())
            {
                return (from e in contexto.UsuarioAtividade 
                        join q in contexto.Usuario on e.CodUsuario equals q.Id
                        where q.Id == id
                        select e).ToList();
            }
        }

        public IList<Atividade> BuscaPorSala(int id)
        {
            using (var contexto = new SalaContext())
            {
                return (from p in contexto.Atividade
                        where p.CodSala == id
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

        public IList<UsuarioAtividade> BuscaPorAlunosAux(int id)
        {
            using (var contexto = new SalaContext())
            {
                return (from ua in contexto.UsuarioAtividade
                        where ua.Concluida == "S"
                        where ua.CodAtividade == id
                        select ua).ToList();
            }
        }

        public IList<Usuario> BuscaPorAlunosCompleto(int id)
        {
            using (var contexto = new SalaContext())
            {
                return (from u in contexto.Usuario
                        join ua in contexto.UsuarioAtividade on u.Id equals ua.CodUsuario
                        where ua.Concluida == "S"
                        where ua.CodAtividade == id
                        select u).ToList();
            }
        }

        public IList<Atividade> BuscaPorAtividadesIncompletas(int idAluno, int idSala)
        {
            using (var contexto = new SalaContext())
            {
                return (from u in contexto.Atividade
                        join ua in contexto.UsuarioAtividade on u.Id equals ua.CodAtividade
                        join a in contexto.Atividade on ua.CodAtividade equals a.Id
                        where ua.Concluida == "N"
                        where u.Id == idAluno
                        where a.CodSala == idSala
                        select u).ToList();
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

        public static void RemoveAtividade(int idAtividade)
        {
            using (var contexto = new SalaContext())
            {
                contexto.RemoveRange(from a in contexto.UsuarioAtividade
                                     where a.CodAtividade == idAtividade
                                     select a);
                contexto.SaveChanges();
            }
        }
    }
}
