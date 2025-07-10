using Microsoft.EntityFrameworkCore;
using MiniBancoCLI.Core.Models;
using MiniBancoCLI.Core.Repositories;
using MiniBancoCLI.Infrastructure.Data;
using MiniBancoCLI.Util.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBancoCLI.Infrastructure.Repositories {
    internal class ClienteRepository : IClienteRepository {

        private readonly MiniBankContext _bankContext;

        public ClienteRepository(MiniBankContext bankContext) {
            _bankContext = bankContext ?? throw new ArgumentException("Error ao injetar dependencia");
        }

        public async Task AbrirConta(Conta conta) {

            var contaExistente = await _bankContext.Clientes.AnyAsync(c => c.IdCliente == conta.IdConta);
            if(contaExistente)
                throw new ExistingUserException("Usuario já existe na base de dados");

            await _bankContext.AddAsync(conta);
            await _bankContext.SaveChangesAsync();


        
        }
    }
}
