﻿using System.Collections;

namespace HotelSystem
{
    /// <summary>
    /// Summary description for Hotel
    /// </summary>
    public class Hotel
    {
        private SortedList coleccionClientes = new();
        private SortedList coleccionHabitaciones = new();
        private SortedList coleccionServicios = new();
        private SortedList coleccionReservas = new();
        public void Inicio()
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
        public void MenuHabitaciones()
        {
            int op;
            bool val;
            do
            {
                do
                {
                    Console.WriteLine("MENU CLIENTES: Ingrese una opcion.\n1- Carga habitacion\n2- Listado de habitaciones\n3- Buscar habitacion\n0- Salir\n");
                    val = int.TryParse(Console.ReadLine(), out op);
                } while (!val);
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
                        if (coleccionHabitaciones == null) ///coleccion clientes vacia
                        {
                            Console.WriteLine("NO HAY CLIENTES CARGADOS!\n");
                            Console.WriteLine("Desea cargar un cliente nuevo? S/n\n");
                            bool respAlt = ValidarBool();
                            if (respAlt)
                            {
                                CreaHabitacion();
                            }
                            else
                            {
                                ListarHabitaciones();
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
        public void MenuServicios()
        {
            int op;
            bool val;
            do
            {
                do
                {
                    Console.WriteLine("MENU CLIENTES: Ingrese una opcion.\n1- Carga servicio\n2- Listado de servicios\n3- Buscar servicio\n0- Salir\n");
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
        public static Cliente CreaCliente()
        {
            Console.WriteLine("DNI\n");
            int id = ValidarInt(Console.ReadLine());
            Console.WriteLine("NOMBRE\n");
            string name = ValidarStr(Console.ReadLine());
            Console.WriteLine("APELLIDO\n");
            string lastname = ValidarStr(Console.ReadLine());
            Console.WriteLine("DIRECCION\n");
            string addr = ValidarStr(Console.ReadLine());
            Console.WriteLine("TELEFONO\n");
            long phone = ValidarLong(Console.ReadLine());
            Cliente cliente = new()
            {
                id = id,
                name = name,
                lastName = lastname,
                addr = addr,
                phone = phone
            };
            cliente.MostrarCliente();
            return cliente;
        }
        public void ListarClientes()
        {
            foreach (Cliente cl in coleccionClientes)
            {
                cl.MostrarCliente();
            }
        }
        public Cliente BuscarCliente()
        {
            Console.WriteLine("Ingrese numero de DNI");
            int dni = ValidarInt(Console.ReadLine());
            Cliente cl = null;
            foreach (Cliente cliente in coleccionClientes)
            {
                if (cliente.dni == dni)
                {
                    cl = cliente;
                }
            }
            //coleccionClientes Hacer busqueda dentro de coleccion, si devuelve null crear cliente nuevo
            if (cl == null)
            {
                cl = CreaCliente();
            }
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
        public bool ValidarBool()
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
        public void CreaHabitacion()
        {
            int op;
            Habitacion hb = new();
            bool resp;
            do
            {
                Console.WriteLine("INGRESE UNA OPCION: \n1- Individual 2-\nDoble \n3- Ejecutiva \n4- Suite\n");
                do
                {
                    op = ValidarInt(Console.ReadLine());
                   /* switch (op)
                    {
                        case 1: hb = new Individual(); break;
                        case 2: hb = new Doble(); break;
                        case 3: hb = new Ejecutiva(); break;
                        case 4: hb = new Suite(); break;
                    }*/
                   if (op == 1) { hb = new Individual(); }
                   else if (op == 2) { hb = new Doble(); }
                   else if (op == 3) { hb = new Ejecutiva(); }
                   else if (op == 4) { hb = new Suite(); }
                } while (op < 1 || op > 4);
                hb.CargaDatos();
                Console.WriteLine("Desea cargar otra habitacion?\n");
                resp = ValidarBool();
            }while(resp);
        }
        public void ListarHabitaciones()
        {

        }
    }
}