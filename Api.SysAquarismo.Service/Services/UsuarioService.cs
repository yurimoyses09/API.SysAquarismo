using Api.SysAquarismo.Domain.Interfaces;
using Api.SysAquarismo.Domain.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.SysAquarismo.Service.Services
{
    internal class UsuarioService : IUsuarioRepository
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public Task GetUsuario(string nm_usuario)
        {
            throw new NotImplementedException();
        }

        public Task InsertUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task LoginUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task ResetSenha(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
