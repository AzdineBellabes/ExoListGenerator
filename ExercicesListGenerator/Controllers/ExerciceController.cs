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
            if (exo_id.HasValue)
            {
                using (IDal dal = new Dal())
                {
                    dal.ModifierExo(
                        exo_id.Value,
                        nom,
                        description,
                        typepass,
                        typeshoot,
                        typeplaymaking,
                        typeathletic,
                        typegoalie);
                    Exo exercice = dal.ObtientTousLesExos().FirstOrDefault(e => e.ID == exo_id.Value);
                    if (exercice == null)
                        return View("Error");
                    return RedirectToAction("index");
                }
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult FileUpload(int? ID, HttpPostedFileBase file)
        {
            using (IDal dal = new Dal())
            {
                if (file != null)
                {

                    string pic = ID.ToString() + "_" + System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(
                                           Server.MapPath("~/Images"), pic);
                    // file is uploaded
                    //file.SaveAs(path);

                    // save the image path path to the database or you can send image 
                    // directly to database
                    // in-case if you want to store byte[] ie. for DB
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                        dal.ModifierImageDansExo(ID.Value, array);
                    }

                }
                Exo exercice = dal.ObtientTousLesExos().FirstOrDefault(e => e.ID == ID.Value);
                if (exercice == null)
                    return View("Error");
                return RedirectToAction("Modifier", "Exercice",  new { exo_id = exercice.ID });
            }
        }

        public ActionResult Creer()
        {
            using (IDal dal = new Dal())
            {
                List<Exo> listeDesExos = dal.ObtientTousLesExos();
                ViewBag.ListeDesExos = listeDesExos;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Creer(Exo NouvelExo)
        {
            using (IDal dal = new Dal())
            {
                dal.CreerExo(
                    NouvelExo.Nom,
                    NouvelExo.Description,
                    null,
                    NouvelExo.TypePass,
                    NouvelExo.TypeShoot,
                    NouvelExo.TypePlayMaking,
                    NouvelExo.TypeAthletic,
                    NouvelExo.TypeGoalie,
                    DateTime.Now,
                    NouvelExo.Author);
                return RedirectToAction("Index");
            }
        }
    }
}