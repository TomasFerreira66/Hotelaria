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
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca;


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
            Console.WriteLine("4. Listar quartos disponiveis/ocupados/Reservados");
            Console.WriteLine("");

        }

        public int MenuQuartosEscolha()
        {
            Console.Write("Escolha:");
            return Convert.ToInt32(Console.ReadLine());

        }

        #endregion

        #region Metodos menu informação quartos
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
            Console.WriteLine("Insira o número do quarto que deseja modificar o preço:");
            int numeroQuarto = Convert.ToInt32(Console.ReadLine());

            // Find the room with the specified number in the loadedQuartos list
            Quarto quartoParaModificar = loadedQuartos.FirstOrDefault(q => q.QuartoID == numeroQuarto);

            if (quartoParaModificar != null)
            {
                //Verifica primeiro se o quarto está ocupado ou reservado
                if (quartoParaModificar.Estado == "Ocupado" || quartoParaModificar.Estado == "Reservado")
                {
                    Console.WriteLine("Este quarto encontra-se Reservado ou Ocupado, por favor aguarde que esteja disponivel para modificar o preço");
                }
                else
                {
                    Console.WriteLine($"O preço atual do quarto {quartoParaModificar.QuartoID} é {quartoParaModificar.Preco}");
                    Console.WriteLine("Insira o novo preço:");
                    int novoPreco = Convert.ToInt32(Console.ReadLine());

                    // Update the room's price in the loadedQuartos list
                    quartoParaModificar.Preco = novoPreco;

                    // Save the updated list to the file
                    hotelController.SerializeObject(loadedQuartos, "quartosData.dat");

                    Console.WriteLine($"Preço do quarto {quartoParaModificar.QuartoID} modificado para {quartoParaModificar.Preco}");
                }
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

                if (quarto.Estado == "Ocupado" || quarto.Estado == "Reservado") {
                    Console.WriteLine($"Cliente: {quarto.Cliente.Nome} ");
                    Console.WriteLine($"CC: {quarto.Cliente.CC}, Numero Telemovel: {quarto.Cliente.Telemovel}, Email: {quarto.Cliente.Email}");
                    Console.WriteLine($"Numero de dias da estadia: {quarto.Reserva.DuracaoEstadia}, Preço total: {quarto.Reserva.PrecoTotal}");
                    Console.WriteLine($"Data Check-in: {quarto.DataCheckIn}");
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
                Console.WriteLine("=============================================================================");
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

            if (mostrarQuarto.Estado == "Ocupado" || mostrarQuarto.Estado == "Reservado") { 

                Console.WriteLine($"Cliente: {mostrarQuarto.Cliente.Nome} ");
                Console.WriteLine($"CC: {mostrarQuarto.Cliente.CC}, Numero Telemovel: {mostrarQuarto.Cliente.Telemovel}, Email: {mostrarQuarto.Cliente.Email}");
                Console.WriteLine($"Numero de dias da estadia: {mostrarQuarto.Reserva.DuracaoEstadia}, Preço total: {mostrarQuarto.Reserva.PrecoTotal}");
                Console.WriteLine($"Data CHECK-IN: {mostrarQuarto.DataCheckIn}");
            }
        }


        public void ListarQuartosLivresOcupados(List<Quarto> loadedQuartos)
        {
            Console.WriteLine("Deseja ver:");
            Console.WriteLine("1 - Disponíveis");
            Console.WriteLine("2 - Ocupados");
            Console.WriteLine("3 - Reservados");

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

                    case 3:

                    Console.WriteLine("Quartos Reservados:");
                    foreach (Quarto quarto in loadedQuartos)
                    {
                        if (quarto.Estado == "Reservado")
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

        #region Reserva


        /// <summary>
        /// Metodo para realizar reservas
        /// </summary>
        /// <param name="loadedQuartos"></param>
        public void RealizarReserva(List<Quarto> loadedQuartos, HotelController hotelController)
        {

            Console.WriteLine("Quartos disponiveis para reservar");
            foreach (Quarto quarto in loadedQuartos)
            {
                if (quarto.Estado == "Disponivel")
                {
                    Console.WriteLine($"Número do Quarto: {quarto.QuartoID}, Estado: {quarto.Estado}");

                }
            }


            Console.WriteLine("Digite o número do quarto que deseja efetuar a reserva:");
            int numeroQuarto = Convert.ToInt32(Console.ReadLine());

            Quarto quartoParaReservar = loadedQuartos.FirstOrDefault(q => q.QuartoID == numeroQuarto);


            Console.WriteLine("Nome do cliente:");
            string nomeCliente = Console.ReadLine();
            Console.WriteLine("Email do Cliente");
            string emailCliente = Console.ReadLine();
            Console.WriteLine("CC do cliente");
            int CCcliente = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Numero de telemovel");
            int telemovelCliente = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Numero de dias estadia");
            int numeroDiasEstadia = Convert.ToInt32(Console.ReadLine());


            quartoParaReservar.Cliente.Nome = nomeCliente;
            quartoParaReservar.Cliente.Email = emailCliente;
            quartoParaReservar.Cliente.CC = CCcliente;
            quartoParaReservar.Cliente.Telemovel = telemovelCliente;
            quartoParaReservar.Estado = "Reservado";
            quartoParaReservar.Reserva.DuracaoEstadia = numeroDiasEstadia;
            quartoParaReservar.Reserva.PrecoTotal = quartoParaReservar.Preco * numeroDiasEstadia;

            hotelController.SerializeObject(loadedQuartos, "quartosData.dat");

        }

       

        #endregion

        #region CheckIN

        /// <summary>
        /// Método para realizar o CHECK-IN de um cliente num quarto.
        /// </summary>
        /// <param name="loadedQuartos"></param>
        /// <param name="hotelController"></param>
        public void CheckIN(List<Quarto> loadedQuartos, HotelController hotelController)
        {
            Console.WriteLine("Reservas:");
            foreach (Quarto quarto in loadedQuartos)
            {
                if (quarto.Estado == "Reservado")
                {
                    Console.WriteLine($"Número do Quarto: {quarto.QuartoID}");

                }
            }

           Console.WriteLine("Escolha um quarto para realizar Check-In");
            int quartoEscolhido = Convert.ToInt32(Console.ReadLine());


            Quarto quartoParaCheckIN = loadedQuartos.FirstOrDefault(q => q.QuartoID == quartoEscolhido);

            Console.WriteLine("Informações desta reserva a verificar:");
            Console.WriteLine($"Nome do cliente: {quartoParaCheckIN.Cliente.Nome}, CC: {quartoParaCheckIN.Cliente.CC}");
            Console.WriteLine($"Dias de estadia: {quartoParaCheckIN.Reserva.DuracaoEstadia}, Preço: {quartoParaCheckIN.Reserva.PrecoTotal}");

            Console.WriteLine("Realizar CHECK-IN?");
            string escolha = Console.ReadLine();
            if (escolha == "s" )
            {
                quartoParaCheckIN.DataCheckIn = DateTime.Now;
            }

            hotelController.SerializeObject(loadedQuartos, "quartosData.dat");
        }


        #endregion

    }
}

