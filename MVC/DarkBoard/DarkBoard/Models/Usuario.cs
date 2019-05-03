using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DarkBoard.Models
{
    public class Usuario
    {
        int codigo;
        string nome, usuario, senha, email;

        public Usuario(int codigo, string ra, string nome, string usuario, string senha, string email)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.usuario = usuario;
            this.senha = senha;
            this.email = email;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        [Required, StringLength(50)]
        public string Nome { get => nome; set => nome = value; }
        [Required, StringLength(30)]
        public string NomeUsuario { get => usuario; set => usuario = value; }
        [Required, StringLength(30)]
        public string Senha { get => senha; set => senha = value; }
        [Required, StringLength(40)]
        public string Email { get => email; set => email = value; }
    }
}
