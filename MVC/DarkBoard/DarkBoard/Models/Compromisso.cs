using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DarkBoard.Models
{
    public class Compromisso
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public DateTime DataComp { get; set; }
        public int CodUsuario { get; set; }
    }
}