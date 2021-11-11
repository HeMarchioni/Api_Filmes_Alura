using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data
{
    public class AppDbContext : DbContext   // -> para falar que a classe é um context do banco (extender a classe DbContext)
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)  // -> criar o contrutor da classe que passa as opçoes do DB (para o contrutor da classe Base)
        {

        }


        public DbSet<Filme> Filmes { get; set; }   // -> qual classe vai ser Mapeada e virar tabela (similar ao @Entity Java)
        public DbSet<Cinema> Cinemas { get; set; }


    }
}
