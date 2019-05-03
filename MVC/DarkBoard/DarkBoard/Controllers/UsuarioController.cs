using System;
using System.Collections.Generic;
using  static System.Console;
using System.Web;
using System.Web.Mvc;
using DarkBoard.Models;
using DarkBoard.DAO;
using System.Web.Routing;

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
            return RedirectToAction("Login", new RouteValueDictionary(new { controller = "Home", action = "Login", msg = "" }));
        }

        public ActionResult Logar(Usuario usu)
        {
            UsuarioDAO dao = new UsuarioDAO();
            Usuario usuario = null;

            foreach(var user in dao.Lista())
            {
                if (user.NomeUsu == usu.NomeUsu)
                {
                    usuario = user;
                    break;
                }
            }

            if(usuario == null)
                return RedirectToAction("Login", new RouteValueDictionary(new { controller = "Home", action = "Login", msg = "Usuario nao cadastrado" }));

            if(usuario.Senha != Criptografia.Criptografar(usu.Senha))
                return RedirectToAction("Login", new RouteValueDictionary(new { controller = "Home", action = "Login", msg = "Senha Incorreta" }));




            return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Home", action = "Index", Id = usuario.Id.ToString()}));
        }
    }
}