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
        public int UitgeverId { get; set; }
        public int OntwikkelaarId { get; set; }

        //navigational properties
        public Uitgever Uitgever { get; set; }

        public Ontwikkelaar Ontwikkelaar { get; set; }
        public ICollection<Platform> Platforms { get; set; }
        public ICollection<Game> Games { get; set; }

        public Game()
        {
            Platforms = new List<Platform>();
            Games = new List<Game>();
        }

        public override string ToString()
        {
            return $"{Id} - {Naam} - {Beschrijving} - {MinimumLeeftijd} - {Prijs} - {Rating} - {UitgeverId} - {OntwikkelaarId}";
        }
    }
}