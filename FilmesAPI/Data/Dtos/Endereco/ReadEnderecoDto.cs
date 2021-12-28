using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmesAPI.Data.Dtos
{
    public class ReadEnderecoDto
    {
        [Key]  //-> PK
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Campo Logadouro é Obrigatorio")]  //-> Validação (ja retorna Bad request e a mensagem no lugar do OBJ) 
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O Campo Bairro é Obrigatorio")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O Campo Numero é Obrigatorio")]
        public int Numero { get; set; }
    }
}
