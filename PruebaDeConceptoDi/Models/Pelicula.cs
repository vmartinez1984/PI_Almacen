using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaDeConceptoDi.Models
{
    public class Pelicula
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPelicula { get; set; }
        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("DIRECTOR")]
        public string Director { get; set; }
        [Column("CLASIFICACION")]
        public string Clasificacion { get; set; }
    }
}
