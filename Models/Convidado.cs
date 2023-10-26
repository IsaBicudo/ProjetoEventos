using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEventos.Models
{
    [Table("Convidado")]
    public class Convidado
    {
        [Column("ConvidadoId")]
        [Display(Name = "Código do Convidado")]
        public int Id { get; set; }

        [Column("ConvidadoTotal")]
        [Display(Name = "Total de Convidados")]
        public int ConvidadoTotal { get; set; }

    
    }
}
