﻿using System;

namespace FitCard.Domain.DTOs.User
{
    public class UserDTOUpdateResult
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}