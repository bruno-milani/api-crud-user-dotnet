using System;
using System.ComponentModel.DataAnnotations;

namespace myApi.Domain.Dtos
{
    public class UserDto
    {
        [Required(ErrorMessage = "Email é um campo obrigatório para Logar!!!")]
        [EmailAddress(ErrorMessage = "Email no formato inválido!!!")]
        [StringLength(100, ErrorMessage = "Email deve ter no maximo {1} caracteres!!!")]
        public string Email { get; set; }
    }
}
