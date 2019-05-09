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
            CompromissoDAO dao = new CompromissoDAO();
            dao.Adiciona(comp);
            return RedirectToAction("Agenda", new RouteValueDictionary(new { controller = "Home", action = "Agenda", Id = comp.CodUsuario.ToString() }));
        }

        public ActionResult Remove(Compromisso comp)
        {
            CompromissoDAO dao = new CompromissoDAO();
            dao.Remove(comp);
            return RedirectToAction("Agenda", new RouteValueDictionary(new { controller = "Home", action = "Agenda", Id = comp.CodUsuario.ToString() }));
        }
    }
}