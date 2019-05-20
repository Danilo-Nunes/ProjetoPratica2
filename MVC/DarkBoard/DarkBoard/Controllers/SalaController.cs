using System;
using DarkBoard.DAO;
using DarkBoard.Models;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DarkBoard.Controllers
{
    public class SalaController : Controller
    {
        // GET: Sala
        public ActionResult AlteraImg(string id)
        {
            var file = Request.Files[0];
            SalaDAO s = new SalaDAO();
            Sala salaFinal = s.BuscaPorId(int.Parse(id));
            if (file.ContentLength > 0)
            {
                byte[] imageBytes = new byte[file.InputStream.Length + 1];
                file.InputStream.Read(imageBytes, 0, imageBytes.Length);
                salaFinal.Img = imageBytes;
            }
            s.Atualiza(salaFinal);
            return RedirectToAction("Administrar", new RouteValueDictionary(new { controller = "Home", action = "Administrar", id=salaFinal.Id}));
        }
    }
}