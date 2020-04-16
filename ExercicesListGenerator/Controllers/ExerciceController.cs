using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExercicesListGenerator.Models;
using System.IO;

namespace ExercicesListGenerator.Controllers
{
    public class ExerciceController : Controller
    {
        // GET: Exercice
        [ActionName("Index")]
        public ActionResult LeNomQueJeVeux()
        {
            using (IDal dal = new Dal())
            {
                List<Exo> listeDesExos = dal.ObtientTousLesExos();
                ViewBag.ListeDesExos = listeDesExos;
                return View();
            }
        }

        [ActionName("Modifier")]
        public ActionResult Modifier(int? exo_id)
        {
            if (exo_id.HasValue)
            {
                using (IDal dal = new Dal())
                {
                    Exo exercice = dal.ObtientTousLesExos().FirstOrDefault(e => e.ID == exo_id.Value);
                    if (exercice == null)
                        return View("Error");
                    return View(exercice);
                }
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Modifier(int? exo_id, string nom, string description, bool typepass, bool typeshoot, bool typeplaymaking, bool typeathletic, bool typegoalie)
        {
            byte[] image = null;
            if (exo_id.HasValue)
            {
                using (IDal dal = new Dal())
                {
                    dal.ModifierExo(
                        exo_id.Value,
                        nom,
                        description,
                        image,
                        typepass,
                        typeshoot,
                        typeplaymaking,
                        typeathletic,
                        typegoalie);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View("Error");
            }
        }
    }
}