using System;

class PersonTask10
{
    public string Name { get; set; }
    public PersonTask10(string name)
    {
        Name = name;
    }
    public virtual void Display()
    {
        Console.WriteLine(Name);
    }
}
class EmployeeTask10 : PersonTask10
{
    public string Company { get; set; }
    public EmployeeTask10(string name, string company) : base(name)
    {
        Company = company;
    }

    // При создании методов с модификатором sealed надо учитывать, что sealed применяется в паре с override, то есть только в переопределяемых методах.
    // И в этом случае мы не сможем переопределить метод Display в классе, унаследованном от EmployeeTask10.
    public override sealed void Display()
    {
        Console.WriteLine($"{Name} работает в {Company}");
    }
}