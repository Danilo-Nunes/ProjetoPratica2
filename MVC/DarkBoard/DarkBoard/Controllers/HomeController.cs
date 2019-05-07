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
    }
}