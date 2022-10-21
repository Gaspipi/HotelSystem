using System;
using System.Collections;

namespace HotelSystem
{
    public class Cliente
    {
        public static int Id;
        public int id;
        public int dni;
        public string name;
        public string lastName;
        public string addr;
        public long phone;

        public static void IniciaId()
        {
            Id = 0;
        }
        public static void ActualizaId()
        {
            Id++;
        }
        public void MostrarCliente()
        {
            Console.WriteLine("////////////////////////////////\n");
            Console.WriteLine($"\n#{id}\n");
            Console.WriteLine("////////////////////////////////\n");
            Console.WriteLine($"\nDNI {dni}\n");
            Console.WriteLine("////////////////////////////////\n");
            Console.WriteLine($"\nApellido {lastName}\n");
            Console.WriteLine("////////////////////////////////\n");
            Console.WriteLine($"\nNombre {name}\n");
            Console.WriteLine("////////////////////////////////\n");
            Console.WriteLine($"\nDireccion {addr}\n");
            Console.WriteLine("////////////////////////////////\n");
            Console.WriteLine($"\nTelefono {phone}\n");
        }
        public void CargaDatos(int clDni)
        {
            int dni;
            if (clDni == 0)
            {
                Console.WriteLine("Ingrese el numero de DNI");
                dni = ValidarInt(Console.ReadLine());
            }
            else
            {
                dni = clDni;
            }
            Console.WriteLine("Ingrese el numero de DNI");
            name = ValidarStr(Console.ReadLine());
            Console.WriteLine("Ingrese el numero de DNI");
            lastName = ValidarStr(Console.ReadLine());
            Console.WriteLine("Ingrese el numero de DNI");
            addr = ValidarStr(Console.ReadLine());
            Console.WriteLine("Ingrese el numero de DNI");
            phone = ValidarLong(Console.ReadLine());
            id = id;
            ActualizaId();
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
        public static long ValidarLong(string a)
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
        public string DevApellido()
        {
            return lastName;
        }
        public int DevDni()
        {
            return dni;
        }
        public int DevId()
        {
            return id;
        }
        public string DevDomicilio()
        {
            return addr;
        }
        public string DevNombre()
        {
            return name;
        }
        public long DevTelefono()
        {
            return phone;
        }
        public void Listar()
        {
            //Lista los atributos del objeto cliente
        }
    }
}