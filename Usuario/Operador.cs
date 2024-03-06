using Obligatorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Usuario
{
    public class Operador:Usuario,IValidate
    {
        public DateTime FechaIngreso { get; set; }

        public Operador(String email, String password, TipoRol rol,  String nombre, String apellido, DateTime fechaIngreso):base(email, password, rol,  nombre, apellido)
        {
            FechaIngreso = fechaIngreso;
        }
        public override string GetNumeroDoc()
        {
            return "-";
        }

        public override TipoDocumento GetTipoDoc()
        {
            return TipoDocumento.OTROS;
        }
    }
}
