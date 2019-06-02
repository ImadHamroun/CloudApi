using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CloudApiProject.Model
{
    public class Result
    {
        [ForeignKey("Bokser")]
        public int Id { get; set; }
        public int AantalGevechten { get; set; }
        public int Overwinningen { get; set; }
        public int Knockouts { get; set; }
        public int Gelijk { get; set; }
        public int Verloren { get; set; }
        [JsonIgnore]
        public virtual Boxer Bokser { get; set; }







    }
}
