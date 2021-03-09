// 1. метод публичен в родительском классе А и публичен в его потомке B
// ВОЗМОЖЕН
class PersonTask13_1
{
    public string Name { get;  set; }
 
    public void Display()
    {
        System.Console.WriteLine(Name);
    }
}
 
class EmployeeTask13_1 : PersonTask13_1
{
    public string Company { get; set; }
}

class MainClassTask13_1
{
    public static void Main (string[] args) 
    {
        var p = new PersonTask13_1 { Name = "Bill" };
        p.Display(); // Bill
        var emp = new EmployeeTask13_1 { Name = "Tom", Company = "Microsoft" };
        emp.Display(); // Tom
        System.Console.Read();
    }
}

// 2. метод публичен в родительском классе А и скрыт в его потомке B
// НЕВОЗМОЖЕН. ТОЛЬКО ЧЕРЕЗ ПЕРЕОПРЕДЕЛЕНИЕ new МОЖНО СКРЫТЬ РОДИТЕЛЬСКИЙ МЕТОД
class PersonTask13_2
{
    public string Name { get;  set; }
 
    public void Display()
    {
        System.Console.WriteLine(Name);
    }
}
 
class EmployeeTask13_2 : PersonTask13_2
{
    public string Company { get; set; }

    public new void Display()
    {
        System.Console.WriteLine(Company);
    }
}

class MainClassTask13_2
{
    public static void Main (string[] args) 
    {
        var p = new PersonTask13_2 { Name = "Bill" };
        p.Display(); // Bill
        var emp = new EmployeeTask13_2 { Name = "Tom", Company = "Microsoft" };
        emp.Display(); // Microsoft
        System.Console.Read();
    }
}
// 3. метод скрыт в родительском классе А и публичен в его потомке B
// НЕВОЗМОЖЕН. ТОЛЬКО ЧЕРЕЗ ПЕРЕОПРЕДЕЛЕНИЕ new МОЖНО ОТКРЫТЬ РОДИТЕЛЬСКИЙ МЕТОД
class PersonTask13_3
{
    public string Name { get;  set; }
 
    protected void Display()
    {
        System.Console.WriteLine(Name);
    }
}
 
class EmployeeTask13_3 : PersonTask13_3
{
    public string Company { get; set; }

    public new void Display()
    {
      System.Console.WriteLine(Company);
    }
}

class MainClassTask13_3
{
    public static void Main (string[] args) 
    {
        var emp = new EmployeeTask13_3 { Name = "Tom", Company = "Microsoft" };
        emp.Display(); // Microsoft
        System.Console.Read();
    }
}

// 4. метод скрыт в родительском классе А и скрыт в его потомке B
// ВОЗМОЖЕН
class PersonTask13_4
{
    public string Name { get;  set; }
 
    protected void Display()
    {
        System.Console.WriteLine(Name);
    }
}
 
class EmployeeTask13_4 : PersonTask13_4
{
    public string Company { get; set; }

    public void Show()
    {
        Display();
    }
}

class MainClassTask13_4
{
    public static void Main (string[] args) 
    {
        var emp = new EmployeeTask13_4 { Name = "Tom", Company = "Microsoft" };
        emp.Show(); // Tom
        System.Console.Read();
    }
}