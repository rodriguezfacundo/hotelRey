using Obligatorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Actividad
{
    public class ActividadHostal:Actividad,IValidate
    {
        public String Responsable { get; set; }
        public Boolean EsAfuera { get; set; }
        public String Lugar { get; set; }

        public ActividadHostal(String nombre, String descripcion, DateTime fecha, int cantPersonas, int edadMinima, 
            Decimal costo, String responsable, Boolean esAfuera, String lugar):base(nombre, descripcion, fecha, cantPersonas, edadMinima, costo)
        {
            this.Responsable = responsable;
            this.EsAfuera = esAfuera;
            this.Lugar = lugar;
        }
        public ActividadHostal(String nombre, String descripcion, DateTime fecha, int cantPersonas, int edadMinima,
            String responsable, Boolean esAfuera, String lugar) : base(nombre, descripcion, fecha, cantPersonas, edadMinima)
        {
            this.Responsable = responsable;
            this.EsAfuera = esAfuera;
            this.Lugar = lugar;
        }

        public override string GetNameProveedor()
        {
            return "-";
        }
        public void Validate()
        {
            try
            {
                base.Validate();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (!ValidateResponsable())
            {
                throw new Exception("Debe tener un proveedor");
            }
        }

        public bool ValidateResponsable()
        {
            return IsStringVacio(this.Responsable);
        }

        public static Boolean IsStringVacio(String toCheck)
        {
            return toCheck.Length > 0;
        }

        public override decimal CalcularCosto(Usuario.Huesped huesped)
        {
            Decimal costoTotal = this.Costo;
            int descuentoPorcentaje = huesped.GetDescuentoByFidelizacion();
            if (descuentoPorcentaje > 0)
            {
                int descuentoTotal = (int)(descuentoPorcentaje / 100M * costoTotal);
                costoTotal = costoTotal - descuentoTotal;
            }
            return costoTotal;
        }

        public override string GetLugar()
        {
            return this.Lugar;
        }
    }
}
