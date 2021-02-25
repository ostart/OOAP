using System;
using System.Collections.Generic;

public class Person // базовый класс
{
    public string Name { get;set; }
    public int Age { get;set; }
}

public class Employee: Person // производный класс. Наследование is-a 
{
    public string Department { get;set; }

    public decimal Salary { get;set; }
}

public class Organization
{
    public Employee Boss { get;set; } // Композиция has-a

    public List<Employee> Workers { get;set; } // Композиция has-a

    public void PrintAllNames(Person person) // метод полиморфный, т.к. можно сюда в качестве аргумента передавать как Person, так и Employee
    {
        Console.WriteLine(person.Name);
    }
}