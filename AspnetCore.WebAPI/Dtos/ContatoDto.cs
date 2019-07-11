using System.ComponentModel.DataAnnotations;

namespace AspnetCore.WebAPI.Dtos
{
    public class ContatoDto
    {
        public string Id { get; set; }
        [Required(ErrorMessage="Campo Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage="Campo Canal é obrigatório.")]
        public string Canal { get; set; }
        [Required(ErrorMessage="Campo Valor é obrigatório.")]
        public string Valor { get; set; }
        public string Obs { get; set; }
    }
}