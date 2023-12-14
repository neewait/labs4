using System;
using System.Collections;
using System.Collections.Generic;

class Car
{
    public string Name { get; set; }
    public int ProductionYear { get; set; }
    public int MaxSpeed { get; set; }
}

class CarCatalog : IEnumerable<Car>
{
    private Car[] cars;

    public CarCatalog(Car[] cars)
    {
        this.cars = cars;
    }

    public IEnumerator<Car> GetEnumerator()
    {
        // Прямой проход с первого элемента до последнего
        for (int i = 0; i < cars.Length; i++)
        {
            yield return cars[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<Car> GetReverseEnumerator()
    {
        // Обратный проход от последнего к первому
        for (int i = cars.Length - 1; i >= 0; i--)
        {
            yield return cars[i];
        }
    }

    public IEnumerable<Car> GetCarsByProductionYear(int productionYear)
    {
        // Проход по элементам массива с фильтром по году выпуска
        foreach (var car in cars)
        {
            if (car.ProductionYear == productionYear)
            {
                yield return car;
            }
        }
    }

    public IEnumerable<Car> GetCarsByMaxSpeed(int maxSpeed)
    {
        // Проход по элементам массива с фильтром по максимальной скорости
        foreach (var car in cars)
        {
            if (car.MaxSpeed <= maxSpeed)
            {
                yield return car;
            }
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

        CarCatalog catalog = new CarCatalog(cars);

        Console.WriteLine("Прямой проход с первого элемента до последнего:");
        foreach (var car in catalog)
        {
            Console.WriteLine($"Название: {car.Name}, Год выпуска: {car.ProductionYear}, Максимальная скорость: {car.MaxSpeed}");
        }

        Console.WriteLine();

        Console.WriteLine("Обратный проход от последнего к первому:");
        foreach (var car in catalog.GetReverseEnumerator())
        {
            Console.WriteLine($"Название: {car.Name}, Год выпуска: {car.ProductionYear}, Максимальная скорость: {car.MaxSpeed}");
        }

        Console.WriteLine();

        Console.WriteLine("Проход по элементам массива с фильтром по году выпуска (2010):");
        foreach (var car in catalog.GetCarsByProductionYear(2010))
        {
            Console.WriteLine($"Название: {car.Name}, Год выпуска: {car.ProductionYear}, Максимальная скорость: {car.MaxSpeed}");
        }

        Console.WriteLine();

        Console.WriteLine("Проход по элементам массива с фильтром по максимальной скорости (250):");
        foreach (var car in catalog.GetCarsByMaxSpeed(250))
        {
            Console.WriteLine($"Название: {car.Name}, Год выпуска: {car.ProductionYear}, Максимальная скорость: {car.MaxSpeed}");
        }
    }
}*/




/*MyInts ints = new MyInts();
Console.WriteLine(ints[5]);
    

class MyInts
{
    List<int> list = new(Enumerable.Range(1, 100));
    
}*/


/*class Program
{
    static void Main(string[] args)
    {
        MyInts ints = new MyInts();
        Console.WriteLine(ints[5]);
    }
}
class MyInts
{
    private List<int> list;

    public MyInts()
    {
        list = Enumerable.Range(1, 100).ToList();
    }

    public int this[int index]
    {
        get
        {
            if (index >= 0 && index < list.Count)
            {
                return list[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        set
        {
            if (index >= 0 && index < list.Count)
            {
                list[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
