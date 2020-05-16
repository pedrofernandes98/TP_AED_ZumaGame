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
            Lista_Zuma jogo = new Lista_Zuma();
            bool continuaJogo = true;
            int pos;
            continuaJogo = jogo.IniciarJogo();
            jogo.processaJogo();

            while (jogo.continuaJogo())
            {
                try
                {
                    Console.Write("Digite a posição que deseja inserir um novo Item: ");
                    pos = int.Parse(Console.ReadLine());
                }
                catch
                {
                    pos = 0;
                }
                

                jogo.InserirItem(pos);

                jogo.processaJogo();
                

                
            }

            Console.WriteLine("Fim de Jogo - Pontuação FINAL: {0} pontos",jogo.Pontuacao);
            

            Console.ReadKey();
        }
    }
}
