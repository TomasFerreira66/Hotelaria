using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelaria
{
    
    public  class Quarto
    {

        public int quartoID { get; set; }

        //Variavel para guardar a informação de cada cliente de cada quarto
        public Clientes Cliente { get; set; }
        //Variavel Estado (se está Ocupado ou não)
        public bool Estado { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }
        public int Preco { get; set;}



         


    }
}
