using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DarkBoard.Models
{
    public class Resultado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public byte[] Img { get; set; }
    }
}