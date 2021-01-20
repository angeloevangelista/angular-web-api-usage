using System;
using System.Collections.Generic;

#nullable disable

namespace angular_web_api_usage.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Email { get; set; }
    }
}
