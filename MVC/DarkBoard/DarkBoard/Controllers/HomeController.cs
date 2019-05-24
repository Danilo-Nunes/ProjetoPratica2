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

            ViewBag.Not = Session["not"];

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
        public ActionResult Usuario(string id)
        {

            UsuarioDAO dao = new UsuarioDAO();
            ViewBag.Not = Session["not"];

            if(id == null)
                id = ((int)Session["usu"]).ToString();

            Usuario usuario = dao.BuscaPorId(((int)Session["usu"]));
            Usuario visitado = dao.BuscaPorId(int.Parse(id));

            ViewBag.Visitado = visitado;          
            ViewBag.Usu = usuario;

            return View();

        }
        [AutorizacaoFilterAttribute]
        public ActionResult Agenda()
        {

            UsuarioDAO dao = new UsuarioDAO();
            ViewBag.Not = Session["not"];
            Usuario usuario = dao.BuscaPorId(((int)Session["usu"]));
            CompromissoDAO d = new CompromissoDAO();



            ViewBag.Usu = usuario;
            ViewBag.Compromissos = d.BuscaPorUsuario(usuario.Id);

            return View();
        }
        [AutorizacaoFilterAttribute]
        public ActionResult Salas()
        {
            SalaDAO s = new SalaDAO();
            UsuarioDAO dao = new UsuarioDAO();
            ViewBag.Not = Session["not"];

            Usuario usuario = dao.BuscaPorId((int)Session["usu"]);
            AlunoSalaDBO d = new AlunoSalaDBO();

            IList<Sala> salas;
            if (usuario.Cargo == 'A')
            {
                salas = d.BuscaPorSalas(usuario.Id);
            }
            else
            {
                salas = s.BuscaPorProfessor(usuario.Id);
            }

            ViewBag.Salas = salas;
            ViewBag.Usu = usuario;

            return View();
        }

        [AutorizacaoFilterAttribute]
        public ActionResult Sala(string id)
        {
            if (id == null)
                return RedirectToAction("Salas");
            UsuarioDAO dao = new UsuarioDAO();
            SalaDAO d = new SalaDAO();
            ViewBag.Not = Session["not"];
            ComunicadoDAO dAO = new ComunicadoDAO();
            UsuarioAtividadeDAO usuarioAtividadeDAO = new UsuarioAtividadeDAO();

            Sala sala = d.BuscaPorId(int.Parse(id));
            Usuario usuario = dao.BuscaPorId((int)Session["usu"]);

            ViewBag.Usu = usuario;
            ViewBag.Atividades = usuarioAtividadeDAO.BuscaPorAtividade(usuario.Id);
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
            ComunicadoAlunoDAO c = new ComunicadoAlunoDAO();
            

            Usuario usuario = dao.BuscaPorId((int)Session["usu"]);
            Sala sala = d.BuscaPorId(comum.CodSala);

            if (usuario.Cargo == 'A')
            {
                ComunicadoAluno aux = c.Busca(usuario.Id, comum.Id);
                aux.Visto = "S";
                c.Atualiza(aux);
            }
            Session["not"] = dAO.QtdPorUsuario(usuario.Id);

            ViewBag.Not = Session["not"];
            ViewBag.Usu = usuario;
            ViewBag.Sala = sala;
            ViewBag.Professor = dao.BuscaPorId(sala.CodProfessor);
            ViewBag.Comunicado = comum;

            return View();
        }
        [AutorizacaoFilterAttribute]
        public ActionResult Notificacoes()
        {
            int not = (int)Session["not"];
            UsuarioDAO dao = new UsuarioDAO();
            ComunicadoDAO d = new ComunicadoDAO();

            Usuario usuario = dao.BuscaPorId(((int)Session["usu"]));
            Usuario[] professores = new Usuario[not];
            IList<Comunicado> c = d.BuscaPorUsuario(usuario.Id);
            for (int i = 0; i < not; i++)
            {
                professores[i] = dao.BuscaPorSala(c[i].CodSala);
            }
            ViewBag.Not = Session["not"];
            ViewBag.Comuns = c;
            ViewBag.Prof = professores;
            ViewBag.Usu = usuario;

            return View();
        }

        [AutorizacaoFilterAttribute]
        public ActionResult AlterarSenha(string msg)
        {
            UsuarioDAO dao = new UsuarioDAO();
            Usuario usuario = dao.BuscaPorId(((int)Session["usu"]));
            ViewBag.Not = Session["not"];
            ViewBag.Usu = usuario;
            ViewBag.Msg = msg;

            return View();
        }
        [AutorizacaoFilterAttribute]
        public ActionResult Administrar(string id)
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();
            SalaDAO salaDAO = new SalaDAO();
            AlunoSalaDBO alunoSalaDbo = new AlunoSalaDBO();

            Usuario professor = usuarioDao.BuscaPorId(((int)Session["usu"]));
            Sala sala = salaDAO.BuscaPorId(int.Parse(id));
            IList<Usuario> alunos = alunoSalaDbo.BuscaPorAlunos(int.Parse(id));

            ViewBag.Not = Session["not"];
            ViewBag.Usu = professor;
            ViewBag.Alunos = alunos;
            ViewBag.Sala = sala;

            return View();
        }
        [AutorizacaoFilterAttribute]
        public ActionResult Comunicar(string id)
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();
            SalaDAO salaDAO = new SalaDAO();
            AlunoSalaDBO alunoSalaDao = new AlunoSalaDBO();

            Sala sala = salaDAO.BuscaPorId(int.Parse(id));
            Usuario usuario = usuarioDao.BuscaPorId(((int)Session["usu"]));
            IList<Usuario> alunos = alunoSalaDao.BuscaPorAlunos(sala.Id);

            ViewBag.Not = Session["not"];
            ViewBag.Usu = usuario;
            ViewBag.Sala = sala;
            Session["Alunos"] = alunos;
            
            return View();
        }

        public ActionResult Pesquisa()
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();
            SalaDAO salaDao = new SalaDAO();

            Usuario usuario = usuarioDao.BuscaPorId(9);
            IList<Usuario> usuariosBuscados = usuarioDao.Pesquisa("a");
            IList<Sala> salasBuscadas = salaDao.Pesquisa("a");

            var usuarios = (from u in usuariosBuscados
                            select new Resultado
                            {
                                Id = u.Id,
                                Nome = u.Nome,
                                Img = u.Img
                            }).ToList();

            var busca = usuarios.Union(from s in salasBuscadas
                                       select new Resultado
                                       {
                                           Id = s.Id,
                                           Nome = s.Nome,
                                           Img = s.Img
                                       }).ToList().OrderBy(p => p.Nome);

            ViewBag.Busca = busca;
            ViewBag.Usu = usuario;
            return View();
        }

        [AutorizacaoFilterAttribute]
        public ActionResult CriarAtividade(string id)
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();
            SalaDAO salaDAO = new SalaDAO();
            AlunoSalaDBO alunoSalaDao = new AlunoSalaDBO();

            Sala sala = salaDAO.BuscaPorId(int.Parse(id));
            Usuario usuario = usuarioDao.BuscaPorId((int)Session["usu"]);
            IList<Usuario> alunos = alunoSalaDao.BuscaPorAlunos(sala.Id);

            ViewBag.Not = Session["not"];
            ViewBag.Usu = usuario;
            ViewBag.Sala = sala;
            Session["Alunos"] = alunos;

            return View();
        }

        public ActionResult AdministrarAtividades(string id, string idAtividade)
        {
            id = "2";
            idAtividade = "1";
            UsuarioDAO usuarioDao = new UsuarioDAO();
            SalaDAO salaDAO = new SalaDAO();
            AlunoSalaDBO alunoSalaDbo = new AlunoSalaDBO();
            AtividadeDAO atividadeDAO = new AtividadeDAO();
            UsuarioAtividadeDAO usuarioAtividadeDAO = new UsuarioAtividadeDAO();

            Usuario professor = usuarioDao.BuscaPorId(11);
            Sala sala = salaDAO.BuscaPorId(int.Parse(id));
            IList<Usuario> alunos = usuarioAtividadeDAO.BuscaPorAlunosIncompleto(int.Parse(idAtividade));
            IList<UsuarioAtividade> alunoAux = usuarioAtividadeDAO.BuscaPorAlunosAux(int.Parse(idAtividade));
            Atividade atividade = atividadeDAO.BuscaPorId(int.Parse(id));

            ViewBag.Not = Session["not"];
            ViewBag.Usu = professor;
            ViewBag.Alunos = alunos;
            ViewBag.AlunosAux = alunoAux;
            ViewBag.Sala = sala;
            ViewBag.Atividade = atividade;

            return View();

        }

        public ActionResult Atividades(string id)
        {
            AtividadeDAO atividadeDAO = new AtividadeDAO();
            SalaDAO salaDAO = new SalaDAO();
            ViewBag.Atividades = atividadeDAO.BuscaPorSala(int.Parse(id));
            ViewBag.Professor = salaDAO.BuscaProfessor(int.Parse(id));
            return View();
        }
    }

}