/* 
@file Dados_Metodos.cs
@author Tomás Fernandes Ferreira (a20457@alunos.ipca.pt)
@author Tiago Amadeu Silva Sousa (a20735@alunos.ipca.pt)
@brief
@date dezembro 2023
@copyright Copyright (c) 2023
*/

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using DataTier;


namespace Application_Tier
{

    
    //Classe hotelController servira para manipular dados
    public class Dados_Metodos
    {

        #region Atributos
        public string NomeHotel;
        //Estrutura para criar uma lista de quartos totais do hotel
        public List<Quarto> QuartosList { get; set; }
        #endregion



        #region Constructor
        public Dados_Metodos()
        {
            QuartosList = new List<Quarto>();

        }
        #endregion


        #region Métodos
        /// <summary>
        /// Metodo para adicionar dados num ficheiro de texto
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="text"></param>
        public void WriteTextToFile(string fileName, string text)
        {

            string currentDirectory = Environment.CurrentDirectory;

            string projectDirectory = Path.Combine(currentDirectory);


            string filePath = Path.Combine(projectDirectory, fileName);


            // Use a StreamWriter to write the string to the file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(text);
            }
        }

        
        /// <summary>
        /// Metodo para ler dados de ficheiro de texto
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string ReadTextFromFile(string fileName)
        {
            string currentDirectory = Environment.CurrentDirectory;
            string projectDirectory = Path.Combine(currentDirectory);
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



        /// <summary>
        /// Metodo para guardar a list de quartos num ficheiro binário.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fileName"></param>
        public void SerializeObject(object obj, string fileName)
        {

            string currentDirectory = Environment.CurrentDirectory;
            string projectDirectory = Path.Combine(currentDirectory);
            string filePath = Path.Combine(projectDirectory, fileName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, obj);
            }
        }

        /// <summary>
        /// Método para ir buscar os dados ao ficheiro binario
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public T DeserializeObject<T>(string fileName)
        {

            string currentDirectory = Environment.CurrentDirectory;
            string projectDirectory = Path.Combine(currentDirectory);
            string filePath = Path.Combine(projectDirectory, fileName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                return (T)binaryFormatter.Deserialize(fileStream);
            }
        }

        /// <summary>
        /// Método para adicionar quartos na lista Quartos, este método é utilizado no SETUP do programa.
        /// </summary>
        /// <param name="id"></param>
        public void AdicionarQuarto(int id)
        {
            Quarto novoQuarto = new Quarto();
            novoQuarto.QuartoID = id;
            
            QuartosList.Add(novoQuarto);

        }

        #endregion





    }
}
