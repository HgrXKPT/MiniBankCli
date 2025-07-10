using MiniBancoCLI.Core.DTOs.ClienteDTO;
using MiniBancoCLI.Core.Interfaces;
using MiniBancoCLI.Core.Models;
using MiniBancoCLI.Core.Repositories;


namespace MiniBancoCLI.Core.Services {
    internal class ClienteService : IClienteService {

        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository) {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }

        public async Task CriarUsuario(CriarUsuarioDTO dto) {

            if(string.IsNullOrWhiteSpace(dto.Nome))
                throw new ArgumentException("O Nome não pode ser vázio");

            if(dto.Cpf.Length != 11)
                throw new ArgumentOutOfRangeException("O Cpf precisa de 11 digitos",nameof(dto.Cpf));

            if(string.IsNullOrWhiteSpace(dto.Senha))
                throw new ArgumentNullException("A senha nao pode ser vazia");

            var cliente = new Cliente(dto.Nome,dto.Cpf);
            var senhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha);
            cliente.DefinirSenha(senhaHash);

            //

           await _repository.CriarUsuario(cliente);






        }
    }
}
