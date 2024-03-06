using Obligatorio.Actividad;
using Obligatorio.Reserva;
using Obligatorio.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio
{
    public class Sistema
    {
        public List<Usuario.Usuario> Usuarios { get; set; } = new List<Usuario.Usuario>();
        private List<Actividad.Actividad> _actividades = new List<Actividad.Actividad>();
        public List<Reserva.Reserva> Reservas { get; set; } = new List<Reserva.Reserva>();
        private List<Proveedor.Proveedor> _proveedores = new List<Proveedor.Proveedor>();
        private static Sistema _instancia;

        public static Sistema Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Sistema();
                }
                return _instancia;
            }
        }
        public Sistema()
        {
            AltaHuesped("huesped1@gmail.com", "Pass123456789", "Juan", "Acosta", "4b", new DateTime(1990, 06, 09), "47895591", TipoDocumento.CI, 3);
            AltaHuesped("huesped2@gmail.com", "Soy1huesped", "Carlos", "Rodriguez", "2c", new DateTime(1963, 11, 27), "42296576", TipoDocumento.PASAPORTE, 2);
            AltaOperador("operador@operador", "Opera115", "Alejandro", "Perez", new DateTime(1985,03,28));
            AltaOperador("operador2@operador", "Soy1operador", "Fabiana", "Cantilo", new DateTime(1999, 10, 04));
            AltaActividadHostal("Cabalgata", "Cabalgata por el campo", DateTime.Today, 12, 4, 150, "Pablo", true, "San Gregorio");
            AltaActividadHostal("Picnic al aire libre", "Actividad al aire libre", DateTime.Today, 20, 18, 0, "Victor", true, "Lago");
            AltaActividadHostal("Viaje a Brasil", "Actividad en la playa", new DateTime(2023, 06, 30), 50, 5, 500, "Dionisio", true, "Río");
            AltaActividadHostal("Tour Colonia", "Tour por la ciudad de Colonia", new DateTime(2023, 06, 30), 20, 15, 150, "Tután", true, "Colonia del Sacramento");
            AltaActividadHostal("Kayaking", "Actividad en kayak", new DateTime(2023, 07, 01), 6, 18, 50, "Antony", true, "Rio Santa Lucia");
            AltaActividadHostal("Viaje por el dia a Bs as", "Un dia en Bs as", new DateTime(2023, 06, 29), 100, 10, 940, "Teresa", true, "Bs as");
            AltaActividadHostal("Paseo en bicicleta", "Actividad en bicicleta", new DateTime(2023, 06, 29), 10, 8, 1000, "Ramón", true, "Piriapolis");
            AltaActividadHostal("Paseo en monopatin", "Actividad en monopatin", new DateTime(2023, 07, 01), 10, 6, 999, "Paul", true, "Piriapolis");
            AltaActividadHostal("Noche de cine", "Las mejores peliculas", new DateTime(2023, 07, 01), 15, 12, 1460, "Pepe", true, "Cine del hostal");
            AltaActividadHostal("Titeres", "Funcion de titeres", new DateTime(2023, 07, 01), 12, 0, 20, "Damián", true, "Sala principal");
            AltaActividadHostal("Tour Barrios Montevideo", "Tour por barrios peligrosos", new DateTime(2023, 07, 02), 50, 10, 150, "Tután", true, "Montevideo");
            AltaActividadHostal("Paseo en Skate", "Tour por la ciudad de Colonia", new DateTime(2023, 06, 12), 20, 18, 150, "Tután", true, "Montevideo");
            AltaActividadHostal("Fútbol en la playa", "Una tarde de fútbol en la Playa Carrasco", new DateTime(2023, 06, 24), 22, 30, 150, "Tután", true, "Montevideo");
            AltaActividadHostal("Tour Minas", "Tour por la ciudad de Colonia", new DateTime(2023, 06, 25), 30, 15, 150, "Tután", true, "Colonia del Sacramento");
            AltaProveedor("DreamWorks S.R.L.", "23048549", "Suarez 3380 Apto 304", 10);
            AltaProveedor("Estela Umpierrez S.A.", "33459678", "Lima 2456", 7);
            AltaProveedor("TravelFun", "29152020", "Misiones 1140", 9);
            AltaProveedor("Rekreation S.A.", "29162019", "Bacacay 1211", 11);
            AltaProveedor("Alonso y Umpierrez", "24051920", "18 de Julio 1956 Apto 4", 10);
            AltaProveedor("Electric Blue", "26018945", "Cooper 678", 5);
            AltaProveedor("Lúdica S.A.", "26142967", "Dublin 560", 4);
            AltaProveedor("Gimenez S.R.L.", "29001010", "Andes 1190", 7);
            AltaProveedor("Norberto Molina", "22001189", "Paraguay 2100", 9);
            AltaProveedor("Peperoni", "22041120", "Agraciada 2512 Apto. 1", 8);
            AltaActividadTercerizada("Noche de juegos de mesa", "Juegos de mesa", new DateTime(2023, 06, 27), 15, 18, 100000, true, new DateTime(2023, 05, 19), GetProveedorByName("Peperoni"));
            AltaActividadTercerizada("Campeonato de ajedrez", "Ajedrez", new DateTime(2023, 06, 27), 10, 10, 3999, false, new DateTime(0001, 01, 01), GetProveedorByName("Gimenez S.R.L."));
            AltaActividadTercerizada("Campeonato de futbol", "Futbol", new DateTime(2023, 06, 27), 50, 18, 450, true, new DateTime(2023, 06, 28), GetProveedorByName("Gimenez S.R.L."));
            AltaActividadTercerizada("Tour a Soriano", "Viaje a minas", new DateTime(2023, 06, 28), 10, 18, 499, false, new DateTime(0001, 01, 01), GetProveedorByName("Gimenez S.R.L."));
            AltaActividadTercerizada("Paysandu por el dia", "un dia en Paysandu", new DateTime(2023, 06, 28), 20, 12, 3000, true, new DateTime(2023, 05, 12), GetProveedorByName("Estela Umpierrez S.A.")); 
            AltaActividadTercerizada("Tacuarembo por el dia", "Un dia en Tacuarembo", new DateTime(2023, 06, 28), 10, 10, 99, true, new DateTime(2023, 05, 19), GetProveedorByName("TravelFun"));
            AltaActividadTercerizada("Artigas por el dia", "Un dia en Artigas", new DateTime(2023, 06, 28), 15, 5, 189, true, new DateTime(2023, 05, 19), GetProveedorByName("DreamWorks S.R.L."));
            AltaActividadTercerizada("Walking tour Montevideo", "Caminando por Montevideo", new DateTime(2023, 06, 29), 18, 2, 675, true, new DateTime(2023, 07, 19), GetProveedorByName("Rekreation S.A."));
            AltaActividadTercerizada("bicicleta por la rambla", "Bicicleta por Montevideo", new DateTime(2023, 06, 29), 15, 8, 9001, true, new DateTime(2023, 05, 25), GetProveedorByName("Estela Umpierrez S.A."));
            AltaActividadTercerizada("Tour por el estadio", "Estadio Centenario", new DateTime(2023, 06, 29), 30, 5, 30000, true, new DateTime(2023, 12, 25), GetProveedorByName("Alonso y Umpierrez"));
            AltaActividadTercerizada("Paseo a caballo", "A caballo", new DateTime(2023, 06, 29), 10, 12, 321, true, new DateTime(2023, 11, 24), GetProveedorByName("Peperoni"));
            AltaActividadTercerizada("Un dia en el Chuy", "Chuy", new DateTime(2023, 06, 29), 20, 18, 123, true, new DateTime(2023, 04, 19), GetProveedorByName("Electric Blue"));
            AltaActividadTercerizada("Un dia en Punta del Este", "Punta del este", new DateTime(2023, 06, 29), 10, 18, 544, true, new DateTime(2023, 07, 19), GetProveedorByName("Gimenez S.R.L."));
            AltaActividadTercerizada("Un dia en San Jose", "San Jose", new DateTime(2023, 06, 29), 25, 5, 766, true, new DateTime(2023, 11, 19), GetProveedorByName("Lúdica S.A."));
            AltaActividadTercerizada("Un dia en Salto", "Paseo por Salto", new DateTime(2023, 06, 29), 25, 11, 384, true, new DateTime(2023, 06, 09), GetProveedorByName("Electric Blue"));
        }

        public List<Actividad.Actividad> GetListaActividades() { return this._actividades; }

        /* 
         * A partir de un mail devuelve un usuario
         */
        public Usuario.Usuario GetUsuario(String email)
        {
            Usuario.Usuario? usuarioToReturn = null;
            int i = 0;
            Boolean founded = false;
            while (i < Usuarios.Count && !founded)
            {
                if (Usuarios[i].Email.Equals(email))
                {
                    usuarioToReturn = Usuarios[i];
                    founded = true;
                }
                i++;
            }
            if (usuarioToReturn == null) {
                throw new Exception("No existe usuario con email " + email);
            }
            return usuarioToReturn;
        }
        /*
         * Devuelve una actividad a partir de un id
         */
        public Actividad.Actividad GetActividad(int idActividad)
        {
            Actividad.Actividad? actividadToReturn = null;
            int i = 0;
            Boolean founded = false;
            while (i < this._actividades.Count && !founded)
            {
                if (_actividades[i].Id.Equals(idActividad))
                {
                    actividadToReturn = _actividades[i];
                    founded = true;
                }
                i++;
            }
            if (actividadToReturn == null)
            {
                throw new Exception("No existe actividad con id " + idActividad);
            }
            return actividadToReturn;
        }

        /*
         * Realiza la agenda a partir de un email y un id de actividad
         * llama a validar la edad del huesped
         * llama a validar la cantidad de cupos disponibles en la actividad
         * llama a calcular el costo total
         */
        public Reserva.Reserva AgendarReserva(String email, int idActividad)
        {
            Usuario.Usuario usuarioToBook = GetUsuario(email);
            Actividad.Actividad actividadToBook = GetActividad(idActividad);
            if (usuarioToBook.Rol.Equals(TipoRol.HUESPED))
            {
                Huesped huespedToBook = (Huesped)usuarioToBook;
                if (!huespedToBook.IsEdadHuespedValida(actividadToBook.EdadMinima))
                {
                    throw new Exception("No cumples con la edad requerida");
                }
                int disponible = ReservasDisponiblesParaActividad(actividadToBook);
                if (disponible <= 0)
                {
                    throw new Exception("No hay cupos disponibles para esta actividad");
                }
                if (actividadToBook.Fecha.Date < DateTime.Today.Date)
                {
                    throw new Exception("No puedes agendarte a una actividad del pasado");
                }
                Decimal costoTotal = actividadToBook.CalcularCosto(huespedToBook);
                EstadoReserva estado = EstadoReserva.PENDIENTE;
                if (costoTotal == 0)
                {
                    estado = EstadoReserva.CONFIRMADO;
                }
                Reserva.Reserva reservaToAdd = new Reserva.Reserva(actividadToBook, huespedToBook, estado, costoTotal);
                if (IsReservaExistente(usuarioToBook, actividadToBook))
                {
                    throw new Exception("Ya tienes una reserva para esa actividad");
                }
                else
                {
                    AddReserva(reservaToAdd);
                    return reservaToAdd;
                }
            }
            else
            {
                throw new Exception("El usuario " + email + " no es un huesped");
            }
        }

        //chequea si un huesped tiene una reserva para una actividad
        public Boolean IsReservaExistente(Usuario.Usuario huesped, Actividad.Actividad actividad)
        {
            bool existe = false;
            int i = 0;
            while (!existe && i < this.Reservas.Count)
            {
                if (Reservas.Count > 0)
                {
                    if (Reservas[i].Huesped.Equals(huesped) && Reservas[i].Actividad.Equals(actividad))
                    {
                        existe = true;
                    }

                }
                i++;
            }
            return existe;
        }

        /*
         * Recibe una actividad y devuelve la cantidad de reservas que todavia pueden hacerse
         */
        public int ReservasDisponiblesParaActividad(Actividad.Actividad actividad)
        {
            int reservasHechas = 0;
            this.Reservas.ForEach(reservas =>
            {
                if (reservas.Actividad.Equals(actividad))
                {
                    reservasHechas++;
                }
            });
            int reservasDisponibles = actividad.CantMaxPersonas - reservasHechas;
            return reservasDisponibles;
        }
        
        /*
         * Recibe un usuario y devuelve si es operador
         */
        public void AddReserva(Reserva.Reserva reserva)
        {
            if(reserva != null)
            {
                this.Reservas.Add(reserva);
            }
        }

        /*
         * Devuelve las reservas que esten pendientes
         */
        public List<Reserva.Reserva> GetReservasPendientes()
        {
            List<Reserva.Reserva> reservasPendientes = new List<Reserva.Reserva> ();
            this.Reservas.ForEach(reserva =>
            {
                if(reserva.Estado.Equals(EstadoReserva.PENDIENTE))
                {
                    reservasPendientes.Add(reserva);
                }
            });
            if(reservasPendientes.Count <= 0)
            {
                throw new Exception("No hay reservas pendientes");
            }
            return reservasPendientes;
        }

        /*
         * recibe un email y una password y chequea primero que exista el usuario(en el metodo GetUsuario) para luego chequear
         * que la contrasena sea la correcta
         */
        public Usuario.Usuario LoginUsuario(String email, String password)
        {
            Usuario.Usuario userLogged = GetUsuario(email);
            if (!userLogged.Password.Equals(password))
            {
                throw new Exception("Contraseña incorrecta");
            }

            return userLogged;
        }

        /*
         * A partir un idReserva y un email cambia el estado de la reserva
         * chequea que el usuario no sea huesped
         * chequea que la reserva este pendiente
         */
        public Reserva.Reserva CambiarEstadoReserva(int idReserva, string email)
        {
            Usuario.Usuario usuario = GetUsuario(email);
            if(usuario.Rol.Equals(TipoRol.HUESPED))
            {
                throw new Exception("No tiene permisos para realizar esta acción");
            }
            List<Reserva.Reserva> reservasPendientes = GetReservasPendientes();
            Reserva.Reserva reservaToCheck = GetReserva(idReserva);
            if (!reservasPendientes.Contains(reservaToCheck))
            {
                throw new Exception("Esa reserva no está pendiente");
            }
            reservaToCheck.Estado = EstadoReserva.CONFIRMADO;
            return reservaToCheck;
        }

        /*
         * devuelve una reserva a partir de un id
         */
        public Reserva.Reserva GetReserva(int idReserva)
        {
            Reserva.Reserva? reservaToReturn = null;
            int i = 0;

            while (i < this.Reservas.Count && reservaToReturn == null)
            {
                if (this.Reservas[i].Id.Equals(idReserva))
                {
                    reservaToReturn = this.Reservas[i];
                }
                i++;
            }
            if( reservaToReturn == null )
            {
                throw new Exception("No existe reserva para ese id");
            }
            return reservaToReturn;
        }

        /*
         * a partir de fechas y costo devuelve una lista de actividades comprendidas en esas variables
         */
        public List<Actividad.Actividad> GetActividadesPorFechaYCosto(DateTime fechaDesde, DateTime fechaHasta, decimal costo)
        {
            List<Actividad.Actividad> actividadesToReturn = new List<Actividad.Actividad>();
            foreach (Actividad.Actividad actividad in _actividades)
            {
                if (!actividadesToReturn.Contains(actividad))
                {
                    if (actividad.Fecha > fechaDesde && actividad.Fecha < fechaHasta)
                    {
                        if (actividad.Costo > costo)
                        {
                            actividadesToReturn.Add(actividad);
                        }
                    }
                }

            }
            if(actividadesToReturn.Count <= 0)
            {
                throw new Exception("No se encuentran actividades desde " + fechaDesde + " hasta " + fechaHasta + " con costo mayor a " + costo);
            }
            actividadesToReturn.Sort();
            return actividadesToReturn;
        }

        /*
         * Agrega un usuario a la lista si no es nulo
         */
        public void AddUsuario(Usuario.Usuario usuario)
        {
            if(usuario != null)
            {
                Usuarios.Add(usuario);
            }
        }

        /*
         * Agrega una actividad a la lista si no es nula
         */
        public void AddActividad(Actividad.Actividad actividad)
        {
            if(actividad != null)
            {
                _actividades.Add(actividad);
            }
        }

        /*
         * a partir de un email y una pass crea un usuario, lo valida y llama para que lo agregue a la lista
         */

        public void AltaOperador(string email, string pass, String nombre, String apellido, DateTime fechaIngreso)
        {
            Operador operador = new Operador(email, pass, TipoRol.OPERADOR, nombre, apellido, fechaIngreso);
            try
            {
                operador.Validate();
                ValidateUsuarioRegistrado(email);
                AddUsuario(operador);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /*
         * Llama a chequear si un email ya se encuentra registrado
         */
        public void ValidateUsuarioRegistrado(String email)
        {
            if (IsUsuarioYaRegistrado(email))
            {
                throw new Exception("El usuario ya se encuentra registrado");
            }
        }

        /*
         * A partir de la informacion recibida crea un proveedor, lo valida y llama para que lo agreguen a la lista
         */
        public void AltaProveedor(String nombre, String direccion, String telefono, int descuento)
        {
            Proveedor.Proveedor newProveedor = new Proveedor.Proveedor(nombre, direccion, telefono, descuento);
            try
            {
                ValidateNombreProveedor(nombre);
                newProveedor.Validate();
                AddProveedor(newProveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
         * Agrega proveedor a la lista
         */
        private void AddProveedor(Proveedor.Proveedor proveedor)
        {
            if(proveedor != null)
            {
                _proveedores.Add(proveedor);
            }
        }


        /*
         * A partir de un email devuelve un booleano si se encuentra un usuario con ese mail en la lista
         */
        private bool IsUsuarioYaRegistrado(String email)
        {
            Boolean result = false;
            this.Usuarios.ForEach(usuario =>
            {
                if (usuario.Email.Equals(email))
                {
                    result = true;
                }
            });
            return result;
        }


        /*
         * Recibe datos de huesped, crea el huesped y lo valida
         * llama para que se agregue a la lista
         */
        public void AltaHuesped(string email, string password, string nombre, string apellido, string habitacion
    , DateTime fechaNac, string numeroDoc, TipoDocumento tipoDoc, int fidelizacion)
        {
            Huesped huesped = new Huesped(email, password, nombre, apellido, habitacion, fechaNac, numeroDoc, tipoDoc, fidelizacion, TipoRol.HUESPED);
            if (!IsUsuarioYaRegistrado(huesped.Email))
            {
                try
                {
                    huesped.Validate();
                    ValidateDocumentoHuesped(tipoDoc, numeroDoc);
                    AddUsuario(huesped);
                }
                catch
                {
                    throw;
                }
            }
            else
            {
                throw new Exception("Ese email ya se encuentra registrado");
            }
        }

        /*
         * recibe los datos de actividad tercerizada. Crea la actividad, la valida y llama para que la agreguen a la lista
         */
        public void AltaActividadTercerizada(String nombre, String descripcion, DateTime fecha, int cantPersonas,
            int edadMinima, Decimal costo, Boolean confirmada, DateTime fechaConfirmada, Proveedor.Proveedor proveedor)
        {
            try
            {
                if (confirmada == false)
                {
                    ActividadTercerizada actividad = new ActividadTercerizada(nombre, descripcion, fecha, cantPersonas, edadMinima, confirmada, proveedor);
                    actividad.Validate();
                    AddActividad(actividad);
                }
                else
                {
                    ActividadTercerizada actividad = new ActividadTercerizada(nombre, descripcion, fecha, cantPersonas, edadMinima, costo, confirmada, fechaConfirmada, proveedor);
                    actividad.Validate();
                    AddActividad(actividad);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /*
         * recibe los datos de actividad de hostal. Crea la actividad, la valida y llama para que la agreguen a la lista
         */
        public void AltaActividadHostal(String nombre, String descripcion, DateTime fecha, int cantPersonas, int edadMinima,
            Decimal costo, String responsable, Boolean esAfuera, String lugar)
        {
            ActividadHostal actividad = new ActividadHostal(nombre, descripcion, fecha, cantPersonas, edadMinima, costo, responsable, esAfuera, lugar);

            try
            {
                actividad.Validate();
                _actividades.Add(actividad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
         * Devuelve las actividades confirmadas
         */
        public List<Actividad.Actividad> GetListaActividadesConfirmadas()
        {
            List<Actividad.Actividad> listaActividades = GetListaActividades();
            List<Actividad.Actividad> listaActividadesConfirmadas = new List<Actividad.Actividad>();
            listaActividades.ForEach(actividad => {
                if (actividad is ActividadTercerizada)
                {
                    ActividadTercerizada actividadTercerizada = (ActividadTercerizada)actividad;
                    if (actividadTercerizada.Confirmada)
                    {
                        listaActividadesConfirmadas.Add(actividad);
                    }

                }
                else
                {
                    if (actividad.Fecha > DateTime.Now.AddDays(-1))
                    {
                        listaActividadesConfirmadas.Add(actividad);
                    }
                }
            });
            return listaActividadesConfirmadas;
        }


        /*
         * Devuelve lista de proveedores
         */
        public List<Proveedor.Proveedor> GetProveedores()
        {
            List<Proveedor.Proveedor> proveedores = new List<Proveedor.Proveedor>();
            this._proveedores.ForEach(proveedor => {
                proveedores.Add(proveedor);
            });
            if(proveedores.Count <= 0)
            {
                throw new Exception("No hay proovedores");
            }

            return proveedores;
        }

        /*
         * Devuelve un proveedor a partir de un nombre
         */
        public Proveedor.Proveedor GetProveedorByName(string nombre)
        {
            List<Proveedor.Proveedor> proveedores = GetProveedores();
            Proveedor.Proveedor? proveedorToReturn = null;
            proveedores.ForEach(proveedor =>
            {
                if (proveedor.Nombre.ToLower().Equals(nombre.ToLower()))
                {
                    proveedorToReturn = proveedor;
                }
            });

            if(proveedorToReturn == null)
            {
                throw new Exception("No existe proveedor con ese nombre");
            }
            return proveedorToReturn;
        }

        /*
         * Llama a validar el documento y tipo de documento del huesped
         */
        public void ValidateDocumentoHuesped(TipoDocumento tipo, string documento)
        {
            if (!IsValidDocumentoHuesped(tipo, documento))
            {
                throw new Exception("Ya existe un huesped con ese tipo de documento y ese documento");
            }
        }

        /*
        * Chequea que no exista un documento y tipo de documento iguales en otro huesped
        */
        public bool IsValidDocumentoHuesped(TipoDocumento tipo, string documento)
        {
            bool isValid = true;
            List<Huesped> huespedes = GetHuespedes();
            int i = 0;
            bool encontrado = false;

            while (i < huespedes.Count && !encontrado)
            {
                if (huespedes[i].ValidateTipoAndNumeroDoc(tipo, documento))
                {
                    encontrado = true;
                    isValid = false;
                }
                i++;
            }
            return isValid;
        }

        /*
         * Devuelve lista de huespedes
         */
        public List<Huesped> GetHuespedes()
        {
            List<Huesped> huespedesToReturn = new List<Huesped>();
            Usuarios.ForEach(usuario =>
            {
                if (usuario is Huesped)
                {
                    Huesped huesped = (Huesped)usuario;
                    huespedesToReturn.Add(huesped);
                }
            });
            return huespedesToReturn;
        }

        /*
         * Valida que el nombre del proveedor no se encuentre registrado
         */
        public bool IsValidNameProveedor(string nombre)
        {
            bool isValid = true;
            bool encontrado = false;
            int i = 0;
            while (i < _proveedores.Count && !encontrado)
            {
                if (_proveedores[i].Nombre.Equals(nombre))
                {
                    encontrado = true;
                    isValid = false;
                }
                i++;
            }
            return isValid;

        }

        /*
         * Devuelve la lista de proveedores ordenados
         */
        public List<Proveedor.Proveedor> GetProveedoresOrdenados()
        {
            _proveedores.Sort();
            return _proveedores;
        }


        /*
         * Llama a validar el nombre del proveedor
         */
        public void ValidateNombreProveedor(string nombre)
        {
            if (!IsValidNameProveedor(nombre))
            {
                new Exception("Nombre ya registrado");
            }
        }

        /*
         * a partir de un nombre de proveedor y un descuento setea ese valor como descuento de ese provedor
         */
        public void SetValorDescuentoParaProveedor(String nombre, String descuento)
        {
            Proveedor.Proveedor proveedor = GetProveedorByName(nombre);
            int descuentoNumber = proveedor.ValidateDescuento(descuento);
            proveedor.Descuento = descuentoNumber;
        }

        /*
         *Devuelve las actividades dada una fecha
         */
        public List<Actividad.Actividad> GetActividadesDadaUnaFecha(DateTime fecha)
        {
            List<Actividad.Actividad> actividadesToReturn = new List<Actividad.Actividad>();
            foreach (Actividad.Actividad actividad in _actividades)
            {
                if (!actividadesToReturn.Contains(actividad) && actividad.Fecha == fecha)
                {
                        actividadesToReturn.Add(actividad);
                    
                }

            }
            actividadesToReturn.Sort();
            return actividadesToReturn;
        }

        /*
         * Devuelve reservas dada una fecha
         */
        public List<Reserva.Reserva> GetReservasPorFecha(DateTime fecha)
        {

            List<Reserva.Reserva> reservasToReturn = new List<Reserva.Reserva>();
            foreach (Reserva.Reserva reserva in Reservas)
            {
                if (!reservasToReturn.Contains(reserva))
                {
                    if (reserva.Actividad.Fecha.Date.Equals(fecha.Date))
                    {
                        reservasToReturn.Add(reserva);
                    }
                }

            }
            reservasToReturn.Sort(new OrdenarReserva());
            return reservasToReturn;
        }
        /*
         * devuelve las reservas de un huesped dado un email
         */
        public List<Reserva.Reserva> GetReservasByHuesped(string email)
        {
            List<Reserva.Reserva> reservasToReturn = new List<Reserva.Reserva>();
            Usuario.Usuario usuario = GetUsuario(email);
            if (usuario != null && usuario.Rol.Equals(TipoRol.HUESPED))
            {
                foreach (Reserva.Reserva reserva in this.Reservas)
                {
                    if (!reservasToReturn.Contains(reserva) && reserva.Huesped.Equals(usuario)
                        && reserva.Actividad.Fecha.Date >= DateTime.Now.Date)
                    {
                        reservasToReturn.Add(reserva);

                    }

                }
            }
            else
            {
                throw new Exception("No eres un huesped");
            }
            reservasToReturn.Sort();
            return reservasToReturn;
        }

        /*
         * Devuelve un usuario dado un tipo documento y un documento
         */
        public Usuario.Usuario GetUsuarioByDocumento(String tipoDoc, String documento)
        {
            try
            {
                Usuario.Usuario? usuarioToReturn = null;
                int i = 0;
                Boolean founded = false;
                while (i < this.Usuarios.Count && !founded)
                {
                    if (Usuarios[i].GetNumeroDoc().Equals(documento) && Usuarios[i].GetTipoDoc().ToString().Equals(tipoDoc))
                    {
                        usuarioToReturn = Usuarios[i];
                        founded = true;
                    }
                    i++;
                }
                if (usuarioToReturn == null)
                {
                    throw new Exception("No existe usuario con esos datos");
                }
                return usuarioToReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
