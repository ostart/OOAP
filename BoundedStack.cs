/*abstract class BoundedStack<T>

  // интерфейс класса, реализующий АТД Stack
  public const int POP_NIL = 0; // pop() ещё не вызывалась
  public const int POP_OK = 1; // последняя pop() отработала нормально
  public const int POP_ERR = 2; // стек пуст

  public const int PEEK_NIL = 0; // peek() ещё не вызывалась
  public const int PEEK_OK = 1; // последняя peek() вернула корректное значение 
  public const int PEEK_ERR = 2; // стек пуст

  public const int PUSH_NIL = 0; // push() еще не вызывалась
  public const int PUSH_OK = 1; // последняя push() добавила корректное значение
  public const int PUSH_ERR = 2; // стек переполнен

  // конструктор
  // предусловие: размер стека по умолчанию - 32 элемента
  // постусловие: создан новый пустой стек на заданное число элементов
  public BoundedStack<T> BoundedStack(int size);

  // команды:
  // предусловие: стек не переполнен; 
  // постусловие: в стек добавлено новое значение
  public void push(T value);
        
  // предусловие: стек не пустой; 
  // постусловие: из стека удалён верхний элемент
  public void pop();

  // постусловие: из стека удалятся все значения и установлены начальные статусы для предусловий push(), peek() и pop()
  public void clear();

  // запросы:
  // предусловие: стек не пустой
  public T peek();

  public int size();

  public int get_pop_status();

  public int get_peek_status();

  public int get_push_status();
*/

public class BoundedStack<T>
{
  private System.Collections.Generic.List<T> stack = new System.Collections.Generic.List<T>(); // основное хранилище стека
  private int peek_status; // статус запроса peek()
  private int pop_status; // статус команды pop()
  private int push_status; // статус команды push()
  private int stack_size = 32; // размер стека

  public const int POP_NIL = 0;
  public const int POP_OK = 1;
  public const int POP_ERR = 2;
  public const int PEEK_NIL = 0;
  public const int PEEK_OK = 1;
  public const int PEEK_ERR = 2;
  public const int PUSH_NIL = 0;
  public const int PUSH_OK = 1;
  public const int PUSH_ERR = 2;

  public BoundedStack(int stackSize = 32) // конструктор
  {
    Clear();
    stack_size = stackSize;
  }

  public void Push(T value)
  {
    if (Size() > stack_size)
        push_status = PUSH_ERR;
    else
    {
      stack.Add(value);
      push_status = PUSH_OK;
    }  
  }     

  public void Pop()
  {
    if (Size() > 0)
    {
      stack.RemoveAt(Size()-1);
      pop_status = POP_OK;
    }
    else
      pop_status = POP_ERR;
  }
    
  public void Clear()
  {
    stack.Clear(); // пустой список/стек
    // начальные статусы для предусловий push(), peek() и pop()
    peek_status = PEEK_NIL;
    pop_status = POP_NIL;
    push_status = POP_NIL;
  }
  public T Peek()
  {
    T result;
    if (Size() > 0)
    {
      result = stack[Size()-1];
      peek_status = PEEK_OK;
    }
    else
    {
      result = default(T);
      peek_status = PEEK_ERR;
    }
    return result;
  }

  public int Size()
  {
    return stack.Count;
  }

  // запросы статусов
  public int Get_pop_status()
  {
     return pop_status;
  }
  public int Get_peek_status()
  {
    return peek_status;
  }   
  public int Get_push_status()
  {
    return push_status;
  }
}