﻿using Api.SysAquarismo.Domain.Dtos.UsuarioDTO;
using Api.SysAquarismo.Domain.Models;
using AutoMapper;

namespace Api.SysAquarismo.Domain.Dtos.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile() 
    {
        CreateMap<CreateUsuarioDTO, Usuario>();
        CreateMap<LoginUsuarioDTO, Usuario>();
        CreateMap<Usuario, ReadUsuarioDTO>();
    }
}
