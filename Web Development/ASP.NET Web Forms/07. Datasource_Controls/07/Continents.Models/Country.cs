using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Continents.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public int Population { get; set; }
        public byte[] Flag { get; set; }
        public virtual Continent Continent{ get; set; }
    }
}
