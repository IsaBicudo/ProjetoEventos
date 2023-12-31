﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEventos.Models
{
    [Table("Local")]
    public class Local
    {
        [Column("LocalId")]
        [Display(Name = "Código do Local")]
        public int Id { get; set; }

        [Column("LocalNome")]
        [Display(Name = "Nome do Local")]
        public string LocalNome { get; set; } = string.Empty;

        [Column("ImagemLocal1")]
        [Display(Name = "Imagem")]
        public string ImagemLocal1 { get; set; } = string.Empty;

        [Column("ImagemLocal2")]
        [Display(Name = "Imagem")]
        public string ImagemLocal2 { get; set; } = string.Empty;

        [Column("ImagemLocal3")]
        [Display(Name = "Imagem")]
        public string ImagemLocal3 { get; set; } = string.Empty;


    }
}
