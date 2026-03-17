using System.Linq.Expressions;
using System.Security.Cryptography;

namespace JogoDaForca.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("-------------------------");
            Console.WriteLine("Jogo da forca");
            Console.WriteLine("-------------------------");

            //Logica jogo da forca

            string palavraAleatoria = PalavraAleatoria();

            Console.WriteLine(palavraAleatoria);

            char[] letraAcertadas = new char[palavraAleatoria.Length]; //guarda caracteres;

            for (int caractere = 0; caractere < letraAcertadas.Length; caractere++)
            {
                letraAcertadas[caractere] = '_';
            }

            bool JogadorAcertouPalavra = false;
            bool JogadorPerdeu = false;

            int quantidadeDeErros = 0;



            while (!JogadorAcertouPalavra && !JogadorPerdeu)
            {

                Console.WriteLine(letraAcertadas);
                Console.WriteLine(quantidadeDeErros);

                Console.Write("Digite uma letra: ");
                string? strLetra = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(strLetra))
                {
                    Console.WriteLine("Digite uma letra valida.");
                    Console.ReadLine();
                    continue;
                }

                char letraChute = char.ToUpper(Convert.ToChar(strLetra));

                bool letraFoiEncontrada = false;

                for (int contador = 0; contador < palavraAleatoria.Length; contador++)
                {
                    char letraAtual = palavraAleatoria[contador];
                   
                    if (letraChute == letraAtual)
                    {
                        letraAcertadas[contador] = letraAtual;
                        letraFoiEncontrada == true;
                    }
                }

                if (letraFoiEncontrada == false)
                {
                    quantidadeDeErros++;
                }               
                    
                JogadorAcertouPalavra = palavraAleatoria == string.Join("", letraAcertadas);
                JogadorPerdeu = quantidadeDeErros > 5;

                if (JogadorAcertouPalavra)
                {
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine($"Voce acertou a palavra a palavra era, {palavraAleatoria}");
                    Console.WriteLine("-----------------------------------------------------------");
                }
                else if (JogadorPerdeu)
                {
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine($"Voce perdeu o jogo a palavra era, {palavraAleatoria}");
                    Console.WriteLine("-----------------------------------------------------------");
                }
            }

            Console.WriteLine("Deseja continuar o jogo? (s/n)");
            string? opcontinuar = Console.ReadLine();

            if (opcontinuar?.ToUpper() != "S")
            {

                break;
            }
        }

        Console.ReadLine();
    }


    static string PalavraAleatoria()
    {
        Console.WriteLine("escolha a palavra aleatoria...");

        string[] palavras = [
            "ABACATE",
            "ABACAXI",
            "ACEROLA",
            "AÇAÍ",
            "ARAÇÁ",
            "ABACATE",
            "BACABA",
            "BACURI",
            "BANANA",
            "CAJÁ",
            "CAJU",
            "CARAMBOLA",
            "CUPUAÇU",
            "GRAVIOLA",
            "GOIABA",
            "JABUTICABA",
            "JENIPAPO",
            "MAÇÃ",
            "MANGABA",
            "MANGA",
            "MARACUJÁ",
            "MURICI",
            "PEQUI",
            "PITANGA",
            "PITAYA",
            "SAPOTI",
            "TANGERINA",
            "UMBU",
            "UVA",
            "UVAIA"
        ];

        int indiceAleatorio = RandomNumberGenerator.GetInt32(palavras.Length);

        string PalavraAleatoria = palavras[indiceAleatorio];
        return PalavraAleatoria;
    }
}


