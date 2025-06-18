using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComarchCwiczenia20250616.App;

public interface ICar
{
    string Marka { get; set; }

    void Wypozycz();
}


public class Car : VehicleBase, ICar
{
    public Car()
    {
        
    }

    ~Car()
    {
        
    }

    public Car(string marka, string model)
    {
        Marka = marka;
        Model = model;
    }

    private int bak;
    private bool czyWlaczony;

    public string Marka { get; set; }

    public string Model { get; set; }

    public int Pojemnosc { get; set; }

    public int LiczbaSiedzen { get; set; }

    public Nadwozia RodzajNadwozia { get; set; }

    public void Zatankuj(int iloscPaliwa)
    {
        bak += iloscPaliwa;
    }

    public void Uruchom()
    {
        if (bak > 0)
        {
            czyWlaczony = true;
        }
    }

    public override string PelnaNazwa()
    {
        return $"{Marka} {Model}";
    }
}

public enum Nadwozia
{
    Hatchback,
    Sedan,
    Combi
}

public abstract class VehicleBase
{
    public int Id { get; set; }

    public void Wypozycz()
    {
        Id = DateTime.Now.Day;
    }

    public abstract string PelnaNazwa();
}

public sealed class Truck : Car
{
    public float Ladownosc { get; set; }

    public override string PelnaNazwa()
    {
        return $"{Marka} {Model} {Ladownosc}";
    }
}

