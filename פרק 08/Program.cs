using System;

// פרק 8: הכלת עצמים
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

        Example01_ObjectInsideObject();
        Example02_Circle();
        Example03_Line();
        Example04_ArrayOfObjects();
        Example05_ClassWithArray();
        Example06_SearchInArray();
        Example07_Overloading();
        Example08_CopyConstructor();
        Example09_ShallowAndDeep();
        Example10_ReturnObject();
    }

    // דוגמה 1: עצם בתוך עצם
    // תכונה של מחלקה יכולה להיות עצם ממחלקה אחרת. לתלמיד כאן יש כתובת, והכתובת היא עצם.
    // כדי להגיע לעיר של התלמיד פונים קודם לתלמיד, ואחר כך לכתובת שלו.
    static void Example01_ObjectInsideObject()
    {
        Console.WriteLine("Example 1: object inside object");
        Address addr = new Address("Haifa", "Herzl", 12);
        Student s = new Student("Dana", addr);
        Console.WriteLine(s.GetName());
        Console.WriteLine(s.GetAddress().GetCity());
        Console.WriteLine(s);
        Console.WriteLine();
    }

    // דוגמה 2: עיגול עם מרכז
    // עיגול מורכב מנקודה, שהיא המרכז, ומרדיוס.
    // הפעולות של העיגול משתמשות בפעולות של הנקודה.
    static void Example02_Circle()
    {
        Console.WriteLine("Example 2: circle");
        Circle c = new Circle(new Point(0, 0), 5);
        Console.WriteLine(c);
        Console.WriteLine("inside (3,4)? " + c.IsInside(new Point(3, 4)));
        Console.WriteLine("inside (4,4)? " + c.IsInside(new Point(4, 4)));
        Console.WriteLine();
    }

    // דוגמה 3: קטע המורכב משתי נקודות
    static void Example03_Line()
    {
        Console.WriteLine("Example 3: line");
        Line l = new Line(new Point(1, 1), new Point(4, 5));
        Console.WriteLine(l);
        Console.WriteLine("length = " + l.Length());
        Console.WriteLine();
    }

    // דוגמה 4: מערך של עצמים
    // כשיוצרים מערך של עצמים, כל התאים בו ריקים בהתחלה.
    // צריך ליצור כל עצם בנפרד ולהכניס אותו למקום שלו במערך.
    static void Example04_ArrayOfObjects()
    {
        Console.WriteLine("Example 4: array of objects");
        Point[] points = new Point[3];
        Console.WriteLine("first cell is empty? " + (points[0] == null));
        points[0] = new Point(1, 2);
        points[1] = new Point(3, 4);
        points[2] = new Point(5, 6);
        for (int i = 0; i < points.Length; i++)
        {
            Console.WriteLine(i + ": " + points[i]);
        }
        Console.WriteLine();
    }

    // דוגמה 5: מחלקה שמכילה מערך של עצמים
    // כיתה מכילה מערך של תלמידים ומספר התלמידים שנמצאים בו.
    // הפעולות של הכיתה עוברות על המערך ומשתמשות בפעולות של התלמידים.
    static void Example05_ClassWithArray()
    {
        Console.WriteLine("Example 5: class with an array");
        ClassRoom room = new ClassRoom(5);
        room.Add(new Student("Dana", new Address("Haifa", "Herzl", 12)), 90);
        room.Add(new Student("Avi", new Address("Acre", "Weizmann", 3)), 70);
        room.Add(new Student("Noa", new Address("Haifa", "Carmel", 8)), 80);
        Console.WriteLine("students = " + room.GetCount());
        Console.WriteLine("average = " + room.Average());
        Console.WriteLine();
    }

    // דוגמה 6: חיפוש במערך של עצמים
    // עוברים על המערך ומשווים תכונה של כל עצם לערך שמחפשים.
    // אם לא נמצא עצם מתאים, מחזירים ערך ריק.
    static void Example06_SearchInArray()
    {
        Console.WriteLine("Example 6: search in an array of objects");
        Student[] arr = new Student[3];
        arr[0] = new Student("Dana", new Address("Haifa", "Herzl", 12));
        arr[1] = new Student("Avi", new Address("Acre", "Weizmann", 3));
        arr[2] = new Student("Noa", new Address("Haifa", "Carmel", 8));
        Student found = FindByName(arr, "Avi");
        if (found != null)
        {
            Console.WriteLine("found: " + found);
        }
        Student missing = FindByName(arr, "Ron");
        Console.WriteLine("Ron found? " + (missing != null));
        Console.WriteLine();
    }

    static Student FindByName(Student[] arr, string name)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].GetName() == name)
            {
                return arr[i];
            }
        }
        return null;
    }

    // דוגמה 7: העמסה
    // העמסה היא כמה פעולות באותה מחלקה עם אותו שם ורשימות פרמטרים שונות.
    // אפשר להעמיס בנאים וגם פעולות רגילות. לפי הפרמטרים שנשלחים נבחרת הפעולה המתאימה.
    static void Example07_Overloading()
    {
        Console.WriteLine("Example 7: overloading");
        Point a = new Point();
        Point b = new Point(3, 4);
        Point c = new Point(7);
        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine(c);
        Console.WriteLine("distance from origin of b = " + b.DistanceTo());
        Console.WriteLine("distance between a and b = " + a.DistanceTo(b));
        Console.WriteLine();
    }

    // דוגמה 8: בנאי מעתיק
    // בנאי מעתיק מקבל עצם מאותה מחלקה, ויוצר עצם חדש עם אותם ערכים.
    // אחרי ההעתקה שני העצמים נפרדים, ושינוי באחד לא משפיע על השני.
    static void Example08_CopyConstructor()
    {
        Console.WriteLine("Example 8: copy constructor");
        Point a = new Point(2, 3);
        Point b = new Point(a);
        b.SetX(50);
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
        Console.WriteLine();
    }

    // דוגמה 9: העתקה רדודה והעתקה עמוקה
    // כשלעצם יש תכונה שהיא עצם, העתקה של ההפניה בלבד גורמת לשני העצמים להשתמש באותו עצם פנימי.
    // לכן שינוי במרכז של עיגול אחד ישנה גם את העיגול השני.
    // בהעתקה עמוקה הבנאי יוצר גם עצם פנימי חדש.
    static void Example09_ShallowAndDeep()
    {
        Console.WriteLine("Example 9: shallow and deep copy");
        Circle original = new Circle(new Point(1, 1), 2);
        Circle shallow = original.ShallowCopy();
        Circle deep = new Circle(original);
        original.GetCenter().SetX(100);
        Console.WriteLine("original: " + original);
        Console.WriteLine("shallow: " + shallow);
        Console.WriteLine("deep: " + deep);
        Console.WriteLine();
    }

    // דוגמה 10: פעולה שמחזירה עצם
    // פעולה יכולה להחזיר עצם. כאן מחזירים את העיגול הגדול ביותר במערך.
    static void Example10_ReturnObject()
    {
        Console.WriteLine("Example 10: return an object");
        Circle[] circles = new Circle[3];
        circles[0] = new Circle(new Point(0, 0), 2);
        circles[1] = new Circle(new Point(1, 1), 9);
        circles[2] = new Circle(new Point(2, 2), 4);
        Circle biggest = Biggest(circles);
        Console.WriteLine("biggest: " + biggest);
        Console.WriteLine();
    }

    static Circle Biggest(Circle[] arr)
    {
        Circle best = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i].GetRadius() > best.GetRadius())
            {
                best = arr[i];
            }
        }
        return best;
    }
}

// כתובת
class Address
{
    private string city;
    private string street;
    private int number;

    public Address(string city, string street, int number)
    {
        this.city = city;
        this.street = street;
        this.number = number;
    }

    public string GetCity()
    {
        return this.city;
    }

    public override string ToString()
    {
        return this.street + " " + this.number + ", " + this.city;
    }
}

// תלמיד שמכיל עצם כתובת
class Student
{
    private string name;
    private Address address;

    public Student(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string GetName()
    {
        return this.name;
    }

    public Address GetAddress()
    {
        return this.address;
    }

    public override string ToString()
    {
        return this.name + " lives at " + this.address;
    }
}

// נקודה עם כמה בנאים
class Point
{
    private int x;
    private int y;

    public Point()
    {
        this.x = 0;
        this.y = 0;
    }

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Point(int both)
    {
        this.x = both;
        this.y = both;
    }

    public Point(Point other)
    {
        this.x = other.x;
        this.y = other.y;
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

    public double DistanceTo()
    {
        return Math.Sqrt(Math.Pow(this.x, 2) + Math.Pow(this.y, 2));
    }

    public double DistanceTo(Point other)
    {
        return Math.Sqrt(Math.Pow(this.x - other.x, 2) + Math.Pow(this.y - other.y, 2));
    }

    public override string ToString()
    {
        return "(" + this.x + "," + this.y + ")";
    }
}

// עיגול עם נקודת מרכז
class Circle
{
    private Point center;
    private int radius;

    public Circle(Point center, int radius)
    {
        this.center = center;
        this.radius = radius;
    }

    // בנאי מעתיק עמוק: נוצר גם מרכז חדש
    public Circle(Circle other)
    {
        this.center = new Point(other.center);
        this.radius = other.radius;
    }

    public Circle ShallowCopy()
    {
        return new Circle(this.center, this.radius);
    }

    public Point GetCenter()
    {
        return this.center;
    }

    public int GetRadius()
    {
        return this.radius;
    }

    public bool IsInside(Point p)
    {
        return this.center.DistanceTo(p) <= this.radius;
    }

    public override string ToString()
    {
        return "circle at " + this.center + " radius " + this.radius;
    }
}

// קטע שמורכב משתי נקודות
class Line
{
    private Point start;
    private Point end;

    public Line(Point start, Point end)
    {
        this.start = start;
        this.end = end;
    }

    public double Length()
    {
        return this.start.DistanceTo(this.end);
    }

    public override string ToString()
    {
        return this.start + " to " + this.end;
    }
}

// כיתה: מערך של תלמידים וציונים
class ClassRoom
{
    private Student[] students;
    private int[] grades;
    private int count;

    public ClassRoom(int capacity)
    {
        this.students = new Student[capacity];
        this.grades = new int[capacity];
        this.count = 0;
    }

    public void Add(Student s, int grade)
    {
        if (this.count < this.students.Length)
        {
            this.students[this.count] = s;
            this.grades[this.count] = grade;
            this.count++;
        }
    }

    public int GetCount()
    {
        return this.count;
    }

    public double Average()
    {
        int sum = 0;
        for (int i = 0; i < this.count; i++)
        {
            sum = sum + this.grades[i];
        }
        return (double)sum / this.count;
    }
}
