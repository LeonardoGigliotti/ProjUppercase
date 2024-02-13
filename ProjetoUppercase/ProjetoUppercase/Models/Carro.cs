using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoUppercase.Models
{
    [Table("Carro")]
    public class Carro
    {
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("Foto")]
        [Display(Name = "Foto")]
        public byte[]? Foto { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [Column("Marca")]
        [Display(Name = "Marca")]
        public string? Marca { get; set; }

        [Column("Modelo")]
        [Display(Name = "Modelo")]
        public string? Modelo { get; set; }

        [Column("Ano")]
        [Display(Name = "Ano")]
        public int Ano { get; set; }

        [Column("Cor")]
        [Display(Name = "Cor")]
        public string? Cor { get; set; }

        [Column("Preco")]
        [Display(Name = "Preco")]
        public int Preco { get; set; }

        [NotMapped]
        public IFormFile? ImagemCarro { get; set; }

        [NotMapped]
        [Display(Name ="Imagem")]
        public string? ImagemCarroBase64 { get; set; }


    }
}
