using System;
using System.Collections.Generic;

public abstract class GeneralTask14: System.Object
{
    public abstract void Add(GeneralTask14 first);
}

public class Vector<T> where T: GeneralTask14
{
    public List<T> List { get; set; }

    public int Length => List.Count;

    public void Add(Vector<T> addict)
    {
        if (this.Length != addict.Length) return;

        for (int i = 0; i < Length; i++)
        {
            List[i].Add(addict.List[i]);
        }
    }
}

