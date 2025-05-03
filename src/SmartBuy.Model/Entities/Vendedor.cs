using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBuy.Core.Entities
{
    public class Vendedor
    {
        [Key]
        public string IdVendedor { get; set; }

        public string Nome { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
