using System;
using System.Collections.Generic;
using  static System.Console;
using System.Web;
using System.Web.Mvc;
using DarkBoard.Models;
using DarkBoard.DAO;

namespace DarkBoard.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Adiciona(Usuario usu)
        {
            usu.Senha = Criptografia.Criptografar(usu.Senha);
            UsuarioDAO dao = new UsuarioDAO();
            dao.Adiciona(usu);
            return RedirectToAction("Index", "Home");
        }
    }
}