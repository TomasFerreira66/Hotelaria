using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelaria
{
    public class Menus
    {

        public void MenuPrincipal()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Escolha uma opção");
            Console.WriteLine("1 - Ver informação quartos");
            Console.WriteLine("2 - Realizar Check-IN");
            Console.WriteLine("3 - Realizar Check-Out");
        }


        public void MenuQuartos()
        {
            Console.WriteLine("Escolha uma opção");
            Console.WriteLine("Mudar preço de um quarto");
            Console.WriteLine("Ver informação de um quarto");
            Console.WriteLine("Listar todos os quartos");
            Console.WriteLine("Listar quartos livres");
            Console.WriteLine("");
            Console.ReadLine();
        }


        

    }
}
