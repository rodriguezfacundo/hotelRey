using Obligatorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Usuario
{
    public class Huesped : Usuario,IValidate
    {

        public String Habitacion { get; set; }
        public DateTime Fechanac { get; set; }
        public int NivelFidelizacion { get; set; }
        public String NumeroDoc { get; set; }
        public TipoDocumento TipoDoc { get; set; }

        public Huesped(string email, string password, string nombre, string apellido, string habitacion
            , DateTime fechaNac, string numeroDoc, TipoDocumento tipoDoc, TipoRol rol) : base(email, password, rol, nombre, apellido)
        {
            this.Habitacion = habitacion;
            this.Fechanac = fechaNac;
            this.NumeroDoc = numeroDoc;
            this.TipoDoc = tipoDoc;
        }

        public Huesped(string email, string password, string nombre, string apellido, string habitacion
    , DateTime fechaNac, string numeroDoc, TipoDocumento tipoDoc, int fidelizacion, TipoRol rol) : base(email, password, rol, nombre, apellido)
        {

            this.Habitacion = habitacion;
            this.Fechanac = fechaNac;
            this.NumeroDoc = numeroDoc;
            this.TipoDoc = tipoDoc;
            this.NivelFidelizacion = fidelizacion;
        }

        public Boolean IsEdadHuespedValida(int edadMinima)
        {
            DateTime fechaHoy = DateTime.Now;
            int edadHuesped = fechaHoy.Year - this.Fechanac.Year;
            if (fechaHoy.Month < this.Fechanac.Month || (fechaHoy.Month == this.Fechanac.Month && fechaHoy.Day < this.Fechanac.Day))
            {
                edadHuesped--;
            }
            return edadHuesped >= edadMinima;
        }

        public void Validate()
        {
            try
            {
                base.Validate();

                if (!ValidateHabitacion())
                {
                    throw new Exception("La habitacion no puede estar vacia");
                }
                if (this.TipoDoc.Equals(TipoDocumento.CI))
                {
                    if (!ValidateCedula())
                    {
                        throw new Exception("La cedula no cumple con el formato uruguayo");
                    }
                }

            }
            catch
            {
                throw;
            }

        }

        private bool ValidateCedula()
        {
            Boolean isValid = false;
            if (NumeroDoc.Length == 8)
            {
                int codigo = 0;
                int[] algoritmo = new int[7] { 2, 9, 8, 7, 6, 3, 4 };

                for (int i = 0; i < 7; i++)
                {
                    int caracter = int.Parse(NumeroDoc.Substring(i, 1));
                    codigo += caracter * algoritmo[i];
                }
                int resto = codigo % 10;
                int verificador = 0;
                if (resto > 0)
                {
                    verificador = 10 - resto;
                    if (int.Parse(NumeroDoc.Substring(NumeroDoc.Length - 1)) == verificador){
                        isValid = true;
                    }
                }
            }
            return isValid;
        }



        public bool ValidateHabitacion()
        {
            return IsStringVacio(this.Habitacion);
        }

        public bool ValidateTipoAndNumeroDoc(TipoDocumento tipo, String documento)
        {
            return this.TipoDoc.Equals(tipo) && this.NumeroDoc.Equals(documento);
        }


        public int GetDescuentoByFidelizacion()
        {
            int descuento = 0;
            if (this.NivelFidelizacion == 2)
            {
                descuento = 10;
            }
            else if (this.NivelFidelizacion == 3)
            {
                descuento = 15;
            }
            else if (this.NivelFidelizacion == 4)
            {
                descuento = 20;
            }

            return descuento;
        }

        public override string GetNumeroDoc()
        {
            return this.NumeroDoc;
        }

        public override TipoDocumento GetTipoDoc()
        {
            return this.TipoDoc;
        }
    }
}
