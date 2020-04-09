using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExercicesListGenerator.Models
{
    [Table("Entrainements")]
    public class Entrainement
    {
        public int ID { get; set; }
        [Required]
        public virtual string Description { get; set; }
        public virtual DateTime? CreationDate { get; set; }
        public virtual DateTime? ExecutionDate { get; set; }
        public virtual List<Exo> ListeExo { get; set; }
    }
}