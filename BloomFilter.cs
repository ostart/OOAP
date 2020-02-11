/*
abstract class BloomFilter
// конструктор
    // постусловие: создан фильтр Блюма размером f_len
    public BloomFilter(int f_len);

// команды
    // постусловие: добавляем строку str в фильтр
    public void Add(string str);

// запросы
    public bool IsValue(string str); // проверка, имеется ли строка str в фильтре
*/

using System.Collections;
public class BloomFilter
{
    private int filter_len;
    private BitArray bitArray;

// конструктор
    public BloomFilter(int f_len)
    {
        filter_len = f_len;
        bitArray = new BitArray(filter_len); // создаём битовый массив длиной f_len
    }

// команды
    public void Add(string str) // добавляем строку str в фильтр
    {
        var index1 = Hash1(str);
        var index2 = Hash2(str);
        bitArray.Set(index1, true);
        bitArray.Set(index2, true);
    }

// запросы
    public bool IsValue(string str) // проверка, имеется ли строка str в фильтре
    {
        var index1 = Hash1(str);
        var index2 = Hash2(str);
        return bitArray[index1] && bitArray[index2];
    }


    // хэш-функции
    private int Hash1(string str1)
    {
        return CalculateHash(17, str1); // 17
    }
    private int Hash2(string str1)
    {
        return CalculateHash(223, str1); // 223
    }
    private int CalculateHash(int constant, string str1)
    {
        var counter = 0;
        for (int i = 0; i < str1.Length; i++)
        {
            int code = (int)str1[i];
            counter = (counter * constant + code) % filter_len;
        }
        return counter;
    }
}