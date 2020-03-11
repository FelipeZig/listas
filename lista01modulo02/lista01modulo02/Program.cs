using System;
using System.Globalization;
using System.Text;

namespace lista01modulo02
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder referencia = new StringBuilder();
            referencia.Append("\n###   Usuarios e senhas para referencia:   ###");
            referencia.Append("\nGmail: usuario = FelipeG ; senha = 12345");
            referencia.Append("\nFacebook: usuario = FelipeF ; senha = 54321");
            referencia.Append("\nInstagram: usuario = FelipeI ; senha = 11111");
            referencia.Append("\n ");

            Console.WriteLine(referencia);

            bool menusair = true;
            do
            {
                StringBuilder menu = new StringBuilder();
                menu.Append("\n###   Escolha uma opcao para logar:   ###");
                menu.Append("\n1 - Logar com sua canta do Gmail");
                menu.Append("\n2 - Logar com sua conta do Facebook");
                menu.Append("\n3 - Logar com sua conta do Instagram");
                menu.Append("\n4 - Sair");

                Console.WriteLine(menu);

                int op = int.Parse(Console.ReadLine());
                TipoLogin opt = (TipoLogin)op;

                if (op == 4)
                    menusair = false;
                else if (op == 0 | op > 4)
                {
                    Console.WriteLine("Opcao invalida, tente novamente.");
                }
                else
                {
                    Console.WriteLine("Digite o usuario:");
                    string usuario = Console.ReadLine();
                    Console.WriteLine("Digite a senha:");
                    dynamic senha = Console.ReadLine();

                    if (opt == TipoLogin.Gmail)
                    {
                        LoginGmail objLogin = new LoginGmail();
                        bool resultValidacao = objLogin.Login(usuario, senha, TipoLogin.Gmail);
                        if (resultValidacao)
                            Console.WriteLine("Login com Gmail realizado com sucesso.");
                        else
                            Console.WriteLine("Login com Gmail falhou");
                        bool resultLogout = objLogin.Logout();
                        if (resultLogout)
                        {
                            Console.WriteLine("Logout realizado com sucesso.");
                        }
                    }
                    else if (opt == TipoLogin.Facebook)
                    {
                        LoginFacebook objLogin = new LoginFacebook();
                        bool resultValidacao = objLogin.Login(usuario, senha, TipoLogin.Facebook);
                        if (resultValidacao)
                            Console.WriteLine("Login com Facebook realizado com sucesso.");
                        else
                            Console.WriteLine("Login com Facebook falhou");
                        bool resultLogout = objLogin.Logout();
                        if (resultLogout)
                        {
                            Console.WriteLine("Logout realizado com sucesso.");
                        }
                    }
                    else if (opt == TipoLogin.Instagram)
                    {
                        LoginInstagram objLogin = new LoginInstagram();
                        bool resultValidacao = objLogin.Login(usuario, senha, TipoLogin.Instagram);
                        if (resultValidacao)
                            Console.WriteLine("Login com Instagram realizado com sucesso.");
                        else
                            Console.WriteLine("Login com Instagram falhou");
                        bool resultLogout = objLogin.Logout();
                        if (resultLogout)
                        {
                            Console.WriteLine("Logout realizado com sucesso.");
                        }
                    }
                }
            }
            while (menusair);
        }
    }

    public enum TipoLogin
    {
        Gmail = 1,
        Facebook = 2,
        Instagram = 3
    }

    public abstract class SuperLogin
    {
        public abstract bool Login(string usuario, dynamic senha, TipoLogin tipo);

        public abstract bool Logout();

        protected virtual bool Autentica(string usuario, dynamic senha, TipoLogin tipo)
        {
            if (usuario == "FelipeG" && senha == "12345" && tipo == TipoLogin.Gmail)
                return true;
            else if (usuario == "FelipeF" && senha == "54321" && tipo == TipoLogin.Facebook)
                return true;
            else if (usuario == "FelipeI" && senha == "11111" && tipo == TipoLogin.Instagram)
                return true;
            else
                return false;
        }
    }

    public class LoginGmail : SuperLogin //desafio
    {
        public override bool Login(string usuario, dynamic senha, TipoLogin tipo)
        {
            bool resultValidacao = Autentica(usuario, senha, TipoLogin.Gmail, 1);
            return resultValidacao;
        }
        public override bool Logout()
        {
            return true;
        }
        protected virtual bool Autentica(string usuario, dynamic senha, TipoLogin tipo, int desafio)
        {
            if (usuario == "FelipeG" && senha == "12345" && tipo == TipoLogin.Gmail)
                return true;
            else
                return false;
        }

    }

    public class LoginFacebook : SuperLogin
    {
        public override bool Login(string usuario, dynamic senha, TipoLogin tipo)
        {
            bool resultValidacao = Autentica(usuario, senha, TipoLogin.Facebook);
            return resultValidacao;
        }
        public override bool Logout()
        {
            return true;
        }
    }

    public class LoginInstagram : SuperLogin
    {
        public override bool Login(string usuario, dynamic senha, TipoLogin tipo)
        {
            bool resultValidacao = Autentica(usuario, senha, TipoLogin.Instagram);
            return resultValidacao;
        }
        public override bool Logout()
        {
            return true;
        }
    }
}
