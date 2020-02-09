/*
abstract class NativeDictionary<T>

// конструктор
    // постусловие: создана новая словарь размером size
    public NativeDictionary(int size);

// команды
    // предусловие: словарь не переполнен
    // постусловие: элемент добавлен в словарь
    public void Put(string key, T value);

// запросы
    // предусловие: словарь содержит ключ
    public T Get(string key); // вернуть значение если ключ имеется

    public bool IsKey(string key);

    public int Size(); // текущий размер словаря 

// запросы статусов (возможные значения статусов)
    public int Get_Put_status(); // успешно; словарь переполнен
    public int Get_Get_status(); // успешно; ключ не имеется
*/

public class NativeDictionary<T>
{
    private int size;
    const int step = 3;
    private string[] slots;
    private T[] values;
    private int put_status;
    private int get_status;

    public const int PUT_NIL = 0; // put() ещё не вызывалась
    public const int PUT_OK = 1; // последняя put() отработала нормально
    public const int PUT_FULL = 2; // словарь переполнен / не удается разрешить коллизию

    public const int GET_ERR = 0; // значения нет в словаре
    public const int GET_OK = 1; // последняя get() отработала нормально

// конструктор
    public NativeDictionary(int sz)
    {
        size = sz;
        slots = new string[size];
        values = new T[size];
        put_status = PUT_NIL;
        get_status = GET_ERR;
        for (int i = 0; i < size; i++) {slots[i] = null; values[i] = default(T);}
    }

// команды
    public void Put(string key, T value)
    {
        var index = SeekSlot(key);
        if (index != -1)
        {
            slots[index] = key;
            values[index] = value;
            put_status = PUT_OK;
        }
        else // возвращается индекс слота или -1, если из-за коллизий элемент не удаётся разместить 
            put_status = PUT_FULL;        
    }

// запросы
    public T Get(string key)
    {
        var index = Find(key);
        if(index == -1)
        {
            get_status = GET_ERR;
            return default(T);
        }
        get_status = GET_OK;
        return values[index];
    }

    public bool IsKey(string key)
    {
        var index = Find(key);
        return index != -1;
    }

    public int Size()
    {
        return size;
    }

// запросы статусов (возможные значения статусов)
    public int Get_Put_status()
    {
        return put_status;
    }
    public int Get_Get_status()
    {
        return get_status;
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