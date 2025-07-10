using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBancoCLI.Features.Cliente {
    internal class ClienteMenu {

        public void Executar() {

            Console.WriteLine("---- Área do Cliente ----");
            Console.WriteLine("1) Login");
            Console.WriteLine("2) Cadastro");
            Console.WriteLine("3) Voltar");
            var escolha = Console.ReadLine();

            switch(escolha) {
                case "1":
                    //Login
                    break;
                 case "2":

                    //cadastro
                    break;
                case "3":
                    //voltar
                    return;
            }
           
        }

    }
}
