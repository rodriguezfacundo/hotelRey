using Obligatorio.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Proveedor
{
    public class Proveedor:IValidate,IComparable<Proveedor>
    {
        public String Nombre { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public int Descuento { get; set; }

        public Proveedor(String nombre, String direccion, String telefono)
        {
            this.Nombre = nombre;
            this.Telefono = telefono;
        }
        public Proveedor(String nombre, String direccion, String telefono, int descuento)
        {
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Descuento = descuento;
        }
        public void SetDescuento(String descuento) {
            this.Descuento = ValidateDescuento(descuento);
        }

        public int ValidateDescuento(string descuento)
        {
            if(descuento == null)
            {
                throw new Exception("Descuento no puede estar vacio");
            }
            if(!int.TryParse(descuento, out int descuentoNumber))
            {
                throw new Exception("Formato de descuento incorrecto");
            }
            if(descuentoNumber > 100 || descuentoNumber < 0)
            {
                throw new Exception("El % descuento debe estar comprendido entre el 0 y el 100");
            }
            return descuentoNumber;

        }

        public void Validate()
        {

            if (!ValidateNombre())
            {
                throw new Exception("Debes ingresar un nombre");
            }
            if (!ValidateDireccion())
            {
                throw new Exception("Debes ingresar una dirección");
            }
            if (!ValidateTelefono())
            {
                throw new Exception("Debes ingresar un telefono");
            }
        }

        public bool ValidateDireccion()
        {
            return IsStringVacio(this.Direccion);
        }

        public bool ValidateTelefono()
        {
            return IsStringVacio(this.Telefono);
        }

        public bool ValidateNombre()
        {
            return IsStringVacio(this.Nombre);
        }

        public int CompareTo(Proveedor proveedor)
        {
            return this.Nombre.CompareTo(proveedor.Nombre);
        }

        public override string ToString()
        {
            String actividadToString =
                $"Nombre: {this.Nombre} \n" +
                $"Telefono: {this.Telefono} \n" +
                $"Dirección: {this.Direccion} \n" +
                $"Descuento: {this.Descuento} \n" +
                $"----------------------------------\n";
            return actividadToString;
        }

        public static Boolean IsStringVacio(String toCheck)
        {
            return toCheck.Length > 0;
        }
    }
}
