public class BaseClass // базовый класс
{
    public string Name { get;set; }
    public int Age { get;set; }

    public virtual void Method()
    {
        // Do something.
    }
}

public class DerivedClassExtended: BaseClass // производный класс, расширение
{
    public string Department { get;set; }

    public decimal Salary { get;set; }
}

public class DerivedClassSpecified: BaseClass // производный класс, специализация
{
    public override void Method()
    {
        // Do something else.
    }
}