using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEventos.Models
{
    [Table("Decoracao")]
    public class Decoracao
    {
        [Column("DecoracaoId")]
        [Display(Name = "Código da Decoração")]
        public int Id { get; set; }

        [Column("DecoracaoTipo")]
        [Display(Name = "Tipo de Decoração")]
        public string DecoracaoTipo { get; set; } = string.Empty;

        [Column("ImagemDecoracao1")]
        [Display(Name = "Imagem")]
        public string ImagemDecoracao1 { get; set; } = string.Empty;

        [Column("ImagemDecoracao2")]
        [Display(Name = "Imagem")]
        public string ImagemDecoracao2 { get; set; } = string.Empty;

        [Column("ImagemDecoracao3")]
        [Display(Name = "Imagem")]
        public string ImagemDecoracao3 { get; set; } = string.Empty;

    }
}
