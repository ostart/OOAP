/*
abstract class PowerSet<T>: HashTable
// конструктор
    // постусловие: создано новое множество
    public PowerSet(int maxSize);

// команды
    // предусловие: множество не содержит элемента
    // постусловие: элемент добавлен в множество
    public void Put(T value);

    // постусловие: элемент удален из множества
    public bool Remove(T value);

// запросы
    public int Size(); // текущий размер множества
    public PowerSet<T> Intersection(PowerSet<T> set2);
    public PowerSet<T> Union(PowerSet<T> set2);
    public PowerSet<T> Difference(PowerSet<T> set2);
    public bool IsSubset(PowerSet<T> set2);

// запросы статусов (возможные значения статусов)
    public int Get_Intersect_status(); // успешно; не удалось создать пересечение
    public int Get_Union_status(); // успешно; не удалось создать объединение
    public int Get_Diff_status(); // успешно; не удалось создать разность

abstract class HashTable
// конструктор
    // постусловие: создана новая хэш-таблица размером size
    protected HashTable(int maxSize);

// команды
    // предусловие: хэш-таблица не переполнена
    // постусловие: элемент добавлен в хэш-таблицу
    protected void Put(string item);

    // постусловие: из хэш-таблицы удален элемент
    protected void Remove(string item);

// запросы
    protected bool Contains(string item); // содержит ли хэш-таблица элемент 

    protected int Size(); // текущий размер хэш-таблицы 

// запросы статусов (возможные значения статусов)
    public int Get_Put_status(); // успешно; хэш-таблица переполнена
*/

using System;
using System.Collections.Generic;
public class PowerSet<T>: HashTable
{
    public const int PUT_ALREADYHAS = 3; // множество уже содержит элемент

    private int intersect_status;
    public const int INTERSECT_OK = 0;
    public const int INTERSECT_ERR = 1;

    private int union_status;
    public const int UNION_OK = 0;
    public const int UNION_ERR = 1;
    private int diff_status;
    public const int DIFF_OK = 0;
    public const int DIFF_ERR = 1;


// конструктор
    public PowerSet(int maxSize) : base(maxSize) {}

// команды
    public void Put(T value)
    {
        var strValue = value.ToString();
        if (Contains(strValue))
        {
            put_status = PUT_ALREADYHAS;
            return;
        }
        Put(strValue);
    }

    public void Remove(T value)
    {
        var strValue = value.ToString();
        Remove(strValue);
    }

// запросы
    public new int Size()
    {
        // количество элементов в множестве
        var counter = 0;
        foreach(var slot in slots)
        {
            if (slot != null) counter += 1;
        }
        return counter;
    }

    public PowerSet<T> Intersection(PowerSet<T> set2)
    {
        // пересечение текущего множества и set2
        var currValues = WhereIsNotNull(slots);
        var set2Values = WhereIsNotNull(set2.slots);
        var result = new PowerSet<T>(base.Size());
        foreach (var currValue in currValues)
        {
            if (set2Values.Contains(currValue)) 
            {
                result.Put(currValue);
                if(Get_Put_status() != PUT_OK)
                {
                    intersect_status = INTERSECT_ERR;
                    return result;
                }
            }
        }
        intersect_status = INTERSECT_OK;
        return result;
    }

    public PowerSet<T> Union(PowerSet<T> set2)
    {
        // объединение текущего множества и set2
        var currValues = WhereIsNotNull(slots);
        var set2Values = WhereIsNotNull(set2.slots);
        var result = new PowerSet<T>(base.Size() + set2.Size());
        foreach (var currValue in currValues)
        {
            var obj = (T)Convert.ChangeType(currValue, typeof(T));
            result.Put(obj);
            var status = Get_Put_status();
            if(status != PUT_OK || status != PUT_ALREADYHAS)
            {
                union_status = UNION_ERR;
                return result;
            }
        }
        foreach (var value in set2Values)
        {
            var obj = (T)Convert.ChangeType(value, typeof(T));
            result.Put(obj);
            var status = Get_Put_status();
            if(status != PUT_OK || status != PUT_ALREADYHAS)
            {
                union_status = UNION_ERR;
                return result;
            }
        }
        union_status = UNION_OK;
        return result;
    }

    public PowerSet<T> Difference(PowerSet<T> set2)
    {
        // разница текущего множества и set2
        var currValues = WhereIsNotNull(slots);
        var set2Values = WhereIsNotNull(set2.slots);
        var result = new PowerSet<T>(base.Size());
        foreach (var currValue in currValues)
        {
            if (!set2Values.Contains(currValue)) 
            {
                result.Put(currValue);
                if(Get_Put_status() != PUT_OK)
                {
                    diff_status = DIFF_ERR;
                    return result;
                }
            }
        }
        diff_status = DIFF_OK;
        return result;
    }

    public bool IsSubset(PowerSet<T> set2)
    {
        // возвращает true, если set2 есть подмножество текущего множества, иначе false
        var currValues = WhereIsNotNull(slots);
        var set2Values = WhereIsNotNull(set2.slots);
        foreach (var set2Value in set2Values)
        {
            if (!currValues.Contains(set2Value)) return false;
        }
        return true;
    }

// запросы статусов (возможные значения статусов)
    public int Get_Intersect_status()
    {
        return intersect_status;
    }

    public int Get_Union_status()
    {
        return union_status;
    }

    public int Get_Diff_status()
    {
        return diff_status;
    }


    private List<string> WhereIsNotNull(string[] slots)
    {
        var result = new List<string>();
        foreach(var slot in slots)
        {
            if (slot != null) result.Add(slot);
        }
        return result;
    }
}

public class HashTable
{
    private int size;
    const int step = 3;
    protected string[] slots;

    protected int put_status;

    public const int PUT_NIL = 0; // put() ещё не вызывалась
    public const int PUT_OK = 1; // последняя put() отработала нормально
    public const int PUT_FULL = 2; // хэш-таблица переполнена


// конструктор
    protected HashTable(int maxSize)
    {
        size = maxSize;
        slots = new string[size];
        put_status = PUT_NIL;
        for (int i = 0; i < size; i++) slots[i] = null;
    }

// команды
    protected void Put(string value)
    {
        // записываем значение по хэш-функции
        var index = SeekSlot(value);
        if (index != -1)
        {
            slots[index] = value;
            put_status = PUT_OK;
        }
        else // возвращается индекс слота или -1, если из-за коллизий элемент не удаётся разместить 
            put_status = PUT_FULL;
    }

    protected void Remove(string value)
    {
        var index = SeekSlot(value);
        if (index != -1)
            slots[index] = null;
    }

// запросы
    protected bool Contains(string value) // содержит ли хэш-таблица элемент 
    {
        var index = Find(value);
        return index != -1;
    }
    protected int Size()
    {
        return size;
    }

// запросы статусов (возможные значения статусов)
    public int Get_Put_status()
    {
        return put_status;
    }



    private int HashFun(string value)
    {
        // всегда возвращает корректный индекс слота
        var total = 0;
        var c = value.ToCharArray();
        for (var i = 0; i <= c.GetUpperBound(0); i++)
            total += (int)c[i];

        return total % size;
    }

    private int SeekSlot(string value)
    {
        // находит индекс пустого слота для значения, или -1
        var initIndex = HashFun(value);
        if (slots[initIndex] == null) return initIndex;
        var current = initIndex;
        do
        {
            current += step;
            if (slots[current % size] == null) return current % size;
        } while (current % size != initIndex);

        return -1;
    }

    private int Find(string value)
    {
        // находит индекс слота со значением, или -1
        var initIndex = HashFun(value);
        if (slots[initIndex] == value) return initIndex;
        var current = initIndex;
        do
        {
            current += step;
            if (slots[current % size] == value) return current % size;
        } while (current % size != initIndex);

        return -1;
    }
}