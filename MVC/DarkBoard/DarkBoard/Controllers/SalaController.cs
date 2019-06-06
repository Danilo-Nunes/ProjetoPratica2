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
            try
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
                return RedirectToAction("Administrar", new RouteValueDictionary(new { controller = "Home", action = "Administrar", id = salaFinal.Id }));
            }
            catch (Exception e)
            {
                Session["msg"] = "Erro: " + e.Message;
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        public ActionResult RemoveAluno(List<string> obj)
        {
            try
            {
                int idAluno = int.Parse(obj[0]);
                int idSala = int.Parse(obj[1]);
                SalaDAO salaDAO = new SalaDAO();
                Sala sala = salaDAO.BuscaPorId(idSala);
                ComunicadoAlunoDAO.RemoveAluno(idAluno, idSala);
                UsuarioAtividadeDAO.RemoveAluno(idAluno, idSala);
                AlunoSalaDAO.RemoveAluno(idAluno, idSala);
                sala.QtdAlunos--;
                salaDAO.Atualiza(sala);
                return View();
            }
            catch (Exception e)
            {
                Session["msg"] = "Erro: " + e.Message;
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        public ActionResult Excluir(int id)
        {
            try
            {
                AlunoSalaDAO.RemoveSala(id);
                UsuarioAtividadeDAO.RemoveSala(id);
                AtividadeDAO.RemoveSala(id);
                ComunicadoAlunoDAO.RemoveSala(id);
                ComunicadoDAO.RemoveSala(id);
                SalaDAO.Remove(id);
                return View();
            }
            catch (Exception e)
            {
                Session["msg"] = "Erro: " + e.Message;
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        public ActionResult Cria(string nome, int id, HttpPostedFileBase file)
        {
            try
            {
                SalaDAO salaDao = new SalaDAO();
                Sala sala = new Sala()
                {
                    Nome = nome,
                    CodProfessor = id
                };

                if (file != null)
                {
                    byte[] imageBytes = new byte[file.InputStream.Length + 1];
                    file.InputStream.Read(imageBytes, 0, imageBytes.Length);
                    sala.Img = imageBytes;
                }

                salaDao.Adiciona(sala);

                return Redirect("/Home/Sala/" + sala.Id);
            }
            catch (Exception e)
            {
                Session["msg"] = "Erro: " + e.Message;
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
    }
}