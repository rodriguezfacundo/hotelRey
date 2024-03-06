using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Reserva
{
    internal class OrdenarReserva: IComparer<Reserva>
    {
        public int Compare(Reserva? x, Reserva y)
        {
            int reservaOrdenada = x.Actividad.Fecha.CompareTo(y.Actividad.Fecha);
            if (reservaOrdenada == 0)
            {
                reservaOrdenada = x.Actividad.Nombre.CompareTo(y.Actividad.Nombre);
            }
            return reservaOrdenada;
        }
    }
}
