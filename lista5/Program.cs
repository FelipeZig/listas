using System;
using System.Collections.Generic;
using System.Text;

namespace lista5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = new List<int>(5);
            bool sair = true;
            do
            {
                StringBuilder menu = new StringBuilder();
                menu.Append("\n###Escolha uma opcao:");
                menu.Append("\n1 - Inserir os 5 numeros");
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
                    foreach (var item in numberList)
                    {
                        Console.WriteLine("Digite um numero:");
                        int num = Convert.ToInt32(Console.ReadLine());
                        numberList.Add(num);
                    }
                                       
                }
                else if (op == 2)
                {
                    
                }
                else if (op == 3)
                {

                }
                else if (op == 4)
                {

                }
                else if (op == 5)
                {
                    Console.WriteLine("\nOs itens contidos na lista sao: ");
                    foreach (var item in numberList)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                    Console.WriteLine("Opcao invalida.");
            }
            while (sair);
        }
    }
}
