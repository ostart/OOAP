// Правило: если отношение похоже на "является", но тип наследуемого объекта по логике работы программы может меняться, то правильным отношением будет "содержит".
// Приведите два словесных примера отношения "содержит" между классами, которое похоже на "является", но по вышеупомянутому правилу таковым не является.

1. Класс "человек" и возможные классы наследники: "отец", "муж", "мать", "инженер", "гражданин", "мужчина", "женщина".
Тогда можно оставить класс "человек" и внутри него ввести полиморфное поле "роль", либо массив "ролей", т.к. они могут присутствовать одновременно. 
Например: и "отец", и "инженер", и "мужчина".

2. Класс "смартфон" может быть наследником класса "телефон". 
Но согласно правилу "смартфон" может содержать поля "батарея" и "чехол", представленные в виде полей.