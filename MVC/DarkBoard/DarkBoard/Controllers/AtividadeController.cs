using System;
using System.Collections.Generic;
using System.Linq;
using DarkBoard.Models;
using DarkBoard.DAO;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;

namespace DarkBoard.Controllers
{
    public class AtividadeController : Controller
    {
        // GET: Atividade
        public ActionResult Adiciona(Comunicado com, Atividade a, HttpPostedFileBase file)
        {
            a.Nome = com.Assunto;

            ComunicadoDAO comunicadoDAO = new ComunicadoDAO();
            ComunicadoAlunoDAO comunicadoAlunoDAO = new ComunicadoAlunoDAO();
            AtividadeDAO atividadeDAO = new AtividadeDAO();
            UsuarioAtividadeDAO usuarioAtividadeDAO = new UsuarioAtividadeDAO();

            if (file != null)
            {
                byte[] arquivoBytes = new byte[file.InputStream.Length + 1];

                file.InputStream.Read(arquivoBytes, 0, arquivoBytes.Length);
                com.Arquivo = arquivoBytes;
                com.NomeArquivo = file.FileName;
                com.TipoArquivo = file.ContentType;
            }

            atividadeDAO.Adiciona(a);
            comunicadoDAO.Adiciona(com);

            foreach (var A in (IList<Usuario>)Session["Alunos"])
            {
                ComunicadoAluno c = new ComunicadoAluno
                {
                    CodAluno = A.Id,
                    CodComunicado = com.Id,
                    Visto = "N"
                };

                UsuarioAtividade u =  new UsuarioAtividade
                {
                    CodUsuario = A.Id,
                    CodAtividade = a.Id,
                    Nota = 0,
                    Concluida = "N"
                };

                comunicadoAlunoDAO.Adiciona(c);
                usuarioAtividadeDAO.Adiciona(u);
            }

            return RedirectToAction("Sala", new RouteValueDictionary(new { controller = "Home", action = "Sala", id = com.CodSala }));
        }

        public ActionResult Atualiza(UsuarioAtividade alu)
        {
            UsuarioAtividadeDAO ua = new UsuarioAtividadeDAO();
            UsuarioAtividade aux = ua.BuscaPorId(alu.Id);
            aux.Nota = alu.Nota;
            ua.Atualiza(aux);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Download(string id)
        {
            UsuarioAtividadeDAO usuarioAtividadeDAO = new UsuarioAtividadeDAO();
            UsuarioAtividade u = usuarioAtividadeDAO.BuscaPorId(int.Parse(id));

            return File(u.Arquivo, u.TipoArquivo, u.NomeArquivo);
        }

		public ActionResult Entregar(int idAtividade, int idAluno, HttpPostedFileBase arquivo)
		{
			UsuarioAtividadeDAO usuarioAtividadeDAO = new UsuarioAtividadeDAO();

			UsuarioAtividade ua = usuarioAtividadeDAO.BuscaPorIds(idAluno, idAtividade);

			if (arquivo != null)
			{
				byte[] arquivoBytes = new byte[arquivo.InputStream.Length + 1];

				arquivo.InputStream.Read(arquivoBytes, 0, arquivoBytes.Length);
				ua.Arquivo = arquivoBytes;
				ua.NomeArquivo = arquivo.FileName;
				ua.TipoArquivo = arquivo.ContentType;
			}

			ua.Concluida = "S";
			usuarioAtividadeDAO.Atualiza(ua);

			return Redirect(Request.UrlReferrer.ToString());
		}
    }
}