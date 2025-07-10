using Microsoft.EntityFrameworkCore.Metadata;
using MiniBancoCLI.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBancoCLI {
    internal class App {

       private readonly ContaService _contaService;

    public App(ContaService contaService) {
            _contaService = contaService;
        }

        public void Run() {

            Console.WriteLine("-----MiniBank-----");
            Console.WriteLine("1Login \n2)Cadastro de Conta");
            string escolha = Console.ReadLine();
            switch(escolha) {
                case "1":
                    
                   //
                    break;

                case "2":
                    //

                    _contaService.AbrirConta();

                    break;
            }
        }
    }
}
