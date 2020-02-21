using System;
using System.ComponentModel;

namespace FitCard.Domain.DTOs.User
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        [DisplayName("Data de Criação")]
        public DateTime CreateAt { get; set; }
    }
}