using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExercicesListGenerator.Models
{
    public class Entrainement
    {
        public int ID { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime? CreationDate { get; set; }
        public virtual DateTime? ExecutionDate { get; set; }
        public virtual List<Exo> ListeExo { get; set; }
    }
}