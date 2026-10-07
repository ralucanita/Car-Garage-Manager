using System;
using System.Collections.Generic;
class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int Power { get; set; }

    public Car(string brand, string model, int year, int power)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Power = power;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine(
            $"{Brand} {Model} | Year: {Year} | Power: {Power} HP");
    }
}

class ElectricCar : Car
{
    public int BatteryCapacity { get; set; }
    public int Range { get; set; }

    public ElectricCar(string brand,string model,int year,int power,int batteryCapacity,int range): base(brand, model, year, power)
    {
        BatteryCapacity = batteryCapacity;
        Range = range;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"{Brand} {Model} | Year: {Year} | " + "Power: {Power} HP | Battery: {BatteryCapacity} kWh | " + "Range: {Range} km");
    }
}

class Program
{
    static void Main()
    {
        List<Car> cars = new List<Car>();
        cars.Add(new Car("BMW","M3",2022,510));
        cars.Add(new Car("Audi","RS3",2021,400));
        cars.Add(new Car( "Volkswagen","Golf GTI",2020,245));
        cars.Add(new ElectricCar( "Tesla", "Model 3", 2023, 283,60,490));
        bool running = true;
        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("==============================");
            Console.WriteLine("      CAR GARAGE MANAGER");
            Console.WriteLine("==============================");
            Console.WriteLine("1. Show all cars");
            Console.WriteLine("2. Add a car");
            Console.WriteLine("3. Search car by brand");
            Console.WriteLine("4. Compare two cars");
            Console.WriteLine("5. Remove a car");
            Console.WriteLine("6. Show most powerful car");
            Console.WriteLine("7. Exit");
            Console.Write("\nChoose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ShowCars(cars);
                    break;

                case "2":
                    Console.WriteLine("\n--- ADD CAR ---");
                    Console.Write("Brand: ");
                    string brand = Console.ReadLine();
                    Console.Write("Model: ");
                    string model = Console.ReadLine();
                    Console.Write("Year: ");
                    int year = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Power (HP): ");
                    int power = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("\nCar type:");
                    Console.WriteLine("1. Normal car");
                    Console.WriteLine("2. Electric car");
                    Console.Write("Choose: ");
                    string type = Console.ReadLine();
                    if (type == "2")
                     {
                        Console.Write("Battery capacity (kWh): ");
                        int battery =Convert.ToInt32(Console.ReadLine());

                        Console.Write("Range (km): ");
                        int range =Convert.ToInt32(Console.ReadLine());

                        ElectricCar electricCar =new ElectricCar(brand,model,year, power, battery, range);
                        cars.Add(electricCar);
                     }
                    else
                        {
                        Car newCar =new Car(brand,model,year,power);
                        cars.Add(newCar);
                        }

                    Console.WriteLine("\nCar added successfully!");
                    break;

                case "3":

                    Console.WriteLine("\n--- SEARCH CAR ---");
                    Console.Write("Enter brand: ");
                    string searchBrand = Console.ReadLine();
                    bool found = false;

                    foreach (Car car in cars)
                     {
                        if (car.Brand.Equals(searchBrand,StringComparison.OrdinalIgnoreCase))
                            {
                            car.DisplayInfo();
                            found = true;
                            }
                     }

                    if (!found)
                        {
                        Console.WriteLine("No cars found with this brand.");
                        }
                    break;

                case "4":

                    Console.WriteLine("\n--- COMPARE CARS ---");
                    ShowCars(cars);
                    Console.Write("\nChoose first car: ");
                    int first =Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Write("Choose second car: ");
                    int second = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (first >= 0 && first < cars.Count &&second >= 0 && second < cars.Count)
                    {
                        Car car1 = cars[first];
                        Car car2 = cars[second];
                        Console.WriteLine("\nComparison:");
                        car1.DisplayInfo();
                        car2.DisplayInfo();

                        Console.WriteLine();

                        if (car1.Power > car2.Power)
                        {
                            Console.WriteLine($"{car1.Brand} {car1.Model} " +"is more powerful.");
                        }
                        else if (car2.Power > car1.Power)
                        {
                            Console.WriteLine($"{car2.Brand} {car2.Model} " +"is more powerful.");
                        }
                        else
                        {
                            Console.WriteLine("Both cars have the same power.");
                        }

                        int difference = Math.Abs(car1.Power - car2.Power);

                        Console.WriteLine( $"Power difference: {difference} HP");
                    }
                    else
                    {
                        Console.WriteLine("Invalid car selection.");
                    }
                    break;

                case "5":

                    Console.WriteLine("\n--- REMOVE CAR ---");
                    ShowCars(cars);
                    Console.Write("\nChoose the car to remove: ");

                    int removeIndex =Convert.ToInt32(Console.ReadLine()) - 1;
                    if (removeIndex >= 0 &&removeIndex < cars.Count)
                    {
                        Car removedCar = cars[removeIndex];
                        cars.RemoveAt(removeIndex);

                        Console.WriteLine($"\n{removedCar.Brand} " +$"{removedCar.Model} was removed.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection.");
                    }
                    break;

                case "6":

                    Console.WriteLine("\n--- MOST POWERFUL CAR ---");

                    if (cars.Count == 0)
                    {
                        Console.WriteLine("The garage is empty.");
                        break;
                    }

                    Car mostPowerful = cars[0];

                    foreach (Car car in cars)
                    {
                        if (car.Power > mostPowerful.Power)
                        {
                            mostPowerful = car;
                        }
                    }

                    Console.WriteLine("The most powerful car is:");
                    mostPowerful.DisplayInfo();
                    break;

                case "7":
                    running = false;
                    Console.WriteLine("\nThank you for using Car Garage Manager!");
                    break;

                default:
                    Console.WriteLine("\nInvalid option. Try again.");
                    break;
            }
        }
    }
    static void ShowCars(List<Car> cars)
    {
        Console.WriteLine("\n--- GARAGE ---");

        if (cars.Count == 0)
        {
            Console.WriteLine("The garage is empty.");
            return;
        }

        for (int i = 0; i < cars.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            cars[i].DisplayInfo();
        }
    }
}