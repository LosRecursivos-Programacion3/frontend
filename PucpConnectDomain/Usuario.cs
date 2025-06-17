using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PucpConnectDomain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Email { get; set; }
        public bool Visible { get; set; }

        public Usuario() { }

        public Usuario(int id, string nombre, string password, bool estado, DateTime fechaRegistro, string email)
        {
            Id = id;
            Nombre = nombre;
            Password = password;
            Estado = estado;
            FechaRegistro = fechaRegistro;
            Email = email;
        }
    }
}
