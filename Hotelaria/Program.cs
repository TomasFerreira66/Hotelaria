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
            HotelController hotelController = new HotelController();
            //inicia a classe dos menus
            HotelViews hotelViews = new HotelViews();
            
            
            string fileNameNomeHotel = "nomeHotel.txt";
            string fileNameNumeroQuartos = "numeroQuartos.txt";
            int numeroTotal = 0;
            string numeroQuartos;

            //da valor ao nomeDoHotel apartir do conteudo do ficheiro txt
            string nomeDoHotel = hotelController.ReadTextFromFile(fileNameNomeHotel);

            //Verifica se o ficheiro nomeHotel tem conteudo, se sim, o programa continua, senão vai para o setup
            if (!string.IsNullOrEmpty(nomeDoHotel))
            {         
                Console.WriteLine($"Menu Hotel {nomeDoHotel}");

                //verifica o numero de quartos dentro do ficheiro txt para depois usar esse valor para criar uma lista de Quartos
                numeroQuartos = hotelController.ReadTextFromFile(fileNameNumeroQuartos);
                numeroTotal = Convert.ToInt32(numeroQuartos);

            }
            //setup
            else
            {
                hotelViews.Setup(hotelController, fileNameNomeHotel, fileNameNumeroQuartos);

            }



            //programa começa aqui 

            //cria os quartos na lista
            for (int i = 0; i < numeroTotal; i++)
            {
                hotelController.AdicionarQuarto(i);
            }

            foreach (Quarto quarto in hotelController.Quartos)
            {
                Console.WriteLine($"Quarto teste {quarto.QuartoID}");
          
            }


            hotelViews.MenuPrincipal();
            string opcao = Console.ReadLine();

            if (opcao == "1")
            {
                hotelViews.MenuQuartos();
            }










        }
    }


}
