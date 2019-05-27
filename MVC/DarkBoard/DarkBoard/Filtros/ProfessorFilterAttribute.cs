using DarkBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DarkBoard.Filtros
{
    public class ProfessorFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //base.OnActionExecuting(filterContext);
            Usuario usuario = (Usuario)filterContext.HttpContext.Session["usu"];
            filterContext.HttpContext.Session.Add("Pagina", filterContext.HttpContext.Request.Url.OriginalString);
            var viewBag = filterContext.Controller.ViewBag;
            // se o usuario não for professor
            if (usuario.Id != viewBag.Sala.CodProfessor)
            {
                // redirecionar usuário para pagina da sala
                filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary(
                new { controller = "Home", action = "Salas" }
                )
                );
            }
        }
    }
}