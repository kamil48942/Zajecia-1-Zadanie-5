using System;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Wybierz opcję:");
        Console.WriteLine("1. Zapisz dane do pliku binarnego");
        Console.WriteLine("2. Odczytaj dane z pliku binarnego");
        Console.Write("Twój wybór: ");

        string wybor = Console.ReadLine();

        switch (wybor)
        {
            case "1":
                ZapiszDaneDoPliku();
                break;
            case "2":
                OdczytajDaneZPliku();
                break;
            default:
                Console.WriteLine("Niepoprawny wybór.");
                break;
        }

        Console.ReadKey();
    }

    static void ZapiszDaneDoPliku()
    {
        Console.WriteLine("Podaj dane do zapisu:");
        Console.Write("Imię: ");
        string imie = Console.ReadLine();
        Console.Write("Wiek: ");
        int wiek = Convert.ToInt32(Console.ReadLine());
        Console.Write("Adres: ");
        string adres = Console.ReadLine();

        DaneOsobowe dane = new DaneOsobowe(imie, wiek, adres);

        try
        {
            string json = JsonSerializer.Serialize(dane);
            File.WriteAllText("dane.json", json);
            Console.WriteLine("Dane zostały zapisane do pliku.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Wystąpił błąd podczas zapisu danych: " + ex.Message);
        }
    }

    static void OdczytajDaneZPliku()
    {
        try
        {
            string json = File.ReadAllText("dane.json");
            DaneOsobowe dane = JsonSerializer.Deserialize<DaneOsobowe>(json);
            Console.WriteLine("Odczytane dane:");
            Console.WriteLine("Imię: " + dane.Imie);
            Console.WriteLine("Wiek: " + dane.Wiek);
            Console.WriteLine("Adres: " + dane.Adres);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Wystąpił błąd podczas odczytu danych: " + ex.Message);
        }
    }
}

class DaneOsobowe
{
    public string Imie { get; set; }
    public int Wiek { get; set; }
    public string Adres { get; set; }

    public DaneOsobowe(string imie, int wiek, string adres)
    {
        Imie = imie;
        Wiek = wiek;
        Adres = adres;
    }
}
