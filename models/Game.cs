using System;
using System.Collections.Generic;
using System.Printing;
using System.Text;

namespace models
{
    public class Game
    {
        //properties
        public int Id { get; set; }

        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public int MinimumLeeftijd { get; set; }
        public Nullable<decimal> Prijs { get; set; }
        public double Rating { get; set; }
    }
}