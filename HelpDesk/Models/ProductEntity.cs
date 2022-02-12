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
        [DataType(DataType.Date)]
        public DateTime? DateStart { get; set; }

        [Display(Name = "Fecha fin")]
        [DataType(DataType.Date)]
        public DateTime? DateStop { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryEntity))]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }    

        [Required]
        [ForeignKey(nameof(ProductStatusEntity))]
        [Display(Name = "Estatus")]
        public int ProductStatusId { get; set; }
        public ProductStatusEntity ProductStatus { get; set;}
    }
}