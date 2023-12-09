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
        private string nome;
        private int cc;
        private int telemovel;
        private string email;

        
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

        public Clientes()
        {

            email = "TESTE";


        }


    }
}
