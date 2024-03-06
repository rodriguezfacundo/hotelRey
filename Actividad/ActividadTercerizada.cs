using Obligatorio.Proveedor;
using Obligatorio.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Actividad
{
    public class ActividadTercerizada:Actividad
    {
        public Boolean Confirmada { get; set; }
        public DateTime FechaConfirmada { get; set; }
        public Proveedor.Proveedor Proveedor { get; set; }

        public ActividadTercerizada(String nombre, String descripcion, DateTime fecha, int cantPersonas,
            int edadMinima, Decimal costo, Boolean confirmada, DateTime fechaConfirmada, Proveedor.Proveedor proveedor):base(nombre, descripcion,
                fecha, cantPersonas, edadMinima, costo)
        {
            this.Confirmada = confirmada;
            this.FechaConfirmada = fechaConfirmada;
            this.Proveedor = proveedor;
        }
        public ActividadTercerizada(String nombre, String descripcion, DateTime fecha, int cantPersonas,
             int edadMinima, Boolean confirmada, DateTime fechaConfirmada, Proveedor.Proveedor proveedor) : base(nombre, descripcion,
        fecha, cantPersonas, edadMinima)
        {
            this.Confirmada = confirmada;
            this.FechaConfirmada = fechaConfirmada;
            this.Proveedor = proveedor;
        }
        public ActividadTercerizada(String nombre, String descripcion, DateTime fecha, int cantPersonas,
             int edadMinima, Boolean confirmada, Proveedor.Proveedor proveedor) : base(nombre, descripcion,
        fecha, cantPersonas, edadMinima)
        {
            this.Confirmada = confirmada;
            this.Proveedor = proveedor;
        }

        public override string GetNameProveedor()
        {
            return this.Proveedor.Nombre;
        }

        public override decimal CalcularCosto(Huesped huesped)
        {
            Decimal costoTotal = this.Costo;
            if (!this.Confirmada)
            {
                throw new Exception("La actividad " + this.Nombre + " no esta confirmada");
            }
            if (this.Proveedor.Descuento > 0)
            {
                int descuentoPorcentajeProveedor = this.Proveedor.Descuento;
                int descuentoTotalProveedor = (int)(descuentoPorcentajeProveedor / 100M * costoTotal);
                costoTotal = costoTotal - descuentoTotalProveedor;
            }
            return costoTotal;
        }

        public override string GetLugar()
        {
            return "-";
        }

    }
}
