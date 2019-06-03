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
            AlunoSalaDAO d = new AlunoSalaDAO();

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
        [ProfessorFilterAttribute]
        public ActionResult Administrar(string id)
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();
            SalaDAO salaDAO = new SalaDAO();
            AlunoSalaDAO alunoSalaDbo = new AlunoSalaDAO();

            Usuario professor = usuarioDao.BuscaPorId(((int)Session["usu"]));
            Sala sala = salaDAO.BuscaPorId(int.Parse(id));
            IList<Usuario> alunos = alunoSalaDbo.BuscaPorAlunos(int.Parse(id));

            ViewBag.Not = Session["not"];
            ViewBag.Usu = professor;
            ViewBag.Alunos = alunos;
            ViewBag.Sala = sala;
            ViewBag.ControllerVariable = sala;

            return View();
        }
        [AutorizacaoFilterAttribute]
        [ProfessorFilterAttribute]
        public ActionResult Comunicar(string id)
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();
            SalaDAO salaDAO = new SalaDAO();
            AlunoSalaDAO alunoSalaDao = new AlunoSalaDAO();

            Sala sala = salaDAO.BuscaPorId(int.Parse(id));
            Usuario usuario = usuarioDao.BuscaPorId(((int)Session["usu"]));
            IList<Usuario> alunos = alunoSalaDao.BuscaPorAlunos(sala.Id);

            ViewBag.Not = Session["not"];
            ViewBag.Usu = usuario;
            ViewBag.Sala = sala;
            Session["Alunos"] = alunos;
            
            return View();
        }
        [AutorizacaoFilterAttribute]
        public ActionResult Pesquisa(string pesq)
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();
            SalaDAO salaDao = new SalaDAO();

            Usuario usuario = usuarioDao.BuscaPorId(9);
            IList<Usuario> usuariosBuscados = usuarioDao.Pesquisa(pesq);
            IList<Sala> salasBuscadas = salaDao.Pesquisa(pesq);

            var usuarios = (from u in usuariosBuscados
                            select new Resultado
                            {
                                Id = u.Id,
                                Nome = u.Nome,
                                Img = u.Img,
                                Eh = "Usuario"
                            }).ToList();

            var busca = usuarios.Union(from s in salasBuscadas
                                       select new Resultado
                                       {
                                           Id = s.Id,
                                           Nome = s.Nome,
                                           Img = s.Img,
                                           Eh = "Sala"
                                       }).ToList().OrderBy(p => p.Nome);

            ViewBag.Busca = busca;
            ViewBag.Usu = usuario;
            return View();
        }

        [AutorizacaoFilterAttribute]
        [ProfessorFilterAttribute]
        public ActionResult CriarAtividade(string id)
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();
            SalaDAO salaDAO = new SalaDAO();
            AlunoSalaDAO alunoSalaDao = new AlunoSalaDAO();

            Sala sala = salaDAO.BuscaPorId(int.Parse(id));
            Usuario usuario = usuarioDao.BuscaPorId((int)Session["usu"]);
            IList<Usuario> alunos = alunoSalaDao.BuscaPorAlunos(sala.Id);

            ViewBag.Not = Session["not"];
            ViewBag.Usu = usuario;
            ViewBag.Sala = sala;
            Session["Alunos"] = alunos;

            return View();
        }
        [AutorizacaoFilterAttribute]
        [ProfessorFilterAttribute]
        public ActionResult AdministrarAtividades(string id)
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();
            SalaDAO salaDAO = new SalaDAO();
            AlunoSalaDAO alunoSalaDbo = new AlunoSalaDAO();
            AtividadeDAO atividadeDAO = new AtividadeDAO();
            UsuarioAtividadeDAO usuarioAtividadeDAO = new UsuarioAtividadeDAO();

            Atividade atividade = atividadeDAO.BuscaPorId(int.Parse(id));
            Sala sala = salaDAO.BuscaPorId(atividade.CodSala);
            Usuario professor = usuarioDao.BuscaPorId(sala.CodProfessor); 
            IList<Usuario> alunos = usuarioAtividadeDAO.BuscaPorAlunosCompleto(atividade.Id);
            IList<UsuarioAtividade> alunoAux = usuarioAtividadeDAO.BuscaPorAlunosAux(atividade.Id);
           

            ViewBag.Not = Session["not"];
            ViewBag.Usu = professor;
            ViewBag.Alunos = alunos;
            ViewBag.AlunosAux = alunoAux;
            ViewBag.Sala = sala;
            ViewBag.Atividade = atividade;

            return View();

        }
        [AutorizacaoFilterAttribute]
        public ActionResult Atividades(string id)
        {

            AtividadeDAO atividadeDAO = new AtividadeDAO();
            SalaDAO salaDAO = new SalaDAO();
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            ViewBag.Not = Session["not"];
            ViewBag.Atividades = atividadeDAO.BuscaPorSala(int.Parse(id));
            ViewBag.Professor = salaDAO.BuscaProfessor(int.Parse(id));
            ViewBag.Usu = usuarioDAO.BuscaPorId((int)Session["usu"]);
            ViewBag.Sala = salaDAO.BuscaPorId(int.Parse(id));

            return View();
        }
        [AutorizacaoFilterAttribute]
        [ProfessorFilterAttribute]
        public ActionResult EditarFrequencia(string id)
        {
            SalaDAO salaDAO = new SalaDAO();
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            AlunoSalaDAO alunoSalaDBO = new AlunoSalaDAO();


            ViewBag.AlunosAux = alunoSalaDBO.BuscaPorAlunosAux(int.Parse(id));
            ViewBag.Alunos = alunoSalaDBO.BuscaPorAlunos(int.Parse(id));
            ViewBag.Sala = salaDAO.BuscaPorId(int.Parse(id));
            ViewBag.Not = Session["not"];
            ViewBag.Usu = usuarioDAO.BuscaPorId((int)Session["usu"]);

            return View();
        }
        [AutorizacaoFilterAttribute]
        [ProfessorFilterAttribute]
        public ActionResult Boletim(string id)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            SalaDAO salaDAO = new SalaDAO();
            AlunoSalaDAO alunoSalaDAO = new AlunoSalaDAO();
            UsuarioAtividadeDAO usuarioAtividadeDAO = new UsuarioAtividadeDAO();

            List<double> Medias = new List<double>();

            foreach(var Aluno in alunoSalaDAO.BuscaPorAlunos(int.Parse(id)))
            {
                double media = 0;
                int pesos = 0;

                foreach(var at in usuarioAtividadeDAO.BuscaPorAtividadesAux(Aluno.Id))
                {
                    media += at.Nota * at.Peso;
                    pesos += at.Peso;
                }

                if(pesos != 0)
                    media = Math.Round(media / pesos, 1);
                Medias.Add(media);
            }

            ViewBag.Alunos = alunoSalaDAO.BuscaPorAlunos(int.Parse(id));
            ViewBag.Sala = salaDAO.BuscaPorId(int.Parse(id));
            ViewBag.Medias = Medias;
            ViewBag.Not = Session["not"];
            ViewBag.AlunosAux = alunoSalaDAO.BuscaPorAlunosAux(int.Parse(id));
            ViewBag.Usu = usuarioDAO.BuscaPorId((int)Session["usu"]);

            return View();
        }
    }

}