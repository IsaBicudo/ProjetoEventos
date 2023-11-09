using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEventos.Models
{
    [Table("Buffet")]
    public class Buffet
    {
        [Column("BuffetId")]
        [Display(Name = "Código do Buffet")]
        public int Id { get; set; }

        [Column("BuffetTipo")]
        [Display(Name = "Tipo do Buffet")]
        public string BuffetTipo { get; set; } = string.Empty;

        [Column("ImagemBuffet1")]
        [Display(Name = "Imagem")]
        public string ImagemBuffet1 { get; set; } = string.Empty;

        [Column("ImagemBuffet2")]
        [Display(Name = "Imagem")]
        public string ImagemBuffet2 { get; set; } = string.Empty;

        [Column("ImagemBuffet3")]
        [Display(Name = "Imagem")]
        public string ImagemBuffet3 { get; set; } = string.Empty;

    }
}
