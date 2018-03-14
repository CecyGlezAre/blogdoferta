using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogdOferta.Models
{
    public class OfertasXCate
    {
        public int OfertaID { get; set; }

        public int CategoriaID { get; set; }

        public string DescripcionOfer { get; set; }

        public string ImagenNeg { get; set; }

        public double Precio { get; set; }

        public int Existencia { get; set; }

        public int Porcentaje { get; set; }

        public int Estado { get; set; }

        public DateTime FechaOferInicial { get; set; }

        public DateTime FechaOferFinal { get; set; }

        public string NomCate { get; set; }
    }
}