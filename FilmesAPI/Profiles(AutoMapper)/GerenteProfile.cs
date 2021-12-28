using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using System.Linq;

namespace FilmesAPI.Profiles
{
    public class GerenteProfile : Profile    //-> classe de Utilização do AutoMapper
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>()
                .ForMember(gerente => gerente.Cinemas, opts => opts      // -> injeçao da dependecia personalizada oq eu quero que seja passado de 1 objeto para poder formatar o retorno
                .MapFrom(gerente => gerente.Cinemas.Select
                (c => new { c.Id, c.Nome, c.Endereco, c.EnderecoId })));  //-> valores passados para o novo Object
            
            
        }
    }
}
