using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DarkBoard.Models
{
    public class Atividade
    {
        public int Id { get; set; }
        public int CodSala { get; set; }
        public DateTime DataAtividade { get; set; }
    }
}