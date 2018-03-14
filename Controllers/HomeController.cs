using BlogdOferta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogdOferta.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var InfoOfertas = db.Database.SqlQuery<OfertasXCate>(@"Select B.OfertaID, B.CategoriaID, B.DescripcionOfer, B.ImagenNeg, B.Precio, B.Existencia, B.Porcentaje, B.Estado, B.FechaOferInicial, B.FechaOferFinal, A.NomCate
                                                                    From Categorias A Inner Join Ofertas B On (A.CategoriaID = B.CategoriaID) order by FechaOferInicial Desc").Take(10).ToList();
            return View(InfoOfertas);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}