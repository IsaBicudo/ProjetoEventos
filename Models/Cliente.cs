using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEventos.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Column ("ClienteId")]
        [Display (Name = "Código do Cliente")]
        public int ClienteId { get; set; }

        [Column("ClienteNome")]
        [Display(Name = "Nome do Cliente")]
        public string ClienteNome { get; set; } = string.Empty;

        [Column("ClienteCpf ")]
        [Display(Name = "Cpf do Cliente")]
        public int ClienteCpf { get; set; }

        [Column("ClienteEmail")]
        [Display(Name = "Email do Cliente")]
        public string ClienteEmail { get; set; } = string.Empty;

    }
}
