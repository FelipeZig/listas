using System;
using System.Collections;
using System.Text;
using System.IO;


namespace lista02modulo02
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menusair = true;
            do
            {
                StringBuilder menup = new StringBuilder();
                menup.Append("\n###   AUTENTICACAO:   ###");
                menup.Append("\n1 - Configurar Usuario/Senha");
                menup.Append("\n2 - Logar");
                menup.Append("\n3 - Limpar base");
                menup.Append("\n4 - Sair");

                Console.WriteLine(menup);

                int opm = int.Parse(Console.ReadLine());

                if (opm == 4)
                    menusair = false;
                else if (opm == 1)
                {
                   ConfigUsuario()
                }
                else if (opm == 2)
                {
                    Logar()
                }
                else
                    Console.WriteLine("Opcao invalida, tente novamente.");
            }
            while (menusair);
        }
    }
}
