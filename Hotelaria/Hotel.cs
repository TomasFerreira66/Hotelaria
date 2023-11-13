using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelaria
{
    public class Hotel
    {

        public List<Quarto> Quartos { get; set; }

        // Construtor padrão
        public Hotel()
        {
            Quartos = new List<Quarto>();
        }

        // Método para adicionar um quarto com base no ID
        public void AdicionarQuarto(int id)
        {
            Quarto novoQuarto = new Quarto { quartoID = id };
            Quartos.Add(novoQuarto);
        }
    }
}
