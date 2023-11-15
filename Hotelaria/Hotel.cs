﻿using System;
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
            Quarto novoQuarto = new Quarto { quartoID = id};
        
            Quartos.Add(novoQuarto);
            
        }

    }
}
