// Пример наследования вида: военнослужащий армии. Там одновременно присутствует иерархия званий, иерархия должностей, иерархия подразделений.
// В определённых условиях нужны каждые из них и выделить первостепенную иерархию не представляется возможным.
// Каждая иерархия реализуется с помощью полиморфизма и наследования, а сам объект военнослужащего содержит соответствующие поля для каждой из иерархий

public abstract class Rank {};
public class Soldier: Rank {};
public class Foreman: Soldier {};
public class Ensign: Foreman {};
public class Lieutenant: Ensign {};
public class Captain: Lieutenant {};

public abstract class Position {};
public class Member: Position {};
public class Branch: Member {};
public class Platoon: Branch {};
public class Company: Platoon {};
public class Colonel: Company {};

public class MilitaryMan 
{
    public Rank Rank { get;set; }
    public Position Position { get;set; }
}