using System;

namespace CarRentalSystem
{
 class Car
 {
  public int Id { get; set; }
  public string Make { get; set; }
  public string Model { get; set; }
  public int RentalPrice { get; set; }
  public bool IsAvailable { get; set; }

  public Car(int id, string make, string model, int rentalPrice, bool isAvailable)
  {
   Id = id;
   Make = make;
   Model = model;
   RentalPrice = rentalPrice;
   IsAvailable = isAvailable;
  }

  public void Rent()
  {
   IsAvailable = false;
  }

  public void Return()
  {
   IsAvailable = true;
  }

  public override string ToString()
  {
   return Id + ". " + Make + " " + Model + " (Rental price: " + RentalPrice + "/day)";
  }
 }

 class CarRentalSystem
 {
  static void Main()
  {
   Car[] cars =
   {
                new Car(1, "BMW", "z4", 50, true),
                new Car(2, "Tesla", "S", 60, true),
                new Car(3, "Ford", "Mustang", 80, true)
            };

   Console.WriteLine("Welcome to the car rental system!\n");

   while (true)
   {
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Rent a car");
    Console.WriteLine("2. Return a car");
    Console.WriteLine("3. View available cars");
    Console.WriteLine("4. Exit");

    Console.Write("\nPlease enter your choice: ");
    string choice = Console.ReadLine();
    Console.WriteLine();

    if (choice == "1")
    {
     Console.WriteLine("Rent a Car:");
     foreach (Car car in cars)
     {
      if (car.IsAvailable)
      {
       Console.WriteLine(car + " - Available");
      }
      else
      {
       Console.WriteLine(car + " - Rented");
      }
     }

     Console.Write("Please enter the ID of the car you want to rent: ");
     int carIdToRent = int.Parse(Console.ReadLine());

     Car selectedCar = null;
     foreach (Car car in cars)
     {
      if (car.Id == carIdToRent && car.IsAvailable)
      {
       selectedCar = car;
       break;
      }
     }

     if (selectedCar == null)
     {
      Console.WriteLine("\nSorry, the selected car is not available for rent.\n");
     }
     else
     {
      selectedCar.Rent();
      Console.WriteLine($"\nRented the {selectedCar.Make} {selectedCar.Model} for ${selectedCar.RentalPrice}/day.\n");
     }
    }
    else if (choice == "2")
    {
     Console.WriteLine("Return a Car:");
     foreach (Car car in cars)
     {
      if (car.IsAvailable)
      {
       Console.WriteLine(car + " - Available");
      }
      else
      {
       Console.WriteLine(car + " - Rented");
      }
     }

     Console.Write("Please enter the ID of the car you want to return: ");
     int carIdToReturn = int.Parse(Console.ReadLine());

     Car selectedCar = null;
     foreach (Car car in cars)
     {
      if (car.Id == carIdToReturn && !car.IsAvailable)
      {
       selectedCar = car;
       break;
      }
     }

     if (selectedCar == null)
     {
      Console.WriteLine("\nSorry, the selected car cannot be returned.\n");
     }
     else
     {
      selectedCar.Return();
      Console.WriteLine($"\nReturned the {selectedCar.Make} {selectedCar.Model}.\n");
     }
    }
    else if (choice == "3")
    {
     Console.WriteLine("Available cars:");

     bool allCarsRented = true;
     foreach (Car car in cars)
     {
      if (car.IsAvailable)
      {
       Console.WriteLine(car + " - Available");
       allCarsRented = false;
      }
      else
      {
       Console.WriteLine(car + " - Rented");
      }
     }

     if (allCarsRented)
     {
      Console.WriteLine("All cars are currently rented.\n");
     }
    }
    else if (choice == "4")
    {
     Console.WriteLine("Thank you for using the car rental system!");
     break;
    }
    else
    {
     Console.WriteLine("Invalid choice. Please try again.\n");
    }
   }

   Console.ReadKey();
  }
 }
}