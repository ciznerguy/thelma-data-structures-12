using System;

// פרק 10: מחלקה מופשטת
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

        Example01_FirstAbstract();
        Example02_AbstractMethod();
        Example03_PartialImplementation();
        Example04_Constructor();
        Example05_ArrayOfShapes();
        Example06_TotalArea();
        Example07_Employees();
        Example08_AbstractAnimals();
        Example09_Biggest();
        Example10_Contract();
    }

    // דוגמה 1: המחלקה המופשטת הראשונה
    // לפעמים מחלקה מתארת רעיון כללי שאי אפשר ליצור ממנו עצם, למשל צורה בלי לדעת איזו צורה.
    // מחלקה כזו מסומנת במילה השמורה למחלקה מופשטת, ואי אפשר ליצור ממנה עצמים.
    // אפשר רק ליצור עצמים מהמחלקות היורשות ממנה.
    static void Example01_FirstAbstract()
    {
        Console.WriteLine("Example 1: first abstract class");
        // ניסיון ליצור עצם ישירות מהמחלקה המופשטת גורם לשגיאת הידור,
        // ולכן אין כאן שורה כזו. יוצרים עצמים רק ממחלקות יורשות.
        Circle c = new Circle(2);
        Console.WriteLine(c.GetName());
        Console.WriteLine();
    }

    // דוגמה 2: פעולה מופשטת
    // פעולה מופשטת מוגדרת בלי גוף, רק עם החתימה שלה.
    // כל מחלקה יורשת שאינה מופשטת חייבת לממש אותה.
    // כך המחלקה המופשטת מבטיחה שלכל הצורות תהיה פעולה לחישוב שטח, בלי לדעת איך היא מחושבת.
    static void Example02_AbstractMethod()
    {
        Console.WriteLine("Example 2: abstract method");
        Rectangle r = new Rectangle(4, 5);
        Circle c = new Circle(2);
        Console.WriteLine("rectangle area = " + r.Area());
        Console.WriteLine("circle area = " + c.Area());
        Console.WriteLine();
    }

    // דוגמה 3: מימוש חלקי
    // במחלקה מופשטת יכולות להיות גם פעולות רגילות, עם גוף.
    // כאן פעולת התיאור משתמשת בפעולה המופשטת, שעדיין לא ידוע איך היא ממומשת.
    static void Example03_PartialImplementation()
    {
        Console.WriteLine("Example 3: partial implementation");
        Shape s1 = new Rectangle(3, 6);
        Shape s2 = new Circle(1);
        Console.WriteLine(s1.Describe());
        Console.WriteLine(s2.Describe());
        Console.WriteLine();
    }

    // דוגמה 4: בנאי במחלקה מופשטת
    // גם למחלקה מופשטת יש בנאי, שמאתחל את התכונות שלה.
    // הוא מופעל כשיוצרים עצם ממחלקה יורשת, בעזרת הפנייה למחלקת האב.
    static void Example04_Constructor()
    {
        Console.WriteLine("Example 4: constructor");
        Square sq = new Square(5);
        Console.WriteLine(sq.GetName());
        Console.WriteLine("area = " + sq.Area());
        Console.WriteLine();
    }

    // דוגמה 5: מערך של צורות
    // אפשר להגדיר משתנה או מערך מסוג המחלקה המופשטת, ולהכניס אליו עצמים של המחלקות היורשות.
    static void Example05_ArrayOfShapes()
    {
        Console.WriteLine("Example 5: array of shapes");
        Shape[] shapes = new Shape[4];
        shapes[0] = new Rectangle(2, 3);
        shapes[1] = new Circle(1);
        shapes[2] = new Square(4);
        shapes[3] = new Circle(3);
        for (int i = 0; i < shapes.Length; i++)
        {
            Console.WriteLine(shapes[i].Describe());
        }
        Console.WriteLine();
    }

    // דוגמה 6: סכום שטחים
    // הלולאה מפעילה את הפעולה המופשטת על כל צורה, ובכל צורה מתבצע החישוב שמתאים לה.
    static void Example06_TotalArea()
    {
        Console.WriteLine("Example 6: total area");
        Shape[] shapes = new Shape[3];
        shapes[0] = new Rectangle(2, 3);
        shapes[1] = new Square(4);
        shapes[2] = new Rectangle(1, 10);
        double total = 0;
        for (int i = 0; i < shapes.Length; i++)
        {
            total = total + shapes[i].Area();
        }
        Console.WriteLine("total area = " + total);
        Console.WriteLine();
    }

    // דוגמה 7: עובדים בשכר שונה
    // מחלקה מופשטת של עובד, עם פעולה מופשטת לחישוב שכר.
    // לכל סוג עובד חישוב אחר.
    static void Example07_Employees()
    {
        Console.WriteLine("Example 7: employees");
        Worker[] workers = new Worker[3];
        workers[0] = new MonthlyWorker("Dana", 9000);
        workers[1] = new HourlyWorker("Avi", 50, 160);
        workers[2] = new MonthlyWorker("Noa", 11000);
        for (int i = 0; i < workers.Length; i++)
        {
            Console.WriteLine(workers[i].GetName() + " earns " + workers[i].Pay());
        }
        Console.WriteLine();
    }

    // דוגמה 8: חיות שמדברות
    // המחלקה המופשטת מגדירה שלכל חיה יש קול, וכל חיה מממשת אותו בדרך שלה.
    static void Example08_AbstractAnimals()
    {
        Console.WriteLine("Example 8: abstract animals");
        Creature[] zoo = new Creature[3];
        zoo[0] = new Lion();
        zoo[1] = new Duck();
        zoo[2] = new Lion();
        for (int i = 0; i < zoo.Length; i++)
        {
            Console.WriteLine(zoo[i].Sound());
        }
        Console.WriteLine();
    }

    // דוגמה 9: הצורה הגדולה ביותר
    static void Example09_Biggest()
    {
        Console.WriteLine("Example 9: biggest shape");
        Shape[] shapes = new Shape[4];
        shapes[0] = new Rectangle(2, 3);
        shapes[1] = new Circle(2);
        shapes[2] = new Square(3);
        shapes[3] = new Rectangle(1, 5);
        Shape best = shapes[0];
        for (int i = 1; i < shapes.Length; i++)
        {
            if (shapes[i].Area() > best.Area())
            {
                best = shapes[i];
            }
        }
        Console.WriteLine("biggest: " + best.Describe());
        Console.WriteLine();
    }

    // דוגמה 10: המחלקה המופשטת כחוזה
    // כל מי שיורש ממחלקה מופשטת מתחייב לממש את כל הפעולות המופשטות שלה.
    // מי שכותב קוד שעובד עם צורות יכול לסמוך על כך שלכל צורה יש שטח,
    // גם צורות שייכתבו בעתיד.
    static void Example10_Contract()
    {
        Console.WriteLine("Example 10: the contract");
        Shape t = new Triangle(6, 5);
        Console.WriteLine(t.Describe());
        Console.WriteLine();
    }
}

// צורה: מחלקה מופשטת
abstract class Shape
{
    private string name;

    public Shape(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return this.name;
    }

    // פעולה מופשטת: אין לה גוף
    public abstract double Area();

    public string Describe()
    {
        return this.name + " with area " + this.Area();
    }
}

class Rectangle : Shape
{
    private int width;
    private int height;

    public Rectangle(int width, int height) : base("rectangle")
    {
        this.width = width;
        this.height = height;
    }

    public override double Area()
    {
        return this.width * this.height;
    }
}

class Circle : Shape
{
    private int radius;

    public Circle(int radius) : base("circle")
    {
        this.radius = radius;
    }

    // לשם פשטות החישוב משתמש בקירוב של פאי למספר 3
    public override double Area()
    {
        return 3 * this.radius * this.radius;
    }
}

class Square : Shape
{
    private int side;

    public Square(int side) : base("square")
    {
        this.side = side;
    }

    public override double Area()
    {
        return this.side * this.side;
    }
}

class Triangle : Shape
{
    private int baseLength;
    private int height;

    public Triangle(int baseLength, int height) : base("triangle")
    {
        this.baseLength = baseLength;
        this.height = height;
    }

    public override double Area()
    {
        return this.baseLength * this.height / 2.0;
    }
}

// עובד: מחלקה מופשטת עם פעולה מופשטת לחישוב שכר
abstract class Worker
{
    private string name;

    public Worker(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return this.name;
    }

    public abstract int Pay();
}

class MonthlyWorker : Worker
{
    private int salary;

    public MonthlyWorker(string name, int salary) : base(name)
    {
        this.salary = salary;
    }

    public override int Pay()
    {
        return this.salary;
    }
}

class HourlyWorker : Worker
{
    private int rate;
    private int hours;

    public HourlyWorker(string name, int rate, int hours) : base(name)
    {
        this.rate = rate;
        this.hours = hours;
    }

    public override int Pay()
    {
        return this.rate * this.hours;
    }
}

abstract class Creature
{
    public abstract string Sound();
}

class Lion : Creature
{
    public override string Sound()
    {
        return "roar";
    }
}

class Duck : Creature
{
    public override string Sound()
    {
        return "quack";
    }
}
