using MiniBancoCLI.Core.DTOs.ContaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBancoCLI.Core.Interfaces {
    internal interface IContaService {



        void AbrirConta(CriarContaDTO contaDTO);
        Task RelizarSaque(int contaId,decimal valor);
        Task RealizarDeposito(int contaId,decimal valor);
        Task RealizarTransferencia(int contaOrigem,int contaDestino,decimal valor);
        Task ExcluirConta(int contaId);

        //
        




        

    }
}
