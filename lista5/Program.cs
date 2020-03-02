using System;
using System.Collections.Generic;
using System.Text;

namespace lista5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ex1 - Crie um programa que colete 5 números inseridos pelo usuário e armazene estes números em algum tipo de lista.Imprima a lista nas seguintes formas:
            //1 - Original, na ordem digitada.
            //2 - Ordenada crescente
            //3 - Ordenada decrescente
            //4 - Total de itens.

            Exercicio1();

            //Ex2 - Crie um programa que colete 5 nomes de sites e suas urls, inseridos pelo usuário, e armazene em algum tipo de lista. 
            //O nome do site e a url devem ser requisitados ao usuário em duas perguntas diferentes. 
            //Ex. “Digite o nome do site:” < enter > “Digite a url do site” < enter >
            //Após armazenar os dados acima, desenvolva os passos:
            //1 - Crie um menu com duas opções. 1 - Achar um site e 2 Sair.
            //2 - Caso escolhido 1: requisite ao usuário o nome do site.
            //3 - Após digitado, busca na lista e imprima qual a url do site digitado. 
            //4 - Volte ao menu do passo 1 para nova escolha.
            //5 - Caso escolhi 2, fechar o programa.

            Exercicio2();


            //Ex.3 - Crie um programa que monte um menu com as opções 1 - Inserir número, 2 - Remover número e 3 - sair.
            //1 - Caso escolhido 1: requisite ao usuário um número e armazene.Imprima a lista sempre após a inserção.Volte para o menu.
            //2 - Caso escolhido 2, remova da lista o ***último*** número inserido.Imprima a lista após a exclusão. Volte para o menu.
            //3 - Caso escolhi 3, fechar o programa.

            Exercicio3();
            

            //Ex.4 - Crie um programa que monte um menu com as opções 1 - Inserir número, 2 - Remover número e 3 - sair.
            //1 - Caso escolhido 1: requisite ao usuário um número e armazene.Imprima a lista sempre após a inserção.Volte para o menu.
            //2 - Caso escolhido 2, remova da lista o ***primeiro*** número inserido.Imprima a lista após a exclusão. Volte para o menu.
            //3 - Caso escolhi 3, fechar o programa.

            Exercicio4();

            
        }

        static void Exercicio1()
        {  
            List<int> numberList = new List<int>();
            bool sair = true;
            do
            {
                StringBuilder menu = new StringBuilder();
                menu.Append("\n### Escolha uma opcao:   ###");
                menu.Append("\n1 - Inserir os numeros");
                menu.Append("\n2 - Imprimir numeros na ordem digitada");
                menu.Append("\n3 - Imprimir numeros na ordem crescente");
                menu.Append("\n4 - Imprimir numeros na ordem decrescente");
                menu.Append("\n5 - Imprimir o total de itens contidos na lista");
                menu.Append("\n6 - Sair");

                Console.WriteLine(menu);

                int op = int.Parse(Console.ReadLine());
                if (op == 6)
                    sair = false;
                else if (op == 1)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine("\nDigite um número:");
                        int num = Convert.ToInt32(Console.ReadLine());
                        numberList.Add(num);
                    }
                }
                else if (op == 2)
                {
                    Console.WriteLine("\nOs numeros foram inseridos nesta ordem: ");
                    foreach (var item in numberList)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (op == 3)
                {
                    Console.WriteLine("\nOs numeros em ordem crescente sao: ");
                    numberList.Sort();
                    foreach (var item in numberList)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (op == 4)
                {
                    Console.WriteLine("\nOs numeros em ordem decrescente sao: ");
                    numberList.Reverse();
                    foreach (var item in numberList)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (op == 5)
                {
                    Console.WriteLine($"\nA lista contem {numberList.Count} elementos.");
                }
                else
                    Console.WriteLine("Opcao invalida.");
            }
            while (sair);
        }

        static void Exercicio2()
        {
            Dictionary<string, string> siteurl = new Dictionary<string, string>();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"\nDigite o nome do site {i + 1}:");
                string site = Console.ReadLine();
                Console.WriteLine($"Digite o url do site {i + 1}:");
                string url = Console.ReadLine();
                siteurl.Add(site, url);
            }

            bool sair = true;
            do
            {
                StringBuilder menu = new StringBuilder();
                menu.Append("\n### Escolha uma opcao:   ###");
                menu.Append("\n1 - Encontre um site");
                menu.Append("\n2 - Sair");

                Console.WriteLine(menu);

                int op = int.Parse(Console.ReadLine());
                if (op == 2)
                    sair = false;
                else if (op == 1)
                {
                    Console.WriteLine("\nDigite o nome do site que deseja encontrar:");
                    string busca = Console.ReadLine();
                    if (siteurl.TryGetValue(busca, out string retorno))
                    {
                        Console.WriteLine($"\nA url deste site e: {retorno}");
                    }
                    else
                    {
                        Console.WriteLine("\nO site nao existe no banco de dados");
                    }                    
                }
                else
                    Console.WriteLine("Opcao invalida.");
            }
            while (sair);
        }

        static void Exercicio3()
        {
            Stack<int> numberStack = new Stack<int>();
            bool sair = true;
            do
            {
                StringBuilder menu = new StringBuilder();
                menu.Append("\n### Escolha uma opcao:   ###");
                menu.Append("\n1 - Inserir um numero");
                menu.Append("\n2 - Remover o ultimo numero inserido");
                menu.Append("\n3 - Sair");

                Console.WriteLine(menu);

                int op = int.Parse(Console.ReadLine());
                if (op == 3)
                    sair = false;
                else if (op == 1)
                {
                    Console.WriteLine("\nDigite um número:");
                    int num = Convert.ToInt32(Console.ReadLine());
                    numberStack.Push(num);
                    Console.WriteLine("Sua lista atualmente possui o(s) seguinte(s) numero(s):");
                    foreach (var item in numberStack)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (op == 2)
                {
                    if (numberStack.Count == 0)
                    {
                        Console.WriteLine("\nA lista nao possui nenhum numero para ser removido!");
                    }
                    else
                    {
                        int removido = numberStack.Pop();
                        Console.WriteLine($"\nO numero {removido} foi removido com sucesso!");
                        Console.WriteLine("\nSua lista agora possui o(s) seguinte(s) numero(s):");
                        if (numberStack.Count == 0)
                        {
                            Console.WriteLine("Nenhum, a lista esta vazia.");
                        }
                        else
                        {
                            foreach (var item in numberStack)
                            {
                                Console.WriteLine(item);
                            }
                        }

                    }

                }
                else
                    Console.WriteLine("Opcao invalida.");
            }
            while (sair);
        }

        static void Exercicio4()
        {
            Queue<int> numberQueue = new Queue<int>();
            bool sair = true;
            do
            {
                StringBuilder menu = new StringBuilder();
                menu.Append("\n### Escolha uma opcao:   ###");
                menu.Append("\n1 - Inserir um numero");
                menu.Append("\n2 - Remover o primeiro numero inserido");
                menu.Append("\n3 - Sair");

                Console.WriteLine(menu);

                int op = int.Parse(Console.ReadLine());
                if (op == 3)
                    sair = false;
                else if (op == 1)
                {
                    Console.WriteLine("\nDigite um número:");
                    int num = Convert.ToInt32(Console.ReadLine());
                    numberQueue.Enqueue(num);
                    Console.WriteLine("Sua lista atualmente possui o(s) seguinte(s) numero(s):");
                    foreach (var item in numberQueue)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (op == 2)
                {
                    if (numberQueue.Count == 0)
                    {
                        Console.WriteLine("\nA lista nao possui nenhum numero para ser removido!");
                    }
                    else
                    {
                        int removido = numberQueue.Dequeue();
                        Console.WriteLine($"\nO numero {removido} foi removido com sucesso!");
                        Console.WriteLine("\nSua lista agora possui o(s) seguinte(s) numero(s):");
                        if (numberQueue.Count == 0)
                        {
                            Console.WriteLine("Nenhum, a lista esta vazia.");
                        }
                        else
                        {
                            foreach (var item in numberQueue)
                            {
                                Console.WriteLine(item);
                            }
                        }
                    }
                }
                else
                    Console.WriteLine("Opcao invalida.");
            }
            while (sair);
        }
    }
}
