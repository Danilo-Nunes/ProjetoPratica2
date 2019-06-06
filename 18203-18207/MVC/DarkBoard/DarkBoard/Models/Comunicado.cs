using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DarkBoard.Models
{
    public class Comunicado
    {
        public int Id { get; set; }
        public int CodSala { get; set; }
        public string Texto { get; set; }
        public string Assunto { get; set; }
        public byte[] Arquivo { get; set; }
        public string TipoArquivo { get; set;}
        public string NomeArquivo { get;set; }
    }
}