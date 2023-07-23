using Api.SysAquarismo.Domain.Dtos.PeixeDTO;
using Api.SysAquarismo.Domain.Models.Peixe;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.SysAquarismo.Domain.Dtos.Profiles
{
    public class PeixeProfile : Profile
    {
        public PeixeProfile() 
        {
            CreateMap<CreatePeixeDTO, Peixe>();
            CreateMap<UpdatePeixeDTO, Peixe>();
        }
    }
}
