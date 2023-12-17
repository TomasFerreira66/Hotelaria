
/* 
@file HotelController.cs
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
    public class MenuPrincipal
    {

        #region Menus
        //Menu principal e respetivos metodos

        public void Menu()
        {
           
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

      
        #endregion

    }
}
