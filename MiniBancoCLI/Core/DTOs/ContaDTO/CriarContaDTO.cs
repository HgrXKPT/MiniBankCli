using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBancoCLI.Core.DTOs.ContaDTO {
    internal class CriarContaDTO {

        public string Agencia {
            get; set;
        }
       
        public int IdCliente {
            get; set;
        }

        
        public int IdBanco {
            get; set;
        }
    }
}
