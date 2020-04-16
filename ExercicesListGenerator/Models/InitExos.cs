using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ExercicesListGenerator.Models
{
    public class InitExos : DropCreateDatabaseAlways<BddContext>
    {
        protected override void Seed(BddContext context)
        {
            context.Exos.Add(new Exo
            {
                ID = 0,
                Nom = "Mon exo n°1",
                Description = "une description rapide",
                Author = "Azdine",
                Date = DateTime.Now,
                TypePass = false,
                TypeShoot = true,
                TypePlayMaking = true,
                TypeAthletic = true,
                TypeGoalie = false,
            });

            context.Exos.Add(new Exo
            {
                ID = 1,
                Nom = "Mon exo n°2",
                Description = "deuze description rapide",
                Author = "Azdine",
                Date = DateTime.Now,
                TypePass = false,
                TypeShoot = true,
                TypePlayMaking = true,
                TypeAthletic = true,
                TypeGoalie = false,
            });

            context.Exos.Add(new Exo
            {
                ID = 2,
                Nom = "Mon exo n°3",
                Description = "trouaze description rapide",
                Author = "Azdine",
                Date = DateTime.Now,
                TypePass = false,
                TypeShoot = true,
                TypePlayMaking = true,
                TypeAthletic = true,
                TypeGoalie = false,
            });

            context.Exos.Add(new Exo
            {
                ID = 3,
                Nom = "Mon exo n°4",
                Description = "quatrez description rapide",
                Author = "Azdine",
                Date = DateTime.Now,
                TypePass = false,
                TypeShoot = true,
                TypePlayMaking = true,
                TypeAthletic = true,
                TypeGoalie = false,
            });

            base.Seed(context);
        }
    }
}