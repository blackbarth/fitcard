using AutoMapper;
using FitCard.Domain.Entities;
using FitCard.Domain.Models;

namespace FitCard.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
            CreateMap<CategoriaEntity, CategoriaModel>().ReverseMap();
            CreateMap<EmpresaEntity, EmpresaModel>().ReverseMap();
        }
    }
}