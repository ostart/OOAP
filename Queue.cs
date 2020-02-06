/*
abstract class Queue<T>

// конструктор
    // постусловие: создана новая пустая очередь
    public Queue<T> Queue();

// команды
    // постусловие: элемент добавлен в очередь
    public void Enqueue(T item);

// запросы
    // предусловие: очередь не пуста
    public T Dequeue();

    public int Size(); // текущий размер массива 

// запросы статусов (возможные значения статусов)
    public int Get_Dequeue_status(); // успешно; очередь пуста
*/

using System.Collections.Generic;
public class Queue<T>
{
    private readonly List<T> list;
    private int dequeue_status;

    public const int DEQUEUE_OK = 0; // успешно
    public const int DEQUEUE_EMP = 1; // очередь пустая

// конструктор
    public Queue()
    {
        list = new List<T>(); // инициализация внутреннего хранилища очереди
        dequeue_status = DEQUEUE_EMP;
    } 

// команды
    public void Enqueue(T item)
    {
        list.Add(item); // вставка в хвост
    }

// запросы
    public T Dequeue()
    {
        // выдача из головы
        if(Size() == 0)
        {
            dequeue_status = DEQUEUE_EMP;
            return default(T);
        }
        var head = list[0];
        list.RemoveAt(0);
        dequeue_status = DEQUEUE_OK;
        return head;
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
}