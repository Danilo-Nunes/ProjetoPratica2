using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DarkBoard.Models
{
    public class Usuario
    {

        public int Id { get; set; }        
        public string Nome { get; set; }
        [Required, StringLength(30)]
        public string NomeUsu { get; set; }
        [Required, StringLength(30)]
        public string Senha { get; set; }
        [Required, StringLength(40)]
        public string Email { get; set; }
        public char Cargo { get; set; }
        public byte[] Img { get; set; }
        public string Descricao { get; set; }
    }
}
