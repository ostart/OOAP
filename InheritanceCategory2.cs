// 4) Наследования вариаций
// Абстрактный класс Vehicle и его реализации: Automobile, Bike, Plane etc, переопределяющие абстрактный метод базового класса Move.
// Базовый класс SEGMENT и его метод perpendicular возвращает объект SEGMENT той же длины и повернутый на 90 градусов, его наследник DOTTED_SEGMENT также имеет метод perpendicular и возвращает объект DOTTED_SEGMENT.

// 5) Наследование с конкретизацией (reification inheritance)
// Класс TABLE, описывающий таблицы в общем виде и его насделники SEQUENTIAL_TABLE и HASH_TABLE. В свою очередь SEQUENTIAL_TABLE имеет классы наследники: ARRAYED_TABLE, LINKED_TABLE, FILE_TABLE.

// 6) Структурное наследование (structure inheritance)
// Класс INTEGER наследуется от класса NUMERIC и от интерфейса COMPARABLE. От NUMERIC он получает арифметические свойства, а от COMPARABLE сигнатуры операций сравнения.
