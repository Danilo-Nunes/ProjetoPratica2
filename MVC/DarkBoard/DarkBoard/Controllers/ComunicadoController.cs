using System;
using System.Collections.Generic;
using DarkBoard.Models;
using DarkBoard.DAO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DarkBoard.Controllers
{
    public class ComunicadoController : Controller
    {
        // GET: Comunicado
        public ActionResult Adiciona(Comunicado com, HttpPostedFileBase file)
        {
            ComunicadoDAO comunicadoDAO = new ComunicadoDAO();
            ComunicadoAlunoDAO comunicadoAlunoDAO = new ComunicadoAlunoDAO();
          
            byte[] arquivoBytes = new byte[file.InputStream.Length + 1];

            file.InputStream.Read(arquivoBytes, 0, arquivoBytes.Length);
            com.Arquivo = arquivoBytes;

            comunicadoDAO.Adiciona(com);

            foreach (var A in (IList<Usuario>)Session["Alunos"])
            {
                ComunicadoAluno c = new ComunicadoAluno
                {
                    CodAluno = A.Id,
                    CodComunicado = com.Id,
                    Visto = "N"
                };

                comunicadoAlunoDAO.Adiciona(c);
            }


            return RedirectToAction("Sala", new RouteValueDictionary(new { controller = "Home", action = "Sala", id = com.CodSala }));
        }
    }
}