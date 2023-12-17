/* 
@file Quarto.cs
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
using System.IO;

namespace DataTier
{
    [Serializable]
    public class Quarto
    {

        #region attributes
        private int quartoID;

        //Variavel para guardar a informação de cada cliente de cada quarto
        public Clientes Cliente { get; set; }
        public Reservas Reserva { get; set; }
        //Variavel Estado (se está Ocupado ou não)
        private string estado;
        public DateTime DataCheckIn { get; set; }
        private int preco;

        #endregion

        #region Constructor

        public Quarto()
        {
            estado = "Disponivel";
            preco = 50;
            Cliente = new Clientes();
            Reserva = new Reservas();
        }

        #endregion

        #region Properties
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


        #endregion

    }
}
