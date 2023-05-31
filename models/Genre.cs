using System;

namespace models
{
    public class Genre
    {
        //properties
        public int Id { get; set; }

        public string Naam { get; set; }

        //constructor
        public Genre()
        { }

        public Genre(string naam)
        {
            Naam = naam;
        }

        //methods
        public override string ToString()
        {
            return $"Genre: {Naam}";
        }

        public override bool Equals(object obj)
        {
            return obj is Genre genre &&
                   Id == genre.Id &&
                   Naam == genre.Naam;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Naam);
        }
    }
}