/*
abstract class ParentList<T>

  // конструктор
// постусловие: создан новый пустой список
  public ParentList<T> ParentList();

  // команды
// предусловие: список не пуст; 
// постусловие: курсор установлен на первый узел в списке
  public void head(); 

// предусловие: список не пуст; 
// постусловие: курсор установлен на последний узел в списке
  public void tail(); 

// предусловие: правее курсора есть элемент; 
// постусловие: курсор сдвинут на один узел вправо
  public void right(); 

// предусловие: список не пуст; 
// постусловие: следом за текущим узлом добавлен новый узел с заданным значением
  public void put_right(T value); 

// предусловие: список не пуст; 
// постусловие: перед текущим узлом добавлен новый узел с заданным значением
  public void put_left(T value); 

 // предусловие: список не пуст; 
// постусловие: текущий узел удалён, курсор смещён к правому соседу, если он есть, в противном случае курсор смещён к левому соседу, если он есть
  public void remove();

// постусловие: список очищен от всех элементов
  public void clear(); 

// постусловие: новый узел добавлен в хвост списка
  public void add_tail(T value); 

// постусловие: в списке удалены все узлы с заданным значением
  public void remove_all(T value);

// предусловие: список не пуст;
// постусловие: значение текущего узла заменено на новое
  public void replace(T value); 

// постусловие: курсор установлен на следующий узел с искомым значением, если такой узел найден
  public void find(T value); 

  // запросы
  public T get(); // предусловие: список не пуст
  public bool is_head();
  public bool is_tail();
  public bool is_value();
  public int size();

  // запросы статусов (возможные значения статусов)
  public int get_head_status(); // успешно; список пуст
  public int get_tail_status(); // успешно; список пуст
  public int get_right_status(); // успешно; правее нету элемента
  public int get_put_right_status(); // успешно; список пуст
  public int get_put_left_status(); // успешно; список пуст
  public int get_remove_status(); // успешно; список пуст
  public int get_replace_status(); // успешно; список пуст
  public int get_find_status(); // следующий найден; следующий не найден; список пуст
  public int get_get_status(); // успешно; список пуст
*/
public class Node<T>
{
    internal T Value;
    internal Node<T> Next, Prev;

    internal Node(T value)
    {
        Value = value;
        Next = null;
        Prev = null;
    }
    internal Node(T value, Node<T> next)
    {
        Value = value;
        Next = next;
        Prev = null;
    }
    internal Node(T value, Node<T> next, Node<T> prev)
    {
        Value = value;
        Next = next;
        Prev = prev;
    }
}

public class ParentList<T>
{
    private Node<T> head;
    private Node<T> tail;
    protected Node<T> cursor;

    private int size;
    private int head_status;
    private int tail_status;
    private int right_status;
    private int put_right_status;
    private int put_left_status;
    private int remove_status;
    private int replace_status;
    private int find_status;
    private int get_status;

    public const int HEAD_NIL = 0; // head() ещё не вызывалась
    public const int HEAD_OK = 1; // последняя head() отработала нормально
    public const int HEAD_ERR = 2; // связанный список пустой

    public const int TAIL_NIL = 0; // tail() ещё не вызывалась
    public const int TAIL_OK = 1; // последняя tail() отработала нормально
    public const int TAIL_ERR = 2; // связанный список пустой

    public const int RIGHT_NIL = 0; // right() ещё не вызывалась
    public const int RIGHT_OK = 1; // последняя right() отработала нормально
    public const int RIGHT_ERR = 2; // связанный список пустой
    public const int RIGHT_EMP = 3; // справа элемент отсутствует

    public const int PUT_RIGHT_NIL = 0; // put_right() ещё не вызывалась
    public const int PUT_RIGHT_OK = 1; // последняя put_right() отработала нормально
    public const int PUT_RIGHT_ERR = 2; // связанный список пустой

    public const int PUT_LEFT_NIL = 0; // put_left() ещё не вызывалась
    public const int PUT_LEFT_OK = 1; // последняя put_left() отработала нормально
    public const int PUT_LEFT_ERR = 2; // связанный список пустой

    public const int REMOVE_NIL = 0; // remove() ещё не вызывалась
    public const int REMOVE_OK = 1; // последняя remove() отработала нормально
    public const int REMOVE_ERR = 2; // связанный список пустой

    public const int REPLACE_NIL = 0; // replace() ещё не вызывалась
    public const int REPLACE_OK = 1; // последняя replace() отработала нормально
    public const int REPLACE_ERR = 2; // связанный список пустой
    public const int REPLACE_NO = 3; // нет элементов для замены

    public const int FIND_NIL = 0; // find() ещё не вызывалась
    public const int FIND_OK = 1; // последняя find() отработала нормально
    public const int FIND_ERR = 2; // связанный список пустой
    public const int FIND_NO = 3; // следующий не найден

    public const int GET_NIL = 0; // get() ещё не вызывалась
    public const int GET_OK = 1; // последняя get() отработала нормально
    public const int GET_ERR = 2; // связанный список пустой
    
    public ParentList()
    {
        Clear();
    }

    public void Head()
    {
        if(Size() == 0)
        {
            head_status = HEAD_ERR;
            return;
        }
        cursor = head;
        head_status = HEAD_OK;
    }

    public void Tail()
    {
        if(Size() == 0)
        { 
          tail_status = TAIL_ERR;
          return;
        }
        cursor = tail;
        tail_status = TAIL_OK;
    }

    public void Right()
    {
        if(Size() == 0)
        {
          right_status = RIGHT_ERR;
          return;
        }
        if(cursor.Next == null)
        {
          right_status = RIGHT_EMP;
          return;
        }
        cursor = cursor.Next;
        right_status = RIGHT_OK;
    }

    public void Put_right(T value)
    {
        if(Size() == 0)
        {  
          put_right_status = PUT_RIGHT_ERR;
          return;
        }
        var next = new Node<T>(value, cursor.Next, cursor);
        if(cursor.Next != null)
            cursor.Next.Prev = next;
        cursor.Next = next;
        put_right_status = PUT_RIGHT_OK;
    }

    public void Put_left(T value)
    {
        if(Size() == 0)
        {
          put_left_status = PUT_RIGHT_ERR;
          return;
        }
        var prev = new Node<T>(value, cursor, cursor.Prev);
        if(cursor.Prev != null)
            cursor.Prev.Next = prev;
        cursor.Prev = prev;
        put_left_status = PUT_LEFT_OK;
    }

    public void Remove()
    {
        if(Size() == 0)
        {
          remove_status = REMOVE_ERR;
          return;
        }
        if(Size() == 1)
        {
            Clear();
            remove_status = REMOVE_OK;
            return;
        }
        var prev = cursor.Prev;
        var next = cursor.Next;
        if(prev != null)
        {
          prev.Next = next;
          cursor = prev;
        }
        if(next != null)
        {
          next.Prev = prev;
          cursor = next;
        }
        remove_status = REMOVE_OK;
    }

    public void Clear()
    {
        head = null;
        tail = null;
        cursor = null;
        size = 0;
        head_status = HEAD_NIL;
        tail_status = TAIL_NIL;
        right_status = RIGHT_NIL;
        put_right_status = PUT_RIGHT_NIL;
        put_left_status = PUT_LEFT_NIL;
        remove_status = REMOVE_NIL;
        replace_status = REPLACE_NIL;
        find_status = FIND_NIL;
        get_status = GET_NIL;
    }

    public void Add_tail(T value)
    {
        Tail();
        var status = Get_tail_status();
        if(status == TAIL_ERR || status == TAIL_NIL)
        {
           var current = new Node<T>(value);
           head = current;
           tail = current;
           cursor = current;
           return;
        }
        Put_right(value);
    }

    public void Remove_all(T value)
    {
      do
      {
          Find(value);
          if(get_find_status() == FIND_OK)
              Remove();
      } while (get_find_status() == FIND_OK);
    }

    public void Replace(T value)
    {
        Find(value);
        var status = get_find_status();
        if(status == FIND_ERR)
        {
            replace_status = REPLACE_ERR;
            return;
        }
        else if(status == FIND_NO)
        {
            replace_status = REPLACE_NO;
            return;
        }
        cursor.Value = value;
        replace_status = REPLACE_OK;
    }

    public void Find(T value)
    {
        if(Size() == 0)
        {
          find_status = FIND_ERR;
          return;
        }

        Head();
        do
        {
            if(cursor.Value == value)
            {
                find_status = FIND_OK;
                return;
            }
            Right();
        }
        while(Get_right_status() == RIGHT_OK);
        
        find_status = FIND_NO;     
    }

    public int Size()
    {
        return size;
    }

    public T Get()
    {
        if(Size() == 0)
        {
          get_status = GET_ERR;
          return;
        }
        get_status = GET_OK;
        return cursor.Value;
    }
    public bool Is_head()
    {
        return cursor != null && cursor.Prev == null;
    }
    public bool Is_tail()
    {
        return cursor != null && cursor.Next == null;
    }
    public bool Is_value()
    {
        return Size() != 0;
    }

    public int Get_head_status()
    {
        return head_status;
    }
    public int Get_tail_status()
    {
        return tail_status;
    }

    public int Get_right_status()
    {
        return right_status;
    }

    public int Get_put_right_status()
    {
        return put_right_status;
    }

    public int Get_put_left_status()
    {
        return put_left_status;
    }

    public int Get_remove_status()
    {
        return remove_status;
    }

    public int get_replace_status()
    {
        return replace_status;
    }
    public int get_find_status()
    {
        return find_status;
    }
    public int get_get_status()
    {
        return get_status;
    }
}