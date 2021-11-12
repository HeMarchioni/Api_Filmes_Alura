using System;
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

        public virtual Endereco Endereco { get; set; }   //-> Referencia de relacionamento 1 x 1 (virtual para o lazy funcionar e nao criar no banco esse valor)
        public int EnderecoId { get; set; }    // -> fk com o id de endereço


        public virtual Gerente Gerente { get; set; }   //-> Referencia de relacionamento 1 cinema so tem 1 gerente (virtual para o lazy funcionar)
        public int GerenteId { get; set; }    // -> fk com o id do Gerente
    }
}