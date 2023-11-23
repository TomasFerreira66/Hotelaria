using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace Hotelaria
{
    class Program
    {
        static void Main(string[] args)
        {


            //Este projeto ao iniciar vai ter dois estados.
            //O primeiro estado é o setup, que acontece caso o programa esteja
            //a ser utilizado pela primeira vez para dar "setup" ao hotel

            //O segundo estado o completo uso do programa depois do setup ser feito.


            // Cria um hotel
            Hotel meuHotel = new Hotel();

            //string para ficheiro txt
            string fileNameNomeHotel = "nomeHotel.txt";
            string fileNameNumeroQuartos = "numeroQuartos.txt";
            //varíável para número total de quartos
            int numeroTotal;
           
            
            //nomeDoHotel toma o valor do conteudo que está dentro do nomeHotel.txt
            string nomeDoHotel = meuHotel.ReadTextFromFile(fileNameNomeHotel);
            // Verifica se o nomeDoHotel tem conteudo, se tiver da "login", senão
            // o setup continua
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
            }






            // Verifica se o ficheiro numeroQuartos.txt tem dados
            string numeroQuartosString = meuHotel.ReadTextFromFile(fileNameNumeroQuartos).Trim();

            if (!string.IsNullOrEmpty(numeroQuartosString))
            {
                // passa o conteudo do ficheiro para a variavel numeroTotal
                if (int.TryParse(numeroQuartosString, out numeroTotal))
                {
                    Console.WriteLine($"Número de quartos encontrado: {numeroTotal}");
                }
                else
                {
                    Console.WriteLine("Erro ao converter o número de quartos.");
                }
            }
            //Se não tiver nada dentro do ficheiro faz o inquerito do número de quartos e guarda no ficheiros numeroQuartos.txt
            else
            {
                Console.WriteLine("Quantos quartos tem o seu hotel?");
                string numeroQuartos = Console.ReadLine();

                meuHotel.WriteTextToFile(fileNameNumeroQuartos, numeroQuartos);

                //numeroTotal servirá para criar o numero de listas aka Quartos que o hotel tem
                numeroTotal = Convert.ToInt32(numeroQuartos);
            }




            //chama o método AdicionarQuartos e cria uma lista vazia com o número total de quartos.
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


       //POR FAZER: Gerar ficheiros de texto correspondestes ao numeroTotal de quartos, por exemplo se no setup
       //disser que o hotel tem 5 quartos, cria 5 ficheiros de json (ver isto melhor)
       //Ficheiros de texto quais que vão ser usados para manipular os dados da list Quartos

        //Caso os ficheiros de texto ja existam, popular a list com os dados de cada ficheiro de texto
    }


}
