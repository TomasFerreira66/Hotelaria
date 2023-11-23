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
            string fileNameNomeHotel = "nomeHotel.txt";
            string fileNameNumeroQuartos = "numeroQuartos.txt";

            // Cria um hotel
            Hotel meuHotel = new Hotel();

            Console.WriteLine("Bem vindo ao setup do seu hotel!");
            Console.WriteLine("Para começar, degite o nome do seu hotel");
            string nomeDoHotel = Console.ReadLine();

            //guarda o nome ao hotel num ficheiro de text
            meuHotel.WriteTextToFile(fileNameNomeHotel, nomeDoHotel);


            Console.WriteLine("Quantos quartos tem o seu hotel?");
            string numeroQuartos = Console.ReadLine();

            //guarda o numero de quartos num ficheiro de texto
            meuHotel.WriteTextToFile(fileNameNumeroQuartos, numeroQuartos);

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
