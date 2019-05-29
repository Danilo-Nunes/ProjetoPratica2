using System;
using DarkBoard.DAO;
using DarkBoard.Models;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Collections.Generic;

namespace DarkBoard.Controllers
{
    public class SalaController : Controller
    {
        // GET: Sala
        public ActionResult AlteraImg(string id)
        {
            var file = Request.Files[0];
            SalaDAO s = new SalaDAO();
            Sala salaFinal = s.BuscaPorId(int.Parse(id));
            if (file.ContentLength > 0)
            {
                byte[] imageBytes = new byte[file.InputStream.Length + 1];
                file.InputStream.Read(imageBytes, 0, imageBytes.Length);
                salaFinal.Img = imageBytes;
            }
            s.Atualiza(salaFinal);
            return RedirectToAction("Administrar", new RouteValueDictionary(new { controller = "Home", action = "Administrar", id=salaFinal.Id}));
        }

        public ActionResult RemoveAluno(List<string> obj)
        {
            int idAluno = int.Parse(obj[0]);
            int idSala = int.Parse(obj[1]);
            ComunicadoAlunoDAO.RemoveAluno(idAluno,idSala);
            UsuarioAtividadeDAO.RemoveAluno(idAluno,idSala);
            AlunoSalaDBO.RemoveAluno(idAluno, idSala);
            return View();
        }

        public ActionResult Excluir(int id)
        {
            AlunoSalaDBO.RemoveSala(id);
            AtividadeDAO.RemoveSala(id);
            ComunicadoAlunoDAO.RemoveSala(id);
            ComunicadoDAO.RemoveSala(id);
            SalaDAO.Remove(id);
            return View();
        }
    }
}