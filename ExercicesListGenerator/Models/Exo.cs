using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace ExercicesListGenerator.Models
{
    public class Exo
    {
        public int ID { get; set; }
        public virtual string Nom { get; set; }
        public virtual string Description { get; set; }
        public virtual Byte[] Image { get; set; }
        public virtual DateTime? Date { get; set; }
        public virtual bool TypePass { get; set; }
        public virtual bool TypeShoot { get; set; }
        public virtual bool TypePlayMaking { get; set; }
        public virtual bool TypeAthletic { get; set; }
        public virtual bool TypeGoalie { get; set; }

    }
    
}