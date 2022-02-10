using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk.Models
{
    public class ProductEntity: BaseEntity
    {
        [Required]
        [Display(Name ="Nombre")]
        [StringLength(150)]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [Display(Name="Número de serie")]
        [StringLength(255)]
        public string SerieNumber { get; set; }

        [Display(Name="Fecha de inicio")]
        public DateTime? DateStart { get; set; }

        [Display(Name = "Fecha fin")]
        public DateTime? DateStop { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryEntity))]
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(ProductStatusEntity))]
        public int ProductStatusId { get; set; }
    }
}