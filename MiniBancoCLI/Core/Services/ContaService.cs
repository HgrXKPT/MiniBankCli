using MiniBancoCLI.Core.DTOs.ContaDTO;
using MiniBancoCLI.Core.Interfaces;
using MiniBancoCLI.Core.Models;
using MiniBancoCLI.Core.Repositories;
using MiniBancoCLI.Infrastructure.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBancoCLI.Core.Services {
    internal class ContaService : IContaService{

        private readonly IContaRepository _contaRepository;

        public ContaService(IContaRepository contaRepository) {
            _contaRepository = contaRepository ?? throw new ArgumentNullException(nameof(contaRepository)); ;
        }
        public void AbrirConta(CriarContaDTO dto) {
            if(dto == null) 
                throw new ArgumentNullException(nameof(dto));

            if(dto.IdBanco < 0)
                throw new ArgumentNullException("Id do banco não pode ser negativo",nameof(dto.IdBanco));

            if(dto.IdCliente < 0)
                throw new ArgumentNullException("Id do cliente não pode ser negativo",nameof(dto.IdCliente));

            if(string.IsNullOrWhiteSpace(dto.Agencia))
                throw new ArgumentException("Agência não pode ser vazia",nameof(dto.Agencia));


            var conta = new Conta(
               agencia: dto.Agencia,
               idBanco: dto.IdBanco,
                idCliente: dto.IdCliente
                );

             _contaRepository.CadastrarConta(conta);
            
        }


    }
}
