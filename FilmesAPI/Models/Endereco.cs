﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Endereco
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

        public Cinema Cinema { get; set; } //-> relacionamento 1 x 1 




    }
}
