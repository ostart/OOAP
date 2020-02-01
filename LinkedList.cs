/* 
2.1
abstract class LinkedList<T>

    // интерфейс класса, реализующий АТД LinkedList
    public const int HEAD_NIL = 0; // head() ещё не вызывалась
    public const int HEAD_OK = 1; // последняя head() отработала нормально
    public const int HEAD_ERR = 2; // связанный список пустой

    public const int TAIL_NIL = 0; // tail() ещё не вызывалась
    public const int TAIL_OK = 1; // последняя tail() отработала нормально
    public const int TAIL_ERR = 2; // связанный список пустой

    public const int RIGHT_NIL = 0; // right() ещё не вызывалась
    public const int RIGHT_OK = 1; // последняя right() отработала нормально
    public const int RIGHT_ERR = 2; // связанный список пустой

    public const int PUT_RIGHT_NIL = 0; // put_right() ещё не вызывалась
    public const int PUT_RIGHT_OK = 1; // последняя put_right() отработала нормально
    public const int PUT_RIGHT_ERR = 2; // связанный список пустой

    public const int PUT_LEFT_NIL = 0; // put_left() ещё не вызывалась
    public const int PUT_LEFT_OK = 1; // последняя put_left() отработала нормально
    public const int PUT_LEFT_ERR = 2; // связанный список пустой

    public const int REMOTE_NIL = 0; // remote() ещё не вызывалась
    public const int REMOTE_OK = 1; // последняя remote() отработала нормально
    public const int REMOTE_ERR = 2; // связанный список пустой

    public const int REPLACE_NIL = 0; // replace() ещё не вызывалась
    public const int REPLACE_OK = 1; // последняя replace() отработала нормально
    public const int REPLACE_ERR = 2; // связанный список пустой

    public const int FIND_NIL = 0; // find() ещё не вызывалась
    public const int FIND_OK = 1; // последняя find() отработала нормально
    public const int FIND_ERR = 2; // связанный список пустой

    public const int REMOVE_ALL_NIL = 0; // remove_all() ещё не вызывалась
    public const int REMOVE_ALL_OK = 1; // последняя remove_all() отработала нормально
    public const int REMOVE_ALL_ERR = 2; // связанный список пустой

    public const int GET_NIL = 0; // get() ещё не вызывалась
    public const int GET_OK = 1; // последняя get() отработала нормально
    public const int GET_ERR = 2; // связанный список пустой
    

    // конструктор
    // постусловие: создан новый пустой связанный список
    public LinkedList<T> LinkedList();


    // команды:
    // предусловие: связанный список не пустой
    // постусловие: курсор переметился на первый узел связанного списка
    public void head();

    // предусловие: связанный список не пустой
    // постусловие: курсор переметился на последний узел связанного списка
    public void tail();

    // предусловие: связанный список не пустой
    // постусловие: курсор переметился на один узел вправо
    public void right();

    // предусловие: связанный список не пустой
    // постусловие: вставлен следом за текущим узлом новый узел с заданным значением
    public void put_right(T value);

    // предусловие: связанный список не пустой
    // постусловие: вставлен перед текущим узлом новый узел с заданным значением
    public void put_left(T value);

    // предусловие: связанный список не пустой
    // постусловие: текущий узел удален. курсор сместился к правому соседу, если он есть, в противном случае курсор сместился к левому соседу, если он есть
    public void remove();

    // постусловие: связанный список пустой
    public void clear();

    // постусловие: добавлен новый узел в хвост списка
    public void add_tail(T value);

    // предусловие: связанный список не пустой
    // постусловие: значение текущего узла заменено заданным значением
    public void replace(T value);

    // предусловие: связанный список не пустой
    // постусловие: курсор установлен на следующий узел с искомым значением (по отношению к текущему узлу)
    public void find(T value);

    // предусловие: связанный список не пустой
    // постусловие: в списке удалены все узлы с заданным значением
    public void remove_all(T value);


    // запросы:
    // предусловие: связанный список не пустой
    public T get();

    public int size();

    public bool is_head();

    public bool is_tail();

    public bool is_value();


    // дополнительные запросы:
    public int get_head_status(); // возвращает значение HEAD_*
    public int get_tail_status(); // возвращает значение TAIL_*
    public int get_right_status(); // возвращает значение RIGHT_*
    public int get_put_right_status(); // возвращает значение PUT_RIGHT_*
    public int get_put_left_status(); // возвращает значение PUT_LEFT_*
    public int get_remote_status(); // возвращает значение REMOTE_*
    public int get_replace_status(); // возвращает значение REPLACE_*
    public int get_find_status(); // возвращает значение FIND_*
    public int get_remove_all_status(); // возвращает значение REMOVE_ALL_*
    public int get_get_status(); // возвращает значение GET_*


2.2. Потому, что сведение операции tail к head + смещения через весь список нельзя считать эффективным.
2.3. Потому, что наличие операции find позволяет работать с целым списком, как со списком отобранных требуемых значений, передвигаясь только по ним
*/