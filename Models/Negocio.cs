using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogdOferta.Models
{
    public class Negocio
    {
        public int NegocioID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre del Negocio")]
        public string NomNeg { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Domicilio del Negocio")]
        public string DomNeg { get; set; }

        [Required]
        [Display(Name = "Imagen del Negocio")]
        public string ImagenNeg { get; set; }

        [Required]
        [Display(Name = "Localización del Negocio")]
        public string LocalizacionNeg { get; set; }

        [Required]
        [Display(Name = "Estado del Negocio")]
        public int EstadoNeg { get; set; }

        [Required]
        [Display(Name = "Fecha de Creación del Negocio")]
        public DateTime FechaCreacionNeg { get; set; }

        public virtual ICollection<Oferta> Ofertas { get; set; }

        public Negocio()
        {
            FechaCreacionNeg = DateTime.Now;
        }
    }
}