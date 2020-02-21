using System;
using System.ComponentModel.DataAnnotations;

namespace FitCard.Domain.DTOs.User
{
    public class UserDTOUpdate
    {
        [Required(ErrorMessage = "Id é um campo obrigatório!")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é um campo obrigatório!")]
        [StringLength(60, ErrorMessage = "O tamanho maximo para nome é de {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "E-mail é um campo obrigatório para Login")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [StringLength(100, ErrorMessage = "E-mail deve ter no maximo {1} caracteres.")]
        public string Email { get; set; }
    }
}