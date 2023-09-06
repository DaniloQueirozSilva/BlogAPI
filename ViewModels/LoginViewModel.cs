using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "O emial é inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]       
        public string Password { get; set; }
    }
}
