/*

abstract class ParentQueue<T>

// конструктор
    // постусловие: создана новая очередь
    public ParentQueue<T> ParentQueue();

// команды
    // постусловие: курсор установлен на первый узел в списке
    public void AddTail(T item);

    // предусловие: очередь не пуста
    // постусловие: из головы очереди удален элемент
    public void RemoveHead();

// запросы
    // предусловие: очередь не пуста
    public T GetHead(); // содержимое головы очереди

    public int Size(); // текущий размер массива 

// запросы статусов (возможные значения статусов)
    public int Get_RemoveHead_status(); // успешно; очередь пуста
    public int Get_GetHead_status(); // успешно; очередь пуста


abstract class Deque<T>: ParentQueue<T>

// команды
    // постусловие: курсор установлен на первый узел в списке
    public void AddHead(T item);

    // предусловие: очередь не пуста
    // постусловие: из хвоста очереди удален элемент
    public void RemoveTail();

// запросы
    // предусловие: очередь не пуста
    public T GetTail(); // содержимое хвоста очереди

// запросы статусов (возможные значения статусов)
    public int Get_RemoveTail_status(); // успешно; очередь пуста
    public int Get_GetTail_status(); // успешно; очередь пуста

abstract class Queue<T>: ParentQueue<T>
*/
using System.Collections.Generic;
public class ParentQueue<T>
{
    protected readonly List<T> list;
    private int removeHead_status;
    private int getHead_status;

    public const int REMOVEHEAD_OK = 0; // успешно
    public const int REMOVEHEAD_EMP = 1; // очередь пустая
    public const int GETHEAD_OK = 0; // успешно
    public const int GETHEAD_EMP = 1; // очередь пустая

// конструктор
    public ParentQueue()
    {
        list = new List<T>(); // инициализация внутреннего хранилища очереди
        removeHead_status = REMOVEHEAD_EMP;
        getHead_status = GETHEAD_EMP;
    } 

// команды
    public void AddTail(T item)
    {
        list.Add(item); // вставка в хвост
    }

    public void RemoveHead()
    {
        if(Size() == 0)
            removeHead_status = REMOVEHEAD_EMP;
        else 
        {
            list.RemoveAt(0);
            removeHead_status = REMOVEHEAD_OK;
        }
    }

// запросы
    public T GetHead()
    {
        if(Size() == 0)
        {
            getHead_status = GETHEAD_EMP;
            return default(T);
        }

        getHead_status = GETHEAD_OK;
        return list[0];
    }

    public int Size()
    {
        return list.Count; // размер очереди
    }

// запросы статусов (возможные значения статусов)
    public int Get_RemoveHead_status()
    {
        return removeHead_status;
    }

    public int Get_GetHead_status()
    {
        return getHead_status;
    }
}


public class Deque<T>: ParentQueue<T>
{
    private int removeTail_status;
    private int getTail_status;

    public const int REMOVETAIL_OK = 0; // успешно
    public const int REMOVETAIL_EMP = 1; // очередь пустая
    public const int GETTAIL_OK = 0; // успешно
    public const int GETTAIL_EMP = 1; // очередь пустая

// конструктор
    public Deque()
    {
        removeTail_status = REMOVETAIL_EMP;
        getTail_status = GETTAIL_EMP;
    } 

// команды
    public void AddHead(T item)
    {
        list.Insert(0, item); // вставка в голову
    }

    public void RemoveTail()
    {
        if(Size() == 0)
            removeTail_status = REMOVETAIL_EMP;
        else 
        {
            list.RemoveAt(list.Count - 1);
            removeTail_status = REMOVETAIL_OK;
        }
    }

// запросы
    public T GetTail()
    {
        if(Size() == 0)
        {
            getTail_status = GETTAIL_EMP;
            return default(T);
        }

        getTail_status = GETTAIL_OK;
        return list[list.Count - 1];
    }

// запросы статусов (возможные значения статусов)
    public int Get_RemoveTail_status()
    {
        return removeTail_status;
    }
    public int Get_GetTail_status()
    {
        return getTail_status;
    }
}


public class Queue<T>: ParentQueue<T> {}