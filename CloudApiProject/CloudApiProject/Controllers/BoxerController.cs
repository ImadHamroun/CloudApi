using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudApiProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CloudApiProject.Controllers
{
    [Route("api/v1/boxers")]
    public class BoxerController : Controller
    {

        public BoxingStatisticsContext _context { get; set; }
        public BoxerController(BoxingStatisticsContext ctxt)
        {
            _context = ctxt;
        }


        [Route("{id}")]
        [HttpGet]
        public Boxer getBoxer(int id)
        {

           return _context.Boxers.Include(d => d.results).SingleOrDefault(d=>d.Id == id);

        }
        [Route("{id}/results")]
        [HttpGet]
        public Result getboxerResults(int id)
        {
            Result rs = _context.Results.Find(id);
            return rs;

        }

      

        [HttpGet]
        public List<Boxer> getAllBoxers(string Weightclass, int? page, string sort, string dir , int length =2)
        {
            IQueryable < Boxer > query = _context.Boxers;
            if (!string.IsNullOrWhiteSpace(Weightclass))
            {
                query = query.Include(d => d.results).Where(d => d.Gewichtsklasse == Weightclass);
                
            }
            if (!string.IsNullOrWhiteSpace(sort))
            {
                switch (sort)
                {
                    case "Nickname":
                        if(dir == "asc")
                        {
                            query = query.OrderBy(d => d.bijnaam);

                        }else if(dir == "desc")
                        {
                            query = query.OrderByDescending(d => d.bijnaam);
                        }

                        break;
                    case "Knockouts":
                        if (dir == "asc")
                        {
                            query = query.OrderBy(d => d.results.Knockouts);
                        }
                        else if (dir == "desc")
                        {
                            query = query.OrderByDescending(d => d.results.Knockouts);
                        }
                        break;
                    case "Winnings":
                        if (dir == "asc")
                        {
                            query = query.OrderBy(d => d.results.Overwinningen);
                        }
                        else if (dir == "desc")
                        {
                            query = query.OrderByDescending(d => d.results.Overwinningen);
                        }
                        break;
                    case "Matches":
                        if (dir == "asc")
                        {
                            query = query.OrderBy(d => d.results.AantalGevechten);
                        }
                        else if (dir == "desc")
                        {
                            query = query.OrderByDescending(d => d.results.AantalGevechten);
                        }
                        break;


                }
            }
            if (page.HasValue)
            {
                query = query.Include(d => d.results).Skip(page.Value * length);
            }
            query = query.Include(d => d.results).Take(length);

            return query.ToList();
           
        }

   

        [HttpPost]
        public void addBoxer([FromBody] Boxer bxr)
        {
            _context.Boxers.Add(new Boxer()
            {
                
                Bereik = bxr.Bereik,
                bijnaam = bxr.bijnaam,
                Geboortedatum = bxr.Geboortedatum,
                Geboorteland = bxr.Geboorteland,
                Geboorteplaats = bxr.Geboorteplaats,
                Gewichtsklasse = bxr.Gewichtsklasse,
                Lengte = bxr.Lengte,
                Nationaliteit = bxr.Nationaliteit,
                results = new Result()
                {
                    AantalGevechten = bxr.results.AantalGevechten,
                    Gelijk = bxr.results.Gelijk,
                    Bokser = bxr,
                    Knockouts = bxr.results.Knockouts,
                    Overwinningen = bxr.results.Overwinningen,
                    Verloren = bxr.results.Verloren

                }

            });


            _context.SaveChanges();

        }
        [Route("{id}")]
        [HttpDelete]
        public IActionResult removeBoxer(int id)
        {
            Boxer bxr = _context.Boxers.Find(id);
           
            if (bxr == null)
                return NotFound();


            _context.Boxers.Remove(bxr);
            _context.SaveChanges();
            return NoContent();





        }
        
        [HttpPut]
        public IActionResult updateBoxer([FromBody] Boxer boxer)
        {

            Boxer bxr = _context.Boxers.Include(d =>d.results).SingleOrDefault(d =>d.Id == boxer.Id);
            if (bxr == null)
                return NotFound();
            bxr.Gewichtsklasse = ((boxer.Gewichtsklasse==null) ? bxr.Gewichtsklasse : boxer.Gewichtsklasse);
            bxr.Bereik = ((boxer.Bereik == 0) ? bxr.Bereik : boxer.Bereik); 
            bxr.bijnaam = ((boxer.bijnaam == null) ? bxr.bijnaam : boxer.bijnaam);
            bxr.Geboortedatum = ((boxer.Geboortedatum == new DateTime(0001,01,01,00,00,00)) ? bxr.Geboortedatum : boxer.Geboortedatum);
            bxr.Geboorteland = ((boxer.Geboorteland == null) ? bxr.Geboorteland : boxer.Geboorteland);
            bxr.Geboorteplaats = ((boxer.Geboorteplaats == null) ? bxr.Geboorteplaats : boxer.Geboorteplaats);
            bxr.Lengte = ((boxer.Lengte == 0) ? bxr.Lengte : boxer.Lengte);
            bxr.Nationaliteit = ((boxer.Nationaliteit == null) ? bxr.Nationaliteit : boxer.Nationaliteit);
            bxr.results.AantalGevechten = ((boxer.results.AantalGevechten == 0) ? bxr.results.AantalGevechten:boxer.results.AantalGevechten);
            bxr.results.Gelijk = ((boxer.results.Gelijk == 0) ? bxr.results.Gelijk : boxer.results.Gelijk); ;
            bxr.results.Knockouts = ((boxer.results.Knockouts == 0) ? bxr.results.Knockouts : boxer.results.Knockouts); ;
            bxr.results.Verloren = ((boxer.results.Verloren == 0) ? bxr.results.Verloren : boxer.results.Verloren); ;
            bxr.results.Overwinningen = ((boxer.results.Overwinningen == 0) ? bxr.results.Overwinningen : boxer.results.Overwinningen); ;
            _context.SaveChanges();
            return Ok(bxr);


        }
    }
}