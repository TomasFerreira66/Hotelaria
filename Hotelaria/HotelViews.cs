/* 
@file HotelViews.cs
@author Tomás Fernandes Ferreira (a20457@alunos.ipca.pt)
@author Tiago Amadeu Silva Sousa (a20735@alunos.ipca.pt)
@brief
@date dezembro 2023
@copyright Copyright (c) 2023
*/

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


        #region Menus
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

          


        //Menu quartos e os respetivos metodos
        public void MenuQuartos()
        {
            Console.WriteLine("Escolha uma opção");
            Console.WriteLine("1. Mudar preço de um quarto");
            Console.WriteLine("2. Ver informação de um quarto");
            Console.WriteLine("3. Listar todos os quartos");
            Console.WriteLine("4. Listar quartos livres");
            Console.WriteLine("");

        }

        public int MenuQuartosEscolha()
        {
            Console.Write("Escolha:");
            return Convert.ToInt32(Console.ReadLine());

        }

        #endregion

        #region Metodos
        /// <summary>
        /// Método para realizar o setup do programa.
        /// </summary>
        /// <param name="hotelController"></param>
        /// <param name="fileNameNomeHotel"></param>
        /// <param name="fileNameNumeroQuartos"></param>
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



        /// <summary>
        /// Método para mudar os preços de cada quarto.
        /// </summary>
        /// <param name="loadedQuartos"></param>
        /// <param name="hotelController"></param>
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

     
        /// <summary>
        /// Metodo para ver as informações de todos os quartos.
        /// </summary>
        /// <param name="loadedQuartos"></param>
        public void VerInformacoesQuartos(List<Quarto> loadedQuartos)
        {

            foreach (Quarto quarto in loadedQuartos)
            {
                Console.WriteLine($"Quarto {quarto.QuartoID}:");
                Console.WriteLine($"Estado: {quarto.Estado}, Preço: {quarto.Preco}");
                Console.WriteLine("");
                if (quarto.Estado == "Disponivel") {
                    Console.WriteLine($"Cliente: {quarto.Cliente.Nome} ");
                    Console.WriteLine($"CC: {quarto.Cliente.CC}, Numero Telemovel: {quarto.Cliente.Telemovel}, Email: {quarto.Cliente.Email}");
                }
                Console.WriteLine("");
                Console.WriteLine("");
            }


        }


        /// <summary>
        /// Método para ver informações de um quarto.
        /// </summary>
        /// <param name="loadedQuartos"></param>
        public void VerInformacaoUmQuarto(List<Quarto> loadedQuartos)
        {
           
            Console.WriteLine("Lista quartos");

            foreach (Quarto quarto in loadedQuartos)
            {
                Console.WriteLine($"Quarto {quarto.QuartoID}");
            }

            Console.WriteLine("Escolha um quarto");
            int escolha = Convert.ToInt32(Console.ReadLine());

            Quarto mostrarQuarto = loadedQuartos.FirstOrDefault(q => q.QuartoID == escolha);

            Console.WriteLine($"Quarto {mostrarQuarto.QuartoID}:");
            Console.WriteLine($"Estado: {mostrarQuarto.Estado}, Preço: {mostrarQuarto.Preco}");
            Console.WriteLine("");
            if (mostrarQuarto.Estado == "Disponivel")
            {
                Console.WriteLine($"Cliente: {mostrarQuarto.Cliente.Nome} ");
                Console.WriteLine($"CC: {mostrarQuarto.Cliente.CC}, Numero Telemovel: {mostrarQuarto.Cliente.Telemovel}, Email: {mostrarQuarto.Cliente.Email}");
            }
        }


        public void ListarQuartosLivresOcupados(List<Quarto> loadedQuartos)
        {
            Console.WriteLine("Deseja ver:");
            Console.WriteLine("1 - Disponíveis");
            Console.WriteLine("2 - Ocupados");

            int escolha = Convert.ToInt32(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    Console.WriteLine("Quartos Disponíveis:");
                    foreach (Quarto quarto in loadedQuartos)
                    {
                        if (quarto.Estado == "Disponivel")
                        {
                            Console.WriteLine($"Número do Quarto: {quarto.QuartoID}, Estado: {quarto.Estado}");
                            // Add other relevant information about the room if needed
                        }
                    }
                    break;

                case 2:
                    Console.WriteLine("Quartos Ocupados:");
                    foreach (Quarto quarto in loadedQuartos)
                    {
                        if (quarto.Estado == "Ocupado")
                        {
                            Console.WriteLine($"Número do Quarto: {quarto.QuartoID}, Estado: {quarto.Estado}");
                          
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Escolha inválida.");
                    break;
            }
        }




        #endregion
    }
}

