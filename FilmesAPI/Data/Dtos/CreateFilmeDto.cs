using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.Dtos
{
    public class CreateFilmeDto
    {

        [Required(ErrorMessage = "O Campo titulo é Obrigatorio")]  //-> Validação (ja retorna Bad request e a mensagem no lugar do OBJ) 
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O Campo Diretor é Obrigatorio")]
        public string Diretor { get; set; }

        [StringLength(30, ErrorMessage = " O genero nao pode passar de 30 Caracteres")]
        public string Genero { get; set; }

        [Range(1, 600, ErrorMessage = "A duração deve ter no minimo 1 a 600 Minutos")] //->range
        public float Duracao { get; set; }

    }
}
