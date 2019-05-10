using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DarkBoard.DAO;
using DarkBoard.Filtros;
using DarkBoard.Models;

namespace DarkBoard.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [AutorizacaoFilterAttribute]
        public ActionResult Index()
        {         
            UsuarioDAO dao = new UsuarioDAO();

            Usuario usuario = dao.BuscaPorId(((int)Session["usu"]));

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
        [AutorizacaoFilterAttribute]
        public ActionResult Usuario()
        {

            UsuarioDAO dao = new UsuarioDAO();

            Usuario usuario = dao.BuscaPorId(((int)Session["usu"]));


            ViewBag.Usu = usuario;

            return View();

        }
        [AutorizacaoFilterAttribute]
        public ActionResult Agenda()
        {

            UsuarioDAO dao = new UsuarioDAO();

            Usuario usuario = dao.BuscaPorId(((int)Session["usu"]));
            CompromissoDAO d = new CompromissoDAO();



            ViewBag.Usu = usuario;
            ViewBag.Compromissos = d.BuscaPorUsuario(usuario.Id);

            return View();
        }
        [AutorizacaoFilterAttribute]
        public ActionResult Salas()
        {

            UsuarioDAO dao = new UsuarioDAO();

            Usuario usuario = dao.BuscaPorId((int)Session["usu"]);
            AlunoSalaDBO d = new AlunoSalaDBO();

            IList<Sala> salas = d.BuscaPorSalas(usuario.Id);

            ViewBag.Salas = salas;
            ViewBag.Usu = usuario;

            return View();
        }

        [AutorizacaoFilterAttribute]
        public ActionResult Sala(string id)
        {
            UsuarioDAO dao = new UsuarioDAO();
            SalaDAO d = new SalaDAO();
            ComunicadoDAO dAO = new ComunicadoDAO();

            Sala sala = d.BuscaPorId(int.Parse(id));
            Usuario usuario = dao.BuscaPorId((int)Session["usu"]);

            ViewBag.Usu = usuario;
            ViewBag.Sala = sala;
            ViewBag.Professor = dao.BuscaPorId(sala.CodProfessor);
            ViewBag.Comunicados = dAO.BuscaPorSala(sala.Id);

            return View();
        }


        [AutorizacaoFilterAttribute]
        public ActionResult Comunicado(string id)
        {
            UsuarioDAO dao = new UsuarioDAO();
            SalaDAO d = new SalaDAO();
            ComunicadoDAO dAO = new ComunicadoDAO();

            Comunicado comum = dAO.BuscaPorId(int.Parse(id));
            Usuario usuario = dao.BuscaPorId((int)Session["usu"]);
            Sala sala = d.BuscaPorId(comum.CodSala);

            ViewBag.Usu = usuario;
            ViewBag.Sala = sala;
            ViewBag.Professor = dao.BuscaPorId(sala.CodProfessor);
            ViewBag.Comunicado = comum;

            return View();
        }
    }

}