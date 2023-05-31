using System;
using System.Collections.Generic;
using System.Text;

namespace models
{
    public class GenreGame
    {
        //properties
        public int Id { get; set; }

        public int GenreId { get; set; }
        public int GameId { get; set; }

        //navigational properties
        public Game Game { get; set; }

        public Genre Genre { get; set; }
    }
}