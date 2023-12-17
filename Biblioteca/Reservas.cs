using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataTier
{

    [Serializable]
    public class Reservas
    {

        private int precototal;
        private int duracaoEstadia;

        public int PrecoTotal
        {
            get { return precototal; }
            set { precototal = value; }
        }

        public int DuracaoEstadia
        {
            get { return duracaoEstadia; }
            set { duracaoEstadia = value; }
        }

    }
}
