using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace lista02modulo02
{
    class Program
    {
        static void Main(string[] args)
        {
            Settings _settings = new Settings();
            using (StreamReader file = File.OpenText(@"settings.json"))
            {
                _settings = JsonConvert.DeserializeObject<Settings>(file.ReadToEnd());
            }     
            
            bool menusair = true;
            do
            {
                Menu();
                int opm = int.Parse(Console.ReadLine());
                
                if (opm == 1)                
                    CadastrarSenha(_settings);                
                else if (opm == 2)                
                    Logar(_settings);                
                else if (opm == 3)                
                    LimparBase(_settings);
                else if (opm == 4)
                {
                    Sair();
                    menusair = false;
                }               
                else
                    OpcaoInvalida();
            }
            while (menusair);
        }

        public static void Menu()
        {
            StringBuilder menup = new StringBuilder();
            menup.Append("\n###   AUTENTICACAO:   ###");
            menup.Append("\n1 - Configurar Usuario/Senha");
            menup.Append("\n2 - Logar");
            menup.Append("\n3 - Limpar base");
            menup.Append("\n4 - Sair");

            Console.WriteLine(menup);
        }

        public static void CadastrarSenha(Settings settings)
        {
            Console.WriteLine("Digite o usuario:");
            string usuario = Console.ReadLine();
            Console.WriteLine("Digite a senha:");
            dynamic senha = Console.ReadLine();

            Criptografia objCri = new Criptografia();
            string senhaHash = objCri.Criptografar(SHA512.Create(), senha);

            ArquivosEPastas.CriarPasta(settings);
            bool ok = ArquivosEPastas.CriarEscreverArquivo(settings, usuario, senhaHash);
            if (ok)
                Console.WriteLine("Usuario criado com sucesso.");
            else
                Console.WriteLine("Usuario ja existe no banco de dados.");
        }

        public static void Logar(Settings settings)
        {
            Console.WriteLine("\nDigite o nome do usuario: ");
            string loginUsuario = Console.ReadLine();
            Console.WriteLine("Digite a senha: ");
            string loginSenha = Console.ReadLine();

            Criptografia objCri = new Criptografia();
            string senhaHash2 = objCri.Criptografar(SHA512.Create(), loginSenha);

            bool ok = ArquivosEPastas.LerArquivo(settings, loginUsuario, senhaHash2);            
            if (ok)            
                Console.WriteLine("\nLogin realizado com sucesso!");
            else            
                Console.WriteLine("\nUsuario ou senha invalidos.");              
        }

        public static void LimparBase(Settings settings)
        {
            bool ok = ArquivosEPastas.DeletarPasta(settings);
            if (ok)
                Console.WriteLine("Usuario deletado com sucesso.");
            else
                Console.WriteLine("Pasta nao existe.");
        }

        public static void Sair()
        {
            Console.WriteLine("Saindo do sistema...");
        }

        public static void OpcaoInvalida()
        {
            Console.WriteLine("Opcao invalida, tente novamente.");
        }
    }
    class Criptografia
    {
        public string Criptografar(HashAlgorithm _algoritmo, string senha)
        {
            var encodedValue = Encoding.UTF8.GetBytes(senha);
            var encryptedPassword = _algoritmo.ComputeHash(encodedValue);
            var sb = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X2"));
            }
            return sb.ToString();
        }
        public bool Validar(HashAlgorithm _algoritmo, string senhaDigitada, string senhaCadastrada)
        {
            if (string.IsNullOrEmpty(senhaCadastrada))
                throw new NullReferenceException("Cadastre uma senha.");
            var encryptedPassword = _algoritmo.ComputeHash(Encoding.UTF8.GetBytes(senhaDigitada));
            var sb = new StringBuilder();
            foreach (var caractere in encryptedPassword)
            {
                sb.Append(caractere.ToString("X2"));
            }
            return sb.ToString() == senhaCadastrada;
        }
    }

    public class Settings
    {
        public string Caminho { get; set; }
        public string Pasta { get; set; }
        public string Arquivo { get; set; }
    }

    public class ArquivosEPastas
    {
        public static bool CriarEscreverArquivo(Settings settings, string usuario, string senha)
        {
            if (!File.Exists(settings.Caminho + settings.Pasta + settings.Arquivo))
            {
                using (StreamWriter sw = File.CreateText(settings.Caminho + settings.Pasta + settings.Arquivo))
                {
                    sw.WriteLine(usuario);
                    sw.WriteLine(senha);
                }
                return true;
            }
            else
                return false;            
        }

        public static bool CriarPasta(Settings settings)
        {
            if (!File.Exists(settings.Caminho + settings.Pasta + settings.Arquivo))
            {
                Directory.CreateDirectory(settings.Caminho + settings.Pasta);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static bool LerArquivo(Settings settings, string usuario, string senha)
        {
            List<string> loginSenha = new List<string>();

            try
            {
                using (StreamReader sr = File.OpenText(settings.Caminho + settings.Pasta + settings.Arquivo))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        loginSenha.Add(s);
                    }
                    if (loginSenha[0] == usuario && loginSenha[1] == senha)
                        return true;
                    else
                        return false;
                }                
            }
            catch
            {
                return false;
            }
            
            
        }        

        public static bool DeletarPasta(Settings settings)
        {
            if (File.Exists(settings.Caminho + settings.Pasta + settings.Arquivo))
            {
                Directory.Delete(settings.Caminho + settings.Pasta, true);
                return true;
            }
            else
            {                
                return false;
            }
            
        }
    }
}
