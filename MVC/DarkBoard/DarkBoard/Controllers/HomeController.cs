using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DarkBoard.DAO;
using DarkBoard.Models;

namespace DarkBoard.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string Id)
        {
            if (Id == null)
                return RedirectToAction("Login");

            UsuarioDAO dao = new UsuarioDAO();

            Usuario usuario = dao.BuscaPorId(int.Parse(Id));

            ViewBag.Usu = usuario;

            return View();
        }

        public ActionResult Cadastro(string msg)
        {
            ViewBag.msg = msg;
            return View();
        }

        public ActionResult Login(string msg)
        {
            ViewBag.msg = msg;
            return View();
        }

        public ActionResult Usuario(string id)
        {
            if (id == null)
                return RedirectToAction("Login");

            UsuarioDAO dao = new UsuarioDAO();

            Usuario usuario = dao.BuscaPorId(int.Parse(id));

            ViewBag.Usu = usuario;

            return View();

        }

        public ActionResult Agenda(string id)
        {
            if (id == null)
                return RedirectToAction("Login");

            UsuarioDAO dao = new UsuarioDAO();
            CompromissoDAO d = new CompromissoDAO();

            ViewBag.Compromissos = d.BuscaPorUsuario(int.Parse(id));

            Usuario usuario = dao.BuscaPorId(int.Parse(id));

            ViewBag.Usu = usuario;

            return View();
        }

        public ActionResult Salas(string id)
        {
            id = "9";
            if (id == null)
                return RedirectToAction("Login");
            UsuarioDAO dao = new UsuarioDAO();
            AlunoSalaDBO d = new AlunoSalaDBO();
            SalaDAO DAO = new SalaDAO();

            IList<AlunoSala> salasAux = d.BuscaPorSalas(int.Parse(id));

            Usuario usuario = dao.BuscaPorId(int.Parse(id));

            ViewBag.Usu = usuario;

            return View();
        }
    }

}