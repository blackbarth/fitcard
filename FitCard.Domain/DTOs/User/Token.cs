using System;

namespace FitCard.Domain.DTOs.User
{
    public class Token
    {
        public bool authenticated { get; set; }
        public DateTime created { get; set; }
        public DateTime expiration { get; set; }
        public string accessToken { get; set; }
        public string username { get; set; }
        public string message { get; set; }
    }
}