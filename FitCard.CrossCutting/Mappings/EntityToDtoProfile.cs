using AutoMapper;
using FitCard.Domain.DTOs.Categoria;
using FitCard.Domain.DTOs.Empresa;
using FitCard.Domain.DTOs.User;
using FitCard.Domain.Entities;

namespace FitCard.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDTO, UserEntity>().ReverseMap();
            CreateMap<UserDTOCreateResult, UserEntity>().ReverseMap();
            CreateMap<UserDTOUpdateResult, UserEntity>().ReverseMap();

            CreateMap<CategoriaDTO, CategoriaEntity>().ReverseMap();
            CreateMap<CategoriaDTOCreateResult, CategoriaEntity>().ReverseMap();
            CreateMap<CategoriaDTOUpdateResult, CategoriaEntity>().ReverseMap();

            CreateMap<EmpresaDTO, EmpresaEntity>().ReverseMap();
            CreateMap<EmpresaDTOCreateResult, EmpresaEntity>().ReverseMap();
            CreateMap<EmpresaDTOUpdateResult, EmpresaEntity>().ReverseMap();

        }
    }
}