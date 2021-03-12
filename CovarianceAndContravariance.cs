using System;

// Иерархия классов
public class Small {}
public class Big: Small {}
public class Bigger : Big {}

// Ковариантность позволяет использовать производный класс там, где ожидается базовый класс (может принимать Big, если ожидается Small)
// Ковариантность может применяться к делегатам, обобщениям, массивам, интерфейсам и т.д.

// Ковариантность делегатов
public delegate Small covarDel(Big mc);

public class Program
{
    public static Big Method1(Big bg)
    {
        Console.WriteLine("Method1");
    
        return new Big();
    }
    public static Small Method2(Big bg)
    {
        Console.WriteLine("Method2");
    
        return new Small();
    }
        
    public static void Main(string[] args)
    {
        covarDel del = Method1; // делегат ожидает возвращаемого типа Small (базовый класс), но мы все равно можем назначить Method1, который возвращает Big (производный класс)

        Small sm1 = del(new Big());

        del= Method2; // имеет ту же сигнатуру, что и делегат
        Small sm2 = del(new Big());
    }
}
// Ковариантность позволяет назначить метод делегату, который имеет менее производный тип возвращаемого значения.

// Контравариантность в C# применяется к параметрам. Контравариантность позволяет метод с параметрами базового класса присвоить делегату, ожидающему параметр производного класса
delegate Small covarDel(Big mc);

class Program
{
    static Big Method1(Big bg)
    {
        Console.WriteLine("Method1");
        return new Big();
    }
    static Small Method2(Big bg)
    {
        Console.WriteLine("Method2");
        return new Small();
    }

    static Small Method3(Small sml)
    {
        Console.WriteLine("Method3");
        
        return new Small();
    }
    static void Main(string[] args)
    {
        covarDel del = Method1;
        del += Method2;
        del += Method3; // Method3 имеет параметр класса Small, в то время как делегает ожидает параметр класса Big

        Small sm = del(new Big());
}

// Ковариантность и Контравариантность одновременно
delegate Small covarDel(Big mc);

class Program
{
    static Big Method4(Small sml)
    {
        Console.WriteLine("Method3");
    
        return new Big();
    }

    static void Main(string[] args)
    {
        covarDel del = Method4;
    
        Small sm = del(new Big());
    }
}