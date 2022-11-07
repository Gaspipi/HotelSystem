using System.Data.SqlClient;

namespace HotelSystem
{
    /// <summary>
    /// Summary description for Hotel
    /// </summary>
    public class Hotel
    {
        private static List<Cliente> coleccionClientes = new();
        private static List<Habitacion> coleccionHabitaciones = new();
        //private List<Servicio> coleccionServicios = new();
        private static List<Reserva> coleccionReservas = new();
        public static void Inicio()
        {
            ///Aqui se inicializan todas las variables de instancia.
            Individual.CargaPrecio();
            Doble.CargaPrecio();
            Ejecutiva.CargaPrecio();
            Suite.CargaPrecio();
        }
        public void Menu()
        {
            int op;
            bool val;
            do
            {
                do
                {
                    Console.WriteLine("Ingrese una opcion:\n1-Clientes\n2-Habitaciones\n3-Servicios\n4-Reservas\n0-Salir\n");
                    val = int.TryParse(Console.ReadLine(), out op);
                } while (!val);
                switch (op)
                {
                    case 1:
                        MenuClientes();
                        break;
                    case 2:
                        MenuHabitaciones();
                        break;
                    case 3:
                        MenuServicios();
                        break;
                    case 4:
                        MenuReservas();
                        break;
                    default:
                        break;
                }
            } while (op != 0);
            return;
        }
        public void MenuClientes()
        {
            Cliente objCliente;
            int op;
            bool val;
            do
            {
                do
                {
                    Console.WriteLine("\nMENU CLIENTES: Ingrese una opcion.\n1- Carga clientes\n2- Listado de clientes\n3- Buscar cliente\n0- Salir\n");
                    val = int.TryParse(Console.ReadLine(), out op);
                } while (!val);
                switch (op)
                {
                    case 1:
                        bool resp;
                        do
                        {
                            CreaCliente();
                            Console.WriteLine("Desea crear otro cliente? S/n\n");
                            resp = ValidarBool();
                        } while (resp);
                        break;
                    case 2:
                        if (coleccionClientes.Count == 0) ///coleccion clientes vacia
                        {
                            Console.WriteLine("NO HAY CLIENTES CARGADOS!\n");
                            Console.WriteLine("Desea cargar un cliente nuevo? S/n\n");
                            bool respAlt = ValidarBool();
                            if (respAlt)
                            {
                                CreaCliente();
                            }

                        }
                        else
                        {
                            ListarClientes();
                        }
                        break;
                    case 3:
                        objCliente = BuscarCliente();
                        objCliente.MostrarCliente();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Ingrese una opcion valida\n");
                        break;
                }
            } while (op != 0);
        }
        public static void MenuHabitaciones()
        {
            int op;
            Habitacion objHabitacion;
            do
            {
                Console.WriteLine("MENU CLIENTES: Ingrese una opcion.\n1- Carga habitacion\n2- Listado de habitaciones\n3- Buscar habitacion\n0- Salir\n");
                op = ValidarInt(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        bool resp;
                        do
                        {
                            CreaHabitacion();
                            Console.WriteLine("Desea crear otra habitacion? S/n\n");
                            resp = ValidarBool();
                        } while (resp);
                        break;
                    case 2:
                        if (coleccionHabitaciones.Count == 0) //coleccion clientes vacia
                        {
                            Console.WriteLine("NO HAY CLIENTES CARGADOS!\n");
                            Console.WriteLine("Desea cargar un cliente nuevo? S/n\n");
                            bool respAlt = ValidarBool();
                            if (respAlt)
                            {
                                CreaHabitacion();
                            }
                        }
                        else
                        {
                            ListarHabitaciones();
                        }
                        break;
                    case 3:
                        objHabitacion = BuscarHabitacion();
                        objHabitacion.MostrarHabitacion();
                        break;
                    case 0:
                        break;
                }
            } while (op != 0);
        }
        public void MenuServicios()
        {
            int op;
            do
            {
                Console.WriteLine("MENU CLIENTES: Ingrese una opcion.\n1- Carga servicio\n2- Listado de servicios\n3- Buscar servicio\n0- Salir\n");
                op = ValidarInt(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        bool resp;
                        do
                        {
                            CreaCliente();
                            Console.WriteLine("Desea crear otro cliente? S/n\n");
                            resp = ValidarBool();
                        } while (resp);
                        break;
                    case 2:
                        if (coleccionClientes == null) ///coleccion clientes vacia
                        {
                            Console.WriteLine("NO HAY CLIENTES CARGADOS!\n");
                            Console.WriteLine("Desea cargar un cliente nuevo? S/n\n");
                            bool respAlt = ValidarBool();
                            if (respAlt)
                            {
                                CreaCliente();
                            }
                            else
                            {
                                ListarClientes();
                            }
                        }
                        break;
                    case 3:
                        break;
                    case 0:
                        break;
                }
            } while (op != 0);
        }
        public void MenuReservas()
        {
            int op;
            do
            {
                Console.WriteLine("MENU CLIENTES: Ingrese una opcion.\n1- Carga reserva\n2- Listado de reservas\n3- Buscar reserva\n0- Salir\n");
                op = ValidarInt(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        bool resp;
                        do
                        {
                            CreaReserva();
                            Console.WriteLine("Desea crear otro reserva? S/n\n");
                            resp = ValidarBool();
                        } while (resp);
                        break;
                    case 2:
                        if (coleccionClientes == null) ///coleccion clientes vacia
                        {
                            Console.WriteLine("NO HAY CLIENTES CARGADOS!\n");
                            Console.WriteLine("Desea cargar un cliente nuevo? S/n\n");
                            bool respAlt = ValidarBool();
                            if (respAlt)
                            {
                                CreaCliente();
                            }
                            else
                            {
                                ListarClientes();
                            }
                        }
                        break;
                    case 3:
                        break;
                    case 0:
                        break;
                }
            } while (op != 0);
        }
        public static void CreaCliente()
        {
            Console.WriteLine("Ingrese el numero de DNI");
            int dni = ValidarInt(Console.ReadLine());
            Cliente cliente = new();
            cliente.CargaDatos(dni);
            cliente.MostrarCliente();
            coleccionClientes.Add(cliente);
        }
        public void ListarClientes()
        {
            foreach (Cliente cl in coleccionClientes)
            {
                cl.MostrarCliente();
            }
        }
        public static Cliente BuscarCliente()
        {
            bool resp;
            Cliente cl = null;
            do
            {
                Console.WriteLine("Ingrese numero de DNI");
                int dni = ValidarInt(Console.ReadLine());

                foreach (Cliente client in coleccionClientes)
                {
                    Console.WriteLine("BUSCANDO");
                    if (client.dni == dni)
                    {
                        cl = client;
                        Console.WriteLine("ENCONTRADO");
                        resp = false;
                        break;
                    }

                }
                if (cl == null)
                {
                    Console.WriteLine("No se encontro un cliente con el DNI ingresado.");
                    Console.WriteLine("Desea crear uno nuevo?");
                    resp = ValidarBool();
                }
                else
                {
                    resp = false;
                    cl.MostrarCliente();
                }
            } while (resp);
            return cl;
        }
        public static string ValidarStr(string? a)
        {
            bool esNull;
            do
            {
                esNull = (String.IsNullOrEmpty(a) || String.IsNullOrWhiteSpace(a));
                if (esNull)
                {
                    Console.WriteLine("El valor no puede ser un espacio en blanco ni vacio");
                    a = Console.ReadLine();
                }
            } while (esNull);
            return a;
        }
        public static int ValidarInt(string? a)
        {
            int ret;
            bool esEntero;
            do
            {
                esEntero = Int32.TryParse(a, out ret);
                if (esEntero)
                {
                }
                else
                {
                    Console.WriteLine("Ingrese un valor permitido");
                    a = Console.ReadLine();
                }
            } while (!esEntero);
            return ret;
        }
        public static long ValidarLong(string? a)
        {
            long ret;
            bool esEntero;
            do
            {
                esEntero = Int64.TryParse(a, out ret);
                if (esEntero)
                {
                }
                else
                {
                    Console.WriteLine("Ingrese un valor permitido");
                    a = Console.ReadLine();
                }
            } while (!esEntero);
            return ret;
        }
        public static bool ValidarBool()
        {
            ConsoleKeyInfo a;
            bool esBoolean = false;
            do
            {
                a = Console.ReadKey();
                Console.WriteLine("");
                if (a.Key == ConsoleKey.S)
                {
                    esBoolean = true;
                    break;
                }
                else if (a.Key == ConsoleKey.N)
                {
                    esBoolean = false;
                    break;
                }
            } while (true);
            return esBoolean;
        }
        public static void CreaHabitacion()
        {
            Habitacion hb;
            int op;
            Console.WriteLine("INGRESE UNA OPCION: \n1- Individual \n2-Doble \n3- Ejecutiva \n4- Suite\n");
            do
            {
                op = ValidarInt(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        hb = new Individual();
                        hb.CargaDatos();
                        coleccionHabitaciones.Add(hb);
                        break;
                    case 2:
                        hb = new Doble();
                        hb.CargaDatos();
                        coleccionHabitaciones.Add(hb);
                        break;
                    case 3:
                        hb = new Ejecutiva();
                        hb.CargaDatos();
                        coleccionHabitaciones.Add(hb);
                        break;
                    case 4:
                        hb = new Suite();
                        hb.CargaDatos();
                        coleccionHabitaciones.Add(hb);
                        break;
                }
            } while (op < 1 || op > 4);
        }
        public static void ListarHabitaciones()
        {
            foreach (Habitacion hb in coleccionHabitaciones)
            {
                hb.MostrarHabitacion();
            }
        }
        public static Habitacion BuscarHabitacion()
        {
            int nroHb;
            Habitacion aux = null;
            bool resp;
            do
            {
                Console.WriteLine("Ingrese el numero de habitacion");
                nroHb = ValidarInt(Console.ReadLine());
                foreach (Habitacion hb in coleccionHabitaciones)
                {
                    if (nroHb == hb.nroHabitacion)
                    {
                        aux = hb;
                        resp = false;
                        break;
                    }
                }
                if (aux == null)
                {

                    Console.WriteLine("No hay habitacion cargada con ese numero, debe ingresar el numero correcto.");
                    Console.WriteLine("Desea volver a intentar? S/n");
                    resp = ValidarBool();
                }
                else { resp = false; }
            } while (resp);
            return aux;
        }
        public static void CreaReserva()
        {
            bool resp;
            bool respBsh;
            Reserva re;
            Habitacion objHabitacion;
            Cliente objCliente;
            do
            {
                do
                {
                    objHabitacion = BuscarHabitacion();
                    if (objHabitacion.DevEstado() == "Ocupada")
                    {
                        Console.WriteLine("La habitacion no esta disponible.");
                        Console.WriteLine("Desea buscar otra?");
                        respBsh = ValidarBool();
                    }
                    else { respBsh = false; }
                } while (respBsh);
                if (objHabitacion.DevEstado() == "Ocupada")
                {
                    Console.WriteLine("La reserva no se pudo completar, intente nuevamente si lo desea.");
                    resp = false;
                }
                else
                {
                    objCliente = BuscarCliente();
                    re = new();
                    re.CargaReserva(objHabitacion, objCliente);
                    coleccionReservas.Add(re);
                    objHabitacion.ActEstado();
                    Console.WriteLine("La reserva se completo correctamente.");
                    resp = false;
                }
            } while (resp);
        }
    }
}