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
        public ActionResult Adiciona(Comunicado com)
        {
            ComunicadoDAO comunicadoDAO = new ComunicadoDAO();
            ComunicadoAlunoDAO comunicadoAlunoDAO = new ComunicadoAlunoDAO();

            comunicadoDAO.Adiciona(com);

            foreach(var A in (IList<Usuario>)Session["Alunos"])
            {
                ComunicadoAluno c = new ComunicadoAluno();
                c.CodAluno = A.Id;
                c.CodComunicado = com.Id;
                c.Visto = "N";

                comunicadoAlunoDAO.Adiciona(c);
            }


            return RedirectToAction("Login", new RouteValueDictionary(new { controller = "Home", action = "Login", msg = com.Id }));
        }
    }
}