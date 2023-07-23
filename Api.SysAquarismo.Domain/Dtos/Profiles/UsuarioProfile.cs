using Api.SysAquarismo.Domain.Dtos.UsuarioDTO;
using Api.SysAquarismo.Domain.Models.Usuario;
using AutoMapper;

namespace Api.SysAquarismo.Domain.Dtos.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile() 
        {
            CreateMap<CreateUsuarioDTO, Usuario>();
        }
    }
}
