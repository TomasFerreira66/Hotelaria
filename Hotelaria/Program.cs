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

            //cria um hotel
            Hotel meuHotel = new Hotel();
            
            
            string fileNameNomeHotel = "nomeHotel.txt";
            string fileNameNumeroQuartos = "numeroQuartos.txt";

          


            int numeroTotal = 0;
            string numeroQuartos;

            //da valor ao nomeDoHotel apartir do conteudo do ficheiro txt
            string nomeDoHotel = meuHotel.ReadTextFromFile(fileNameNomeHotel);

            //Verifica se o ficheiro nomeHotel tem conteudo, se sim, o programa continua, senão vai para o setup
            if (!string.IsNullOrEmpty(nomeDoHotel))
            {

                
                Console.WriteLine($"Nome do hotel encontrado: {nomeDoHotel}");

                //verifica o numero de quartos dentro do ficheiro txt para depois usar esse valor para criar uma lista de Quartos
                numeroQuartos = meuHotel.ReadTextFromFile(fileNameNumeroQuartos);
                numeroTotal = Convert.ToInt32(numeroQuartos);

            }
            //setup
            else
            {
                Console.WriteLine("Bem vindo ao setup do seu hotel!");
                Console.WriteLine("Para começar, digite o nome do seu hotel");
                nomeDoHotel = Console.ReadLine();

                // Save the nomeDoHotel to the file
                meuHotel.WriteTextToFile(fileNameNomeHotel, nomeDoHotel);

                Console.WriteLine("Quantos quartos tem o seu hotel?");
                numeroQuartos = Console.ReadLine();
                meuHotel.WriteTextToFile(fileNameNumeroQuartos, numeroQuartos);
                numeroTotal = Convert.ToInt32(numeroQuartos);

                //cria os ficheiros .dat para cada quarto
                for (int i = 0; i < numeroTotal; i++)
                    {
                    string fileName = $"quarto_{i}.dat";
                    meuHotel.WriteTextToFile(fileName, "d");
                }

            }



            //programa começa aqui 


            //cria as listas
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
