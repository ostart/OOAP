/*
abstract class HashTable
// конструктор
    // постусловие: создана новая хэш-таблица размером size
    public HashTable(int maxSize);

// команды
    // предусловие: хэш-таблица не переполнена
    // постусловие: элемент добавлен в хэш-таблицу
    public void Put(string item);

    // постусловие: из хэш-таблицы удален элемент
    public void Remove(string item);

// запросы
    public bool Contains(string item); // содержит ли хэш-таблица элемент 

    public int Size(); // текущий размер хэш-таблицы 

// запросы статусов (возможные значения статусов)
    public int Get_Put_status(); // успешно; хэш-таблица переполнена
*/

public class HashTableTask8
{
    private int size;
    const int step = 3;
    private string[] slots;

    private int put_status;

    public const int PUT_NIL = 0; // put() ещё не вызывалась
    public const int PUT_OK = 1; // последняя put() отработала нормально
    public const int PUT_FULL = 2; // хэш-таблица переполнена


// конструктор
    public HashTableTask8(int maxSize)
    {
        size = maxSize;
        slots = new string[size];
        put_status = PUT_NIL;
        for (int i = 0; i < size; i++) slots[i] = null;
    }

// команды
    public void Put(string value)
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

    public void Remove(string value)
    {
        var index = SeekSlot(value);
        if (index != -1)
            slots[index] = null;
    }

// запросы
    public bool Contains(string value) // содержит ли хэш-таблица элемент 
    {
        var index = Find(value);
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