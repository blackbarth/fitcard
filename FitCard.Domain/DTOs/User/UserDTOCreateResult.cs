using System;

namespace FitCard.Domain.DTOs.User
{
    public class UserDTOCreateResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
    }
}