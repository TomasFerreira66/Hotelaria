/* 
@file InfoQuartos.cs
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

namespace Presentation_Tier
{
    public class InfoQuartos
    {

        public void MenuQuartos()
        {
            Console.WriteLine("1. Mudar preço de um quarto");
            Console.WriteLine("2. Ver informação de um quarto");
            Console.WriteLine("3. Listar todos os quartos");
            Console.WriteLine("4. Listar quartos disponiveis/ocupados/Reservados");
            Console.WriteLine("5. Voltar");
            Console.WriteLine("");

        }

        public int MenuQuartosEscolha()
        {
            try
            {
                Console.Write("Escolha:");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Por favor, insira um número válido.");
                return MenuQuartosEscolha(); // Recursively call the method to get a valid input
            }
        }

    }
}
