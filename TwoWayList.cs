/*
abstract TwoWayList<T>: ParentList<T>

      // команды
    // предусловие: левее курсора есть элемент; 
    // постусловие: курсор сдвинут на один узел влево
      public void left(); 
*/

public class TwoWayList<T>: ParentList<T>
{
    private int left_status;

    public const int LEFT_NIL = 0; // right() ещё не вызывалась
    public const int LEFT_OK = 1; // последняя right() отработала нормально
    public const int LEFT_ERR = 2; // связанный список пустой
    public const int LEFT_EMP = 3; // слева элемент отсутствует

    public TwoWayList(): base()
    {
        left_status = LEFT_NIL;
    }

    public void Left()
    {
        if(Size() == 0)
            left_status = LEFT_ERR;

        if(cursor.Prev == null)
            left_status = LEFT_EMP;
        
        cursor = cursor.Prev;
        left_status = LEFT_OK;
    }

    public int Get_left_status()
    {
        return left_status;
    }
}