using System;
using System.Collections.Generic;
using System.Text;

namespace models
{
    public class Platform
    {
        //properties
        public int Id { get; set; }

        public string Naam { get; set; }
        public int UitgaveJaar { get; set; }
        public string Specificaties { get; set; }
        public int ProducentId { get; set; }
        public Nullable<decimal> Adviesprijs { get; set; }
    }
}