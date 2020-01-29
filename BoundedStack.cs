/* class BoundedStack<T>

  // скрытые поля
  private List<T> stack; // основное хранилище стека
  private int peek_status; // статус запроса peek()
  private int pop_status; // статус команды pop()
  private int push_status; // статус команды push()
  private int stack_size; // размер стека


  // интерфейс класса, реализующий АТД Stack
  public const int POP_NIL = 0;
  public const int POP_OK = 1;
  public const int POP_ERR = 2;
  public const int PEEK_NIL = 0;
  public const int PEEK_OK = 1;
  public const int PEEK_ERR = 2;
  public const int PUSH_NIL = 0;
  public const int PUSH_OK = 1;
  public const int PUSH_ERR = 2;

  public void Stack(int stackSize = 32) // конструктор
    clear()
    stack_size = stackSize


  public void push(T value)
    if size() > stack_size
        push_status = PUSH_ERR
    else
        stack.Append(value)
        push_status = PUSH_OK
        

  public void pop()
    if size() > 0
      stack.RemoveAt(-1)
      pop_status = POP_OK
    else
      pop_status = POP_ERR

  public void clear()
    stack = [ ] // пустой список/стек

    // начальные статусы для предусловий push(), peek() и pop()
    peek_status = PEEK_NIL
    pop_status = POP_NIL
    push_status = POP_NIL

  public T peek()
    if size() > 0
      result = stack[-1]
      peek_status = PEEK_OK
    else
      result = 0
      peek_status = PEEK_ERR
    return result

  public int size()
    return stack.Length()

  // запросы статусов
  public int get_pop_status()
    return pop_status

  public int get_peek_status()
    return peek_status

  public int get_push_status()
    return push_status */

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