using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_ZumaGame
{
    public class Item
    {
        public int Cod;
        public string Cor;

        public Item(int cod)
        {
            switch (cod)
            {
                case 1:
                    Cor = "Amarelo";
                    break;

                case 2:
                    Cor = "Azul";
                    break;

                case 3:
                    Cor = "Vermelho";
                    break;

                case 4:
                    Cor = "Verde";
                    break;

                default:
                    Cor = "";
                    break;
            }
        }
    }

    public class Elemento
    {
        public Item Item;
        public Elemento Prox;
        public Elemento Ant;

        public Elemento(int cod)
        {
            Item = new Item(cod);
            Prox = null;
            Ant = null;
        }

        public Elemento()
        {
            Item = null;
            Prox = null;
            Ant = null;
        }
    }
}
