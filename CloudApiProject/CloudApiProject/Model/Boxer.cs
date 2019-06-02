using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudApiProject.Model
{
    public class Boxer
    {
        public int Id { get; set; }
        public string bijnaam { get; set; }
        public string Gewichtsklasse { get; set; }
        public double Lengte { get; set; }
        public double Bereik { get; set; }
        public string Nationaliteit { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Geboorteland { get; set; }
        public string Geboorteplaats { get; set; }
       
        public virtual Result results { get; set; }



    }
}
