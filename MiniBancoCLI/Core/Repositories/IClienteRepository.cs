using MiniBancoCLI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBancoCLI.Core.Repositories {
    internal interface IClienteRepository {

        //
        Task CriarUsuario(Cliente cliente);
        Task ExcluirConta(int idCliente);

        //
    }
}
