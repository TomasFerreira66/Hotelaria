using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelaria
{
    class Program
    {
        static void Main(string[] args)
        {

            
            
            // Exemplo de criar um hotel com 5 quartos
            Hotel meuHotel = new Hotel();

            int numeroTotal = 5;
            for (int i = 0; i < numeroTotal; i++)
            {
                meuHotel.AdicionarQuarto(i);
            }

            foreach (Quarto quarto in meuHotel.Quartos)
            {
                Console.WriteLine($"Quarto teste {quarto.quartoID}");
            }
            Console.ReadLine();
        }
    }
}
