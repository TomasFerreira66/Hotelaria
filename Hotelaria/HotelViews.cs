using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelaria
{
    //Class UI e mostrar dados
    public class HotelViews
    {


        //Menu principal e respetivos metodos

        public void MenuPrincipal()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Escolha uma opção");
            Console.WriteLine("1 - Ver informação quartos");
            Console.WriteLine("2 - Realizar reserva");
            Console.WriteLine("3 - Realizar Check-IN");
            Console.WriteLine("4 - Realizar Check-Out");
            Console.WriteLine("5 - Sair");
        }

        public int MenuPrincipalEscolha()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        /////////


        //Menu quartos e os respetivos metodos
        public void MenuQuartos()
        {
            Console.WriteLine("Escolha uma opção");
            Console.WriteLine("Mudar preço de um quarto");
            Console.WriteLine("Ver informação de um quarto");
            Console.WriteLine("Listar todos os quartos");
            Console.WriteLine("Listar quartos livres");
            Console.WriteLine("");

        }

        public int MenuQuartosEscolha()
        {
            Console.Write("Escolha:");
            return Convert.ToInt32(Console.ReadLine());

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
            //da valores default à lista para depois guardar num ficheiro .dat
            int numeroTotal = int.Parse(numeroQuartos);
            for (int i = 0; i < numeroTotal; i++)
            {
                hotelController.AdicionarQuarto(i);
            }
        }


        //MudarPrecoQuarto
        public void MudarPreco(List<Quarto> loadedQuartos, HotelController hotelController)
        {

            // Mudar preço de um quarto
            Console.WriteLine("Digite o número do quarto que deseja modificar o preço:");
            int numeroQuarto = Convert.ToInt32(Console.ReadLine());

            // Find the room with the specified number in the loadedQuartos list
            Quarto quartoParaModificar = loadedQuartos.FirstOrDefault(q => q.QuartoID == numeroQuarto);

            if (quartoParaModificar != null)
            {
                Console.WriteLine($"O preço atual do quarto {quartoParaModificar.QuartoID} é {quartoParaModificar.Preco}");
                Console.WriteLine("Digite o novo preço:");
                int novoPreco = Convert.ToInt32(Console.ReadLine());

                // Update the room's price in the loadedQuartos list
                quartoParaModificar.Preco = novoPreco;

                // Save the updated list to the file
                hotelController.SerializeObject(loadedQuartos, "quartosData.dat");

                Console.WriteLine($"Preço do quarto {quartoParaModificar.QuartoID} modificado para {quartoParaModificar.Preco}");
            }
            else
            {
                Console.WriteLine($"Quarto com o número {numeroQuarto} não encontrado.");
            }
        }

     

        

    }
}

