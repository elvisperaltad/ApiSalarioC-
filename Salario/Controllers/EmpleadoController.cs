using Salario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Web.Http;

namespace Salario.Controllers
{
    [Route("api/Empleados")]
    public class EmpleadoController : ApiController
    {
        [HttpPost]
        public object PostEmpleados(List<Empleado> empleados)
        {
            List<Response> response = new List<Response>();

            foreach (var empleado in empleados)
            {
                Response rs = new Response();
                rs.Cedula = empleado.Cedula;
                rs.nombre = empleado.Nombre;
                rs.posicion = empleado.Posicion;
                double hr = 0;
                double salario = 0;
                double salarioHorasExtra = 0;


                //Se realiza tomando el salario dividido en 23.83(días del mes), y dividido entre 8(Horas).Así obtenemos SalarioXHora.
                double SalarioHora = (empleado.Salario / 23.83) / 8;
                double ss = 0;


                foreach (var hora in empleado.HorasTrabajadas)
                {
                    DateTime h1 = hora.HoraEntrada;
                    DateTime h2 = hora.HoraSalida;
                    hr += h2.Subtract(h1).TotalHours;

                    if(hr > 44 && hr < 69)
                    {
                        double horasExc = hr - 44;
                        salarioHorasExtra = SalarioHora * 1.35 * horasExc;
                        salario = 44 * SalarioHora;
                    }
                    else if(hr > 69)
                    {
                        double horasExc = 69 - 44;
                        salarioHorasExtra = SalarioHora * 1.35 * horasExc;
                        salario = 44 * SalarioHora;
                    }
                    else
                    {
                        salario = hr * SalarioHora;
                    }
                }
                rs.ThorasTrabajadas = hr;
                rs.SHorasExtra = Math.Round(salarioHorasExtra,2);
                rs.SSemanal = Math.Round(salario, 2);
                rs.STotalRecibido = Math.Round(salario + salarioHorasExtra);
                response.Add(rs);
            }
            return response;
        }
    }
}
