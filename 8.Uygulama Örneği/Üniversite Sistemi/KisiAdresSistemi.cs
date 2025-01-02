using System;

// Base Class: Person
abstract class Person
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }

    public abstract void PurchaseParkingPass();
}

// Derived Class: Student
class Student : Person
{
    public int StudentNumber { get; set; }
    public int AverageMark { get; set; }

    public override void PurchaseParkingPass()
    {
        Console.WriteLine($"{Name} otopark geçiş kartı satın aldı.");
    }

    public bool IsEligibleToEnroll(string course)
    {
        Console.WriteLine($"{Name}, {course} dersine kayıt için uygun.");
        return true;
    }
}

// Derived Class: Professor
class Professor : Person
{
    public int Salary { get; set; }
    public int StaffNumber { get; set; }

    public override void PurchaseParkingPass()
    {
        Console.WriteLine($"Profesör {Name} otopark geçiş kartı satın aldı.");
    }

    public void Supervise(Student student)
    {
        Console.WriteLine($"Profesör {Name}, {student.Name} adlı öğrenciyi denetliyor.");
    }
}

// Address Class
class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int PostalCode { get; set; }
    public string Country { get; set; }

    public bool Validate()
    {
        return !string.IsNullOrEmpty(Street) && PostalCode > 0;
    }

    public string OutputAsLabel()
    {
        return $"{Street}, {City}, {State}, {Country}";
    }
}

// Main Class
class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Student
            Student student = new Student
            {
                Name = "Esra Kalkan",
                PhoneNumber = "05516507464",
                EmailAddress = "esra.kalkan@gmail.com",
                StudentNumber = 123456,
                AverageMark = 85
            };

            // Professor
            Professor professor = new Professor
            {
                Name = "Dr. Ahmet Yılmaz",
                PhoneNumber = "05516667788",
                EmailAddress = "ahmet.yilmaz@university.edu",
                Salary = 5000,
                StaffNumber = 78910
            };

            // Address
            Address address = new Address
            {
                Street = "123 Üniversite Cad.",
                City = "Bursa",
                State = "Nilüfer",
                PostalCode = 16000,
                Country = "Türkiye"
            };

            // Actions
            student.PurchaseParkingPass();
            professor.Supervise(student);
            Console.WriteLine($"Adres etiketi: {address.OutputAsLabel()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hata: {ex.Message}");
        }
        Console.ReadLine();
    }
}
