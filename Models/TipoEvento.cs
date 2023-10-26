using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEventos.Models
{
    [Table("TipoEvento")]
    public class TipoEvento
    {
        [Column("TipoEventoId")]
        [Display(Name = "Código do Tipo de Evento")]
        public int Id { get; set; }

        [Column("EventoTipo")]
        [Display(Name = "Tipo de Evento")]
        public string EventoTipo { get; set; } = string.Empty;

       
    }
}
