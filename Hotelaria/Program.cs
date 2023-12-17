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
using DataTier;
using Presentation_Tier;
using Application_Layer;

namespace Hotelaria
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Atributos
            Dados_Metodos dadosMetodos = new Dados_Metodos();
            Metodos metodos = new Metodos();
            Main main = new Main();
            List<Quarto> loadedQuartos;


            string fileNameNomeHotel = "nomeHotel.txt";
            string fileNameNumeroQuartos = "numeroQuartos.txt";
            string nomeDoHotel = dadosMetodos.ReadTextFromFile(fileNameNomeHotel);
            #endregion

            #region Ve


            //O startup verifica na pasta do projeto se já existe ficheiros
            //do nome e numero de quartos do hotel, senão faz referencia
            if (string.IsNullOrEmpty(nomeDoHotel))
            {
                metodos.Setup(dadosMetodos, fileNameNomeHotel, fileNameNumeroQuartos);
                dadosMetodos.SerializeObject(dadosMetodos.QuartosList, "quartosData.dat");
            }
            else
            {
                Console.WriteLine($"Menu Hotel {nomeDoHotel}");
            }

            #endregion

            bool terminarPrograma = true;

            do
            {
                //Sempre que se volta ao menu principal depois uma açáo, o programa da load aos dados guardados no quartosData.dat
                loadedQuartos = dadosMetodos.DeserializeObject<List<Quarto>>("quartosData.dat");
                //Chama os menus
                main.Startup(loadedQuartos);
                terminarPrograma = true;
            } while (terminarPrograma);

        }
    }
}
