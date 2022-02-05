using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaDeConcepto.Api.Models
{
    public class Pais
    {
        public Pais()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required]
        public int Habitantes { get; set; }
    }
}
