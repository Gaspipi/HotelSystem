using System;
using System.Collections;
using System.Linq.Expressions;

namespace HotelSystem
{
    public class Reserva
    {
        public int nroReserva;
        public DateTime fechaDesde;
        public DateTime fechaHasta;
        public Habitacion objHabitacion = new();
        public Cliente objCliente = new();
        public SortedList coleccionServicios = new();
        private static int contaReserva;
        public static void ActualizaContaReserva()
        {
            contaReserva += 1;
        }
        public static void IniciaReserva()
        {
            contaReserva = 0;
        }
        public DateTime DevFechaDesde()
        {
            return fechaDesde;
        }
        public DateTime DevFechaHasta()
        {
            return fechaHasta;
        }
        public int DevNroReserva()
        {
            return nroReserva;
        }
        public Habitacion DevObjHabitacion()
        {
            return objHabitacion;
        }
        public Cliente DevObjCliente()
        {
            return objCliente;
        }
        public void MostrarReserva()
        {
            TimeSpan cantDias = fechaHasta - fechaDesde;
            int subTotal = objHabitacion.DevPrecio();//Arreglar devPrecio para clase Habitacion????
            string aux = cantDias.ToString();
            string aux2 = "";
            //Arreglar solo tomar los dias
            foreach (char element in aux)
            {
                while (element != '.')
                {
                    aux2 += element;
                }
            }
            int aux3 = ValidarInt(aux2);
            int total = aux3 * subTotal;

        }
        public void CargaReserva(Habitacion hb, Cliente cl)
        {
            Console.WriteLine("Cargue la fecha de inicio de la reserva");
            fechaDesde = CargaFecha();
            Console.WriteLine("Cargue la fecha final de la reserva");
            fechaHasta = CargaFecha();
            objHabitacion = hb;
            objCliente = cl;
            nroReserva = contaReserva;
            ActualizaContaReserva();
            coleccionServicios = new();
        }
        public DateTime CargaFecha()
        {
            Console.WriteLine("Ingrese el dia");
            int day = ValidarInt(Console.ReadLine());
            Console.WriteLine("Ingrese el mes");
            int month = ValidarInt(Console.ReadLine());
            Console.WriteLine("Ingrese el año");
            int year = ValidarInt(Console.ReadLine());
            DateTime dt = new(year, month, day);
            return dt.Date;
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
    }
}
