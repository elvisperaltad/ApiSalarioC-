using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Salario.Models
{
    public class Empleado
    {
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Posicion { get; set; }
        public int Salario { get; set; }
        public List<HorasTrabajadas> HorasTrabajadas { get; set; }
    }
}