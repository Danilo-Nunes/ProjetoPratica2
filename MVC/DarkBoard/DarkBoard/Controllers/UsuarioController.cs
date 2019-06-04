using System;
using System.Collections.Generic;
using  static System.Console;
using System.Web;
using System.Web.Mvc;
using DarkBoard.Models;
using DarkBoard.DAO;
using System.Web.Routing;
using System.IO;
using System.Drawing;

namespace DarkBoard.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Adiciona(Usuario usu, HttpPostedFileBase file)
        {
            UsuarioDAO dao = new UsuarioDAO();
            if(dao.BuscaPorNome(usu.NomeUsu) != null)
                return RedirectToAction("Cadastro", new RouteValueDictionary(new { controller = "Home", action = "Cadastro", msg = "Nome indisponivel" }));

            if (file != null)
            {
                byte[] imageBytes = new byte[file.InputStream.Length + 1];
                file.InputStream.Read(imageBytes, 0, imageBytes.Length);
                usu.Img = imageBytes;
            }
            usu.Senha = Criptografia.Criptografar(usu.Senha);            
            dao.Adiciona(usu);

            ComunicadoDAO d = new ComunicadoDAO();
            Session["usu"] = usu.Id;
            Session["not"] = d.QtdPorUsuario(usu.Id);

            return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Home", action = "Index"}));
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

            ComunicadoDAO d = new ComunicadoDAO();
            Session["usu"] = usuario.Id;
            Session["not"] = d.QtdPorUsuario(usuario.Id);

            try
            {
                return Redirect((string)Session["Pagina"]);
            }
            catch
            {
                return Redirect("/Home/Index");
            }
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

        public ActionResult AlteraSenha(Usuario usu, string novaSenha)
        {
            usu.Senha = Criptografia.Criptografar(usu.Senha);
            UsuarioDAO d = new UsuarioDAO();
            Usuario usuario = d.BuscaPorId(usu.Id);
            if(usuario.Senha == usu.Senha)
            {
                usuario.Senha = Criptografia.Criptografar(novaSenha);
                d.Atualiza(usuario);
                return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Home", action = "Index"}));
            }
            return RedirectToAction("AlterarSenha", new RouteValueDictionary(new { controller = "Home", action = "AlterarSenha", msg = "Senha Incorreta" }));
        }

        public ActionResult AtualizaFrequencia(List<AlunoSala> no)
        {
            AlunoSalaDAO alunoSalaDBO = new AlunoSalaDAO();
            foreach (var alu in no)
            {
                AlunoSala aux = alunoSalaDBO.BuscaPorId(alu.Id);
                if (alu.Faltas > 0)
                    aux.Faltas = alu.Faltas;
                else
                    aux.Faltas = 0;
                alunoSalaDBO.Atualiza(aux);
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult AdicionaNaSala(string nome, int id)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            ComunicadoAlunoDAO comunicadoAlunoDAO = new ComunicadoAlunoDAO();
            UsuarioAtividadeDAO usuarioAtividadeDAO = new UsuarioAtividadeDAO();
            AlunoSalaDAO alunoSalaDBO = new AlunoSalaDAO();
            SalaDAO salaDAO = new SalaDAO();


            var comunicados = comunicadoAlunoDAO.BuscaSala(id);
            var atividades = usuarioAtividadeDAO.BuscaPorSala(id);

            Usuario usuario = usuarioDAO.BuscaPorNomeCompleto(nome);
            Sala sala = salaDAO.BuscaPorId(id);

            if (usuario != null && usuario.Cargo == 'A')
            {


                foreach (var comunicado in comunicados)
                {
                    ComunicadoAluno c = new ComunicadoAluno
                    {
                        CodAluno = usuario.Id,
                        CodComunicado = comunicado.Id,
                        Visto = "N"

                    };

                    comunicadoAlunoDAO.Adiciona(c);
                }

                foreach (var at in atividades)
                {
                    UsuarioAtividade u = new UsuarioAtividade
                    {
                        CodUsuario = usuario.Id,
                        CodAtividade = at.Id,
                        Concluida = "N",
                        Peso = at.Peso
                    };
                }


                AlunoSala a = new AlunoSala
                {
                    CodAluno = usuario.Id,
                    CodSala = id,
                    Faltas = 0,
                    Media = 0
                };

                alunoSalaDBO.Adiciona(a);

                sala.QtdAlunos++;
                salaDAO.Atualiza(sala);

                return Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                Session["msg"] = "Aluno inexistente";
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
    }
}