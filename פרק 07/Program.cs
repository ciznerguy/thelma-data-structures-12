using System;

// פרק 7: מחלקות ועצמים
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

        Example01_FirstClass();
        Example02_ManyObjects();
        Example03_Setters();
        Example04_ToString();
        Example05_Methods();
        Example06_ValidState();
        Example07_Constructors();
        Example08_ValidInSetter();
        Example09_References();
        Example10_ObjectAsParameter();
    }

    // דוגמה 1: המחלקה הראשונה
    // תוכנית מונחית עצמים מתארת את העולם בעזרת עצמים. לכל עצם יש תכונות, שמתארות את מצבו,
    // ופעולות, שמתארות מה הוא יכול לעשות.
    // מחלקה היא תבנית שמגדירה אילו תכונות ואילו פעולות יהיו לעצמים מסוג מסוים.
    // המילה השמורה ליצירה יוצרת עצם חדש לפי התבנית, והבנאי מאתחל את התכונות שלו.
    // התכונות הן פרטיות, והגישה אליהן היא דרך פעולות קבלה.
    static void Example01_FirstClass()
    {
        Console.WriteLine("Example 1: first class");
        Point p = new Point(3, 4);
        Console.WriteLine("x = " + p.GetX());
        Console.WriteLine("y = " + p.GetY());
        Console.WriteLine();
    }

    // דוגמה 2: הרבה עצמים ממחלקה אחת
    // מאותה מחלקה אפשר ליצור כמה עצמים. לכל עצם יש תכונות משלו.
    // כל עצם הוא מופע של המחלקה.
    static void Example02_ManyObjects()
    {
        Console.WriteLine("Example 2: many objects");
        Student a = new Student("Dana", 95);
        Student b = new Student("Avi", 60);
        Student c = new Student("Noa", 45);
        Console.WriteLine(a.GetName() + " " + a.GetGrade());
        Console.WriteLine(b.GetName() + " " + b.GetGrade());
        Console.WriteLine(c.GetName() + " " + c.GetGrade());
        Console.WriteLine();
    }

    // דוגמה 3: פעולות עדכון
    // פעולת עדכון משנה תכונה של העצם. כך משנים את מצב העצם בלי לגשת ישירות לתכונות.
    static void Example03_Setters()
    {
        Console.WriteLine("Example 3: setters");
        Point p = new Point(1, 1);
        Console.WriteLine("before: " + p.GetX() + "," + p.GetY());
        p.SetX(10);
        p.SetY(20);
        Console.WriteLine("after: " + p.GetX() + "," + p.GetY());
        Console.WriteLine();
    }

    // דוגמה 4: המרה למחרוזת
    // כשמדפיסים עצם, מופעלת הפעולה שממירה אותו למחרוזת.
    // אם המחלקה לא מגדירה אותה, מודפס רק שם המחלקה. לכן מגדירים אותה מחדש בכל מחלקה.
    static void Example04_ToString()
    {
        Console.WriteLine("Example 4: ToString");
        Point p = new Point(5, 7);
        Console.WriteLine(p);
        Student s = new Student("Ron", 88);
        Console.WriteLine(s);
        Console.WriteLine();
    }

    // דוגמה 5: פעולות שמחשבות
    // שאילתה היא פעולה שמחזירה ערך ולא משנה את מצב העצם.
    // כאן כל הפעולות של המלבן הן שאילתות שמחשבות מהתכונות.
    static void Example05_Methods()
    {
        Console.WriteLine("Example 5: methods");
        Rectangle r = new Rectangle(4, 6);
        Console.WriteLine("area = " + r.Area());
        Console.WriteLine("perimeter = " + r.Perimeter());
        Console.WriteLine("is square? " + r.IsSquare());
        Rectangle s = new Rectangle(5, 5);
        Console.WriteLine("is square? " + s.IsSquare());
        Console.WriteLine();
    }

    // דוגמה 6: מצב תקין
    // מצב תקין של עצם הוא מצב שמקיים את הכללים של המחלקה. כאן היתרה לא תהיה שלילית.
    // פקודה היא פעולה שמשנה את מצב העצם. הפקודות מקפידות לא לשבור את הכלל.
    static void Example06_ValidState()
    {
        Console.WriteLine("Example 6: valid state");
        BankAccount acc = new BankAccount(100);
        acc.Deposit(50);
        Console.WriteLine("balance = " + acc.GetBalance());
        bool ok = acc.Withdraw(500);
        Console.WriteLine("withdraw 500 worked? " + ok);
        Console.WriteLine("balance = " + acc.GetBalance());
        ok = acc.Withdraw(120);
        Console.WriteLine("withdraw 120 worked? " + ok);
        Console.WriteLine("balance = " + acc.GetBalance());
        Console.WriteLine();
    }

    // דוגמה 7: כמה בנאים
    // למחלקה יכולים להיות כמה בנאים, והם נבדלים ברשימת הפרמטרים.
    // בנאי בלי פרמטרים נותן ערכי התחלה קבועים.
    static void Example07_Constructors()
    {
        Console.WriteLine("Example 7: constructors");
        Counter a = new Counter();
        Counter b = new Counter(100);
        a.Increase();
        a.Increase();
        b.Increase();
        Console.WriteLine("a = " + a.GetCount());
        Console.WriteLine("b = " + b.GetCount());
        a.Reset();
        Console.WriteLine("a after reset = " + a.GetCount());
        Console.WriteLine();
    }

    // דוגמה 8: בדיקה בפעולת העדכון
    // פעולת עדכון יכולה לבדוק את הערך החדש, ולשנות את התכונה רק אם הערך חוקי.
    static void Example08_ValidInSetter()
    {
        Console.WriteLine("Example 8: validation in a setter");
        Person p = new Person("Gil", 30);
        p.SetAge(31);
        Console.WriteLine(p);
        p.SetAge(-5);
        Console.WriteLine(p);
        p.SetAge(200);
        Console.WriteLine(p);
        Console.WriteLine();
    }

    // דוגמה 9: הפניות
    // משתנה מסוג מחלקה לא מכיל את העצם עצמו, אלא הפניה אליו.
    // כשמשימים משתנה אחד לאחר, מועתקת ההפניה ולא העצם. שני המשתנים מצביעים על אותו עצם.
    // רק המילה השמורה ליצירה יוצרת עצם חדש.
    static void Example09_References()
    {
        Console.WriteLine("Example 9: references");
        Point a = new Point(1, 2);
        Point b = a;
        b.SetX(99);
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
        Point c = new Point(99, 2);
        Console.WriteLine("a and b are the same object? " + (a == b));
        Console.WriteLine("a and c are the same object? " + (a == c));
        Console.WriteLine();
    }

    // דוגמה 10: עצם כפרמטר
    // כשמעבירים עצם לפעולה, מועברת הפניה אליו. לכן פעולה יכולה לשנות את העצם עצמו.
    // לעומת זאת, אם הפעולה תשים בפרמטר עצם אחר, זה לא ישפיע על המשתנה של הקורא.
    static void Example10_ObjectAsParameter()
    {
        Console.WriteLine("Example 10: object as a parameter");
        Student s = new Student("Lia", 50);
        Console.WriteLine("before: " + s);
        GiveBonus(s);
        Console.WriteLine("after bonus: " + s);
        Replace(s);
        Console.WriteLine("after replace: " + s);
        Console.WriteLine();
    }

    static void GiveBonus(Student st)
    {
        st.SetGrade(st.GetGrade() + 10);
    }

    static void Replace(Student st)
    {
        st = new Student("Other", 0);
    }
}

// נקודה במישור
class Point
{
    private int x;
    private int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int GetX()
    {
        return this.x;
    }

    public int GetY()
    {
        return this.y;
    }

    public void SetX(int x)
    {
        this.x = x;
    }

    public void SetY(int y)
    {
        this.y = y;
    }

    public override string ToString()
    {
        return "(" + this.x + "," + this.y + ")";
    }
}

// תלמיד עם שם וציון
class Student
{
    private string name;
    private int grade;

    public Student(string name, int grade)
    {
        this.name = name;
        this.grade = grade;
    }

    public string GetName()
    {
        return this.name;
    }

    public int GetGrade()
    {
        return this.grade;
    }

    public void SetGrade(int grade)
    {
        this.grade = grade;
    }

    public override string ToString()
    {
        return this.name + ": " + this.grade;
    }
}

// מלבן
class Rectangle
{
    private int width;
    private int height;

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public int Area()
    {
        return this.width * this.height;
    }

    public int Perimeter()
    {
        return 2 * (this.width + this.height);
    }

    public bool IsSquare()
    {
        return this.width == this.height;
    }
}

// חשבון בנק. היתרה אף פעם לא שלילית
class BankAccount
{
    private int balance;

    public BankAccount(int balance)
    {
        this.balance = balance;
    }

    public int GetBalance()
    {
        return this.balance;
    }

    public void Deposit(int amount)
    {
        if (amount > 0)
        {
            this.balance = this.balance + amount;
        }
    }

    public bool Withdraw(int amount)
    {
        if (amount > 0 && amount <= this.balance)
        {
            this.balance = this.balance - amount;
            return true;
        }
        return false;
    }
}

// מונה
class Counter
{
    private int count;

    public Counter()
    {
        this.count = 0;
    }

    public Counter(int start)
    {
        this.count = start;
    }

    public int GetCount()
    {
        return this.count;
    }

    public void Increase()
    {
        this.count++;
    }

    public void Reset()
    {
        this.count = 0;
    }
}

// אדם עם גיל חוקי
class Person
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public void SetAge(int age)
    {
        if (age >= 0 && age <= 120)
        {
            this.age = age;
        }
    }

    public override string ToString()
    {
        return this.name + ", age " + this.age;
    }
}
