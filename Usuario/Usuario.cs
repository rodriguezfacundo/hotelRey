using Obligatorio.Interface;

namespace Obligatorio.Usuario
{
    public abstract class Usuario:IValidate
    {
        public String Email { get; set; }
        public String Password { get; set; }
        public TipoRol Rol { get; set; }

        public String Nombre { get; set; }

        public String Apellido { get; set; }


        public Usuario(string email, string password, TipoRol rol, string nombre, string apellido)
        {
            this.Email = email;
            this.Password = password;
            Rol = rol;
            Nombre = nombre;
            Apellido = apellido;
        }
        public void Validate()
        {
            if (!ValidateArrobaEmail())
            {
                throw new Exception("Correo inválido");
            }
            if (!ValidatePassword())
            {
                throw new Exception("Contraseña inválida");
            }
            if (!ValidateNombre())
            {
                throw new Exception("El nombre no puede estar vacio");
            }
            if (!ValidateApellido())
            {
                throw new Exception("El apellido no puede estar vacio");
            }
        }


        public bool ValidateNombre()
        {
            return IsStringVacio(this.Nombre);
        }

        public bool ValidateApellido()
        {
            return IsStringVacio(this.Apellido);
        }
        public bool ValidateArrobaEmail()
        {
            bool isValid = false;
            char arroba = '@';
            if (this.Email.IndexOf(arroba) > 0)
            {
                int valor = this.Email.Length;
                if (!this.Email[0].Equals(arroba) && !this.Email.Trim()[valor -1].Equals(arroba))
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        public bool ValidatePassword()
        {
            bool isValid = false;
            if (this.Password.Length >= 8)
            {
                isValid = true;
            }
            return isValid;
        }


        public static Boolean IsStringVacio(String toCheck)
        {
            return toCheck.Length > 0;
        }

        public abstract TipoDocumento GetTipoDoc();
        public abstract String GetNumeroDoc();
    }
}