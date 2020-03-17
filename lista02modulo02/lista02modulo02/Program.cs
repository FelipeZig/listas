using System;
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
                    Console.WriteLine("Digite o usuario:");
                    string usuario = Console.ReadLine();
                    Console.WriteLine("Digite a senha:");
                    dynamic senha = Console.ReadLine();

                    Cri objCri = new Cri();
                    string senhaHash = objCri.CriptografarSenha(SHA512.Create(), senha);

                    CriarPasta(_settings);
                    CriarEscreverArquivo(_settings, usuario, senhaHash);                    
                }
                else if (opm == 2)
                {
                    
                }
                else if (opm == 3)
                {
                    
                }
                else
                    Console.WriteLine("Opcao invalida, tente novamente.");
            }
            while (menusair);
        }

        static bool CriarEscreverArquivo(Settings settings, string usuario, string senha)
        {
            if (!File.Exists(settings.Caminho + settings.Pasta + settings.Arquivo))
            {
                using (StreamWriter sw = File.CreateText(settings.Caminho + settings.Pasta + settings.Arquivo))
                {
                    sw.WriteLine(usuario);
                    sw.WriteLine(senha);                                       
                }                
            }
            else                
                return false;
                       
            return true;
        }

        static bool CriarPasta(Settings settings)
        {
            if (!File.Exists(settings.Caminho + settings.Pasta + settings.Arquivo))
            {                
                Directory.CreateDirectory(settings.Caminho + settings.Pasta);
                Console.WriteLine("Usuario salvo com sucesso");
            }
            else
            {
                Console.WriteLine("Usuario ja existe no banco de dados.");
                return false;
            }
            return true;            
        }

        //static bool DeletarPasta()
        //{
        //    //Deletar Pasta            
        //    string folder = @"C:\Users\fe_zi\Desktop\Repo\PastaFileWork\Origem";
        //    Directory.Delete(folder);
        //    Console.WriteLine("Sucesso");
        //}
    }
    class Cri
    {
        public string CriptografarSenha(HashAlgorithm _algoritmo, string senha)
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
        public bool VerificarSenha(HashAlgorithm _algoritmo, string senhaDigitada, string senhaCadastrada)
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
}
