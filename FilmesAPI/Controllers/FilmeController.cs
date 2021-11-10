using FilmesAPI.Data;
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


        public FilmeController(FilmeContext filmeContext)   //-> injetando o FilmeContect(DB) no contrutor
        {
            _context = filmeContext;
        }




        [HttpPost]  //-> metodo http que ira Fazer a chamada da rota
        public IActionResult AdicionaFilme([FromBody] Filme filme)  //-> FromBody (vem do corpo da requisição)
        {

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
                return Ok(filme); // -> Retorno para (Ok 200)
            }
            return NotFound(); // -> retorno de Nao encontrado (404)

        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilmePorId(int id, [FromBody] Filme filmeAtualizado)  //->recebe o Valor da Url // -> IActionResult (retorna um resultado 200 ok 404 (nesse caso Created)
        {


            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);


            if (filme == null) // busca pelo id se for nulo 
            {
                return NotFound(); // -> Retorno nao encontrado (404)
            }

            filme.Titulo = filmeAtualizado.Titulo;
            filme.Genero = filmeAtualizado.Genero;
            filme.Duracao = filmeAtualizado.Duracao;
            filme.Diretor = filmeAtualizado.Diretor;

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


