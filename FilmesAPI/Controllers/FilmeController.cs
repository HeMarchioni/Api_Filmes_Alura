using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{

    [ApiController]  // -> define que é um controlador
    [Route("[controller]")] // -> Define a rota mesmo nome que a [controller] (Filme)
    public class FilmeController : ControllerBase //-> sempre extender a classe Base
    {

        private FilmeContext _context;  //-> Variavel que recebe -> a classe de acesso ao BD
        private IMapper _mapper;        //> variavel que recebe -> mapper (IMapper tipo)



        public FilmeController(FilmeContext filmeContext, IMapper mapper)   //-> injetando o FilmeContect(DB) no contrutor e (IMapper -> mapper)
        {
            _context = filmeContext;
            _mapper = mapper;
        }




        [HttpPost]  //-> metodo http que ira Fazer a chamada da rota
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)  //-> FromBody (vem do corpo da requisição)
        {

            Filme filme = _mapper.Map<Filme>(filmeDto);  // -> utilizando o mapper para injetar filmeDto em Filme (criando o filme)



            _context.Add(filme); //-> _context é a extensao de acesso ao banco .add (adiciona)

            _context.SaveChanges();   // ->depois de alterar algo tem que salvar as mudanças 

            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme); // -> retorno para elemento criado

        }


        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes()  //-> IEnuerable (interface define que pode ser o retorno qualquer tipo List, set, )
        {
            return _context.Filmes;   //   _context.Filmes -> vai no banco e volta todos os filmes
        }


        [HttpGet("{id}")] // -> passa o valor pela Url e passa para Variavel de Entrada
        public IActionResult RecuperaFilmesPorId(int id)  //->recebe o Valor da Url // -> IActionResult (retorna um resultado 200 ok 404 (nesse caso Created)
        {



            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id); // -> (FirstOrDefault) Retorna o primeiro elemento da sequência que satisfaz uma condição ou um valor padrão

            if (filme != null)
            {

                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);


                return Ok(filmeDto); // -> Retorno para (Ok 200)
            }
            return NotFound(); // -> retorno de Nao encontrado (404)

        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilmePorId(int id, [FromBody] UpdateFilmeDto filmeDto)  //->recebe o Valor da Url // -> IActionResult (retorna um resultado 200 ok 404 (nesse caso Created)
        {




            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);


            if (filme == null) // busca pelo id se for nulo 
            {
                return NotFound(); // -> Retorno nao encontrado (404)
            }

            _mapper.Map(filmeDto,filme);  // -> se o Objeto ja esta criado (usar desse jeito injeta FilmeDto em filme)

            _context.SaveChanges();

            return NoContent();

        }


        [HttpDelete("{id}")]
        public IActionResult DeletarFilmePorId(int id)  //->recebe o Valor da Url // -> IActionResult (retorna um resultado 200 ok 404 (nesse caso Created)
        {


            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id); // -> (FirstOrDefault) Retorna o primeiro elemento da sequência que satisfaz uma condição ou um valor padrão

            if (filme != null)
            {

                _context.Remove(filme);   // -> remover o filme do BD

                _context.SaveChanges(); // -> salvar mudanças

                return NoContent(); // -> Retorno  (Ok 204 sem resposta)
            }
            return NotFound(); // -> retorno de Nao encontrado (404)


        }
    }
}


