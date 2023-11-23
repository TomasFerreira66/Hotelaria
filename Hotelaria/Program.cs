using System.IO;
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
            //string path para ficheiro txt
            string filePath = "../nomeHotel.txt";




            Console.WriteLine("Bem vindo ao setup do seu hotel!");
            Console.WriteLine("Para começar, degite o nome do seu hotel");
            string nomeDoHotel = Console.ReadLine();

            

            // Exemplo de criar um hotel com 5 quartos
            Hotel meuHotel = new Hotel();

            //dar nome ao hotel
            meuHotel.WriteTextToFile(filePath, nomeDoHotel);

            int numeroTotal = 5;
            for (int i = 0; i < numeroTotal; i++)
            {
                meuHotel.AdicionarQuarto(i);
  
            }

            foreach (Quarto quarto in meuHotel.Quartos)
            {
                Console.WriteLine($"Quarto teste {quarto.QuartoID}");
                
            }
            Console.ReadLine();
        }
    }


}
