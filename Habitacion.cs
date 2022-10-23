using System;

namespace HotelSystem
{
    /// <summary>
    /// Summary description for Habitacion
    /// </summary>
	public class Habitacion
	{
        public int nroHabitacion;
        public int nroPiso;
        public bool estado;
        public int cantidadCamas;
        public string descripcion = "";
        private static int Precio;
        public static void CargaPrecio()
        {
            Console.WriteLine("Ingrese el precio de las habitaciones\n");
            int a = ValidarInt(Console.ReadLine());
            Precio = a;
        }
        public int DevPrecio()
        {
            return Precio;
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
        public static bool ValidarBool()
        {
            ConsoleKeyInfo a;
            bool esBoolean;
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
        public void CargaDatos()
        {
            Console.WriteLine("Ingrese el numero de habitacion");
            nroHabitacion = ValidarInt(Console.ReadLine());
            Console.WriteLine("Ingrese el numero de piso");
            nroPiso = ValidarInt(Console.ReadLine());
            Console.WriteLine("La habitacion esta ocupada? S/n");
            estado = ValidarBool();
            Console.WriteLine("Ingrese el numero de camas");
            cantidadCamas = ValidarInt(Console.ReadLine());
            Console.WriteLine("Ingrese una descripcion");
            descripcion = ValidarStr(Console.ReadLine());
        }
        public static string ValidarStr(string? a)
        {
            bool esNull;
            do
            {
                esNull = (String.IsNullOrEmpty(a) || String.IsNullOrWhiteSpace(a));
                if (esNull)
                {
                    Console.WriteLine("El valor no puede ser un espacio en blanco ni vacio\n");
                    a = Console.ReadLine();
                }
            } while (esNull);
            return a;
        }
        public void ActEstado()
        {
            if (estado)
            {
                estado = false;
            }
            else if (!estado)
            {
                estado = true;
            }
        }
    }
    public class Individual : Habitacion
    { 

    }
    public class Doble : Habitacion
    {
        public static bool EsDoble()
        {
            return true;
        }
    }
    public class Ejecutiva : Habitacion
    {
        public static bool EsEjecutiva() 
        {
            return true; 
        }
    }
    public class Suite : Habitacion
    {
        public static bool EsSuite()
        {
            return true;
        }
    }
}
