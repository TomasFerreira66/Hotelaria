using System;
//para escrever em ficheiros
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelaria
{

    //Classe hotel servira para relacionar dados e construir funções usando as outras classes
    public class Hotel
    {

        public string NomeHotel;
        //Estrutura para criar uma lista de quartos totais do hotel
        public List<Quarto> Quartos { get; set; }
     

        // Construtor
        public Hotel()
        {
            Quartos = new List<Quarto>();

        }

        // Método para adicionar um quarto com base no numero pedodp
        public void AdicionarQuarto(int id)
        {
            Quarto novoQuarto = new Quarto { QuartoID = id};
            Quartos.Add(novoQuarto);
            
        }


        //função para adicionar o nome do hotel
        public void WriteTextToFile(string filePath, string text)
        {
            // Use a StreamWriter to write the string to the file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(text);
            }
        }

    }
}
