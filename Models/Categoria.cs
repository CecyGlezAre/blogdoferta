using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogdOferta.Models
{
    public class Categoria
    {
        public int CategoriaID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre de la Categoria")]
        public string NomCate { get; set; }

        [Required]
        [Display(Name = "Estado de la Categoria")]
        public int EstadoCate { get; set; }

        [Required]
        [Display(Name = "Fecha de Creación de Categoria")]
        public DateTime FechaCreacionCate { get; set; }

        public virtual ICollection<Oferta> Ofertas { get; set; }

        public Categoria()
        {
            FechaCreacionCate = DateTime.Now;
        }
    }
}