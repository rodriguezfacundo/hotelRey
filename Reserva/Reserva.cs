using Obligatorio.Actividad;
using Obligatorio.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Reserva
{
    public class Reserva:IComparable<Reserva>
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Actividad.Actividad Actividad { get; set; }
        public Huesped Huesped { get; set; }
        public EstadoReserva Estado { get; set; }
        static int s_ultimoId = 1;
        public Decimal Costo { get; set; }

        public Reserva(Actividad.Actividad actividad, Huesped huesped, EstadoReserva estado, Decimal costo)
        {
            this.Id = s_ultimoId++;
            this.Fecha = DateTime.Now;
            this.Actividad = actividad;
            this.Huesped = huesped;
            this.Estado = estado;
            this.Costo = costo;
        }

        public override string ToString()
        {
            String reservaToString = String.Empty;
            if(this.Actividad is ActividadHostal)
            {
                ActividadHostal actividadHostal = (ActividadHostal)this.Actividad;
                reservaToString =
                $"Reserva a nombre de: {this.Huesped.Nombre} {this.Huesped.Apellido} \n" +
                $"Actividad: {actividadHostal.Nombre} \n" +
                $"Fecha: {actividadHostal.Fecha.ToShortDateString()} \n" +
                $"Lugar: {actividadHostal.Lugar} \n" +
                $"Costo: {(this.Actividad.Costo.Equals(0) ? "Actividad Gratuita" : "$" + this.Costo)}\n" +
                $"Estado: {this.Estado}";
            }
            else if (this.Actividad is ActividadTercerizada)
            {
                ActividadTercerizada actividadTercerizada = (ActividadTercerizada)this.Actividad;
                if (actividadTercerizada.Confirmada)
                {
                    reservaToString =
                    $"Reserva a nombre de: {this.Huesped.Nombre} {this.Huesped.Apellido} \n" +
                    $"Actividad: {actividadTercerizada.Nombre} \n" +
                    $"Fecha: {actividadTercerizada.Fecha.ToShortDateString()} \n" +
                    $"Costo: {(this.Actividad.Costo.Equals(0) ? "Actividad Gratuita" : "$" + this.Costo)}\n" +
                    $"Proveedor: {actividadTercerizada.Proveedor.Nombre} \n" +
                    $"Estado {this.Estado}";
                }
            }
            return reservaToString;
        }
        public int CompareTo(Reserva reserva)
        {
            return this.Actividad.Fecha.CompareTo(reserva.Actividad.Fecha);
        }

        public string MostrarCosto()
        {
            if (this.Costo == 0)
            {
                return ("Actividad Gratuita");
            }
            else
            {
                return ($"${this.Costo}");
            }
        }
    }
}
