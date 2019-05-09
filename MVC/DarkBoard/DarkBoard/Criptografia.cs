using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DarkBoard
{
    public class Criptografia
    {
        public static string Criptografar(string texto)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(texto);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Descriptografar(string texto)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(texto);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}