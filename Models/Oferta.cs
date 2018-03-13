using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogdOferta.Models
{
    public class Oferta
    {
        public int OfertaID { get; set; }

        [Required]
        public int CategoriaID { get; set; }

        [Required]
        public int NegocioID { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Descripción de la Oferta")]
        [DataType(DataType.MultilineText)]
        public string DescripcionOfer { get; set; }

        [Required]
        [Display(Name = "Imagen de la Oferta")]
        public string ImagenNeg { get; set; }

        [Required]
        public double Precio { get; set; }

        [Required]
        public int Existencia { get; set; }

        [Required]
        public int Porcentaje { get; set; }

        [Required]
        public int Estado { get; set; }

        [Required]
        [Display(Name = "Fecha Inicial de la Oferta")]
        public DateTime FechaOferInicial { get; set; }

        [Required]
        [Display(Name = "Fecha Final de la Oferta")]
        public DateTime FechaOferFinal { get; set; }

        public virtual Categoria Categorias { get; set; }

        public virtual Negocio Negocios { get; set; }

        public Oferta()
        {
            FechaOferInicial = DateTime.Now;
            FechaOferFinal = DateTime.Now;
        }
    }
}