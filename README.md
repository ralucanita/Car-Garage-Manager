# Car Garage Manager
Car Garage Manager is a console application written in C# for managing a small collection of cars.
The application provides a menu through which the user can view the available cars, add new cars, search for a specific brand, compare vehicles and remove cars from 
the garage.
The project uses Object-Oriented Programming concepts to organize the information and functionality of the application.

## Features

The application includes the following functionalities:
- Display all cars currently stored in the garage
- Add a new car by entering its brand, model, year and power
- Add electric cars with additional information about battery capacity and range
- Search for cars by brand
- Compare two cars based on their power
- Calculate the power difference between two selected cars
- Remove a car from the garage
- Find and display the most powerful car
- Navigate through the application using a console menu

## Application Structure
The "Car" class represents a general vehicle and contains the main information used by the application:
- Brand
- Model
- Year
- Power
It also contains the "DisplayInfo()" method used to display the information about a car.

The "ElectricCar: class inherits from "Car".
In addition to the general car information, it stores:
- Battery capacity
- Driving range
The class overrides the "DisplayInfo()" method in order to also display the information specific to an electric vehicle.

## Car Storage
The vehicles are stored using a "List<Car>".
This allows cars to be added and removed while the application is running. The list is also used when displaying, searching and comparing the available vehicles.

## OOP Concepts
The application uses several basic Object-Oriented Programming concepts:
- **Classes and objects** - cars are represented as objects created from classes
- **Encapsulation** - car information is organized using properties inside the classes
- **Inheritance** - "ElectricCar" inherits the common characteristics of "Car"
- **Polymorphism** - "ElectricCar" overrides the "DisplayInfo()" method
- **Constructors** - used to initialize new car objects
- **Methods** - used to organize the functionality of the application

## Console Menu
When the application starts, the following menu is displayed:
1. Show all cars
2. Add a car
3. Search car by brand
4. Compare two cars
5. Remove a car
6. Show most powerful car
7. Exit
The user selects an option by entering the corresponding number.


## Technologies and Concepts
- C#
- Object-Oriented Programming
- Console input/output
- List collections
- Loops and conditional statements
