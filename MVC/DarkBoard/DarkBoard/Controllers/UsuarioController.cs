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
            UsuarioDAO dao = new UsuarioDAO();
            if(dao.BuscaPorNome(usu.NomeUsu) != null)
                return RedirectToAction("Cadastro", new RouteValueDictionary(new { controller = "Home", action = "Cadastro", msg = "Nome indisponivel" }));
            var file = Request.Files[0];
            byte[] imageBytes = new byte[file.InputStream.Length + 1];          
            file.InputStream.Read(imageBytes, 0, imageBytes.Length);
            usu.Img = imageBytes;
            usu.Senha = Criptografia.Criptografar(usu.Senha);            
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


            Session["usu"] = usuario.Id;

            return Redirect((string)Session["Pagina"]);
        }

        public ActionResult Atualiza(Usuario usuario)
        {
            var file = Request.Files[0];         
            UsuarioDAO dao = new UsuarioDAO();
            Usuario usu = dao.BuscaPorId(usuario.Id);
            if (file.ContentLength > 0)
            {
                byte[] imageBytes = new byte[file.InputStream.Length + 1];
                file.InputStream.Read(imageBytes, 0, imageBytes.Length);
                usu.Img = imageBytes;
            }
            usu.Descricao = usuario.Descricao;
            dao.Atualiza(usu);
            return RedirectToAction("Usuario", new RouteValueDictionary(new { controller = "Home", action = "Usuario", Id = usuario.Id.ToString() }));

        }
    }
}