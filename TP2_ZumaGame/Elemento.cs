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

        public Item(int cod) //Construtor da classe que recebe um código como parâmetro 
        {
            Cod = cod;//Atribui o código para o atributo código
            switch (cod)//Atribui a cor do Item de acordo com o código passado seguindo a regra a seguir:
            {           //1 - Amarelo, 2 - Azul, 3 - Vermelho e 4 - Verde
                        //Caso o código seja diferente desses valores, nenhuma cor é atribuída 
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

        public Elemento(int cod) // Construtor da Classe, recebe um inteiro como parâmetro para instânciar um novo Item
        {
            Item = new Item(cod);
            Prox = null;
            Ant = null;
        }

        public Elemento() //Construtor da Classe caso não seja passado nenhum parâmetro
        {
            Item = null;
            Prox = null;
            Ant = null;
        }
    }
}
