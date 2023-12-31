﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

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

        [Column ("QuantidadeConvidados")]
        [Display (Name = "Convidados")]
        public int QuantidadeConvidados { get; set; }

        [ForeignKey("LocalId")]
        public int LocalId { get; set; }
        public Local? Local { get; set; }

        [Column("Horario")]
        [Display(Name = "Horário")]
        public DateTime Horario { get; set; }

        [ForeignKey("DecoracaoId")]
        [Display(Name = "Decoração")]
        public int DecoracaoId { get; set; }
        
        [Display(Name = "Decoração")]
        public Decoracao? Decoracao { get; set; }

        [ForeignKey("BuffetId")]
        public int BuffetId { get; set; }
        public Buffet? Buffet { get; set; }

        [ForeignKey("TipoEventoId")]
        public int TipoEventoId { get; set; }
        [Display(Name = "Evento")]
        public TipoEvento? TipoEvento { get; set; }

        [Column("TotalValor")]
        [Display(Name = "Valor")]
        public double TotalValor { get; set; } 

    }
}
