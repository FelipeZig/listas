using System;
using System.Collections.Generic;
using System.Text;

namespace lista5
{
    class Program
    {
        static void Main(string[] args)
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
    }
}
