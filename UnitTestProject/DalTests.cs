using System.Drawing;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using ExercicesListGenerator.Models;

namespace UnitTestProject
{
    [TestClass]
    public class DalTests
    {
        Byte[] testimage;
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

                dal.CreerExo("Carrousel", "Toute les balles en A", testimage, true, true, false, false, true, ladate);
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
                dal.CreerExo("Carrousel", "Toute les balles en A", testimage, true, true, false, false, true, ladate);
                dal.CreerExo("3 Shoots in a row", "A demarre sa course en 1 recoit une passe de B : Shoot", testimage, true, true, false, false, true, ladate);

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
    }
}
