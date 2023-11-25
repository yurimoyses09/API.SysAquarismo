using Api.SysAquarismo.Domain.Dtos.PeixeDTO;
using Api.SysAquarismo.Domain.Models;
using AutoMapper;

namespace Api.SysAquarismo.Domain.Dtos.Profiles;

public class PeixeProfile : Profile
{
    public PeixeProfile()
    {
        CreateMap<CreatePeixeDTO, Peixe>();
        CreateMap<UpdatePeixeDTO, Peixe>();
        CreateMap<Peixe, ReadPeixeDTO>();
    }
}