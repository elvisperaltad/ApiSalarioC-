using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Salario.Models
{
    public class Response
    {
        public string Cedula { get; set; }
        public string nombre { get; set; }
        public string posicion { get; set; }
        public double ThorasTrabajadas { get; set; }
        public double SSemanal { get; set; }
        public double SHorasExtra { get; set; }
        public double STotalRecibido { get; set; }

           
           
    }
}