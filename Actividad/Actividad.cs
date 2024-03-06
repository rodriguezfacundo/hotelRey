using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Actividad
{
    public abstract class Actividad:IComparable<Actividad>
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int CantMaxPersonas { get; set; }
        public int EdadMinima { get; set; }
        public Decimal Costo { get; set; }
        static int s_ultimoId = 1;

        public Actividad(string nombre, string descripcion, DateTime fecha, int cantMaxPersonas, int edadMinima, decimal costo)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Fecha = fecha;
            this.CantMaxPersonas = cantMaxPersonas;
            this.EdadMinima = edadMinima;
            this.Costo = costo;
            this.Id = s_ultimoId++;
        }
        public Actividad(string nombre, string descripcion, DateTime fecha, int cantMaxPersonas, int edadMinima)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Fecha = fecha;
            this.CantMaxPersonas = cantMaxPersonas;
            this.EdadMinima = edadMinima;
            this.Costo = 0;
            this.Id = s_ultimoId++;
        }

        public abstract Decimal CalcularCosto(Usuario.Huesped huesped);

        public abstract String GetNameProveedor();

        public abstract String GetLugar();

        public override string ToString()
        {
            String actividadToString =
            $"Nro: {this.Id} \n" +
            $"Nombre: {this.Nombre} \n" +
            $"Descripción: {this.Descripcion} \n" +
            $"Fecha: {this.Fecha.ToShortDateString()} \n" +
            $"Cantidad Maxima de Personas: {this.CantMaxPersonas} \n" +
            $"Costo: {(this.Nombre.Equals(0) ? "Actividad gratuita" : this.Nombre)} \n" +
            $"Edad Minima: {this.EdadMinima} \n" +
            "----------------------------------- \n";
            return actividadToString;
        }

        public void Validate()
        {
            if (!ValidateNombreYDescripcion())
            {
                throw new Exception("Debes asignarle un nombre y una descrión");
            }
            if (!ValidateLargoNombre())
            {
                throw new Exception("El nombre de la actividad no puede superar los 25 caracteres");
            }

        }

        public bool ValidateNombreYDescripcion()
        {
            return IsStringVacio(this.Nombre) && IsStringVacio(this.Descripcion);
        }

        public bool ValidateLargoNombre()
        {
            bool isValid = false;
            if (this.Nombre.Length <= 25)
            {
                isValid = true;
            }
            return isValid;
        }

        public int CompareTo(Actividad actividad)
        {
            return this.Costo.CompareTo(actividad.Costo) * -1;
        }

        public static Boolean IsStringVacio(String toCheck)
        {
            return toCheck.Length > 0;
        }
    }
}
