using System;

// פרק 9: הורשה
internal class Program
{
    static void Main(string[] args)
    {
        // ===== איך מריצים את התוכנית =====
        // 1. נכנסים לסביבת הקוד של סטאקס, לוחצים על סביבת קוד, אחר כך על פרויקט חדש, נותנים שם לפרויקט ובוחרים בשפה סי שארפ.
        // 2. מוחקים את הקוד שמופיע בקובץ שנפתח, אם יש בו קוד.
        // 3. מעתיקים את כל הקוד שבקובץ הזה, מההתחלה ועד הסוף, ומדביקים בסביבה.
        // 4. לוחצים על כפתור ההרצה בסרגל העליון. הפלט מופיע בחלון הפלט.
        // 5. כל שורה למטה מפעילה דוגמה אחת. כדי להריץ רק דוגמה מסוימת,
        //    שמים שני לוכסנים בתחילת השורות של שאר הדוגמאות והופכים אותן להערה.

        Example01_FirstInheritance();
        Example02_BaseConstructor();
        Example03_NewMembers();
        Example04_Override();
        Example05_CallBase();
        Example06_ToStringInherited();
        Example07_ThreeLevels();
        Example08_Protected();
        Example09_IsA();
        Example10_Employees();
    }

    // דוגמה 1: ההורשה הראשונה
    // הורשה מאפשרת להגדיר מחלקה חדשה על בסיס מחלקה קיימת.
    // המחלקה החדשה נקראת מחלקה יורשת, והמחלקה הקיימת נקראת מחלקת האב.
    // המחלקה היורשת מקבלת את כל התכונות והפעולות של מחלקת האב, בלי לכתוב אותן שוב.
    // ההורשה מבטאת את היחס הוא סוג של: כלב הוא סוג של חיה.
    static void Example01_FirstInheritance()
    {
        Console.WriteLine("Example 1: first inheritance");
        Dog d = new Dog("Rex");
        Console.WriteLine(d.GetName());
        d.Eat();
        Console.WriteLine();
    }

    // דוגמה 2: בנאי של מחלקת האב
    // הבנאי אינו עובר בהורשה. הבנאי של המחלקה היורשת פונה לבנאי של מחלקת האב,
    // בעזרת המילה השמורה שמציינת את מחלקת האב, כדי לאתחל את התכונות שירשה.
    static void Example02_BaseConstructor()
    {
        Console.WriteLine("Example 2: base constructor");
        Cat c = new Cat("Tom", 4);
        Console.WriteLine(c.GetName());
        Console.WriteLine("lives = " + c.GetLives());
        Console.WriteLine();
    }

    // דוגמה 3: חברים חדשים במחלקה היורשת
    // מחלקה יורשת יכולה להוסיף תכונות ופעולות משלה, בנוסף למה שירשה.
    static void Example03_NewMembers()
    {
        Console.WriteLine("Example 3: new members");
        Dog d = new Dog("Max");
        d.Fetch();
        d.Eat();
        Console.WriteLine();
    }

    // דוגמה 4: דריסת פעולה
    // מחלקה יורשת יכולה להגדיר מחדש פעולה שירשה, כדי שתתאים לה. זו דריסה.
    // כדי לאפשר דריסה, הפעולה במחלקת האב מסומנת במילה השמורה שמתירה אותה,
    // והפעולה במחלקה היורשת מסומנת במילה השמורה שמציינת שהיא דורסת.
    static void Example04_Override()
    {
        Console.WriteLine("Example 4: override");
        Animal a = new Animal("Generic");
        Dog d = new Dog("Rex");
        Cat c = new Cat("Tom", 9);
        a.Speak();
        d.Speak();
        c.Speak();
        Console.WriteLine();
    }

    // דוגמה 5: קריאה לפעולה של מחלקת האב
    // פעולה שדורסת פעולה אחרת יכולה להפעיל גם את הפעולה המקורית של מחלקת האב.
    // כך מרחיבים את ההתנהגות במקום להחליף אותה לגמרי.
    static void Example05_CallBase()
    {
        Console.WriteLine("Example 5: call the base method");
        Puppy p = new Puppy("Bobby");
        p.Speak();
        Console.WriteLine();
    }

    // דוגמה 6: המרה למחרוזת בהורשה
    // כל מחלקה יורשת מהמחלקה הראשונה, שהיא אב קדמון של כל המחלקות, וממנה ירשה את פעולת ההמרה למחרוזת.
    // המחלקות דורסות אותה, ויכולות להשתמש בגרסה של מחלקת האב.
    static void Example06_ToStringInherited()
    {
        Console.WriteLine("Example 6: ToString");
        Animal a = new Animal("Generic");
        Dog d = new Dog("Rex");
        Cat c = new Cat("Tom", 7);
        Console.WriteLine(a);
        Console.WriteLine(d);
        Console.WriteLine(c);
        Console.WriteLine();
    }

    // דוגמה 7: שלוש רמות של הורשה
    // גור הכלבים יורש מכלב, וכלב יורש מחיה. לכן גור הכלבים מקבל את כל מה שיש לשתיהן.
    static void Example07_ThreeLevels()
    {
        Console.WriteLine("Example 7: three levels");
        Puppy p = new Puppy("Bobby");
        Console.WriteLine(p.GetName());
        p.Eat();
        p.Fetch();
        p.Play();
        Console.WriteLine();
    }

    // דוגמה 8: הרשאת גישה מוגנת
    // תכונה פרטית היא נגישה רק במחלקה שהגדירה אותה, ואפילו מחלקה יורשת לא יכולה לגשת אליה.
    // תכונה מוגנת היא נגישה במחלקה שהגדירה אותה ובכל המחלקות שיורשות ממנה.
    static void Example08_Protected()
    {
        Console.WriteLine("Example 8: protected");
        Vehicle v = new Vehicle("generic", 100);
        Car car = new Car("sedan", 180, 4);
        Console.WriteLine(v.Describe());
        Console.WriteLine(car.Describe());
        Console.WriteLine();
    }

    // דוגמה 9: היחס הוא סוג של
    // עצם של מחלקה יורשת הוא גם עצם של מחלקת האב, ולכן אפשר להציב אותו במשתנה מסוג האב.
    // דרך המשתנה הזה אפשר להפעיל רק את הפעולות שמוגדרות במחלקת האב.
    static void Example09_IsA()
    {
        Console.WriteLine("Example 9: is a");
        Animal a = new Dog("Rex");
        Console.WriteLine(a.GetName());
        a.Eat();
        Console.WriteLine("a is a dog? " + (a is Dog));
        Console.WriteLine("a is a cat? " + (a is Cat));
        Console.WriteLine();
    }

    // דוגמה 10: עובדים ומנהלים
    // מנהל הוא סוג של עובד. הוא יורש את השם ואת המשכורת, ודורס את חישוב המשכורת
    // כדי להוסיף לה בונוס.
    static void Example10_Employees()
    {
        Console.WriteLine("Example 10: employees");
        Employee e = new Employee("Dana", 8000);
        Manager m = new Manager("Avi", 12000, 3000);
        Console.WriteLine(e);
        Console.WriteLine(m);
        Console.WriteLine("employee pays " + e.GetPay());
        Console.WriteLine("manager pays " + m.GetPay());
        Console.WriteLine();
    }
}

// חיה: מחלקת האב
class Animal
{
    private string name;

    public Animal(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return this.name;
    }

    public void Eat()
    {
        Console.WriteLine(this.name + " is eating");
    }

    public virtual void Speak()
    {
        Console.WriteLine(this.name + " makes a sound");
    }

    public override string ToString()
    {
        return "animal " + this.name;
    }
}

// כלב יורש מחיה
class Dog : Animal
{
    public Dog(string name) : base(name)
    {
    }

    public void Fetch()
    {
        Console.WriteLine(this.GetName() + " fetches the ball");
    }

    public override void Speak()
    {
        Console.WriteLine(this.GetName() + " says woof");
    }

    public override string ToString()
    {
        return "dog " + this.GetName();
    }
}

// חתול יורש מחיה ומוסיף תכונה
class Cat : Animal
{
    private int lives;

    public Cat(string name, int lives) : base(name)
    {
        this.lives = lives;
    }

    public int GetLives()
    {
        return this.lives;
    }

    public override void Speak()
    {
        Console.WriteLine(this.GetName() + " says meow");
    }

    public override string ToString()
    {
        return base.ToString() + " with " + this.lives + " lives";
    }
}

// גור כלבים יורש מכלב
class Puppy : Dog
{
    public Puppy(string name) : base(name)
    {
    }

    public void Play()
    {
        Console.WriteLine(this.GetName() + " plays");
    }

    public override void Speak()
    {
        base.Speak();
        Console.WriteLine(this.GetName() + " also squeaks");
    }
}

// רכב עם תכונה מוגנת
class Vehicle
{
    private string type;
    protected int maxSpeed;

    public Vehicle(string type, int maxSpeed)
    {
        this.type = type;
        this.maxSpeed = maxSpeed;
    }

    public string GetVehicleType()
    {
        return this.type;
    }

    public virtual string Describe()
    {
        return this.type + " up to " + this.maxSpeed;
    }
}

class Car : Vehicle
{
    private int doors;

    public Car(string type, int maxSpeed, int doors) : base(type, maxSpeed)
    {
        this.doors = doors;
    }

    public override string Describe()
    {
        // התכונה המוגנת נגישה כאן, אבל התכונה הפרטית של מחלקת האב אינה נגישה
        return this.GetVehicleType() + " with " + this.doors + " doors, speed " + this.maxSpeed;
    }
}

// עובד ומנהל
class Employee
{
    private string name;
    private int salary;

    public Employee(string name, int salary)
    {
        this.name = name;
        this.salary = salary;
    }

    public string GetName()
    {
        return this.name;
    }

    public int GetSalary()
    {
        return this.salary;
    }

    public virtual int GetPay()
    {
        return this.salary;
    }

    public override string ToString()
    {
        return this.name + " (salary " + this.salary + ")";
    }
}

class Manager : Employee
{
    private int bonus;

    public Manager(string name, int salary, int bonus) : base(name, salary)
    {
        this.bonus = bonus;
    }

    public override int GetPay()
    {
        return base.GetPay() + this.bonus;
    }

    public override string ToString()
    {
        return "manager " + base.ToString();
    }
}
