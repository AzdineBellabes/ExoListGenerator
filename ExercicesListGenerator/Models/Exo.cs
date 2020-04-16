using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExercicesListGenerator.Models
{
    [Table("Exos")]
    public class Exo
    {
        public int ID { get; set; }
        [Required]
        public virtual string Nom { get; set; }
        public virtual string Description { get; set; }
        public virtual byte[] Image { get; set; }
        public virtual DateTime? Date { get; set; }
        [Display(Name = "Exercice de passes")]
        public virtual bool TypePass { get; set; }
        [Display(Name = "Exercice de tirs")]
        public virtual bool TypeShoot { get; set; }
        [Display(Name = "Exercice de strategie")]
        public virtual bool TypePlayMaking { get; set; }
        [Display(Name = "Exercice physique")]
        public virtual bool TypeAthletic { get; set; }
        [Display(Name = "Exercice pour gardien")]
        public virtual bool TypeGoalie { get; set; }
        [Display(Name = "Auteur")]
        public virtual string Author { get; set;  }

    }
    
}