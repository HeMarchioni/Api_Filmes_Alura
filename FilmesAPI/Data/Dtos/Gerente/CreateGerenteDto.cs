using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.Dtos
{
    public class CreateGerenteDto
    {

        [Required(ErrorMessage = "O Campo Nome é Obrigatorio")]  //-> Validação (ja retorna Bad request e a mensagem no lugar do OBJ) 
        public string Nome { get; set; }

     

    }
}
