using MiniBancoCLI.Core.DTOs.ClienteDTO;
using MiniBancoCLI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBancoCLI.Core.Interfaces {
    internal interface IClienteService {
        Task CriarUsuario(CriarUsuarioDTO dto);
    } 
}
