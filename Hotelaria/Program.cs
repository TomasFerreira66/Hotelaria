/* 
@file Program.cs
@author Tomás Fernandes Ferreira (a20457@alunos.ipca.pt)
@author Tiago Amadeu Silva Sousa (a20735@alunos.ipca.pt)
@brief
@date dezembro 2023
@copyright Copyright (c) 2023
*/
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca;

namespace Hotelaria
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Atributos
            HotelController hotelController = new HotelController();
            HotelViews hotelViews = new HotelViews();
            List<Quarto> loadedQuartos;
            string fileNameNomeHotel = "nomeHotel.txt";
            string fileNameNumeroQuartos = "numeroQuartos.txt";
            string nomeDoHotel = hotelController.ReadTextFromFile(fileNameNomeHotel);
            #endregion

            #region Startup


            //O startup verifica na pasta do projeto se já existe ficheiros
            //do nome e numero de quartos do hotel, senão faz referencia
            if (string.IsNullOrEmpty(nomeDoHotel))
            {
                hotelViews.Setup(hotelController, fileNameNomeHotel, fileNameNumeroQuartos);
                hotelController.SerializeObject(hotelController.QuartosList, "quartosData.dat");
            }
            else
            {
                Console.WriteLine($"Menu Hotel {nomeDoHotel}");
            }

            #endregion

            bool terminarPrograma = true;

            do
            {
                loadedQuartos = hotelController.DeserializeObject<List<Quarto>>("quartosData.dat");
                hotelViews.MenuPrincipal();
                int escolha = hotelViews.MenuPrincipalEscolha();

                switch (escolha)
                {
                    case 1:
                        hotelViews.MenuQuartos();
                        int escolhaQuartos = hotelViews.MenuQuartosEscolha();

                        switch (escolhaQuartos)
                        {
                            case 1:
                                Console.Clear();
                                hotelViews.MudarPreco(loadedQuartos, hotelController);
                                break;

                            case 2:
                                Console.Clear();
                                hotelViews.VerInformacaoUmQuarto(loadedQuartos);
                                break;

                            case 3:
                                Console.Clear();
                                hotelViews.VerInformacoesQuartos(loadedQuartos);
                                break;

                            case 4:
                                Console.Clear();    
                                hotelViews.ListarQuartosLivresOcupados(loadedQuartos);
                                break;

                            default:
                                Console.WriteLine("Opção inválida.");
                                break;
                        }
                        break;

                    case 2:
                        hotelViews.RealizarReserva(loadedQuartos, hotelController);
                    break;

                    case 3:

                    break;

                    case 5:
                        terminarPrograma = false;
                        break;
                }
            } while (terminarPrograma);
        }
    }
}
