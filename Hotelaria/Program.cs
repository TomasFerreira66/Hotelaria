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
               
            }
            //setup
            else
            {
                hotelViews.Setup(hotelController, fileNameNomeHotel, fileNameNumeroQuartos);
                hotelController.SerializeObject(hotelController.QuartosList, "quartosData.dat");
            }



            //programa começa aqui 


            //da load aos dados default
            List<Quarto> loadedQuartos = hotelController.DeserializeObject<List<Quarto>>("quartosData.dat");
            //teste para verse ta a funcionar o loadedQuartos
            foreach (Quarto quarto in loadedQuartos)
            {
                Console.WriteLine($"Quarto teste {quarto.QuartoID}, {quarto.Estado}, {quarto.Cliente.Email}");

            }

           


            //Menu
            hotelViews.MenuPrincipal();
            string opcao = Console.ReadLine();

            if (opcao == "1")
            {
                hotelViews.MenuQuartos();
            }

            









        }
    }


}
