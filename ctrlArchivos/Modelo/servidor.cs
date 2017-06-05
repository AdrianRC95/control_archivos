using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ctrlArchivos.Modelo
{
    public class servidor
    {
        public string Svractual { get; set; }
        public string Bdatos { get; set; }
        public string MyQuery { get; set; }
        public string MyCadCon { get; set; }

        public servidor(string Svractual, string Bdatos)
        {
            this.Svractual = Svractual;
            this.Bdatos = Bdatos;
        }
    }
}