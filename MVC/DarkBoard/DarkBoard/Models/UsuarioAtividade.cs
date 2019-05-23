using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DarkBoard.Models
{
    public class UsuarioAtividade
    {
        public int Id { get; set; }
        public int CodUsuario { get; set; }
        public int CodAtividade { get; set; }
        public double Nota { get; set; }
        public int Peso { get; set; }
        public string Concluida { get; set; }
        public byte[] Arquivo { get; set; }

    }
}