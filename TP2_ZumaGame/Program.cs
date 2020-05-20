using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_ZumaGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Lista_Zuma jogo = new Lista_Zuma(); //Cria uma nova instância da Classe Lista_Zuma na qual foi implementada as funcionalidades e regras do jogo
                                                //A fim de construir o jogo, foi implementada a Lista Duplamente Encadeada que foi escolhida devido a maior
                                                //facilidade para se percorrer toda lista, encontrar e manipular os elementos na mesma através do apontador
                                                //para o elemento anterior.
            //bool continuaJogo = true;//
            int pos; //Cria uma variável inteira para armazenar a posição que o usuário deseja inserir um novo Item
            //continuaJogo = jogo.IniciarJogo();
            jogo.IniciarJogo(); //Chamada da função IniciarJogo() da Classe Lista Zuma, esta função é responsável por gerar os 8 itens que compõem a lista inicial do jogo

            jogo.processaJogo(); //Chamada da função processaJogo() da Classe Lista Zuma, esta função é responsável por verificar se existe uma sequência de 3 ou 4 itens
                                 //De mesmo tipo da Lista que foi gerada, caso haja, ela irá excluir os itens da lista e computar os pontos para o jogador. Caso tenha uma
                                 //sequência de 3 itens iguais, ela irá acrescentar 2 pontos a Pontuação Total do Jogador, caso tenha uma sequência de 4 itens iguais ela 
                                 //irá adicionar 3 pontos a Pontuação Total do Jogador.

            while (jogo.continuaJogo())//Inicia um loop, que continua o Jogo enquanto o retorno da função continuaJogo() da classe Lista_Zuma for true. É importante salientar
            {                          //dizer que esta é a função responsável por verificar se o número de itens da Lista é maior que o máximo permitido no jogo que no caso
                                       //são 20 itens. Desta forma enquanto o número de Itens for menor ou igual a 20 o jogo continua, contudo, caso seja maior que 20 o pro-
                                       //grama sai do loop e o jogo se encerra.

                try //O trecho abaixo é responsável por receber a posição que o usuário deseja inserir um novo Item. Foi utilizado o bloco try catch para o tratamento de erros
                {   //caso o usuário digite alguma tecla inválida.

                    Console.Write("\nDigite a posição que deseja inserir um novo Item: ");//Solicita ao usuário a posição que ele deseja inserir um novo elemento
                    pos = int.Parse(Console.ReadLine());//Recebe a posição digitada pelo usuário
                    Console.WriteLine();//Pula uma linha, apenas por design
                }
                catch
                {
                    pos = 0;// Caso o usuário digite um caractere inválido, é atribuído o valor 0 para a variável que recebe a posição, desta forma, não irá haver nenhuma inserção
                            //na lista não afetando o jogo.
                }
                

                jogo.InserirItem(pos);//Chamada da função InserirItem() da Classe Lista Zuma, responsável por inserir um novo Item da lista do Jogo na posição solicitada pelo usuário

                jogo.processaJogo();//Chamada novamente da função processaJogo() que conforme explicada acima, verifica se após a inserção de um novo elemento, a Lista possui uma
                                    //sequência de 3 ou 4 itens iguais, ou seja, de mesma cor.



            }

            Console.WriteLine("\nFim de Jogo - Pontuação FINAL: {0} pontos",jogo.Pontuacao); //Mostra a Pontuação Final do Jogador após o fim do jogo.
            

            Console.ReadKey();//Congela a tela até o usuário digitar uma tecla e sair do programa.
        }
    }
}
