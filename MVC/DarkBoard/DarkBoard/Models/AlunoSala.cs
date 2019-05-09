using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DarkBoard.Models
{
    public class AlunoSala
    {
       
        public int CodAluno { get; set; }
        public int CodSala{ get; set; }
        public int Media { get; set; }
        public int Faltas { get; set; }
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
    }
}