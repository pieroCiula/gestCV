using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CurriculumBIZ.AuthenticationBIZ;
using CurricolumDAL;

namespace CurriculumWEB.Controllers
{
    public class RuoloController : Controller
    {
        public static RuoloCRUD ruolo_repo = new RuoloCRUD();
        //
        // GET: /Ruolo/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AllRuoloForDropDown()
        {
            var listRuolo = GetAllRuolo().Select(r => new {Id = r.id, Name = r.tipo_ruolo }).ToList();
            return Json(listRuolo, JsonRequestBehavior.AllowGet);
        }

        public static List<Ruolo> GetAllRuolo()
        {
            return ruolo_repo.GetAll().ToList();
        }

    }
}
