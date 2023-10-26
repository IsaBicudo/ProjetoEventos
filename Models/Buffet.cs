using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEventos.Models
{
    [Table("Buffet")]
    public class Buffet
    {
        [Column("BuffetId")]
        [Display(Name = "Código do Buffet")]
        public int ClienteId { get; set; }

        [Column("BuffetTipo")]
        [Display(Name = "Tipo do Buffet")]
        public string BuffetTipo { get; set; } = string.Empty;

    }
}
