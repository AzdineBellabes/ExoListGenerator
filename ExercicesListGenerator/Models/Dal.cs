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

        public void CreerExo(string nom, string description, byte[] image, bool typepass, bool typeshoot, bool typeplaymaking,
            bool typeathletic, bool typegoalie, DateTime creationdate, string author)
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
                Date = creationdate,
                Author = author
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

        public void ModifierExo(int id, string nom, string description, byte[] image, bool typepass, bool typeshoot, bool typeplaymaking, bool typeathletic, bool typegoalie)
        {
            Exo exoTrouve = bdd.Exos.FirstOrDefault(exo => exo.ID == id);
            if (exoTrouve != null)
            {
                if (nom != null)
                {
                    exoTrouve.Nom = nom;
                }
                if (description != null)
                {
                    exoTrouve.Description = description;
                }
                if (image != null)
                {
                    exoTrouve.Image = image;
                }
                exoTrouve.TypePass = typepass;
                exoTrouve.TypeShoot = typeshoot;
                exoTrouve.TypePlayMaking = typeplaymaking;
                exoTrouve.TypeAthletic = typeathletic;
                exoTrouve.TypeGoalie = typegoalie;
            }
            bdd.SaveChanges();
        }
        public void ModifierEntrainement(int id, string description, DateTime executiondate, List<Exo> listeexos)
        {
            Entrainement trainingtrouve = bdd.Entrainements.FirstOrDefault(training => training.ID == id);
            if (trainingtrouve != null)
            {
                if (description != null)
                {
                    trainingtrouve.Description = description;
                }
                if (executiondate != null)
                {
                    trainingtrouve.ExecutionDate = executiondate;
                }
                if (listeexos != null)
                {
                    trainingtrouve.ListeExo = listeexos;
                }
            }
            bdd.SaveChanges();
        }

        public void AjouterExoAEntrainement(Entrainement training, int idExo)
        {
            Exo exoTrouve = bdd.Exos.FirstOrDefault(exo => exo.ID == idExo);
            if (exoTrouve != null)
            {
                training.ListeExo.Add(exoTrouve);
            }
            bdd.SaveChanges();
        }

        public void SupprimerExoAEntrainement(Entrainement training, int idExo)
        {
            List<Exo> NouvelleListeExo = training.ListeExo;
            Exo exoTrouve = bdd.Exos.FirstOrDefault(exo => exo.ID == idExo);
            NouvelleListeExo.Remove(exoTrouve);
            training.ListeExo = NouvelleListeExo;
            bdd.SaveChanges();
        }
    }
}