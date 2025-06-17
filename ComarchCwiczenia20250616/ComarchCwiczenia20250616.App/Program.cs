
namespace ComarchCwiczenia20250616.App
{
    internal class Program
    {
        /// <summary>
        /// Metoda startowa aplikacji konsolowej.
        /// </summary>
        /// 
        /// <param name="args">parametry wejściowe aplikacji</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Kalkulator v1.0");
            Console.WriteLine(" 1. Dodawnie");
            Console.WriteLine(" 2. Odejmowanie");
            Console.WriteLine(" 3. Mnożenie");
            Console.WriteLine(" 4. Dzielenie");
            Console.WriteLine(" 5. Reszta z dzielenia");
            Console.WriteLine(" 6. Szyfr Cezara");
            Console.Write("Wybierz opcję: ");

            string sWybor = Console.ReadLine();
            bool czyPoprawnyWybor = int.TryParse(sWybor, out int wybor);

            if (czyPoprawnyWybor)
            {
                Console.Write("Podaj X: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Podaj Y: ");
                int y = int.Parse(Console.ReadLine());

                switch (wybor)
                {
                    case 1:
                        Console.WriteLine($"Wynik dodawania {x} oraz {y} to {x + y}.");
                        break;
                    case 2:
                        Console.WriteLine($"Wynik odejmowania {x} oraz {y} to {x - y}.");
                        break;
                    case 3:
                        Console.WriteLine($"Wynik mnożenia {x} oraz {y} to {x * y}.");
                        break;
                    case 4:
                        Console.WriteLine($"Wynik dzielenia {x} oraz {y} to {x / (float)y}.");
                        break;
                    case 5:
                        Console.WriteLine($"Wynik reszty z dzielenia {x} oraz {y} to {x % y}.");
                        break;
                    case 6:
                        Console.Write("Podaj tekst do zaszyfrowania.");
                        string jawnyTekst = Console.ReadLine();
                        string zaszyfrowanyTekst = SzyfrCezara(jawnyTekst, 3);
                        Console.WriteLine($"Zaszyfrowany tekst: {zaszyfrowanyTekst}");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Podana wartość wykracza poza menu!");
                        Console.ResetColor();
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Podana wartość nie jest liczbą!");
                Console.ResetColor();
            }
        }

        private static string SzyfrCezara(string? jawnyTekst, int przesuniecie)
        {
            string wynik = "";

            foreach (char znak in jawnyTekst)
            {
                if (znak >= 'a' && znak <= 'z')
                {
                    char zaszyfrowany = (char)((znak - 'a' + przesuniecie + 26) % 26 + 'a');
                    wynik += zaszyfrowany;
                }
                else if (znak >= 'A' && znak <= 'Z')
                {
                    char zaszyfrowany = (char)((znak - 'A' + przesuniecie + 26) % 26 + 'A');
                    wynik += zaszyfrowany;
                }
                else
                {
                    wynik += znak;
                }
            }

            return wynik;
        }
    }
}
