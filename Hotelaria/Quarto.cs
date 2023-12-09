using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Hotelaria
{
    [Serializable]
    public  class Quarto
    {

        private int quartoID { get; set; }

        //Variavel para guardar a informação de cada cliente de cada quarto
        public Clientes Cliente { get; set; }
        //Variavel Estado (se está Ocupado ou não)
        private string estado { get; set; }
        public DateTime DataCheckIn { get; set; }
        private int preco { get; set;}


        public Quarto()
        {
            estado = "Disponivel";
            preco = 0;
            Cliente = new Clientes();
        }

        public int QuartoID
        {
            get { return quartoID; }
            set { quartoID = value; }

        }

        public string Estado
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
