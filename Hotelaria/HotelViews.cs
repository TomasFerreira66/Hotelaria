using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelaria
{
    public class HotelViews
    {


        //Class UI e mostrar dados

        public void MenuPrincipal()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Escolha uma opção");
            Console.WriteLine("1 - Ver informação quartos");
            Console.WriteLine("2 - Realizar Check-IN");
            Console.WriteLine("3 - Realizar Check-Out");
        }


        public void MenuQuartos()
        {
            Console.WriteLine("Escolha uma opção");
            Console.WriteLine("Mudar preço de um quarto");
            Console.WriteLine("Ver informação de um quarto");
            Console.WriteLine("Listar todos os quartos");
            Console.WriteLine("Listar quartos livres");
            Console.WriteLine("");
            Console.ReadLine();
        }


        //metodo para o setup da programa Hotel
        public void Setup(HotelController hotelController, string fileNameNomeHotel, string fileNameNumeroQuartos)
        {
            Console.WriteLine("Bem vindo ao setup do seu hotel!");
            Console.WriteLine("Para começar, digite o nome do seu hotel");
            string nomeDoHotel = Console.ReadLine();

            // Save the nomeDoHotel to the file
            hotelController.WriteTextToFile(fileNameNomeHotel, nomeDoHotel);

            Console.WriteLine("Quantos quartos tem o seu hotel?");
            string numeroQuartos = Console.ReadLine();
            hotelController.WriteTextToFile(fileNameNumeroQuartos, numeroQuartos);
            int numeroTotal = Convert.ToInt32(numeroQuartos);

            //cria os ficheiros .dat para cada quarto
            for (int i = 0; i < numeroTotal; i++)
            {
                string fileNameQuarto = $"{i}.dat";
                string fileNameCliente = $"Cliente {i}.dat";
                hotelController.WriteTextToFile(fileNameQuarto, "d");
                hotelController.WriteTextToFile(fileNameCliente, "d");
            }


        }

    }
}
    
