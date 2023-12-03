using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelaria
{
    
    public  class Quarto
    {

        private int quartoID { get; set; }

        //Variavel para guardar a informação de cada cliente de cada quarto
        public Clientes Cliente { get; set; }
        //Variavel Estado (se está Ocupado ou não)
        private bool estado { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }
        private int preco { get; set;}

        public int QuartoID
        {
            get { return quartoID; }
            set { quartoID = value; }

        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }

        }
        public int Preco
        {
            get { return preco; }
            set { preco = value; }

        }




    }
}
