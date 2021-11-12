using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;




namespace FilmesAPI.Profiles
{
    public class GerenteProfile : Profile    //-> classe de Utilização do AutoMapper
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>();
            
        }
    }
}
