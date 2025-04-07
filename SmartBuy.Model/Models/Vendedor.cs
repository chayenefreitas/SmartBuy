using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBuy.Models
{
    public class Vendedor
    {
        [Key]
        public int IdVendedor { get; set; }

        public string IdUsuario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Confirme o {0}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Compare("E-mail", ErrorMessage = "Os e-mails não coincidem")]
        [NotMapped]
        public string EmailConfirmacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }

        [Display(Name = "Confirme a senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Compare("Senha", ErrorMessage = "As senhas não coincidem")]
        [NotMapped]
        public string SenhaConfirmacao { get; set; }
    }
}
