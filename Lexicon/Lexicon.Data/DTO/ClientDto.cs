﻿
namespace Lexicon.Data.DTO
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
