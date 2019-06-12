using System;
using System.ComponentModel.DataAnnotations;

namespace DreamCatcher.Models.ViewModels
{
    public class UserViewModel
    {
        public Guid? Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "É obrigatório ter um login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "É obrigatório uma senha")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "A Confirmação de Senha é obrigatória.")]
        [Compare("Password", ErrorMessage = "As senhas digitadas são diferentes.")]
        [Display(Name = "Confirmar Senha")]
        [DataType(DataType.Password)]
        public string ConfirmationPassword { get; set; }

    }
}
