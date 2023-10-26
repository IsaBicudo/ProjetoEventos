using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEventos.Models
{
    [Table("TotalPagar")]
    public class TotalPagar
    {
        [Column("TotalPagarId")]
        [Display(Name = "Código do Total a Pagar")]
        public int Id { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        [ForeignKey("ConvidadoId")]
        public int ConvidadoId { get; set; }
        public Convidado? Convidado { get; set; }

        [ForeignKey("LocalId")]
        public int LocalId { get; set; }
        public Local? Local { get; set; }

        [ForeignKey("HorarioId")]
        public int HorarioId { get; set; }
        public Horario? Horario { get; set; }

        [ForeignKey("DecoracaoId")]
        public int DecoracaoId { get; set; }
        public Decoracao? Decoacao { get; set; }

        [ForeignKey("BuffetId")]
        public int BuffetId { get; set; }
        public Buffet? Buffet { get; set; }

        [ForeignKey("TipoEventoId")]
        public int TipoEventoId { get; set; }
        public TipoEvento? TipoEvento { get; set; }

        [Column("TotalValor")]
        [Display(Name = "Total do Valor")]
        public double TotalValor { get; set; } 

    }
}
