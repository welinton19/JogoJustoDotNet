using AutoMapper;
using JogoJustoDotNet.Models;
using JogoJustoDotNet.ViewModels;

namespace JogoJustoDotNet.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UsuarioModel, UsuarioViewModel>().ReverseMap();
        CreateMap<FuncionarioModel, FuncionarioCreatedViewModel>().ReverseMap();
    }
}
