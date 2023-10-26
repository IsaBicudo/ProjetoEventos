using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEventos.Models
{
    [Table("Local")]
    public class Local
    {
        [Column("LocalId")]
        [Display(Name = "Código do Local")]
        public int LocalId { get; set; }

        [Column("LocalNome")]
        [Display(Name = "Nome do Local")]
        public string LocalNome { get; set; } = string.Empty;

        
    }
}
