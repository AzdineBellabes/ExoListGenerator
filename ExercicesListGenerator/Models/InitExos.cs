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
                //ID = 0,
                Nom = "Carroussel",
                Description = "A Passe à B \n B Shoot \n A > B > A",
                Author = "Jan-Erik Vaara",
                Date = DateTime.Now,
                TypePass = true,
                TypeShoot = true,
                TypePlayMaking = false,
                TypeAthletic = false,
                TypeGoalie = true,
            });

            context.Exos.Add(new Exo
            {
                //ID = 1,
                Nom = "Carroussel Inversé",
                Description = "A Passe à B \n B Shoot \n A > B > A",
                Author = "Azdine",
                Date = DateTime.Now,
                TypePass = true,
                TypeShoot = true,
                TypePlayMaking = false,
                TypeAthletic = false,
                TypeGoalie = true,
            });

            context.Exos.Add(new Exo
            {
                //ID = 2,
                Nom = "Triangle et Rebonds",
                Description = @"A Passe à B – A va en B B passe à C – B va en C",
                Author = "Azdine",
                Date = DateTime.Now,
                TypePass = true,
                TypeShoot = false,
                TypePlayMaking = true,
                TypeAthletic = false,
                TypeGoalie = false,
            });

            context.Exos.Add(new Exo
            {
                //ID = 3,
                Nom = "3 tirs à la suite",
                Description = @"A demarre sa course en 1 recoit une passe de B : Shoot",
                Author = "Petri Kettunen",
                Date = DateTime.Now,
                TypePass = false,
                TypeShoot = true,
                TypePlayMaking = false,
                TypeAthletic = true,
                TypeGoalie = true,
            });

            base.Seed(context);
        }
    }
}