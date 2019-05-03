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
        public ActionResult Index(string Id)
        {
            ViewBag.id = Id;
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Login(string msg)
        {
            UsuarioDAO dao = new UsuarioDAO();
            ViewBag.usuarios = dao.Lista();
            ViewBag.msg = msg;
            return View();
        }
    }
}