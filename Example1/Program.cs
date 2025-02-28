﻿
using MonoExample.Console;

var animals = new List<IAnimal>();

var optionId = 0;

do
{
    Console.WriteLine("Choose option:\n1 - See all animals\n2 - Add animal\n3 - Edit animal\n4 - Delete animal\n5 - Quit");
    int.TryParse(Console.ReadLine(), out optionId );
    switch (optionId)
    {
        default:
            Console.WriteLine("Something went wrong. Please try again.");
            break;
        case 1:
            ShowAnimals();
            break;
        case 2:
            AddAnimal();
            break;
        case 3:
            EditAnimal();
            break;
        case 4:
            DeleteAnimal();
            break;
        case 5:
            Environment.Exit(0);
            break;

    }
} while (optionId != 5);

IAnimal? SelectAnimal()
{
    Console.WriteLine("Enter ID of animal you want to select:");
    if (!int.TryParse(Console.ReadLine(), out int animalId))
    {
        Console.WriteLine("Wrong input.");
        return null;
    }
    if (animals.FirstOrDefault(a => a.Id == animalId) == null)
    {
        Console.WriteLine($"Animal with ID {animalId} does not exist.");
        return null;
    }
    return animals.FirstOrDefault(a => a.Id == animalId);
}

void EditAnimal()
{
    Console.WriteLine("Select animal you want to edit.");
    var animal = SelectAnimal();
    if (animal == null)
        return;

    Console.WriteLine(animal.ShowInfo());
    Console.WriteLine("Choose field you want to edit:\n1 - Name\n2 - Species\n3 - Age\n4 - Is adopted");
    var optionId = 0;
    int.TryParse(Console.ReadLine(), out optionId);
    switch (optionId)
    {
        default:
            Console.WriteLine("Something went wrong. Please try again.");
            break;
        case 1:
            Console.WriteLine("Enter new name:");
            animal.Name = Console.ReadLine();
            break;
        case 2:
            Console.WriteLine("Enter new species:");
            animal.Species = new Species(Console.ReadLine() ?? "Default species");
            break;
        case 3:
            Console.WriteLine("Enter new age:");
            var age = 0;
            if (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Wrong input.");
                return;
            }
            animal.Age = age;
            break;
        case 4:
            Console.WriteLine("Is Adopted:\n1 - Yes\n2 - No");
            var isAdopted = 0;
            if (!int.TryParse(Console.ReadLine(), out isAdopted))
            {
                Console.WriteLine("Wrong input.");
                return;
            }
            if (isAdopted != 1 && isAdopted != 2)
            {
                Console.WriteLine("Wrong input.");
                return;
            }
            if (isAdopted == 1)
                animal.IsAdopted = true;
            else
                animal.IsAdopted = false;
            break;
    }
}

void DeleteAnimal()
{
    Console.WriteLine("Select animal you want to delete.");
    var animal = SelectAnimal();
    if (animal == null)
        return;
    animals.Remove(animal);
}

void AddAnimal()
{
    var animalId = 0;

    Console.WriteLine("Input animal details:\nAnimal:\n1 - Dog\n2 - Cat");
    int.TryParse(Console.ReadLine(), out animalId );
    if ( animalId != 1 && animalId != 2 )
    {
        Console.WriteLine("Something went wrong.");
        return;
    }
    Animal animal = animalId == 1 ? new Dog() : new Cat();
    Console.WriteLine("Name:");
    animal.Name = Console.ReadLine();
    Console.WriteLine("Species:");
    var speciesName = Console.ReadLine();
    animal.Species = new Species(speciesName ?? "Defaul species");
    Console.WriteLine("Age:");
    var age = 0;
    if (!int.TryParse(Console.ReadLine(), out age))
    {
        Console.WriteLine("Wrong input.");
        return;
    }
    animal.Age = age;
    Console.WriteLine("Is adopted:\n1 - Yes\n2 - No");
    var isAdopted = 0;
    if (!int.TryParse(Console.ReadLine(), out isAdopted))
    {
        Console.WriteLine("Wrong input.");
        return;
    }
    if (isAdopted != 1 && isAdopted != 2)
    {
        Console.WriteLine("Wrong input.");
        return;
    }
    if (isAdopted == 1)
        animal.IsAdopted = true;
    else
        animal.IsAdopted = false;

    animal.Id = animals.Count > 0 ? animals.Max(a => a.Id) + 1 : 1;

    animals.Add(animal);
}

void ShowAnimals()
{
    if (animals.Count < 1)
        Console.WriteLine("There are no animals in shelter yet.");
    else
    {
        foreach (var animal in animals)
            Console.WriteLine(animal.ShowInfo());
    }
}
