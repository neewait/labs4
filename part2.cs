using System;

using System.Collections.Generic;
class Car
{
    public string Name { get; set; }
    public int ProductionYear { get; set; }
    public int MaxSpeed { get; set; }
}

class CarComparer : IComparer<Car>
{
    public enum SortOption
    {
        Name,
        ProductionYear,
        MaxSpeed
    }

    private SortOption _sortOption;

    public CarComparer(SortOption sortOption)
    {
        _sortOption = sortOption;
    }

    public int Compare(Car x, Car y)
    {
        if (_sortOption == SortOption.Name)
        {
            return string.Compare(x.Name, y.Name);
        }
        else if (_sortOption == SortOption.ProductionYear)
        {
            return x.ProductionYear.CompareTo(y.ProductionYear);
        }
        else if (_sortOption == SortOption.MaxSpeed)
        {
            return x.MaxSpeed.CompareTo(y.MaxSpeed);
        }
        else
        {
            throw new InvalidOperationException("Неправильный параметр сортировки");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car[] cars = new Car[]
        {
            new Car() { Name = "Audi", ProductionYear = 2010, MaxSpeed = 250 },
            new Car() { Name = "BMW", ProductionYear = 2015, MaxSpeed = 270 },
            new Car() { Name = "Tesla", ProductionYear = 2020, MaxSpeed = 200 }
        };

        Console.WriteLine("Сортировка по названию:");

        Array.Sort(cars, new CarComparer(CarComparer.SortOption.Name));

        foreach (var car in cars)
        {
            Console.WriteLine($"Название: {car.Name}, Год выпуска: {car.ProductionYear}, Максимальная скорость: {car.MaxSpeed}");
        }

        Console.WriteLine();

        Console.WriteLine("Сортировка по году выпуска:");

        Array.Sort(cars, new CarComparer(CarComparer.SortOption.ProductionYear));

        foreach (var car in cars)
        {
            Console.WriteLine($"Название: {car.Name}, Год выпуска: {car.ProductionYear}, Максимальная скорость: {car.MaxSpeed}");
        }

        Console.WriteLine();

        Console.WriteLine("Сортировка по максимальной скорости:");

        Array.Sort(cars, new CarComparer(CarComparer.SortOption.MaxSpeed));

        foreach (var car in cars)
        {
            Console.WriteLine($"Название: {car.Name}, Год выпуска: {car.ProductionYear}, Максимальная скорость: {car.MaxSpeed}");
        }
    }
}
