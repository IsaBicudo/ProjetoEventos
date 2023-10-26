using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEventos.Models
{
    [Table("Decoracao")]
    public class Decoracao
    {
        [Column("DecoracaoId")]
        [Display(Name = "Código da Decoracao")]
        public int Id { get; set; }

        [Column("DecoracaoTipo")]
        [Display(Name = "Tipo de Decoracao")]
        public string DecoracaoTipo { get; set; } = string.Empty;

    }
}
