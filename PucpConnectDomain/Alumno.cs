using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PucpConnectDomain
{
    public class Alumno : Usuario
    {
        public int Edad { get; set; }
        public string Carrera { get; set; }
        public string FotoPerfil { get; set; }
        public string Ubicacion { get; set; }
        public string Biografia { get; set; }

        public Alumno() : base() { }

        public Alumno(int id, string nombre, string password, bool estado, DateTime fechaRegistro, string email,
                      int edad, string carrera, string fotoPerfil, string ubicacion, string biografia)
            : base(id, nombre, password, estado, fechaRegistro, email)
        {
            Edad = edad;
            Carrera = carrera;
            FotoPerfil = fotoPerfil;
            Ubicacion = ubicacion;
            Biografia = biografia;
        }
    }
}
