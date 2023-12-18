/* 
@file Reservas.cs
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
