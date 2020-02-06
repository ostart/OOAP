/*
abstract class Queue<T>

// конструктор
    // постусловие: создана новая пустая очередь
    public Queue<T> Queue();

// команды
    // постусловие: элемент добавлен в очередь
    public void Enqueue(T item);

    // предусловие: очередь не пуста
    // постусловие: из головы очереди удален элемент
    public void Dequeue();

// запросы
    public T Get(); // содержимое головы очереди

    public int Size(); // текущий размер массива 

// запросы статусов (возможные значения статусов)
    public int Get_Dequeue_status(); // успешно; очередь пуста
    public int Get_Get_status(); // успешно; очередь пуста
*/

using System.Collections.Generic;
public class Queue<T>
{
    private readonly List<T> list;
    private int dequeue_status;
    private int get_status;

    public const int DEQUEUE_OK = 0; // успешно
    public const int DEQUEUE_EMP = 1; // очередь пустая
    public const int GET_OK = 0; // успешно
    public const int GET_EMP = 1; // очередь пустая

// конструктор
    public Queue()
    {
        list = new List<T>(); // инициализация внутреннего хранилища очереди
        dequeue_status = DEQUEUE_EMP;
        get_status = GET_EMP;
    } 

// команды
    public void Enqueue(T item)
    {
        list.Add(item); // вставка в хвост
    }

    public void Dequeue()
    {
        // выдача из головы
        if(Size() == 0)
            dequeue_status = DEQUEUE_EMP;
        else 
        {
            list.RemoveAt(0);
            dequeue_status = DEQUEUE_OK;
        }
    }

// запросы
    public T Get()
    {
        if(Size() == 0)
        {
            get_status = GET_EMP;
            return default(T);
        }

        dequeue_status = DEQUEUE_OK;
        return list[0];
    }

    public int Size()
    {
        return list.Count; // размер очереди
    }

// запросы статусов (возможные значения статусов)
    public int Get_Dequeue_status()
    {
        return dequeue_status;
    }

    public int Get_Get_status()
    {
        return get_status;
    }
}