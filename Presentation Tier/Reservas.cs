using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Tier
{
    public class Reservas
    {

        public void MenuReservas()
        {
            Console.WriteLine("1. Fazer uma reserva");
            Console.WriteLine("2. Cancelar uma reserva");
            Console.WriteLine("3. Voltar");
            Console.WriteLine("");

        }

        public int MenuReservasEscolha()
        {
            try
            {
                Console.Write("Escolha:");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Por favor, insira um número válido.");
                return MenuReservasEscolha(); // Recursively call the method to get a valid input
            }
        }

    }
}
