using System;

class Program
{
    static void Main(string[] args)
    {
        A myObj = new B(); // вода // огонь
        Console.WriteLine ("Hello World");
        Console.WriteLine(myObj.a()); // вода - DynamicBinding
    }        
}

//Базовый класс A
public class A
{
    public virtual string a()
    {
        return "огонь";
    }
}

//Произвольный класс B, наследующий класс A
class B : A
{
    public override string a()
    {
        return "вода";
    }

    public B()
    {
        //Выводим результат возвращаемый переопределённым методом
        Console.Out.WriteLine(a()); //вода
        //Выводим результат возвращаемый методом родительского класса
        Console.Out.WriteLine(base.a());    //огонь
    }
}