
namespace ComarchCwiczenia20250616.App
{
    internal class Program
    {
        /// <summary>
        /// Metoda startowa aplikacji konsolowej.
        /// </summary>
        /// 
        /// <param name="args">parametry wejściowe aplikacji</param>
        public static void Main(string[] args)
        {
            ShowMenu();

            string sWybor = Console.ReadLine();
            bool czyPoprawnyWybor = int.TryParse(sWybor, out int wybor);

            if (czyPoprawnyWybor)
            {
                int x, y;

                switch (wybor)
                {
                    case 1:
                        GetXY(out x, out y);
                        Console.WriteLine($"Wynik dodawania {x} oraz {y} to {x + y}.");
                        break;
                    case 2:
                        GetXY(out x, out y);
                        Console.WriteLine($"Wynik odejmowania {x} oraz {y} to {x - y}.");
                        break;
                    case 3:
                        GetXY(out x, out y);
                        Console.WriteLine($"Wynik mnożenia {x} oraz {y} to {x * y}.");
                        break;
                    case 4:
                        GetXY(out x, out y);
                        Console.WriteLine($"Wynik dzielenia {x} oraz {y} to {x / (float)y}.");
                        break;
                    case 5:
                        GetXY(out x, out y);
                        Console.WriteLine($"Wynik reszty z dzielenia {x} oraz {y} to {x % y}.");
                        break;
                    case 6:
                        Console.Write("Podaj tekst do zaszyfrowania: ");
                        string jawnyTekst = Console.ReadLine();
                        string zaszyfrowanyTekst = SzyfrCezara(jawnyTekst, 3);
                        Console.WriteLine($"Zaszyfrowany tekst: {zaszyfrowanyTekst}");
                        break;
                    case 7:
                        Console.Write("Podaj dowolną ilość liczb rozdzielonych spacją: ");
                        string[] sLiczby = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        int[] liczby = new int[sLiczby.Length];
                        for (int i = 0; i < sLiczby.Length; i++)
                        {
                            liczby[i] = int.Parse(sLiczby[i]);
                        }

                        SortowanieBabelkowe(liczby);
                        WyswietlTablice(liczby);

                        break;
                    default:
                        ShowError("Podana wartość wykracza poza menu!");
                        break;
                }
            }
            else
            {
                ShowError("Podana wartość nie jest liczbą!");
            }
        }

        private static void GetXY(out int x, out int y)
        {
            Console.Write("Podaj X: ");
            x = int.Parse(Console.ReadLine());
            Console.Write("Podaj Y: ");
            y = int.Parse(Console.ReadLine());
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Kalkulator v1.0");
            Console.WriteLine(" 1. Dodawnie");
            Console.WriteLine(" 2. Odejmowanie");
            Console.WriteLine(" 3. Mnożenie");
            Console.WriteLine(" 4. Dzielenie");
            Console.WriteLine(" 5. Reszta z dzielenia");
            Console.WriteLine(" 6. Szyfr Cezara");
            Console.WriteLine(" 7. Sortowanie bąbelkowe");
            Console.Write("Wybierz opcję: ");
        }

        private static void ShowError(string wiadomosc)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(wiadomosc);
            Console.ResetColor();
        }

        private static void WyswietlTablice(int[] tablica)
        {
            foreach (int liczba in tablica)
            {
                Console.Write(liczba + " ");
            }
            Console.WriteLine();
        }

        private static void SortowanieBabelkowe(int[] tablica)
        {
            int n = tablica.Length; // Długość tablicy

            // Zewnętrzna pętla powtarza się n-1 razy
            // Przy każdym przebiegu największa liczba "wędruje" na koniec
            for (int i = 0; i < n - 1; i++)
            {
                // Wewnętrzna pętla porównuje sąsiednie elementy
                // Nie musimy już sprawdzać ostatnich i elementów, które są już posortowane
                for (int j = 0; j < n - 1 - i; j++)
                {
                    // Sprawdzamy, czy element po lewej stronie jest większy od tego po prawej
                    if (tablica[j] > tablica[j + 1])
                    {
                        // Jeśli tak, to je zamieniamy miejscami

                        // Przechowujemy tymczasowo wartość z lewej strony
                        int temp = tablica[j];

                        // Przypisujemy mniejszy element z prawej na miejsce większego
                        tablica[j] = tablica[j + 1];

                        // Przypisujemy większy element (z temp) po prawej stronie
                        tablica[j + 1] = temp;
                    }
                    // Jeśli elementy są już w dobrej kolejności, nic nie robimy
                }
                // Po każdej iteracji największy element "wypływa" na koniec tablicy
            }
            // Gdy zakończymy pętle, tablica jest posortowana rosnąco
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
