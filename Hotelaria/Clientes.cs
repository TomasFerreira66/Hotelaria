/* 
@file Clientes.cs
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



namespace Hotelaria
{

    //Classe Clientes, está classe é do registo de clientes onde podemos obter dados pessoais do Cliente

    [Serializable]
    public class Clientes
    {

        #region Atributos
        private string nome;
        private int cc;
        private int telemovel;
        private string email;
        #endregion


        #region Propriedades
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int CC
        {
            get { return cc; }
            set { cc = value; }
        }

        public int Telemovel
        {
            get { return telemovel; }
            set { telemovel = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        #endregion

        #region Contrutor
        public Clientes()
        {

            email = "TESTE";
            CC = 123456789;

        }
        #endregion

    }
}
