using System;
using System.Collections.Generic;

namespace MiniBancoCLI.Core.Models;

public partial class Cliente
{

    private string _nome;
    private string _cpf;
    private string _senhaHash;


    public Cliente(string nome,string cpf) {
        _nome = nome;
        _cpf = cpf;
    }


    public int IdCliente { get; set; }

    public string Nome {
        get => _nome; 
        set => _nome = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentNullException("O nome não pode ser vazio",nameof(value)) : value;
    }

    public string Cpf {
        get => _cpf;
        set {
            if(string.IsNullOrWhiteSpace(value)) 
                throw new ArgumentNullException("O CPF nao pode ser vazio",nameof(value));
            if(value.Length > 11)
                throw new ArgumentException("Formato de CPF invalido",nameof(value));
                
                
                _cpf = value;
        }
    } 
    
    



    public string? SenhaHash {
        get => _senhaHash;
        private set {
            if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("A senha nao pode ser nula",nameof(value));
        } 
    
    }

    public void DefinirSenha(string Hash) {
        _senhaHash = Hash;
    }

    public virtual ICollection<Conta> Conta { get; set; } = new List<Conta>();
}
