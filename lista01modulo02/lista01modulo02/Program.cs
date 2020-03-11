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
                        objLogin.Login(usuario, senha, TipoLogin.Gmail);
                        objLogin.Logout();
                    }
                    else if (opt == TipoLogin.Facebook)
                    {
                        LoginFacebook objLogin = new LoginFacebook();
                        objLogin.Login(usuario, senha, TipoLogin.Facebook);
                        objLogin.Logout();
                    }
                    else if (opt == TipoLogin.Instagram)
                    {
                        LoginInstagram objLogin = new LoginInstagram();
                        objLogin.Login(usuario, senha, TipoLogin.Instagram);
                        objLogin.Logout();
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
        public abstract void Login(string usuario, dynamic senha, TipoLogin tipo);

        public abstract void Logout();

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

    public class LoginGmail : SuperLogin
    {
        public override void Login(string usuario, dynamic senha, TipoLogin tipo)
        {
            bool resultValidacao = Autentica(usuario, senha, tipo);
            if (resultValidacao)
                Console.WriteLine("Login com Gmail realizado com sucesso.");
            else
                Console.WriteLine("Login com Gmail falhou");
        }
        public override void Logout()
        {
            Console.WriteLine("Logout realizado com sucesso.");
        }
        

    }

    public class LoginFacebook : SuperLogin
    {
        public override void Login(string usuario, dynamic senha, TipoLogin tipo)
        {
            bool resultValidacao = Autentica(usuario, senha, TipoLogin.Facebook);
            if (resultValidacao)
                Console.WriteLine("Login com Facebook realizado com sucesso.");
            else
                Console.WriteLine("Login com Facebook falhou");
        }
        public override void Logout()
        {
            Console.WriteLine("Logout realizado com sucesso.");
        }
    }

    public class LoginInstagram : SuperLogin
    {
        public override void Login(string usuario, dynamic senha, TipoLogin tipo)
        {
            bool resultValidacao = Autentica(usuario, senha, tipo);
            if (resultValidacao)
                Console.WriteLine("Login com Instagram realizado com sucesso.");
            else
                Console.WriteLine("Login com Instagram falhou");
        }
        public override void Logout()
        {
            Console.WriteLine("Logout realizado com sucesso.");
        }
    }
}
