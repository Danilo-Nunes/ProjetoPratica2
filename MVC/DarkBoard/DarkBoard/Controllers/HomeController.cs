using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DarkBoard.DAO;

namespace DarkBoard.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Login()
        {
            UsuarioDAO dao = new UsuarioDAO();
            ViewBag.usuarios = dao;
            return View();
        }
    }
}