﻿namespace ComarchCwiczenia20250616.App;

internal class Calculator
{
    public int Add(int x, int y)
    {
        return x + y;
    }

    public int Subtract(int x, int y)
    {
        return x - y;
    }

    public int Multiply(int x, int y)
    {
        return x * y;
    }

    public float Divide(float x, float y)
    {
        if (y == 0)
            throw new DivideByZeroException("Pamiętaj cholero! Nie dziel przez zero!");
        return x / y;
    }

    /// <summary>
    /// Moduloes the specified x.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns></returns>
    /// <exception cref="DivideByZeroException">Gdy y == 0 dostajemy błąd.</exception>
    public int Modulo(int x, int y)
    {
        return x % y;
    }

    public void BubbleSort(int[] tab)
    {
        int n = tab.Length; // Długość tablicy

        // Zewnętrzna pętla powtarza się n-1 razy
        // Przy każdym przebiegu największa liczba "wędruje" na koniec
        for (int i = 0; i < n - 1; i++)
        {
            // Wewnętrzna pętla porównuje sąsiednie elementy
            // Nie musimy już sprawdzać ostatnich i elementów, które są już posortowane
            for (int j = 0; j < n - 1 - i; j++)
            {
                // Sprawdzamy, czy element po lewej stronie jest większy od tego po prawej
                if (tab[j] > tab[j + 1])
                {
                    // Jeśli tak, to je zamieniamy miejscami

                    // Przechowujemy tymczasowo wartość z lewej strony
                    int temp = tab[j];

                    // Przypisujemy mniejszy element z prawej na miejsce większego
                    tab[j] = tab[j + 1];

                    // Przypisujemy większy element (z temp) po prawej stronie
                    tab[j + 1] = temp;
                }
                // Jeśli elementy są już w dobrej kolejności, nic nie robimy
            }
            // Po każdej iteracji największy element "wypływa" na koniec tablicy
        }
        // Gdy zakończymy pętle, tablica jest posortowana rosnąco
    }

    public string CaesarsCipher(string? plainText, int shift)
    {
        string wynik = "";

        foreach (char type in plainText)
        {
            if (type >= 'a' && type <= 'z')
            {
                char zaszyfrowany = (char)((type - 'a' + shift + 26) % 26 + 'a');
                wynik += zaszyfrowany;
            }
            else if (type >= 'A' && type <= 'Z')
            {
                char zaszyfrowany = (char)((type - 'A' + shift + 26) % 26 + 'A');
                wynik += zaszyfrowany;
            }
            else
            {
                wynik += type;
            }
        }

        return wynik;
    }

    public int DayCounter(Days day)
    {
        int result = 0;

        var currentDay = DateTime.Now.DayOfWeek;
        result = (int)day - (int)currentDay;
        return result;
    }

}


public enum Days
{
    Monday = 1,
    Tuesday, 
    Wednesday, 
    Thursday, 
    Friday, 
    Saturday, 
    Sunday
}