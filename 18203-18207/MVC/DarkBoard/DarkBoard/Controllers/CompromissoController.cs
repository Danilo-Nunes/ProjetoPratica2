using System;
using System.Collections.Generic;
using DarkBoard.DAO;
using DarkBoard.Models;
using System.Web.Mvc;
using System.Web.Routing;

namespace DarkBoard.Controllers
{
    public class CompromissoController : Controller
    {
        // GET: Compromisso
        public ActionResult Adiciona(Compromisso comp)
        {
            try
            {
                CompromissoDAO dao = new CompromissoDAO();
                dao.Adiciona(comp);
                return RedirectToAction("Agenda", new RouteValueDictionary(new { controller = "Home", action = "Agenda" }));
            }
            catch (Exception e)
            {
                Session["msg"] = "Erro: " + e.Message;
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        public ActionResult Remove(Compromisso comp)
        {
            try
            {
                CompromissoDAO dao = new CompromissoDAO();
                dao.Remove(comp);
                return RedirectToAction("Agenda", new RouteValueDictionary(new { controller = "Home", action = "Agenda" }));
            }
            catch (Exception e)
            {
                Session["msg"] = "Erro: " + e.Message;
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
    }
}