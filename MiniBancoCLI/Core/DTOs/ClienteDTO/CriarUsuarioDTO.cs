using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBancoCLI.Core.DTOs.ClienteDTO {
    internal class CriarUsuarioDTO {

        public string Nome { get; set; }
        public string Cpf { get; set; }

        public string Senha {
            get; set;
        }
    }
}
