using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DarkBoard.Models
{
    public class ComunicadoAluno
    {
        public int Id { get; set; }
        public int CodAluno { get; set; }
        public int CodComunicado { get; set; }
        public string Visto { get; set; }
    }
}