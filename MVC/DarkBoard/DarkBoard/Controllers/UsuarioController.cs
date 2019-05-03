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

        public ActionResult Adiciona(Usuario usu, string rb, string senha)
        {
            usu.Senha = Criptografia.Criptografar(usu.Senha);
            return RedirectToAction("Index", "Home");
        }
    }
}