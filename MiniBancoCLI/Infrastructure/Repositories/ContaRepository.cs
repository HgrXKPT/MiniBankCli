using Microsoft.EntityFrameworkCore;
using MiniBancoCLI.Core.Models;
using MiniBancoCLI.Core.Repositories;
using MiniBancoCLI.Infrastructure.Data;
using MiniBancoCLI.Util.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBancoCLI.Infrastructure.Repositories {
    internal class ContaRepository : IContaRepository{

        private readonly MiniBankContext _dbContext;
       
        public ContaRepository(MiniBankContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task CadastrarConta(Conta conta) {
          
           var contaExiste = await  _dbContext.Conta.AnyAsync(c => c.IdCliente == conta.IdCliente && c.IdBanco == conta.IdBanco);

            if(!contaExiste)
                throw new ExistingUserException("O usuario já está cadastrado no banco de dados");

            

          
            await _dbContext.Conta.AddAsync(conta);
            await _dbContext.SaveChangesAsync();
        
        }
    }
}
