/* 
@file Main.cs
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
using Application_Tier;
using DataTier;


namespace Presentation_Tier
{
    public class Main
    {
        MenuPrincipal menuPrincipal = new MenuPrincipal();
        InfoQuartos infoQuartos = new InfoQuartos();
        Reservas reservas = new Reservas();
        Dados_Metodos dados_Metodos = new Dados_Metodos();
        Metodos metodos = new Metodos();
        public Main()
        {
           
        }

        public void Startup(List<Quarto> loadedQuartos)
        {
            
            menuPrincipal.Menu();
            int escolha = menuPrincipal.MenuPrincipalEscolha();
            switch (escolha)
            {
                //Abre o menu "1 - Ver informação quartos"
                case 1:
                    Console.Clear();
                    infoQuartos.MenuQuartos();
                    int escolhaQuartos = infoQuartos.MenuQuartosEscolha();

                    switch (escolhaQuartos)
                    {
                        case 1:
                            Console.Clear();
                            metodos.MudarPreco(loadedQuartos, dados_Metodos);
                            break;

                        case 2:
                            Console.Clear();
                            metodos.VerInformacaoUmQuarto(loadedQuartos);
                            break;

                        case 3:
                            Console.Clear();
                            metodos.VerInformacoesQuartos(loadedQuartos);
                            break;

                        case 4:
                            Console.Clear();
                            metodos.ListarQuartosLivresOcupados(loadedQuartos);
                            break;

                        case 5:
                            Console.Clear();                           
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                break;
                    //fecha o menu "1 - Ver informação quartos"

                 
                    //abre o menu das reservas
                case 2:
                    Console.Clear();
                    reservas.MenuReservas();
                    int escolhaReservas = reservas.MenuReservasEscolha();
                    switch(escolhaReservas)
                    { 
                        case 1:
                            Console.Clear();
                            metodos.RealizarReserva(loadedQuartos, dados_Metodos);
                        break;

                        case 2:
                            Console.Clear();
                            metodos.CancelarReserva(loadedQuartos, dados_Metodos);
                        break;

                        case 3:
                            Console.Clear();
                        break;

                           
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;

                    }
                    break;
                   //fecha o menu das reservas

                case 3:
                    Console.Clear();
                    metodos.CheckIN(loadedQuartos, dados_Metodos);
                    break;

                case 4:
                    Console.Clear();
                    metodos.CheckOUT(loadedQuartos, dados_Metodos);
                    break;

                case 5:
                    Console.Clear();
                    metodos.Notificacoes(loadedQuartos, dados_Metodos);
                    break;

                case 6:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;

            }
        }


    }
}
