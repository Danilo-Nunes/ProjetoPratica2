using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using DarkBoard.Models;

namespace DarkBoard.DAO
{
    public class AlunoDAO
    {
        public void Adiciona(Usuario alu)
        {
            using (var context = new SalaContext())
            {
                context.Aluno.Add(alu);
                context.SaveChanges();
            }
        }
        public IList<Usuario> Lista()
        {
            using (var contexto = new SalaContext())
            {
                return contexto.Aluno.ToList();
            }
        }

        public Usuario BuscaPorCodigo(int codigo)
        {
            using (var contexto = new SalaContext())
            {
                return contexto.Aluno
                .Where(p => p.Codigo == codigo)
                .FirstOrDefault();
            }
        }
        public void Atualiza(Usuario aluno)
        {
            using (var contexto = new SalaContext())
            {
                contexto.Entry(aluno).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}