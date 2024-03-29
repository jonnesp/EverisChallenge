﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EverisChallenge.App.DTOs
{
    public class UsuarioCreateDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public List<TelefoneCreateDto> Telefones { get; set; }
    }
}
