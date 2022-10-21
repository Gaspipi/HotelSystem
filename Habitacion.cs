using System;

namespace HotelSystem
{
	public class Habitacion
	{
        public int nroHabitacion;
        public int nroPiso;
        public bool estado;
        public int cantidadCamas;
        public string descripcion = "";
        public static int Precio;

        public int DevPrecio()
        {
            return Precio;
        }
        public static int ValidarInt(string a)
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
        public static void CargaPrecio()
        {
            int ret = 0;
            bool esEntero;
            do
            {
                Console.WriteLine($"Ingrese el precio de las habitaciones Individuales\n");
                string a = Console.ReadLine();
                esEntero = Int32.TryParse(a, out ret);
                if (!esEntero)
                {
                    Console.WriteLine("Ingrese datos validos\n");
                }
            } while (!esEntero);
            Precio = ret;
        }
    }
    public class Individual : Habitacion
	{
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
        public static string ValidarStr(string a)
        {
            bool esString;
            do
            {
                esString = (String.IsNullOrEmpty(a) && String.IsNullOrWhiteSpace(a));
                if (esString)
                {
                    Console.WriteLine("El valor no puede ser un espacio en blanco ni vacio");
                    a = Console.ReadLine();
                }
            } while (esString);
            return a;
        }
        
    }
    public class Doble : Habitacion
    {
        public bool EsDoble()
        {
            return true;
        }
    }
    public class Ejecutiva : Habitacion
    {
        public bool EsEjecutiva() 
        {
            return true; 
        }
    }

    public class Suite : Habitacion
    {
        public bool EsSuite() 
        {
            return true;
        }    
    }
}
