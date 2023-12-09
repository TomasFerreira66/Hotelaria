using System;
//para escrever em ficheiros
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Hotelaria
{

    
    //Classe hotelController servira para manipular dados
    public class HotelController
    {

        public string NomeHotel;
        //Estrutura para criar uma lista de quartos totais do hotel
        public List<Quarto> QuartosList { get; set; }
     

        // Construtor
        public HotelController()
        {
            QuartosList = new List<Quarto>();

        }



        //função para adicionar o nome do hotel e o numero de quartos
        public void WriteTextToFile(string fileName, string text)
        {

            string currentDirectory = Environment.CurrentDirectory;

            string projectDirectory = Path.Combine(currentDirectory, "..//..");


            string filePath = Path.Combine(projectDirectory, fileName);


            // Use a StreamWriter to write the string to the file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(text);
            }
        }

        public string ReadTextFromFile(string fileName)
        {
            string currentDirectory = Environment.CurrentDirectory;
            string projectDirectory = Path.Combine(currentDirectory, "..//..");
            string filePath = Path.Combine(projectDirectory, fileName);

            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            else
            {
              
                return null; // or throw an exception, depending on your application's requirements
            }
        }



        //Metodo para serializar a lista e guardar dados
        public void SerializeObject(object obj, string fileName)
        {

            string currentDirectory = Environment.CurrentDirectory;
            string projectDirectory = Path.Combine(currentDirectory, "..//..");
            string filePath = Path.Combine(projectDirectory, fileName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, obj);
            }
        }

        public T DeserializeObject<T>(string fileName)
        {

            string currentDirectory = Environment.CurrentDirectory;
            string projectDirectory = Path.Combine(currentDirectory, "..//..");
            string filePath = Path.Combine(projectDirectory, fileName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                return (T)binaryFormatter.Deserialize(fileStream);
            }
        }

        // Método para adicionar um quarto com base no numero pedido
        public void AdicionarQuarto(int id)
        {
            Quarto novoQuarto = new Quarto();
            novoQuarto.QuartoID = id;
          
            QuartosList.Add(novoQuarto);

        }





    }
}
