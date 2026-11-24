using System;

// פרק 11: פולימורפיזם
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

        Example01_BaseVariable();
        Example02_PolymorphicCall();
        Example03_MixedArray();
        Example04_BaseParameter();
        Example05_ReturnBase();
        Example06_PrintArray();
        Example07_IsOperator();
        Example08_Downcast();
        Example09_Payroll();
        Example10_NewSubclass();
    }

    // דוגמה 1: משתנה מסוג מחלקת האב
    // פולימורפיזם פירושו רב צורות. משתנה מסוג מחלקת האב יכול להצביע על עצם של כל מחלקה יורשת.
    // הצבת עצם של מחלקה יורשת במשתנה מסוג האב נקראת המרה כלפי מעלה, והיא מתבצעת אוטומטית.
    static void Example01_BaseVariable()
    {
        Console.WriteLine("Example 1: variable of the base type");
        Vehicle v = new Car();
        Console.WriteLine(v.GetWheels());
        v = new Bicycle();
        Console.WriteLine(v.GetWheels());
        Console.WriteLine();
    }

    // דוגמה 2: זימון פולימורפי
    // כשמפעילים פעולה דרך משתנה מסוג האב, מתבצעת הפעולה של המחלקה של העצם עצמו,
    // והיא נקבעת רק בזמן הריצה. זהו זימון פולימורפי.
    // הפעולה חייבת להיות מוגדרת במחלקת האב, ולהיות מסומנת כניתנת לדריסה.
    static void Example02_PolymorphicCall()
    {
        Console.WriteLine("Example 2: polymorphic call");
        Vehicle a = new Car();
        Vehicle b = new Bicycle();
        Vehicle c = new Truck();
        Console.WriteLine(a.Describe());
        Console.WriteLine(b.Describe());
        Console.WriteLine(c.Describe());
        Console.WriteLine();
    }

    // דוגמה 3: מערך מעורב
    // במערך מסוג האב אפשר לשמור עצמים של מחלקות שונות.
    // הלולאה מפעילה את אותה פעולה על כולם, וכל עצם מגיב בדרך שמתאימה לו.
    static void Example03_MixedArray()
    {
        Console.WriteLine("Example 3: mixed array");
        Vehicle[] fleet = new Vehicle[4];
        fleet[0] = new Car();
        fleet[1] = new Bicycle();
        fleet[2] = new Truck();
        fleet[3] = new Car();
        int wheels = 0;
        for (int i = 0; i < fleet.Length; i++)
        {
            wheels = wheels + fleet[i].GetWheels();
        }
        Console.WriteLine("total wheels = " + wheels);
        Console.WriteLine();
    }

    // דוגמה 4: פרמטר מסוג האב
    // פעולה שמקבלת פרמטר מסוג האב מקבלת עצם של כל מחלקה יורשת.
    // לכן מספיק לכתוב אותה פעם אחת.
    static void Example04_BaseParameter()
    {
        Console.WriteLine("Example 4: base-type parameter");
        Report(new Car());
        Report(new Bicycle());
        Report(new Truck());
        Console.WriteLine();
    }

    static void Report(Vehicle v)
    {
        Console.WriteLine("vehicle report: " + v.Describe() + ", wheels " + v.GetWheels());
    }

    // דוגמה 5: פעולה שמחזירה סוג אב
    // הפעולה מחזירה עצם מסוג האב, אבל בפועל נוצר עצם של מחלקה יורשת לפי הפרמטר.
    // מי שקורא לה לא צריך לדעת איזו מחלקה נבחרה.
    static void Example05_ReturnBase()
    {
        Console.WriteLine("Example 5: return the base type");
        for (int i = 1; i <= 3; i++)
        {
            Vehicle v = Create(i);
            Console.WriteLine(i + " -> " + v.Describe());
        }
        Console.WriteLine();
    }

    static Vehicle Create(int kind)
    {
        if (kind == 1)
        {
            return new Car();
        }
        if (kind == 2)
        {
            return new Bicycle();
        }
        return new Truck();
    }

    // דוגמה 6: הדפסת מערך של עצמים
    // הדפסה של עצם מפעילה את פעולת ההמרה למחרוזת שלו, והיא גם פולימורפית.
    static void Example06_PrintArray()
    {
        Console.WriteLine("Example 6: print an array");
        Vehicle[] fleet = new Vehicle[3];
        fleet[0] = new Truck();
        fleet[1] = new Bicycle();
        fleet[2] = new Car();
        for (int i = 0; i < fleet.Length; i++)
        {
            Console.WriteLine(fleet[i]);
        }
        Console.WriteLine();
    }

    // דוגמה 7: בדיקת סוג העצם
    // האופרטור שמציין שעצם הוא מופע של מחלקה בודק את סוג העצם בפועל.
    // כדאי להשתמש בו כמה שפחות, כי הפולימורפיזם נועד להימנע מבדיקות כאלה.
    static void Example07_IsOperator()
    {
        Console.WriteLine("Example 7: checking the type");
        Vehicle[] fleet = new Vehicle[3];
        fleet[0] = new Car();
        fleet[1] = new Truck();
        fleet[2] = new Bicycle();
        int trucks = 0;
        for (int i = 0; i < fleet.Length; i++)
        {
            if (fleet[i] is Truck)
            {
                trucks++;
            }
        }
        Console.WriteLine("trucks = " + trucks);
        Console.WriteLine();
    }

    // דוגמה 8: המרה כלפי מטה
    // דרך משתנה מסוג האב אפשר להפעיל רק פעולות של מחלקת האב.
    // כדי להפעיל פעולה שקיימת רק במחלקה היורשת, ממירים את המשתנה כלפי מטה לסוג של המחלקה היורשת.
    // ההמרה מצליחה רק אם העצם באמת מהסוג הזה, ולכן בודקים אותו קודם.
    static void Example08_Downcast()
    {
        Console.WriteLine("Example 8: downcast");
        Vehicle v = new Truck();
        if (v is Truck)
        {
            Truck t = (Truck)v;
            Console.WriteLine("load = " + t.GetLoad());
        }
        Vehicle w = new Bicycle();
        if (w is Truck)
        {
            Console.WriteLine("this line is not printed");
        }
        else
        {
            Console.WriteLine("w is not a truck");
        }
        Console.WriteLine();
    }

    // דוגמה 9: חישוב שכר פולימורפי
    // הפעולה מחשבת סכום שכר לכל העובדים, בלי לדעת איזה סוג עובד יש בכל תא.
    static void Example09_Payroll()
    {
        Console.WriteLine("Example 9: payroll");
        Employee[] staff = new Employee[4];
        staff[0] = new Employee("Dana", 8000);
        staff[1] = new Manager("Avi", 12000, 3000);
        staff[2] = new Employee("Noa", 9000);
        staff[3] = new Manager("Ron", 10000, 1500);
        int total = 0;
        for (int i = 0; i < staff.Length; i++)
        {
            total = total + staff[i].GetPay();
        }
        Console.WriteLine("total pay = " + total);
        Console.WriteLine();
    }

    // דוגמה 10: הוספת מחלקה חדשה בלי לשנות קוד קיים
    // המחלקה החדשה של מנהל בכיר יורשת ממנהל, ודורסת את חישוב השכר.
    // הלולאה שכתבנו קודם לא תשתנה, והיא תעבוד גם עם העצמים החדשים.
    // זה היתרון הגדול של הפולימורפיזם: אפשר להרחיב את התוכנית בלי לשבור את מה שכבר כתוב.
    static void Example10_NewSubclass()
    {
        Console.WriteLine("Example 10: a new subclass");
        Employee[] staff = new Employee[3];
        staff[0] = new Employee("Dana", 8000);
        staff[1] = new Manager("Avi", 12000, 3000);
        staff[2] = new SeniorManager("Gal", 15000, 4000, 2000);
        for (int i = 0; i < staff.Length; i++)
        {
            Console.WriteLine(staff[i].GetName() + " earns " + staff[i].GetPay());
        }
        Console.WriteLine();
    }
}

class Vehicle
{
    public virtual int GetWheels()
    {
        return 0;
    }

    public virtual string Describe()
    {
        return "a vehicle";
    }

    public override string ToString()
    {
        return this.Describe();
    }
}

class Car : Vehicle
{
    public override int GetWheels()
    {
        return 4;
    }

    public override string Describe()
    {
        return "a car";
    }
}

class Bicycle : Vehicle
{
    public override int GetWheels()
    {
        return 2;
    }

    public override string Describe()
    {
        return "a bicycle";
    }
}

class Truck : Vehicle
{
    public override int GetWheels()
    {
        return 6;
    }

    public override string Describe()
    {
        return "a truck";
    }

    public int GetLoad()
    {
        return 12;
    }
}

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

    public virtual int GetPay()
    {
        return this.salary;
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
}

class SeniorManager : Manager
{
    private int extra;

    public SeniorManager(string name, int salary, int bonus, int extra) : base(name, salary, bonus)
    {
        this.extra = extra;
    }

    public override int GetPay()
    {
        return base.GetPay() + this.extra;
    }
}
