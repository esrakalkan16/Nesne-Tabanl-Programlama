using System;
using System.Collections.Generic;

// Protocol (Interface) Identifiable
interface Identifiable
{
    Guid Id { get; }
}

// Base Class: Pet
abstract class Pet : Identifiable
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; set; }
    public int Age { get; set; }
    public Owner Owner { get; set; }
    public Animal Type { get; set; }
    public PetInformation PetInfo { get; set; }

    public abstract void Feed();

    public bool IsHerbivore()
    {
        return Type != null && !Type.Carnivore;
    }
}

// Derived Class: SpecificPet
class SpecificPet : Pet
{
    public override void Feed()
    {
        Console.WriteLine($"{Name} adlı hayvan besleniyor.");
    }
}

// Owner Class
class Owner
{
    public string Name { get; set; }
}

// Animal Class
class Animal
{
    public string Type { get; set; }
    public string Breed { get; set; }
    public bool Carnivore { get; set; }
}

// Pet Information Class
class PetInformation
{
    public List<string> Traits { get; set; } = new List<string>();
    public List<Vaccine> Vaccines { get; set; } = new List<Vaccine>();
}

// Vaccine Class
class Vaccine
{
    public string Name { get; set; }
    public string Type { get; set; }
}

// Main Class
class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Owner
            Owner owner = new Owner { Name = "Esra Kalkan" };

            // Animal
            Animal dog = new Animal
            {
                Type = "Dog",
                Breed = "Golden Retriever",
                Carnivore = true
            };

            // Pet Information
            PetInformation petInfo = new PetInformation();
            petInfo.Traits.Add("Friendly");
            petInfo.Vaccines.Add(new Vaccine { Name = "Rabies", Type = "Essential" });

            // Pet
            SpecificPet pet = new SpecificPet
            {
                Name = "Max",
                Age = 3,
                Owner = owner,
                Type = dog,
                PetInfo = petInfo
            };

            // Actions
            pet.Feed();
            Console.WriteLine($"{pet.Name} otçul mu? {pet.IsHerbivore()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hata: {ex.Message}");
        }
        Console.ReadLine();
    }
}
