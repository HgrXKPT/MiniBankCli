using MiniBancoCLI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBancoCLI.Core.Repositories {
    internal interface IContaRepository {

        //Cadastro
        Task CadastrarConta(Conta conta);

        //Especificos

        Task<decimal> ConsultarSaldo();
        Task<Transacao> Depositar(int contaId, decimal valor);
        Task<Transacao> Sacar(int contaId, decimal valor);
        Task<Transacao> Transferencia(int idContaOrigem, int idContaDestino, decimal valor);
        Task<IEnumerable<Transacao>> ObterExtrato(int contaId, DateTime dataInicial, DateTime DataFinal);


        //CRUD
        
        Task<Conta> GetById(int id);
        Task<IEnumerable<Conta>> GetAll();
        Task Update(Conta conta);
        Task Delete(int contaId);


        //Validações

        Task<bool> ContaExiste(int contaId);
        Task<bool> NumeroContaExiste(string numeroConta);





    }
}
