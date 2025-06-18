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
            bool czyKontynuowac = false;

            do
            {
                ShowMenu();

                string sWybor = Console.ReadLine();
                bool czyPoprawnyWybor = int.TryParse(sWybor, out int wybor);

                if (czyPoprawnyWybor)
                {
                    Console.Clear();
                    Calculator calculator = new Calculator();
                    int x, y;

                    switch (wybor)
                    {
                        case 1:
                            GetXY(out x, out y);
                            Console.WriteLine($"Wynik dodawania {x} oraz {y} to {calculator.Add(x, y)}.");
                            break;
                        case 2:
                            GetXY(out x, out y);
                            Console.WriteLine($"Wynik odejmowania {x} oraz {y} to {calculator.Subtract(x, y)}.");
                            break;
                        case 3:
                            GetXY(out x, out y);
                            Console.WriteLine($"Wynik mnożenia {x} oraz {y} to {calculator.Multiply(x, y)}.");
                            break;
                        case 4:
                            GetXY(out x, out y);
                            try
                            {
                                Console.WriteLine($"Wynik dzielenia {x} oraz {y} to {calculator.Divide(x, y)}.");
                            }
                            catch (Exception ex)
                            {
                                ShowError(ex.Message);
                            }
                            break;
                        case 5:
                            GetXY(out x, out y);
                            try
                            {
                                Console.WriteLine($"Wynik reszty z dzielenia {x} oraz {y} to {calculator.Modulo(x, y)}.");
                            }
                            catch (DivideByZeroException ex)
                            {
                                ShowError("Pamiętaj cholero! Nie dziel przez 0.");
                            }
                            catch (Exception ex)
                            {
                                ShowError("Przepraszamy za usterki ;-(");
                            }
                            break;
                        case 6:
                            Console.Write("Podaj tekst do zaszyfrowania: ");
                            string jawnyTekst = Console.ReadLine();
                            string zaszyfrowanyTekst = calculator.CaesarsCipher(jawnyTekst, 3);
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

                            calculator.BubbleSort(liczby);
                            WyswietlTablice(liczby);
                            break;
                        case 8:
                            ZabawyZCar();
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

                Console.ReadLine();
                Console.Clear();

                Console.Write("Czy chcesz wykonać kolejną operację? [T|n]");
                var key = Console.ReadKey().Key;
                czyKontynuowac = key != ConsoleKey.N;

            } while (czyKontynuowac);
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
            Console.Clear();

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





        private static void ZabawyZCar()
        {
            VehicleBase vb = new Car();
            Car c1 = new Car();
            Truck t1 = new Truck();

            Wypozycz(vb);
            Wypozycz(c1);
            Wypozycz(t1);

            Drukuj(c1);
            Drukuj(t1);
            //Drukuj(vb);
        }

        private static void Wypozycz(VehicleBase vehicleBase)
        {
            vehicleBase.Wypozycz();
        }

        public static void Drukuj(ICar car)
        {
            Console.WriteLine(car.Marka);
        }

    }
}
