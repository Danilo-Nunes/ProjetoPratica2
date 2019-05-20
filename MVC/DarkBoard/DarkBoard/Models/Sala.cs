using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DarkBoard.Models
{
    public class Sala
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CodProfessor { get; set; }
        public int QtdAlunos { get; set; }
        public byte[] Img { get; set; }
    }
}