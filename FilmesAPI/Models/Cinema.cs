﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }

        public Endereco Endereco { get; set; }   //-> Referencia de relacionamento 1 x 1 
        public int EnderecoId { get; set; }    // -> fk com o id de endereço
       // public int GerenteFK { get; set; }
    }
}