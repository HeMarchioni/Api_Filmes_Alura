using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile   // -> para usar o mapper (extende essa classe :profile)
    {

        public FilmeProfile()
        {

            CreateMap<CreateFilmeDto, Filme>();   // -> criando as conversões (UpdateFilme -> para Filme)
            CreateMap<Filme, ReadFilmeDto>();     // -> filme para ReadFilme
            CreateMap<UpdateFilmeDto, Filme>();

        }



    }

}
