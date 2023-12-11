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

            List<Quarto> loadedQuartos;

           
            string fileNameNomeHotel = "nomeHotel.txt";
            string fileNameNumeroQuartos = "numeroQuartos.txt";
           
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


            bool terminarPrograma = true;

            do {
                
                //vai buscar os dados ao ficheiro.dat
                loadedQuartos = hotelController.DeserializeObject<List<Quarto>>("quartosData.dat");
                //Menu
                hotelViews.MenuPrincipal();

            int escolha = hotelViews.MenuPrincipalEscolha();

            switch (escolha)
            {

                    //Muda para o menu dos quartos
                case 1:
                        hotelViews.MenuQuartos();

                        int escolhaQuartos = hotelViews.MenuQuartosEscolha();

                        switch (escolhaQuartos)
                        {
                            //Mudar de preço
                            case 1:
                                    Console.Clear();
                                    hotelViews.MudarPreco(loadedQuartos, hotelController);

                            break;


                            //Listar todos os quartos
                            case 3:
                                    Console.Clear();
                                    foreach (Quarto quarto in loadedQuartos)
                                 {
                                   Console.WriteLine($"Quarto teste {quarto.QuartoID}, {quarto.Estado}, {quarto.Cliente.Email}, {quarto.Preco}");
                                 }

                            break;


                            




              

                            default:
                                Console.WriteLine("Opção inválida.");
                                break;
                        }
                        break;

                    //acaba com o loop, matando o programa
                    case 5:
                        terminarPrograma = false;
                    break;
                        
                        // Add other cases for other options in MenuPrincipal if needed
                }
            } while (terminarPrograma == true);

        }













        }
    }


