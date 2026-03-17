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

            //Logica jogo da forca

            string palavraAleatoria = PalavraAleatoria();
            char[] letraAcertadas = PreencherLetrasAcertadas(palavraAleatoria);
            ExecutarTentativas(letraAcertadas, palavraAleatoria);

            Console.WriteLine(palavraAleatoria);

            if (!sairOunao())
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

        string palavraAleatoria = palavras[indiceAleatorio];
        return palavraAleatoria;
    }

    static char[] PreencherLetrasAcertadas(string palavraAleatoria)
    {
        char[] letraAcertadas = new char[palavraAleatoria.Length]; //guarda caracteres;

        for (int caractere = 0; caractere < letraAcertadas.Length; caractere++)
        {
            letraAcertadas[caractere] = '_';
        }

        return letraAcertadas;
    }

    static void ExecutarTentativas(char[] letraAcertadas, string palavraAleatoria)
    {

        int quantidadeDeErros = 0;
        bool JogadorAcertouPalavra = false;
        bool JogadorPerdeu = false;

        while (!JogadorAcertouPalavra && !JogadorPerdeu)
        {
            desenharForca(quantidadeDeErros);

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
                    letraFoiEncontrada = true;
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
                Console.WriteLine(@" ___________        ");
                Console.WriteLine(@" |/        |        ");
                Console.WriteLine(@" |         o        ");
                Console.WriteLine(@" |        /|\       ");
                Console.WriteLine(@" |         |        ");
                Console.WriteLine(@" |        / \       ");
                Console.WriteLine(@" |                  ");
                Console.WriteLine(@" |                  ");
                Console.WriteLine(@"_|____              ");
            }
        }
    }

    static void cabecalho()
    {
        Console.WriteLine("-------------------------");
        Console.WriteLine("Jogo da forca");
        Console.WriteLine("-------------------------");
    }

    static void desenharForca(int quantidadeDeErros)
    {
        if (quantidadeDeErros == 0)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (quantidadeDeErros == 1)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (quantidadeDeErros == 2)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        /|        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (quantidadeDeErros == 3)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        /|\       ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (quantidadeDeErros == 4)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        /|\       ");
            Console.WriteLine(@" |         |        ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (quantidadeDeErros == 5)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        /|\       ");
            Console.WriteLine(@" |         |        ");
            Console.WriteLine(@" |        / \       ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        Console.WriteLine("-------------------------");
    }

    static bool sairOunao()
    {
        Console.WriteLine("Deseja continuar o jogo? (s/n)");
        string? opcontinuar = Console.ReadLine();

        if (opcontinuar?.ToUpper() != "S")
        {
            return false;
        }
        return true;
    }
}