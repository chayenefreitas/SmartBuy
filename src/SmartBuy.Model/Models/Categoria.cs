using System.ComponentModel.DataAnnotations;

namespace SmartBuy.Models
{
    public class Categoria
    {
        [Key]
        [Display(Name = "Código")]
        public int IdCategoria { get; set; }


        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, ErrorMessage = "O campo {0} precisa ter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter no máximo {1} caracteres")]
        public string Descricao { get; set; } = string.Empty;
    }
}
