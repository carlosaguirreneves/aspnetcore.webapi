using System.ComponentModel.DataAnnotations;

namespace AspnetCore.WebAPI.Dtos
{
    public class UserLoginDto
    {
        [Required(ErrorMessage="Login é obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage="Password é obrigatório")]
        public string Password { get; set; }
    }
}