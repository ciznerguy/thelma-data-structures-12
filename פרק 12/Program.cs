using System;

// פרק 12: ממשקים
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

        Example01_FirstInterface();
        Example02_Contract();
        Example03_TwoInterfaces();
        Example04_InterfaceVariable();
        Example05_InterfaceParameter();
        Example06_InterfaceInheritance();
        Example07_CanDo();
        Example08_ShapesInterface();
        Example09_Comparable();
        Example10_AbstractAndInterface();
    }

    // דוגמה 1: הממשק הראשון
    // ממשק מגדיר התנהגות: רשימה של פעולות, בלי מימוש.
    // מחלקה שמממשת את הממשק מתחייבת לכתוב מימוש לכל הפעולות שלו.
    // ממשק מבטא את היחס יכול ל: ציפור יכולה לעוף.
    // לפי המוסכמה שם של ממשק מתחיל באות איי גדולה.
    static void Example01_FirstInterface()
    {
        Console.WriteLine("Example 1: first interface");
        Bird b = new Bird("Sparrow");
        b.Fly();
        Console.WriteLine();
    }

    // דוגמה 2: ממשק כחוזה
    // ממשק אינו מחלקה, ולא ניתן ליצור ממנו עצמים. הוא רק מגדיר טיפוס.
    // מחלקה שאינה מממשת את כל הפעולות של הממשק תגרום לשגיאת הידור.
    static void Example02_Contract()
    {
        Console.WriteLine("Example 2: the contract");
        Plane p = new Plane("Boeing");
        p.Fly();
        Console.WriteLine("max altitude = " + p.GetMaxAltitude());
        Console.WriteLine();
    }

    // דוגמה 3: כמה ממשקים
    // מחלקה יכולה לרשת ממחלקת אב אחת בלבד, אבל לממש כמה ממשקים.
    // הברווז יכול לעוף וגם לשחות.
    static void Example03_TwoInterfaces()
    {
        Console.WriteLine("Example 3: two interfaces");
        Duck d = new Duck("Donald");
        d.Fly();
        d.Swim();
        Console.WriteLine();
    }

    // דוגמה 4: משתנה מסוג ממשק
    // אפשר להגדיר משתנה או מערך מסוג ממשק, ולהציב בו עצם של כל מחלקה שמממשת אותו.
    // זה פולימורפיזם בעזרת ממשק: מחלקות שונות לגמרי, שמשותף להן רק מה שהן יכולות לעשות.
    static void Example04_InterfaceVariable()
    {
        Console.WriteLine("Example 4: interface variable");
        IFlyable[] flyers = new IFlyable[3];
        flyers[0] = new Bird("Sparrow");
        flyers[1] = new Plane("Boeing");
        flyers[2] = new Duck("Donald");
        for (int i = 0; i < flyers.Length; i++)
        {
            flyers[i].Fly();
        }
        Console.WriteLine();
    }

    // דוגמה 5: ממשק כפרמטר
    // פעולה שמקבלת פרמטר מסוג ממשק עובדת עם כל עצם שמממש אותו.
    static void Example05_InterfaceParameter()
    {
        Console.WriteLine("Example 5: interface parameter");
        LaunchAll(new Bird("Eagle"));
        LaunchAll(new Plane("Airbus"));
        Console.WriteLine();
    }

    static void LaunchAll(IFlyable f)
    {
        Console.WriteLine("preparing to fly");
        f.Fly();
    }

    // דוגמה 6: ירושה בין ממשקים
    // ממשק יכול לרשת מממשק אחר. מחלקה שמממשת את הממשק היורש חייבת לממש את הפעולות של שניהם.
    static void Example06_InterfaceInheritance()
    {
        Console.WriteLine("Example 6: interface inheritance");
        Robot r = new Robot("R2");
        r.Move();
        r.Charge();
        IChargeable c = r;
        c.Move();
        Console.WriteLine();
    }

    // דוגמה 7: סוג של ויכול ל
    // מחלקה יורשת ממחלקה אחת, כי היא סוג של משהו, וגם מממשת ממשקים, כי היא יכולה לעשות דברים.
    // מטוס הוא סוג של כלי תחבורה, והוא יכול לעוף.
    static void Example07_CanDo()
    {
        Console.WriteLine("Example 7: is a and can do");
        Jet j = new Jet("F-35", 4);
        Console.WriteLine(j.GetName() + " has " + j.GetEngines() + " engines");
        j.Fly();
        IFlyable f = j;
        f.Fly();
        Console.WriteLine();
    }

    // דוגמה 8: צורות בעזרת ממשק
    // הממשק מגדיר שלכל צורה יש שטח. כל מחלקה מממשת אותו בדרך שלה.
    static void Example08_ShapesInterface()
    {
        Console.WriteLine("Example 8: shapes");
        IShape[] shapes = new IShape[3];
        shapes[0] = new Rect(3, 4);
        shapes[1] = new Sq(5);
        shapes[2] = new Rect(1, 9);
        double total = 0;
        for (int i = 0; i < shapes.Length; i++)
        {
            Console.WriteLine(shapes[i].GetName() + ": " + shapes[i].Area());
            total = total + shapes[i].Area();
        }
        Console.WriteLine("total = " + total);
        Console.WriteLine();
    }

    // דוגמה 9: ממשק להשוואה
    // ממשק של השוואה מאפשר לכתוב אלגוריתם אחד, כמו מציאת המקסימום, שעובד על כל סוג עצמים
    // שיודעים להשוות את עצמם לעצם אחר.
    static void Example09_Comparable()
    {
        Console.WriteLine("Example 9: comparable");
        Book[] books = new Book[3];
        books[0] = new Book("Short", 120);
        books[1] = new Book("Long", 540);
        books[2] = new Book("Medium", 300);
        IComparableItem best = books[0];
        for (int i = 1; i < books.Length; i++)
        {
            if (books[i].IsBiggerThan(best))
            {
                best = books[i];
            }
        }
        Console.WriteLine("biggest book: " + best);
        Console.WriteLine();
    }

    // דוגמה 10: מחלקה מופשטת וממשק יחד
    // מחלקה מופשטת מגדירה בסיס משותף, עם תכונות, וממשק מגדיר יכולת.
    // כאן המחלקה של הכלב יורשת ממחלקה מופשטת, וגם מממשת ממשק.
    static void Example10_AbstractAndInterface()
    {
        Console.WriteLine("Example 10: abstract class and interface");
        Pet p = new PetDog("Rex");
        Console.WriteLine(p.GetName());
        Console.WriteLine(p.Sound());
        ITrainable t = (ITrainable)p;
        t.Train();
        Console.WriteLine();
    }
}

interface IFlyable
{
    void Fly();
}

interface ISwimmer
{
    void Swim();
}

class Bird : IFlyable
{
    private string name;

    public Bird(string name)
    {
        this.name = name;
    }

    public void Fly()
    {
        Console.WriteLine(this.name + " flaps its wings and flies");
    }
}

class Plane : IFlyable
{
    private string model;

    public Plane(string model)
    {
        this.model = model;
    }

    public void Fly()
    {
        Console.WriteLine(this.model + " flies with engines");
    }

    public int GetMaxAltitude()
    {
        return 12000;
    }
}

class Duck : IFlyable, ISwimmer
{
    private string name;

    public Duck(string name)
    {
        this.name = name;
    }

    public void Fly()
    {
        Console.WriteLine(this.name + " flies low");
    }

    public void Swim()
    {
        Console.WriteLine(this.name + " swims");
    }
}

interface IMovable
{
    void Move();
}

interface IChargeable : IMovable
{
    void Charge();
}

class Robot : IChargeable
{
    private string name;

    public Robot(string name)
    {
        this.name = name;
    }

    public void Move()
    {
        Console.WriteLine(this.name + " rolls forward");
    }

    public void Charge()
    {
        Console.WriteLine(this.name + " is charging");
    }
}

class Transport
{
    private string name;

    public Transport(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return this.name;
    }
}

class Jet : Transport, IFlyable
{
    private int engines;

    public Jet(string name, int engines) : base(name)
    {
        this.engines = engines;
    }

    public int GetEngines()
    {
        return this.engines;
    }

    public void Fly()
    {
        Console.WriteLine(this.GetName() + " flies fast");
    }
}

interface IShape
{
    string GetName();
    double Area();
}

class Rect : IShape
{
    private int width;
    private int height;

    public Rect(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public string GetName()
    {
        return "rectangle";
    }

    public double Area()
    {
        return this.width * this.height;
    }
}

class Sq : IShape
{
    private int side;

    public Sq(int side)
    {
        this.side = side;
    }

    public string GetName()
    {
        return "square";
    }

    public double Area()
    {
        return this.side * this.side;
    }
}

interface IComparableItem
{
    bool IsBiggerThan(IComparableItem other);
    int GetSize();
}

class Book : IComparableItem
{
    private string title;
    private int pages;

    public Book(string title, int pages)
    {
        this.title = title;
        this.pages = pages;
    }

    public int GetSize()
    {
        return this.pages;
    }

    public bool IsBiggerThan(IComparableItem other)
    {
        return this.pages > other.GetSize();
    }

    public override string ToString()
    {
        return this.title + " (" + this.pages + " pages)";
    }
}

interface ITrainable
{
    void Train();
}

abstract class Pet
{
    private string name;

    public Pet(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return this.name;
    }

    public abstract string Sound();
}

class PetDog : Pet, ITrainable
{
    public PetDog(string name) : base(name)
    {
    }

    public override string Sound()
    {
        return "woof";
    }

    public void Train()
    {
        Console.WriteLine(this.GetName() + " learns to sit");
    }
}
