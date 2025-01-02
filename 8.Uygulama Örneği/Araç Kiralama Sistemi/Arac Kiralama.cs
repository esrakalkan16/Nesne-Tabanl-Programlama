using System;

// Base Class: Customer
abstract class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Contact { get; set; }
    public string Address { get; set; }

    public abstract void Update();
}

// Derived Class: Customer
class Customer : Person
{
    public int Payment { get; set; }

    public override void Update()
    {
        Console.WriteLine($"{Name} adlı müşteri güncellendi.");
    }
}

// Renting Owner
class RentingOwner : Person
{
    public int Age { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public void VerifyAccount()
    {
        Console.WriteLine($"Kiralama sahibi {Name} hesabı doğrulandı.");
    }

    public override void Update()
    {
        Console.WriteLine($"Kiralama sahibi {Name} güncellendi.");
    }
}

// Car
class Car
{
    public int Id { get; set; }
    public string Details { get; set; }
    public string OrderType { get; set; }

    public void ProcessDebit()
    {
        Console.WriteLine("Araç ödemesi işlendi.");
    }
}

// Payment
class Payment
{
    public int Id { get; set; }
    public int CardNumber { get; set; }
    public decimal Amount { get; set; }

    public void Add()
    {
        Console.WriteLine("Ödeme eklendi.");
    }

    public void Update()
    {
        Console.WriteLine("Ödeme güncellendi.");
    }
}

// Main Class
class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Customer Example
            Customer customer = new Customer
            {
                Id = 1,
                Name = "Esra Kalkan",
                Contact = "esrakalkan@gmail.com",
                Address = "Bursa, Türkiye",
                Payment = 1000
            };
            customer.Update();

            // Renting Owner Example
            RentingOwner owner = new RentingOwner
            {
                Id = 2,
                Name = "Ahmet Yılmaz",
                Contact = "ahmetyilmaz@gmail.com",
                Address = "İstanbul, Türkiye",
                Age = 35,
                Username = "ahmet35",
                Password = "123456"
            };
            owner.VerifyAccount();

            // Car Example
            Car car = new Car
            {
                Id = 1,
                Details = "Sedan, Beyaz, 2023 Model",
                OrderType = "Daily"
            };
            car.ProcessDebit();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hata: {ex.Message}");
        }
        Console.ReadLine();
    }
}
