using AutoMapper;
using FitCard.Domain.DTOs.Categoria;
using FitCard.Domain.DTOs.Empresa;
using FitCard.Domain.DTOs.User;

namespace FitCard.CrossCutting.Mappings
{
    public class DtoToDtoProfile : Profile
    {
        public DtoToDtoProfile()
        {

            CreateMap<UserDTO, UserDTOCreate>().ReverseMap();
            CreateMap<UserDTO, UserDTOUpdate>().ReverseMap();


            CreateMap<CategoriaDTO, CategoriaDTOCreate>().ReverseMap();
            CreateMap<CategoriaDTO, CategoriaDTOUpdate>().ReverseMap();


            CreateMap<EmpresaDTO, EmpresaDTOCreate>().ReverseMap();
            CreateMap<EmpresaDTO, EmpresaDTOUpdate>().ReverseMap();
        }
    }
}