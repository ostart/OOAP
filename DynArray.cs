/*
abstract class DynArray<T>

// конструктор
    // постусловие: создан новый пустой динамический массив дефолтного размера(например, 16 элементов)
    public DynArray<T> DynArray();

// команды
    // постусловие: элемент добавлен в конец массива, если массив не заполнен.
    // Если массив заполнен, происходит увеличение размера массива (например, в 2 раза)
    // и добавление элемента в конец массива.
    public void Append(T item);

    // предусловие: индекс лежит в допустимых границах
    // постусловие: элемент встален на позицию index. Оставшаяся часть массива сдвинута вправо.
    // Если индекс соответствует размеру массива происходит вставка в конец массива.
    public void Insert(T item, int index);

    // предусловие: индекс лежит в допустимых границах
    // постусловие: элемент удален с позиции index. Оставшаяся часть массива сдвинута влево.
    public void Remove(int index);

    // предусловие: индекс лежит в допустимых границах
    // постусловие: элемент на позиции index заменен на item.
    public void Replace(T item, int index);


// запросы
    // предусловие: индекс лежит в допустимых границах; 
    public T GetItem(int index);

    public int Size(); // текущий размер массива 

// запросы статусов (возможные значения статусов)
    public int Get_GetItem_status(); // успешно; индекс лежит вне допустимых границ
    public int Get_Insert_status(); // успешно; индекс лежит вне допустимых границ
    public int Get_Remove_status(); // успешно; индекс лежит вне допустимых границ
    public int Get_Replace_status(); // успешно; индекс лежит вне допустимых границ
*/
using System;
public class DynArray<T>
{
    private int replace_status;
    private int remove_status;
    private int insert_status;
    private int getItem_status;

    public const int GETITEM_OK = 0; // успешно
    public const int GETITEM_ERR = 1; // индекс лежит вне допустимых границ
    public const int INSERT_OK = 0; // успешно
    public const int INSERT_ERR = 1; // индекс лежит вне допустимых границ
    public const int REMOVE_OK = 0; // успешно
    public const int REMOVE_ERR = 1; // индекс лежит вне допустимых границ
    public const int REPLACE_OK = 0; // успешно
    public const int REPLACE_ERR = 1; // индекс лежит вне допустимых границ

    private T[] array;
    private int count;
    private int capacity;

// конструктор
    public DynArray()
    {
        count = 0;
        MakeArray(16);
    }

// команды
    public void Append(T item)
    {
        if (count + 1 > capacity) MakeArray(capacity * 2);
        array[count] = item;
        count += 1;
    }

    public void Insert(T item, int index)
    {
        if (index < 0 || index > count)
        {
            insert_status = INSERT_ERR;
            return;
        }
        if (count + 1 > capacity) MakeArray(capacity*2);
        if(index == count) Append(item);
        else
        {
            var tempArray = new T[capacity];
            if(index > 0) Array.Copy(array, tempArray, index);
            tempArray[index] = item;
            Array.Copy(array, index, tempArray, index + 1, count - index);
            array = tempArray;
            count += 1;
        }
        insert_status = INSERT_OK;
    }

    public void Remove(int index)
    {
        if (index < 0 || index >= count)
        {
            remove_status = REMOVE_ERR;
            return;
        }
        var tempArray = new T[capacity];
        if (index > 0) Array.Copy(array, tempArray, index);
        Array.Copy(array, index + 1, tempArray, index, count - index - 1);
        array = tempArray;
        count -= 1;
        if(count < capacity / 2) MakeArray(capacity * 2 / 3);
        remove_status = REMOVE_OK;
    }

    public void Replace(T item, int index)
    {
        if (index < 0 || index >= count)
        {
            replace_status = REPLACE_ERR;
            return;
        }
        array[index] = item;
        replace_status = REPLACE_OK;
    }

// запросы
    // предусловие: индекс лежит в допустимых границах; 
    public T GetItem(int index)
    {
        if(index < 0 || index >= count)
        {
            getItem_status = GETITEM_ERR;
            return default;
        }
        getItem_status = GETITEM_OK;
        return array[index];
    }

    public int Size()
    {
        return count;
    }

// запросы статусов (возможные значения статусов)
    public int Get_GetItem_status()
    {
        return getItem_status;
    }
    public int Get_Insert_status()
    {
        return insert_status;
    }
    public int Get_Remove_status()
    {
        return remove_status;
    }
    public int Get_Replace_status()
    {
        return replace_status;
    }

    private void MakeArray(int new_capacity)
    {
        if(new_capacity < 16) MakeArray(16);
        else
        {
            capacity = new_capacity;
            if (array == null) array = new T[new_capacity];
            else
            {
                var tempArray = new T[new_capacity];
                Array.Copy(array, tempArray, count);
                array = tempArray;
            }
        }
    }
}