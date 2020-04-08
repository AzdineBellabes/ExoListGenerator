using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace ExercicesListGenerator.Models
{
    public interface IDal : IDisposable
    {
        void CreerExo(string nom, string description, Byte[] image, bool typepass, bool typeshoot, bool typeplaymaking, bool typeathletic, bool typegoalie, DateTime creationdate);
        void CreerEntrainement(string description, DateTime creationdate, DateTime executiondate, List<Exo> listeexos);

        List<Exo> ObtientTousLesExos();
        List<Entrainement> ObtientTousLesEntrainements();
    }

}