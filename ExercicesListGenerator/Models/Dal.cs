using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace ExercicesListGenerator.Models
{
    public class Dal : IDal
    {
        public BddContext bdd;
        public Dal()
        {
            bdd = new BddContext();
        }

        public List<Exo> ObtientTousLesExos()
        {
            return bdd.Exos.ToList();
        }

        public List<Entrainement> ObtientTousLesEntrainements()
        {
            return bdd.Entrainements.ToList();
        }
        public void Dispose()
        {
            bdd.Dispose();
        }

        public void CreerExo(string nom, string description, Byte[] image, bool typepass, bool typeshoot, bool typeplaymaking,
            bool typeathletic, bool typegoalie, DateTime creationdate)
        {
            bdd.Exos.Add(new Exo 
            { 
                Nom = nom,
                Description = description,
                Image = image,
                TypePass = typepass,
                TypeShoot = typeshoot,
                TypePlayMaking = typeplaymaking,
                TypeAthletic = typeathletic,
                TypeGoalie = typegoalie,
                Date = creationdate
            });
            bdd.SaveChanges();
        }

        public void CreerEntrainement(string description, DateTime creationdate, DateTime executiondate, List<Exo> listexos)
        {
            bdd.Entrainements.Add(new Entrainement
            {
                Description = description,
                CreationDate = creationdate,
                ExecutionDate = executiondate,
                ListeExo = listexos
            });
            bdd.SaveChanges();
        }
    }
}