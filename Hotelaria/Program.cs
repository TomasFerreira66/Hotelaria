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

<<<<<<< HEAD
            // string for txt file
            string fileNameNomeHotel = "nomeHotel.txt";

            // variable for total number of rooms
            int numeroTotal = 0; // Initialize it outside the if statement
            string numeroQuartos;

            // nomeDoHotel takes the value from the content inside nomeHotel.txt
            string nomeDoHotel = meuHotel.ReadTextFromFile(fileNameNomeHotel);

            // Check if nomeDoHotel has content; if it does, display it; otherwise, proceed with setup
            if (!string.IsNullOrEmpty(nomeDoHotel))
            {
                Console.WriteLine($"Nome do hotel encontrado: {nomeDoHotel}");
            }
            else
            {
                Console.WriteLine("Bem vindo ao setup do seu hotel!");
                Console.WriteLine("Para começar, digite o nome do seu hotel");
                nomeDoHotel = Console.ReadLine();

                // Save the nomeDoHotel to the file
                meuHotel.WriteTextToFile(fileNameNomeHotel, nomeDoHotel);

                Console.WriteLine("Quantos quartos tem o seu hotel?");
                numeroQuartos = Console.ReadLine();
                numeroTotal = Convert.ToInt32(numeroQuartos);



            }

            // Call the AdicionarQuartos method and create an empty list with the total number of rooms.
=======
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
>>>>>>> parent of 401dba2 (aaa)
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
