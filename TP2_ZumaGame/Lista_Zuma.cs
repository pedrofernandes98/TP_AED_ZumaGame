using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_ZumaGame
{
    class Lista_Zuma
    {
        private const int elementosIniciais = 8;
        private const int maximo = 20;
        private Elemento Inicio;            // Primeiro elemento da lista
        private Elemento Fim;               // Último elemento da lista
        private Elemento Aux;               // Objeto auxiliar

        public int Tamanho;                 // Número de Elementos da Lista
        public int Pontuacao = 0;
        public Lista_Zuma()                      // Construtor da Classe
        {
            Inicio = null;
            Fim = null;
            Tamanho = 0;
        }

        public void InserirItem(int posicao)
        {
            Elemento Aux;
            Random x = new Random();
            int Valor = x.Next(1, 5);

            Elemento Novo = new Elemento(Valor);
            int pos = 1;

            if (posicao > Tamanho || posicao < 1)
            {
                Console.WriteLine("Não é possível inserir na posição {0} da lista!", posicao);
            }
            else
            {

                if (Inicio == null)
                {
                    Inicio = Novo;
                    Fim = Novo;

                    Novo.Prox = null;
                    Novo.Ant = null;
                }
                else
                {
                    if (posicao == 1)
                    {
                        Novo.Prox = Inicio;
                        Inicio.Ant = Novo;
                        Novo.Ant = null;
                        Inicio = Novo;
                    }
                    else if (posicao == Tamanho)
                    {
                        Fim.Prox = Novo;
                        Novo.Ant = Fim;
                        Fim = Novo;
                        Novo.Prox = null;
                    }
                    else
                    {
                        Aux = Inicio;

                        while (Aux != null && pos < posicao)
                        {
                            Aux = Aux.Prox;
                            ++pos;
                        }

                        Novo.Ant = Aux.Ant;
                        Novo.Prox = Aux;

                        Aux.Ant.Prox = Novo;
                        Aux.Ant = Novo;


                    }
                }

                Tamanho++;

                Console.WriteLine("Um Item {0} foi inserido na posição {1}!", Novo.Item.Cor, posicao);
            }
        }

        // Função para inserir um elemento no Inicio da lista
        public void InserirInicio(int Valor)
        {
            Elemento Novo = new Elemento(Valor);     // Alocação Dinâmica - Novo Elemento para a Lista

            //Novo.Num = Valor;                   // Insere o valor do elemento na lista

            if (Inicio == null)                 // A lista está vazia? Primeiro elemento...
            {
                Inicio = Novo;                  // O elemento inserido é o primeiro e o último. Guarda o endereço dele.
                Fim = Novo;

                Novo.Prox = null;               // O ponteiro para o próximo elemento passa a ser nulo
                Novo.Ant = null;                // O ponteiro para o elemento anterior passa a ser nulo
            }
            else                                // A lista já possui elementos?
            {
                Novo.Prox = Inicio;             // O elemento Novo aponta para o elemento que já havia sido inserido anteriormente
                Inicio.Ant = Novo;              // O ponteiro anterior do elemento já existente aponta para o novo elemento
                Novo.Ant = null;                // Já que é o primeiro, o ponteiro anterior aponta para null
                Inicio = Novo;                  // e o Inicio passa a ter o endereço do elemento Novo que acabou de ser inserido
            }

            Tamanho++;                          // O elemento entrou na lista
        }

        // Função para inserir um elemento no final da lista
        public void InserirFinal(int Valor)
        {
            Elemento Novo = new Elemento(Valor);     // Alocação Dinâmica - Novo Elemento para a Lista

            //Novo.Num = Valor;                   // Insere o valor do elemento na lista

            if (Inicio == null)                 // A lista está vazia? Primeiro elemento...
            {
                Inicio = Novo;                  // O elemento inserido é o primeiro e o último. Guarda o endereço dele.
                Fim = Novo;

                Novo.Prox = null;               // O ponteiro para o próximo elemento passa a ser nulo
                Novo.Ant = null;                // O ponteior para o elemento anterior para a ser nulo
            }
            else                                // A lista já possui elementos?
            {
                Fim.Prox = Novo;                // O elemento que era o último da lista aponta para o elemento inserido
                Novo.Ant = Fim;                 // O ponteiro anterior do novo elemento aponta para o que já existia
                Novo.Prox = null;               // O ponteiro próximo do novo elemento aponta para nada, já que ele é o último
                Fim = Novo;                     // Atualiza o último: o elemento final passa a ser o novo elemento inserido
            }

            Tamanho++;                          // O elemento entrou na lista

            if(Tamanho > maximo)
            {
                EncerrarJogo();
            }
        }

        //Função para mostrar todos os elementos da lista do Inicio ao Fim
        public void imprimir()
        {
            //Console.Clear();            // Limpa a tela
            int pos = 1;

            if (Inicio == null)         // Se não tem elemento na lista...
            {
                Console.WriteLine("A lista não possui nenhum elemento!!! \n\n");
                Console.ReadKey();
            }
            else                        // Se a lista tem pelo menos um elemento
            {
                Console.WriteLine("Elementos da Lista: {0}\n", Tamanho);

                Aux = Inicio;           // Pega o primeiro elemento

                while (Aux != null)     // Enquanto a lista tiver elementos que apontam para outro elemento da lista
                {
                    Console.WriteLine("{0} - {1}",pos, Aux.Item.Cor);        // Mostra o elemento,
                    ++pos;
                    Aux = Aux.Prox;                             // aponta para o próximo elemento
                }                                               // e volta

                Console.ReadKey();
            }
        }

        public void retirarItem(int posicao)
        {
            int pos = 1;
            Elemento aux = new Elemento();

            if(posicao > Tamanho || posicao < 0)
            {
                Console.WriteLine("Não existe a posição {0} da lista!", posicao);
            }
            else
            {
                if(posicao == 1)
                {
                    Inicio.Prox.Ant = null;
                    Inicio = Inicio.Prox;
                }
                else if (posicao == Tamanho)
                {
                    Fim.Ant.Prox = null;
                    Fim = Fim.Ant;
                }
                else
                {
                    aux = Inicio;

                    while(aux != null && pos < posicao)
                    {
                        aux = aux.Prox;
                        ++pos;
                    }

                    if(aux != null)
                    {
                        aux.Ant.Prox = aux.Prox;
                        aux.Prox.Ant = aux.Ant;
                    }
                    else
                    {
                        Console.WriteLine("A posição {0} não foi encontrada na lista!",posicao);
                        ++Tamanho;//Para manter o tamanho da lista
                    }

                }

                --Tamanho;
            }
        }

        //Função para mostrar todos os elementos da lista do Fim ao Inicio
        public void MostraListaFIMINI()
        {
            Console.Clear();            // Limpa a tela

            if (Inicio == null)         // Se não tem elemento na lista...
            {
                Console.WriteLine("A lista não possui nenhum elemento!!! \n\n");
                Console.ReadKey();
            }
            else                        // Se a lista tem pelo menos um elemento
            {
                Console.WriteLine("Elementos da Lista: {0}\n", Tamanho);

                Aux = Fim;              // Pega o último elemento

                while (Aux != null)     // Enquanto a lista tiver elementos que apontam para algum elemento anterior da lista
                {
                    Console.WriteLine("{0,5}", Aux.Item.Cor);        // Mostra o elemento,
                    Aux = Aux.Ant;                              // aponta para o elemento anterior
                }                                               // e volta

                Console.ReadKey();
            }
        }

        //Função para retirar um elemento da lista
        public void RetiraElemento(int Valor)
        {
            Console.Clear();                        // Limpa a tela

            if (Inicio == null)                     // Se não tem elemento na lista...
            {
                Console.WriteLine("A lista não possui nenhum elemento!!! \n\n");        // Mostra
                Console.ReadKey();
            }
            else                                    // A lista não está vazia
            {
                Aux = Inicio;                       // Pega o endereço do primeiro elemento

                int Achou = 0;                      // Variável para contar quantas vezes o elemento é encontrado na lista

                while (Aux != null)                 // Enquanto a lista tiver elementos que apontam para outro elemento da lista
                {
                    if (Aux.Item.Cod == Valor)           // O número digitado foi encontrado na lista
                    {
                        Achou++;                    // Conta ocorrência

                        if (Aux == Inicio)                  // O número a ser removido é o primeiro da lista?
                        {
                            Inicio = Aux.Prox;              // O primeiro elemento foi removido e ele ganha o endereço do da frente

                            if (Inicio != null)             // Se o elemento existe
                            {
                                Inicio.Ant = null;          // O ponteiro anterior dele não aponta para nada, já que ele é o primeiro
                            }

                            Aux = Inicio;                   // Armazena o endereço dele para o próximo uso

                            Tamanho--;                      // Diminui o tamanho da lista
                        }
                        else if (Aux == Fim)                // O número a ser removido é o último da lista?
                        {
                            Fim = Fim.Ant;                  // Ele ganha o endereço do último
                            Fim.Prox = null;                // e o ponteiro próximo aponta para nada, já que ele é o último
                            Aux = null;                     // O Aux agora também aponta para nada

                            Tamanho--;                      // Diminui o tamanho da lista
                        }
                        else                                // O número a ser removido está no meio da lista?
                        {
                            // Um pouco mais confuso...

                            // O endereço próximo do elemento anterior ao elemento atual (que será removido)
                            // terá o endereço do elemento posterior ao elemento atual
                            Aux.Ant.Prox = Aux.Prox;

                            // O endereço anterior do elemento posterior ao elemento atual
                            // terá o endereço do elemento anterior ao elemento atual
                            Aux.Prox.Ant = Aux.Ant;

                            Aux = Aux.Prox;                 // Próximo elemento

                            Tamanho--;                      // Diminui o tamanho da lista
                        }
                    }
                    else                                    // reposiciona para o próximo elemento da lista
                    {
                        Aux = Aux.Prox;
                    }
                }                                           // e volta para nova pesquisa

                if (Achou == 0)                             // Não encontrou o número na lista
                {
                    Console.WriteLine("O valor {0} não foi encontrado na lista!!! \n", Valor);
                }
                else if (Achou == 1)                        // Achou uma ocorrência
                {
                    Console.WriteLine("O valor {0} foi encontrado na lista e removido!!! \n", Valor);
                }
                else                                        // Achou mais de uma ocorrência
                {
                    Console.WriteLine("O valor {0} foi encontrado {1} vezes na lista e removido!!! \n", Valor, Achou);
                }

                Console.WriteLine("Número de Elementos da Lista: {0}\n\n", Tamanho);
                Console.ReadKey();
            }
        }

        //Função para esvaziar toda a lista
        public void EsvaziarLista()
        {
            if (Inicio == null)                     // Se não tem elemento na lista...
            {
                Console.WriteLine("A lista não possui nenhum elemento!!! \n\n");        // Mostra
                Console.ReadKey();
            }
            else                                    // A lista não está vazia
            {
                Inicio = null;                      // O Inicio da Lista não aponta para ninguém...
                Tamanho = 0;
            }
        }

        public void trocarElementos(int m, int n)
        {
            Console.Clear();
            //Elemento anterior;
            Elemento aux = null;
            int pos = 1;
            Elemento M, N;
            Elemento auxAnt, auxProx;

            if (Inicio == null)
            {
                Console.WriteLine("A lista não possui nenhum elemento!!! \n\n");        // Mostra
                Console.ReadKey();
            }
            else
            {
                if (m > Tamanho && n > Tamanho || (m > Tamanho && n < 1) || (n > Tamanho && m < 1) || m < 1 && n < 1)
                {
                    Console.WriteLine("Não existem as posiçãoes {0} e {1} na lista!", m, n);
                }
                else if (m > Tamanho || m < 1)
                {
                    Console.WriteLine("Não existe a posição {0} na lista!", m);
                }
                else if (n > Tamanho || n < 1)
                {
                    Console.WriteLine("Não existe a posição {0} na lista!", n);
                }
                else
                {
                    aux = Inicio;
                    M = null;
                    N = null;

                    while (aux != null && (M == null || N == null))
                    {
                        if (pos == m)
                        {
                            M = aux;
                        }

                        if (pos == n)
                        {
                            N = aux;
                        }

                        aux = aux.Prox;
                        ++pos;
                    }


                    if (M != null && N != null)
                    {

                        //Guarda Referências de M

                        auxAnt = M.Ant;
                        auxProx = M.Prox;

                        //Atualiza Referências dos Elementos Anteriores e Próximos

                        if (m == 1)
                        {
                            Inicio = N;
                            if (n == Tamanho)
                            {
                                Fim = M;
                                M.Prox.Ant = N;
                                N.Ant.Prox = M;
                            }
                            else
                            {
                                M.Prox.Ant = N;
                                N.Ant.Prox = M;
                                N.Prox.Ant = M;
                            }


                        }
                        else if (n == 1)
                        {
                            Inicio = M;
                            if (m == Tamanho)
                            {
                                Fim = N;
                                M.Ant.Prox = N;


                                N.Prox.Ant = M;
                            }
                            else
                            {
                                M.Ant.Prox = N;
                                M.Prox.Ant = N;

                                N.Prox.Ant = M;
                            }


                        }
                        else
                        {
                            if (m == Tamanho)
                            {
                                Fim = N;
                                M.Ant.Prox = N;

                                N.Ant.Prox = M;
                                N.Prox.Ant = M;
                            }
                            else if (n == Tamanho)
                            {
                                Fim = M;
                                M.Ant.Prox = N;
                                M.Prox.Ant = N;
                                N.Ant.Prox = M;

                            }
                            else
                            {
                                M.Ant.Prox = N;
                                M.Prox.Ant = N;
                                N.Ant.Prox = M;
                                N.Prox.Ant = M;
                            }

                        }

                        //Troca m

                        M.Ant = N.Ant;
                        M.Prox = N.Prox;

                        //Troca n

                        N.Ant = auxAnt;
                        N.Prox = auxProx;

                        Console.WriteLine("Os elementos da posição {0} e {1} foram trocados!\n", m, n);

                        imprimir();
                    }
                    
                }

                Console.ReadKey();
            }
        }

        public bool IniciarJogo()
        {
            Random x = new Random();
            //Elemento Aux;
            for (int i = 0; i < elementosIniciais ; i++)
            {
                InserirFinal(x.Next(1,5));
            }

            Console.WriteLine("Jogo iniciado! \n\n");

            //imprimir();

            return true;
        }

        public int GerarNovaCor()
        {
            Random x = new Random();
            int cod = x.Next(1, 5);

            return cod;
        }

        public bool EncerrarJogo()
        {
            Console.WriteLine("O número de elementos da lista passou do Máximo permitido, você perdeu!");
            return false;
        }

        public bool continuaJogo()
        {
            if(Tamanho > maximo)
            {
                return EncerrarJogo();
            }

            return true;
        }

        public Elemento retornarItemPorPosicao(int posicao)
        {
            Elemento Aux = new Elemento();
            int pos = 1;
            Aux = Inicio;

            while(Aux != null && pos < posicao)
            {
                Aux = Aux.Prox;
                ++pos;
            }

            if(Aux == null)
            {
                Console.WriteLine("A posição {0} não foi encontrada na lista!");
            }

            return Aux;
        }

        public void processaJogo()
        {
            Elemento aux = new Elemento();
            int contCor = 0;
            string corAnt = "";
            int pos = 1;
            bool sequencia4Elementos = false;

            imprimir();

            //Verificar se existe sequencia de 3 ou 4 cores iguais

            aux = Inicio;
            corAnt = Inicio.Item.Cor;
            ++contCor;
            aux = aux.Prox;
            while (aux != null && contCor < 3)
            {
                if(aux.Item.Cor == corAnt)
                {
                    ++contCor;
                }
                else
                {
                    corAnt = aux.Item.Cor;
                    contCor = 1;
                }

                aux = aux.Prox;
                ++pos;
            }

            if(contCor >= 3)
            {
                if(aux.Prox != null)//Necessário pois se o elemento estiverr na última posição da erro
                {
                    if (aux.Prox.Item.Cor == aux.Ant.Item.Cor)
                    {
                        ++pos;
                        ++contCor;
                        Console.WriteLine("Os elementos {0} - {1} - {2} - {3} possuem a mesma cor. Você ganhou 3 pontos!", pos - 3, pos - 2, pos - 1, pos);
                        Pontuacao += 3;
                    }
                    else
                    {
                        Console.WriteLine("Os elementos {0} - {1} - {2} possuem a mesma cor. Você ganhou 2 pontos!", pos - 2, pos - 1, pos);
                        Pontuacao += 2;
                    }
                }
                else
                {
                    Console.WriteLine("Os elementos {0} - {1} - {2} possuem a mesma cor. Você ganhou 2 pontos!", pos - 2, pos - 1, pos);
                    Pontuacao += 2;
                }


                for (int i = pos; i > pos - contCor; i--)
                {
                    retirarItem(i);
                }

                processaJogo();
            }
            else
            {
                Console.WriteLine("Não existem sequências para pontuar!");
            }


        }
    }
}
