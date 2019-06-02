using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudApiProject.Model
{
    public class DBInitializer
    {
        public static void Initialize(BoxingStatisticsContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Boxers.Any())
            {
              

                var boxer = new Boxer()
                {
                    
                    Bereik = 180,
                    bijnaam = "Iron Mike",
                    Geboortedatum = new DateTime(1966, 01, 01),
                    Geboorteland = "Amerika",
                    Geboorteplaats = "Catskill",
                    Gewichtsklasse = "Heavyweight",
                    Lengte = 178,
                    Nationaliteit = "Amerikaan"

                };

                var boxer2 = new Boxer()
                {

                    Bereik = 203,
                    bijnaam = "The People's Champion",
                    Geboortedatum = new DateTime(1942, 01, 17),
                    Geboorteland = "Amerika",
                    Geboorteplaats = "Louisville",
                    Gewichtsklasse = "Heavyweight",
                    Lengte = 191,
                    Nationaliteit = "Amerikaan"

                };

                var result = new Result()
                {
                    AantalGevechten = 23,
                    Knockouts = 20,
                    Overwinningen = 21,
                    Verloren = 1,
                    Bokser = boxer
                    


                };
                var result2 = new Result()
                {
                    AantalGevechten = 23,
                    Knockouts = 20,
                    Overwinningen = 21,
                    Verloren = 1,
                    Bokser = boxer2



                };

                context.Boxers.Add(boxer);
                context.Boxers.Add(boxer2);
                context.Results.Add(result);
                context.Results.Add(result2);
                context.SaveChanges();



            }





        }


    }
}
