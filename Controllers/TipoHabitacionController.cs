using Capa_Entidad;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiPrimeraAplicacionMVCConCapas.Controllers
{
    public class TipoHabitacionController : Controller
    {
        // GET: TipoHabitacion
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult VistaPruebaInicio()
        {
            return View();
        }

        // metodos
        public string cadena()
        {
            return "123";
        }

        public int numero()
        {
            return 5;
        }

        //public List<TipoHabitacionCLS> lista()
        //{
        //    TipoHabitacionBL obj = new TipoHabitacionBL();
        //    return obj.listarTipoHabitacion();
        //}

        public JsonResult lista()
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return Json(obj.listarTipoHabitacion(),JsonRequestBehavior.AllowGet);
        }
    }
}