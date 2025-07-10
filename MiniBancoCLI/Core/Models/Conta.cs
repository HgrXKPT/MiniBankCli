using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace MiniBancoCLI.Core.Models;

public partial class Conta {
    private string _numeroConta;
    private decimal _saldo;
    private string _agencia;

    public Conta(string agencia, int idBanco, int idCliente) {

        this.NumeroConta = GerarNumeroConta();
        this.Agencia = agencia;
        this.Saldo = 0;

        this.IdBanco = idBanco;
        this.IdCliente = idCliente;


    }




    public int IdConta { get; set; }

    public string NumeroConta {
        get => _numeroConta;
        private set => _numeroConta = value;

    }

    public string Agencia {
        get => _agencia;
        set => _agencia = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentNullException(nameof(value)) : value;

    }

    public decimal Saldo {
        get => _saldo;
        private set => _saldo = value < 0
            ? throw new ArgumentOutOfRangeException(nameof(value))
            : value;
    }


    public int? IdBanco { get; set; }

    public int? IdCliente { get; set; }

    public virtual Banco? IdBancoNavigation { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual ICollection<Transacao> Transacaos { get; set; } = new List<Transacao>();

    //methods

    public void Depositar(decimal valor) {
        if(valor < 0)
            throw new ArgumentOutOfRangeException("Favor inserir valor válido ",nameof(valor));
        _saldo += valor;
    }

    public void Sacar(decimal valor) {
        if(valor < 0)
            throw new ArgumentOutOfRangeException("Impossivel sacar um valor menor q 0",nameof(valor));
        if(valor > _saldo)
            throw new ArgumentOutOfRangeException("Impossivel sacar um valor maior que o saldo atual",nameof(valor));

        _saldo -= valor;
        
    }

    private string GerarNumeroConta() {
        return new Random().Next(0, 9999).ToString() + "-1";
    }
    

}

    

