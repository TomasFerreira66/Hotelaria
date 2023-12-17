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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataTier;


namespace Application_Layer
{
    //Class UI e mostrar dados
    public class Metodos
    {

        

        #region Setup
        /// <summary>
        /// Método para realizar o setup do programa.
        /// </summary>
        /// <param name="hotelController"></param>
        /// <param name="fileNameNomeHotel"></param>
        /// <param name="fileNameNumeroQuartos"></param>
        public void Setup(Dados_Metodos hotelController, string fileNameNomeHotel, string fileNameNumeroQuartos)
        {
            Console.WriteLine("Bem vindo ao setup do seu hotel!");

            Console.WriteLine("Para começar, digite o nome do seu hotel");
            string nomeDoHotel = Console.ReadLine();

            //Loop para continuar o setup até o utilizador meter dados validos
            bool inputValid = false;

            while (!inputValid)
            {
                Console.WriteLine("Quantos quartos tem o seu hotel?");
                
                try
                {
                    string numeroQuartos = Console.ReadLine();
                    //verifica se numeroQuarto é um numero, senão dá erro
                    if (!int.TryParse(numeroQuartos, out int numeroTotal))
                    {
                        throw new ArgumentException("O número de quartos deve ser um número inteiro válido.");
                    }


                    //se der certo, guarda os valores do nome do hotel e o numero de quartos num txt.
                    hotelController.WriteTextToFile(fileNameNumeroQuartos, numeroQuartos);
                    hotelController.WriteTextToFile(fileNameNomeHotel, nomeDoHotel);
                    // da valores default à lista para depois guardar num ficheiro .dat
                    for (int i = 0; i < numeroTotal; i++)
                    {
                        hotelController.AdicionarQuarto(i);
                    }

                    //acaba o loop
                    inputValid = true; // Break out of the loop if the input is valid
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                    
                }
            }
        }



        #endregion

        #region MudarPreco
        /// <summary>
        /// Método para mudar os preços de cada quarto.
        /// </summary>
        /// <param name="loadedQuartos"></param>
        /// <param name="hotelController"></param>
        public void MudarPreco(List<Quarto> loadedQuartos, Dados_Metodos hotelController)
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

        #endregion

        #region InfoTodosQuartos
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

        #endregion

        #region InfoUmQuarto
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
        #endregion

        #region Listar quartos Disponivels/Reservados/Ocupados
        /// <summary>
        /// Este metodo permite ver informações dos quartos dependendo do estado que escolher
        /// </summary>
        /// <param name="loadedQuartos"></param>
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
        public void RealizarReserva(List<Quarto> loadedQuartos, Dados_Metodos hotelController)
        {

            Console.WriteLine("Quartos disponiveis para reservar");
            foreach (Quarto quarto in loadedQuartos)
            {
                if (quarto.Estado == "Disponivel")
                {
                    Console.WriteLine($"Número do Quarto: {quarto.QuartoID}, Estado: {quarto.Estado}");

                }
            }



            int numeroQuarto;

            while (true)
            {
                try
                {
                    Console.WriteLine("Digite o número do quarto que deseja efetuar a reserva:");
                    numeroQuarto = Convert.ToInt32(Console.ReadLine());

                    // Ve se o numero do quarto está disponivel
                    if (loadedQuartos.Any(q => q.QuartoID == numeroQuarto && q.Estado == "Disponivel"))
                    {
                        break; //Loop acaba se um numero de quarto valido é inputed
                    }
                    else
                    {
                        Console.WriteLine("Quarto não disponível. Por favor, escolha um quarto disponível.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, insira um número válido.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("O número inserido é muito grande. Por favor, insira um número menor.");
                }
            }

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
        public void CheckIN(List<Quarto> loadedQuartos, Dados_Metodos hotelController)
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
                quartoParaCheckIN.Estado = "Ocupado";
            }

            hotelController.SerializeObject(loadedQuartos, "quartosData.dat");
        }


        #endregion

        #region CheckOUT

        /// <summary>
        /// Metodo para realizar o CHECKOUT de um cliente
        /// </summary>
        /// <param name="loadedQuartos"></param>
        /// <param name="hotelController"></param>
        public void CheckOUT(List<Quarto> loadedQuartos, Dados_Metodos hotelController)/*-*/


        {

            Console.WriteLine("Quartos:");
            foreach (Quarto quarto in loadedQuartos)
            {
                if (quarto.Estado == "Ocupado")
                {
                    Console.WriteLine($"Número do Quarto: {quarto.QuartoID}");

                }
            }


            Console.WriteLine("Escolha um quarto para realizar Check-OUT");
            int quartoEscolhido = Convert.ToInt32(Console.ReadLine());

            Quarto QuartoTemp = loadedQuartos.FirstOrDefault(q => q.QuartoID == quartoEscolhido);
            int PrecoOriginal = QuartoTemp.Preco;
            int IDOriginal = QuartoTemp.QuartoID;

            int quartoParaCheckOUT = loadedQuartos.FindIndex(q => q.QuartoID == quartoEscolhido);
            loadedQuartos[quartoParaCheckOUT] = new Quarto();
            loadedQuartos[quartoParaCheckOUT].Preco = PrecoOriginal;
            loadedQuartos[quartoParaCheckOUT].QuartoID = IDOriginal;

            hotelController.SerializeObject(loadedQuartos, "quartosData.dat");

        }

        #endregion
    }
}

