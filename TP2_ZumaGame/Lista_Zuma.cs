using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_ZumaGame
{
    class Lista_Zuma
    {
        private const int elementosIniciais = 8; //Variável constante responsável por armazenar a quantidade de elementos que irão iniciar a lista do jogo
        private const int maximo = 20;// Variável constante que indica o número máximo de Itens na lista do Jogo, caso o número de Itens fique maior que este, o jogo se encerra.

        private Elemento Inicio;            // Primeiro elemento da lista
        private Elemento Fim;               // Último elemento da lista
        private Elemento Aux;               // Objeto auxiliar

        public int Tamanho;                 // Número de Elementos da Lista
        public int Pontuacao = 0;           // Pontuação Total do Jogador
        public Lista_Zuma()                      // Construtor da Classe
        {
            Inicio = null;
            Fim = null;
            Tamanho = 0;
        }

        //Função responsável por inserir um novo Item na posição selecionada pelo usuário
        public void InserirItem(int posicao)
        {
            Elemento Aux; 
            Random x = new Random();//Instância uma variável rândômica
            int Valor = x.Next(1, 5);//Sorteia um número de 1 a 4 que irá indicar o atributo Cod do elemento, que será utilizado para gerar uma cor.

            Elemento Novo = new Elemento(Valor);//Instância um novo elemento da Lista passando o valor sorteado como parâmetro.
            int pos = 1;//Inicializa a variável pos utilizada para controlar em qual posição se está o elemento que está manipulando na lista

            if (posicao > Tamanho + 1 || posicao < 1)//Verifica se a posição solicitada pelo usuário é válida
            {
                Console.WriteLine("Não é possível inserir na posição {0} da lista!", posicao); //Caso a posição não seja válida exibe mensagem informando
            }
            else
            {
                if (Inicio == null) // Verifica se a lista está vazia, caso o esteja o novo elemento será colocado na primeira posição e o apontador de Inicio da lista irá apontar para ele
                {
                    Inicio = Novo; // Aponta o Inicio da Lista para o novo Elemento.
                    Fim = Novo;// Aponta o Fim da Lista para o novo Elemento.

                    Novo.Prox = null; // Atribui null para o Prox do elemento
                    Novo.Ant = null; // Atribui null para o Ant do elemento
                }
                else
                {
                    if (posicao == 1) //Verifica se o usuário solicitou para inserir no primeiro elemento da lista, caso seja inserido na posição 1 da Lista e o apontador de Inicio da lista irá apontar para ele
                    {
                        Novo.Prox = Inicio; // O elemento Novo aponta para o elemento que já havia sido inserido anteriormente e que era o elemento Inicial da lista
                        Inicio.Ant = Novo; // O ponteiro anterior do elemento já existente aponta para o novo elemento
                        Novo.Ant = null; // Já que é o primeiro, o ponteiro anterior aponta para null
                        Inicio = Novo; //O Início da Lista aponta para o endereço do elemento Novo que acabou de ser inserido
                    }
                    else if (posicao == Tamanho + 1) //Verifica se o usuário solicitou para inserir no último elemento da lista, desta forma o apontador Fim deve apontar para o endereço do novo elemento a ser inserido
                    {
                        Fim.Prox = Novo; // O elemento que era o último da lista aponta para o elemento inserido
                        Novo.Ant = Fim; // O ponteiro anterior do novo elemento aponta para o que já existia
                        Fim = Novo; // Atualiza o último: o elemento final passa a ser o novo elemento inserido 
                        Novo.Prox = null; // O ponteiro próximo do novo elemento aponta para null, já que ele é o último
                    }
                    else // Se não é o primeiro nem a última posição da lista
                    {
                        Aux = Inicio; //A variável auxiliar aponta para o início da Lista

                        while (Aux != null && pos < posicao)//Percorre a lista até encontrar a posição desejada pelo o usuário ou até o fim da Lista
                        {
                            Aux = Aux.Prox; // Atribui a variável aux o próximo elemento da Lista
                            ++pos; //Incrementa pos
                        }

                        //Quando sair do loop, a variável Aux estará com o elemento que está na posição ao qual será inserido o novo elemento

                        Novo.Ant = Aux.Ant; //O Novo elemento a ser inserido irá ter o seu Ant apontando para o Ant do elemento que já estava na Lista
                        Novo.Prox = Aux; //O Prox do Novo elemento irá apontar para o elemento que já estava na lista

                        Aux.Ant.Prox = Novo; //O Prox do elemento Ant do elemento que já estava na lista irá apontar para o Novo elemento
                        Aux.Ant = Novo; // E o Ant do elemento que já estava na Lista irá apontar para o novo elemento 


                    }
                }

                Tamanho++; //Irá incrementar o Tamanho de Itens na Lista após a inserção de um novo elemento

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

            if(Tamanho > maximo)// Caso o Tamanho da lista seja maior que o máximo permitido pelo jogo chama a função responsável por encerrar o jogo.
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
                Console.WriteLine("\nElementos da Lista: {0}\n", Tamanho);

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

        //Função para retirar um elemento da lista passando como parâmentro a posição do elemento
        public void retirarItem(int posicao)
        {
            int pos = 1; //Inicializa a uma variável que irá guardar a posição do elemento que se está atualmente na lista
            Elemento aux = new Elemento();//Instância um elemento auxiliar para percorrer a lista

            if(posicao > Tamanho || posicao < 0)//Verifica se a posição que deseja-se retirar existe na lista
            {
                Console.WriteLine("Não existe a posição {0} da lista!", posicao);//Caso não exista a posição, informa ao usuário
            }
            else
            {//Caso exista
                if(posicao == 1)//Verifica se foi solicitado para retirar a primeira posição de forma a atualizar o apontador de Início da Lista
                {
                    Inicio.Prox.Ant = null; //O anterior do elemento Prox do primeiro elemento da lista, recebe null, de forma a retirar o primeiro elemento da lista
                    Inicio = Inicio.Prox; // O primeiro elemento foi removido e o apontador de Início aponta para o elemento da frente
                }
                else if (posicao == Tamanho)//Verifica se foi solicitado para retirar a última posição de forma a atualizar o apontador de Fim da Lista
                {
                    Fim.Ant.Prox = null;//O Prox do elemento anterior ao último elemento da lista recebe null, de forma a retirar o último elemento da lista
                    Fim = Fim.Ant;// O último elemento foi removido e o apontador de Fim aponta para o elemento anterior
                }
                else
                {//Caso não seja nem o primeiro nem o último elemento da lista
                    aux = Inicio;//A variável auxiliar aponta para o início da lista

                    while(aux != null && pos < posicao)//Percorre a lista até encontrar a posição do elemento que deseja-se retirar ou até o fim da Lista
                    {
                        aux = aux.Prox;//Atualiza a variável aux para o próximo elemento da lista
                        ++pos;//Atualiza a posição em que se está percorrendo na lista
                    }

                    //Quando sair do loop, a variável Aux estará com o elemento que está na posição ao qual será inserido o novo elemento

                    if (aux != null)//Verifica se aux não está nula
                    {
                        aux.Ant.Prox = aux.Prox; // O endereço próximo do elemento anterior ao elemento atual (que será removido)
                                                 // terá o endereço do elemento posterior ao elemento atual
                        aux.Prox.Ant = aux.Ant; // O endereço anterior do elemento posterior ao elemento atual
                                                // terá o endereço do elemento anterior ao elemento atual
                    }
                    else
                    {
                        Console.WriteLine("A posição {0} não foi encontrada na lista!",posicao);//Caso aux esta nulo o elemento não foi encontrado na lista
                        ++Tamanho;//Para manter o tamanho da lista
                    }

                }

                --Tamanho; //Atualiza o tamanho da lista após a retirada do elemento
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

        
        //Função responsável por inicializar o jogo atravel da Inserção dos 8 Elementos Iniciais da Lista do Jogo
        public void IniciarJogo()
        {
            Random x = new Random(); //Instância uma variável rândômica
            //Elemento Aux;
            for (int i = 0; i < elementosIniciais ; i++) //Cria um loop que se repete 8 vezes a fim de Inserir os 8 Elementos Iniciais no Final da Lista
            {
                InserirFinal(x.Next(1,5)); //Chama a função InserirFinal() que irá inserir um novo elemento, passando por parâmetro um código de 1 a 4 sorteado pela variável randômica e que será utilizada para determinar a cor do Item
            }

            Console.WriteLine("Jogo iniciado! \n\n");//Exibe para o usário que o jogo foi iniciado

            //imprimir();

            //return true;
        }

        //Função responsável por encerrar o Jogo e que retorna false, fazendo com que o programa saia do Loop que continua o jogo.
        public bool EncerrarJogo()
        {
            Console.WriteLine("O número de elementos da lista passou do Máximo permitido, você perdeu!"); //Exibe uma mensagem para o usuário informando que o jogo acabou.
            return false;// retorna false
        }

        //Função responsável por verificar se o Jogo deve continuar ou não de acordo com o Tamanho da Lista de Elementos verificar=ndo se o número de itens da Lista é maior que o máximo permitido no jogo que no caso
        //são 20 itens
        public bool continuaJogo()
        {
            if(Tamanho > maximo)//Verifica se o tamanho da Lista é maior que o número máximo de elementos permitidos na Lista do jogo.
            {
                return EncerrarJogo();//Caso o número de elemento seja maior que o máximo que é chama a função EncerrarJogo() responsável por retornar false fazendo com que o Loop do Jogo termine.
            }

            return true; //Caso o tamanho da Lista não seja maior que o máximo permitido retorna true a fim de dar continuidade no jogo.
        }


        //Esta função é responsável por verificar se existe uma sequência de 3 ou 4 itens
        //De mesmo tipo da Lista que foi gerada, caso haja, ela irá excluir os itens da lista e computar os pontos para o jogador. Caso tenha uma
        //sequência de 3 itens iguais, ela irá acrescentar 2 pontos a Pontuação Total do Jogador, caso tenha uma sequência de 4 itens iguais ela 
        //irá adicionar 3 pontos a Pontuação Total do Jogador.
        public void processaJogo()
        {
            Elemento aux = new Elemento();//Instância um elemento auxiliar para percorrer a lista;
            int contCor = 0;//Cria uma variável para contar o número de cores que são iguais e estão em sequência na Lista e atribui 0 a ela
            string corAnt = "";//Cria e inicializa uma variável que será utilizada para verificar a cor do elemento anterior
            int pos = 1;//Cria e inicializa uma variável com 1 que será utilizada para percorrete entre as posições da Lista
            //bool sequencia4Elementos = false;

            imprimir();//Imprime a lista para o usuário
            Console.WriteLine();//Pula uma linha, apenas por design

            //Verificar se existe sequencia de 3 ou 4 cores iguais

            aux = Inicio; //Aponta a variável auxiliar para o início da Lista
            corAnt = Inicio.Item.Cor; //Guarda o valor da Cor do Item que está no início da lista
            ++contCor;//Incrementa o contCor
            aux = aux.Prox; // Passa a variável auxiliar para o próximo elemento da Lista
            while (aux != null && contCor < 3)//Entra em um loop que verifica se exitem 3 elementos de mesma cor em sequência na lista, para tal usa a variável contCor para contar quantos elementos de mesma cor estão em sequencia.
            {
                if(aux.Item.Cor == corAnt)//Verifica se a cor do Item atual é igual a do Item anterior 
                {
                    ++contCor; //Caso as cores sejam iguais, incremento o contCor
                }
                else // Caso as cores sejam diferentes,
                {
                    corAnt = aux.Item.Cor;// Atribuir a variável corAnt para a cor do Item atual
                    contCor = 1; //Retorna a variável contCor para um
                }

                aux = aux.Prox;// Passa a variável auxiliar para o próximo elemento da Lista
                ++pos;//Incrementa a posição que se está na lista
            }

            //Quando sai do loop a variavel aux está com o elemento Prox do último elemento que teve a cor semelhante em uma sequencia de 3 elementos iguais ou com null, caso tenha percorrido a lista toda sem encontrar nenhuma sequencia de elementos iguais.

            if(contCor >= 3) // Caso a variável contCor tenha encontrado 3 ou mais elementos de mesma cor em sequência na lista, será necessário excluir esse elementos da lista e contabilizar os pontos para o usuário
            {
                if(aux != null)//Verifica se a variável aux está nula
                {
                    if (aux.Item.Cor == aux.Ant.Item.Cor)//Caso não esteja nula, verifica se o item atual tem a cor igual a ao elemento anterior que faz parte da sequencia de 3 a ser excluída
                    { //Se as cores forem iguais, a sequência é de 4 Itens com as cores iguais e deve-se acrescentar 3 pontos na pontuação e retirar os 4 Itens da Lista.
                        ++pos; //Incrementa a posição
                        ++contCor; //Incrementa a quantidade de cores iguais em sequência
                        Console.WriteLine("Os elementos {0} - {1} - {2} - {3} possuem a mesma cor. Você ganhou 3 pontos!", pos - 3, pos - 2, pos - 1, pos);// Informa ao usuário que encontrou uma sequência de 4 itens iguais na lista, a posição em que esses itens estão na lista e a pontução que o usuário ganhou. 
                        Pontuacao += 3;//Acrescenta 3 pontos a pontução do usuário
                    }
                    else
                    {
                        //Se as cores não forem iguais, a sequência é de 3 Itens com as cores iguais e deve-se acrescentar 2 pontos na pontuação e retirar os 3 itens
                        Console.WriteLine("Os elementos {0} - {1} - {2} possuem a mesma cor. Você ganhou 2 pontos!", pos - 2, pos - 1, pos);// Informa ao usuário que encontrou uma sequência de 3 itens iguais na lista, a posição em que esses itens estão na lista e a pontução que o usuário ganhou. 
                        Pontuacao += 2;//Acrescenta 2 pontos a pontução do usuário
                    }
                }
                else
                {
                    //Se a variável aux está nula, significa a sequência é de 3 Itens com as cores iguais e encontra-se no final da lista e não é óssível ser de 4 itens. Logo deve-se acrescentar 2 pontos na pontuação e retirar os 3 itens
                    Console.WriteLine("Os elementos {0} - {1} - {2} possuem a mesma cor. Você ganhou 2 pontos!", pos - 2, pos - 1, pos); // Informa ao usuário que encontrou uma sequência de 3 itens iguais na lista, a posição em que esses itens estão na lista e a pontução que o usuário ganhou. 
                    Pontuacao += 2;//Acrescenta 2 pontos a pontução do usuário
                }


                for (int i = pos; i > pos - contCor; i--)//Inicia um loop para que retire os itens que estão em uma sequência de cores iguais
                {
                    retirarItem(i);//Chama a função retirarItem() passando a posição do item a ser retirado
                }

                processaJogo();//Chama novamente a função processaJogo() a fim de verificar se após a retirada dos itens em sequência, surgiu uma nova sequência de 3 ou 4 itens de mesma cor na lista.
            }
            else
            { //Caso a variável contCor não tenha encontrado uma sequência de 3 ou 4 itens de mesma cor
                Console.WriteLine("Não existem sequências para pontuar!");//Informa ao usuário que não foi encontrada nenhuma sequeêcia de itens de mesma cor e não é possível pontuar.
            }


        }
    }
}
