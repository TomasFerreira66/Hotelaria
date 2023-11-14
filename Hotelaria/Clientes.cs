using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelaria
{

    //Classe Clientes, está classe é do registo de clientes onde podemos obter dados pessoais do Cliente, tal como dados referentes
    //a uma reserva que o cliente faça
    public class Clientes
    {

        public int IDCliente { get; set; }
        public string Nome { get; set; }

        public int CC { get; set; }

        public Quarto QuartoAlugado;

    }
}
