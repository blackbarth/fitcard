using AutoMapper;
using FitCard.Domain.DTOs.Categoria;
using FitCard.Domain.DTOs.Empresa;
using FitCard.Domain.DTOs.User;
using FitCard.Domain.Models;

namespace FitCard.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDTO>().ReverseMap();
            CreateMap<UserModel, UserDTOCreate>().ReverseMap();
            CreateMap<UserModel, UserDTOUpdate>().ReverseMap();

            CreateMap<CategoriaModel, CategoriaDTO>().ReverseMap();
            CreateMap<CategoriaModel, CategoriaDTOCreate>().ReverseMap();
            CreateMap<CategoriaModel, CategoriaDTOUpdate>().ReverseMap();

            CreateMap<EmpresaModel, EmpresaDTO>().ReverseMap();
            CreateMap<EmpresaModel, EmpresaDTOCreate>().ReverseMap();
            CreateMap<EmpresaModel, EmpresaDTOUpdate>().ReverseMap();
        }
    }
}