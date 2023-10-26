using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEventos.Models
{
    [Table("Horario")]
    public class Horario
    {
 

        [Column("HorarioId")]
        [Display(Name = "Código do Horario")]
        public int HorarioId { get; set; }

        [Column("HorarioEvento")]
        [Display(Name = "Agendar Horario")]

        public DateTime HorarioEvento { get; set; }


    }
}
