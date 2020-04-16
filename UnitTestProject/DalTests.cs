using System.Drawing;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Moq;

using System.Data.Entity;
using ExercicesListGenerator.Models;

namespace UnitTestProject
{
    [TestClass]
    public class DalTests
    {

        byte[] testimage = { 0, 16, 104, 213 }; //some values different of null
        DateTime ladate = DateTime.Now;

        [TestInitialize]
        public void Init_Testing()
        {
            IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
            Database.SetInitializer(init);
            init.InitializeDatabase(new BddContext());
        }

        [TestMethod]
        public void CreerUnExo_RetourneBienLExo()
        {
            using (IDal dal = new Dal())
            {

                /*//Read Image File into Image object.
                Image img = Image.FromFile("C:\\Koala.jpg");
 
                //ImageConverter Class convert Image object to Byte array.
                byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(img, typeof(byte[]));*/

                dal.CreerExo("Carrousel", "Toute les balles en A", testimage, true, true, false, false, true, ladate, "Auteur");
                List<Exo> exos = dal.ObtientTousLesExos();

                Assert.IsNotNull(exos);
                Assert.AreEqual(1, exos.Count);
                Assert.AreEqual("Carrousel", exos[0].Nom);
                Assert.AreEqual(testimage, exos[0].Image);
            }
        }

        [TestMethod]
        public void CreerUnEntrainement_RetournBienLEntrainement()
        {
            using (IDal dal = new Dal())
            {
                dal.CreerExo("Carrousel", "Toute les balles en A", testimage, true, true, false, false, true, ladate, "Auteur");
                dal.CreerExo("3 Shoots in a row", "A demarre sa course en 1 recoit une passe de B : Shoot", testimage, true, true, false, false, true, ladate, "Auteur");

                List<Exo> exos = dal.ObtientTousLesExos();
                dal.CreerEntrainement("Entrainement du jour", ladate, ladate, exos);
                List<Entrainement> training = dal.ObtientTousLesEntrainements();

                Assert.IsNotNull(exos);
                Assert.AreEqual(2, exos.Count);
                Assert.AreEqual("Carrousel", exos[0].Nom);
                Assert.AreEqual(testimage, exos[0].Image);

                Assert.IsNotNull(training);
                Assert.AreEqual(1, training.Count);
                Assert.AreEqual("Entrainement du jour", training[0].Description);
                Assert.AreEqual(exos, training[0].ListeExo);
                Assert.AreEqual("Carrousel", training[0].ListeExo[0].Nom);
                Assert.AreEqual(testimage, training[0].ListeExo[0].Image);
                Assert.AreEqual("3 Shoots in a row", training[0].ListeExo[1].Nom);
            }
        }

        [TestMethod]
        public void ModifierExo_CreationEtModification()
        {
            using (IDal dal = new Dal())
            {
                dal.CreerExo("Carrousel", "Toute les balles en A", testimage, true, true, false, false, true, ladate, "Auteur");
                dal.CreerExo("3 Shoots in a row", "A demarre sa course en 1 recoit une passe de B : Shoot", testimage, true, true, false, false, true, ladate, "Auteur");
                List<Exo> exos = dal.ObtientTousLesExos();

                int id = exos.First(r => r.Nom == "3 Shoots in a row").ID;

                dal.ModifierExo(id, null, null, null, false, false, false, false, false);

                exos = dal.ObtientTousLesExos();

                Assert.IsNotNull(exos);
                Assert.AreEqual(2, exos.Count);
                Assert.AreEqual(false, exos[1].TypePass);
                Assert.AreEqual(false, exos[1].TypeShoot);
            }
        }

        [TestMethod]
        public void ModifierEntrainement_CreationEtModificationAvecChangementDexo()
        {
            using(IDal dal = new Dal())
            {
                DateTime newdate = ladate;
                newdate.AddDays(7);
                dal.CreerExo("Carrousel", "Toute les balles en A", testimage, true, true, false, false, true, ladate, "Auteur");
                dal.CreerExo("3 Shoots in a row", "A demarre sa course en 1 recoit une passe de B : Shoot", testimage, true, true, false, false, true, ladate, "Auteur");
                List<Exo> exos = dal.ObtientTousLesExos();

                dal.CreerEntrainement("Entrainement du jour", ladate, ladate, exos);
                List<Entrainement> training = dal.ObtientTousLesEntrainements();

                int id = training.First(r => r.Description == "Entrainement du jour").ID;
                dal.ModifierEntrainement(id, "Entrainement de la semaine", newdate, null);

                Assert.IsNotNull(training);
                Assert.AreEqual(1, training.Count);
                Assert.AreEqual(newdate, training[0].ExecutionDate);
                Assert.AreEqual("Entrainement de la semaine", training[0].Description);
            }
        }

        [TestMethod]
        public void AjouterUnExoALEntrainement()
        {
            using (IDal dal = new Dal())
            {
                DateTime newdate = ladate;
                dal.CreerExo("Carrousel", "Toute les balles en A", testimage, true, true, false, false, true, ladate, "Auteur");
                dal.CreerExo("3 Shoots in a row", "A demarre sa course en 1 recoit une passe de B : Shoot", testimage, true, true, false, false, true, ladate, "Auteur");
                List<Exo> exos = dal.ObtientTousLesExos();

                dal.CreerEntrainement("Entrainement du jour", ladate, ladate, exos);
                List<Entrainement> training = dal.ObtientTousLesEntrainements();

                dal.CreerExo("Exo En Plus", "voila un exo en plus", testimage, true, false, true, false, true, ladate, "Auteur");
                Assert.AreEqual(2, training[0].ListeExo.Count());
                dal.AjouterExoAEntrainement(training[0], 2);
                Assert.AreEqual(3, training[0].ListeExo.Count());
            }
        }

        [TestMethod]
        public void SupprimerUnExoALEntrainement()
        {
            using (IDal dal = new Dal())
            {
                DateTime newdate = ladate;
                dal.CreerExo("Carrousel", "Toute les balles en A", testimage, true, true, false, false, true, ladate, "Auteur");
                dal.CreerExo("3 Shoots in a row", "A demarre sa course en 1 recoit une passe de B : Shoot", testimage, true, true, false, false, true, ladate, "Auteur");
                dal.CreerExo("Exo En Plus", "voila un exo en plus", testimage, true, false, true, false, true, ladate, "Auteur");
                List<Exo> exos = dal.ObtientTousLesExos();

                dal.CreerEntrainement("Entrainement du jour", ladate, ladate, exos);
                List<Entrainement> training = dal.ObtientTousLesEntrainements();
                Assert.AreEqual(3, training[0].ListeExo.Count());
                dal.SupprimerExoAEntrainement(training[0], 1);
                Assert.AreEqual(2, training[0].ListeExo.Count());
                Assert.AreEqual("Exo En Plus", training[0].ListeExo[1].Nom);
            }
        }
    }
}
