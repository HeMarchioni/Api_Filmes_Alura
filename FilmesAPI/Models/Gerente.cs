using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Gerente
    {
        [Key]  //-> PK
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="O Campo Nome é Obrigatorio")]  //-> Validação (ja retorna Bad request e a mensagem no lugar do OBJ) 
        public string Nome { get; set; }

        [JsonIgnore] // -> para evitar loop na hora que chama o Cinema que vai chamar Gerente que tem o cinema entra em loop (VAI SER IGNORADO na chamada de get all)
        public virtual List<Cinema> Cinemas { get; set; }   // -> relação muitos para 1 (gerente pode ter varios Cinemas)

    }
}
