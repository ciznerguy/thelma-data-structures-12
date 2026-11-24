using System;

// פרק 5: שרשרת חוליות
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

        Example01_BuildChain();
        Example02_Traverse();
        Example03_LengthAndSum();
        Example04_Contains();
        Example05_AddFirst();
        Example06_AddLast();
        Example07_RemoveValue();
        Example08_InsertSorted();
        Example09_ChainOfStrings();
        Example10_RecursiveChain();
    }

    // דוגמה 1: בניית שרשרת חוליות
    // חוליה מכילה ערך, והפניה לחוליה הבאה. החוליה האחרונה מצביעה על ריק.
    // שרשרת חוליות מיוצגת על ידי משתנה שמצביע על החוליה הראשונה.
    // כאן בונים את השרשרת מהסוף להתחלה: כל חוליה חדשה מקבלת את ההפניה לחוליה שאחריה.
    static void Example01_BuildChain()
    {
        Console.WriteLine("Example 1: build a chain");
        Node<int> third = new Node<int>(30);
        Node<int> second = new Node<int>(20, third);
        Node<int> head = new Node<int>(10, second);
        Console.WriteLine(head);
        Console.WriteLine("first value = " + head.GetValue());
        Console.WriteLine("second value = " + head.GetNext().GetValue());
        Console.WriteLine();
    }

    // דוגמה 2: מעבר על השרשרת
    // משתנה עזר מתחיל בחוליה הראשונה, ובכל סיבוב עובר לחוליה הבאה.
    // הלולאה נגמרת כשמשתנה העזר מגיע לערך ריק, כלומר אחרי החוליה האחרונה.
    // חשוב לא לשנות את המשתנה שמצביע על ההתחלה, כדי לא לאבד את השרשרת.
    static void Example02_Traverse()
    {
        Console.WriteLine("Example 2: traverse a chain");
        Node<int> head = BuildSample();
        Node<int> p = head;
        while (p != null)
        {
            Console.Write(p.GetValue() + " ");
            p = p.GetNext();
        }
        Console.WriteLine();
        Console.WriteLine();
    }

    // פעולת עזר: בונה את השרשרת 4, 8, 15, 16, 23.
    static Node<int> BuildSample()
    {
        Node<int> head = new Node<int>(4);
        Node<int> last = head;
        int[] values = new int[] { 8, 15, 16, 23 };
        for (int i = 0; i < values.Length; i++)
        {
            Node<int> n = new Node<int>(values[i]);
            last.SetNext(n);
            last = n;
        }
        return head;
    }

    // דוגמה 3: אורך השרשרת וסכום הערכים
    // אין לשרשרת אורך שמור, ולכן סופרים את החוליות בעזרת מעבר.
    static void Example03_LengthAndSum()
    {
        Console.WriteLine("Example 3: length and sum");
        Node<int> head = BuildSample();
        Console.WriteLine("length = " + Length(head));
        Console.WriteLine("sum = " + Sum(head));
        Console.WriteLine();
    }

    static int Length(Node<int> head)
    {
        int count = 0;
        Node<int> p = head;
        while (p != null)
        {
            count++;
            p = p.GetNext();
        }
        return count;
    }

    static int Sum(Node<int> head)
    {
        int sum = 0;
        Node<int> p = head;
        while (p != null)
        {
            sum = sum + p.GetValue();
            p = p.GetNext();
        }
        return sum;
    }

    // דוגמה 4: חיפוש ערך בשרשרת
    // עוברים על החוליות עד שמוצאים את הערך, או עד שהשרשרת נגמרת.
    // במקרה הרע צריך לעבור על כל החוליות, כי אין גישה ישירה לחוליה לפי מקום.
    static void Example04_Contains()
    {
        Console.WriteLine("Example 4: search");
        Node<int> head = BuildSample();
        Console.WriteLine("contains 16? " + Contains(head, 16));
        Console.WriteLine("contains 5? " + Contains(head, 5));
        Console.WriteLine("position of 15 = " + PositionOf(head, 15));
        Console.WriteLine("position of 5 = " + PositionOf(head, 5));
        Console.WriteLine();
    }

    static bool Contains(Node<int> head, int value)
    {
        Node<int> p = head;
        while (p != null)
        {
            if (p.GetValue() == value)
            {
                return true;
            }
            p = p.GetNext();
        }
        return false;
    }

    // הפעולה מחזירה את המקום של הערך, כשהחוליה הראשונה היא במקום 0, או מינוס 1 אם הערך לא נמצא.
    static int PositionOf(Node<int> head, int value)
    {
        int index = 0;
        Node<int> p = head;
        while (p != null)
        {
            if (p.GetValue() == value)
            {
                return index;
            }
            index++;
            p = p.GetNext();
        }
        return -1;
    }

    // דוגמה 5: הוספה בהתחלה
    // יוצרים חוליה חדשה שההפניה שלה היא לראש הקודם, והיא הופכת לראש החדש.
    // הפעולה מחזירה את הראש החדש, כי ערך הפרמטר שהועבר לפעולה לא משתנה אצל הקורא.
    static void Example05_AddFirst()
    {
        Console.WriteLine("Example 5: add first");
        Node<int> head = BuildSample();
        head = AddFirst(head, 1);
        head = AddFirst(head, 0);
        PrintChain(head);
        Console.WriteLine();
    }

    static Node<int> AddFirst(Node<int> head, int value)
    {
        return new Node<int>(value, head);
    }

    // פעולת עזר להדפסת השרשרת.
    static void PrintChain(Node<int> head)
    {
        Node<int> p = head;
        while (p != null)
        {
            Console.Write(p.GetValue());
            if (p.HasNext())
            {
                Console.Write(" --> ");
            }
            p = p.GetNext();
        }
        Console.WriteLine();
    }

    // דוגמה 6: הוספה בסוף
    // צריך להגיע לחוליה האחרונה, זו שאין לה חוליה הבאה, ולחבר אליה את החוליה החדשה.
    // אם השרשרת ריקה, החוליה החדשה היא הראש. זה מקרה מיוחד שצריך לטפל בו.
    static void Example06_AddLast()
    {
        Console.WriteLine("Example 6: add last");
        Node<int> head = null;
        head = AddLast(head, 7);
        head = AddLast(head, 8);
        head = AddLast(head, 9);
        PrintChain(head);
        Console.WriteLine();
    }

    static Node<int> AddLast(Node<int> head, int value)
    {
        Node<int> n = new Node<int>(value);
        if (head == null)
        {
            return n;
        }
        Node<int> p = head;
        while (p.HasNext())
        {
            p = p.GetNext();
        }
        p.SetNext(n);
        return head;
    }

    // דוגמה 7: מחיקת ערך
    // כדי למחוק חוליה צריך לעצור על החוליה שלפניה, ולדלג עליה.
    // אם החוליה שצריך למחוק היא הראשונה, הראש החדש הוא החוליה השנייה.
    static void Example07_RemoveValue()
    {
        Console.WriteLine("Example 7: remove a value");
        Node<int> head = BuildSample();
        PrintChain(head);
        head = RemoveValue(head, 15);
        PrintChain(head);
        head = RemoveValue(head, 4);
        PrintChain(head);
        head = RemoveValue(head, 99);
        PrintChain(head);
        Console.WriteLine();
    }

    static Node<int> RemoveValue(Node<int> head, int value)
    {
        if (head == null)
        {
            return null;
        }
        if (head.GetValue() == value)
        {
            return head.GetNext();
        }
        Node<int> p = head;
        while (p.HasNext() && p.GetNext().GetValue() != value)
        {
            p = p.GetNext();
        }
        if (p.HasNext())
        {
            p.SetNext(p.GetNext().GetNext());
        }
        return head;
    }

    // דוגמה 8: הוספה לשרשרת ממוינת
    // השרשרת ממוינת מהקטן לגדול. עוצרים על החוליה שאחריה צריך להכניס.
    // מחברים את החוליה החדשה לחוליה שאחריה, ואז מחברים את העצירה לחוליה החדשה.
    // סדר החיבורים חשוב. אם נחבר בסדר הפוך נאבד את שאר השרשרת.
    static void Example08_InsertSorted()
    {
        Console.WriteLine("Example 8: insert into a sorted chain");
        Node<int> head = null;
        int[] values = new int[] { 50, 20, 70, 10, 40 };
        for (int i = 0; i < values.Length; i++)
        {
            head = InsertSorted(head, values[i]);
            PrintChain(head);
        }
        Console.WriteLine();
    }

    static Node<int> InsertSorted(Node<int> head, int value)
    {
        if (head == null || value < head.GetValue())
        {
            return new Node<int>(value, head);
        }
        Node<int> p = head;
        while (p.HasNext() && p.GetNext().GetValue() < value)
        {
            p = p.GetNext();
        }
        Node<int> n = new Node<int>(value, p.GetNext());
        p.SetNext(n);
        return head;
    }

    // דוגמה 9: שרשרת של מחרוזות
    // החוליה גנרית, ולכן אפשר ליצור שרשרת חוליות עם כל סוג ערך.
    static void Example09_ChainOfStrings()
    {
        Console.WriteLine("Example 9: chain of strings");
        Node<string> head = new Node<string>("red", new Node<string>("green", new Node<string>("blue")));
        Node<string> p = head;
        int count = 0;
        while (p != null)
        {
            Console.WriteLine("node " + count + ": " + p.GetValue());
            count++;
            p = p.GetNext();
        }
        Console.WriteLine();
    }

    // דוגמה 10: פעולה רקורסיבית על שרשרת
    // שרשרת היא מבנה רקורסיבי: חוליה ראשונה, ואחריה שרשרת קטנה יותר.
    // תנאי העצירה הוא שרשרת ריקה.
    // כשההדפסה מתבצעת אחרי הקריאה הרקורסיבית, הערכים מודפסים בסדר הפוך.
    static void Example10_RecursiveChain()
    {
        Console.WriteLine("Example 10: recursion on a chain");
        Node<int> head = BuildSample();
        Console.WriteLine("length = " + LengthRec(head));
        Console.Write("reversed: ");
        PrintReversed(head);
        Console.WriteLine();
        Console.WriteLine();
    }

    static int LengthRec(Node<int> head)
    {
        if (head == null)
        {
            return 0;
        }
        return 1 + LengthRec(head.GetNext());
    }

    static void PrintReversed(Node<int> head)
    {
        if (head == null)
        {
            return;
        }
        PrintReversed(head.GetNext());
        Console.Write(head.GetValue() + " ");
    }
}

﻿public class Node<T>
{
    private T value;
    private Node<T> next;

    //-----------------------------------
    //בנאים
    public Node(T value)
    {
        this.value = value;
        this.next = null;
    }
    public Node(T value, Node<T> next)
    {
        this.value = value;
        this.next = next;
    }
    //-----------------------------------
    //פעולות קבלה
    public T GetValue()
    {
        return this.value;
    }
    public Node<T> GetNext()
    {
        return this.next;
    }
    //-----------------------------------
    //פעולות עדכון
    public void SetValue(T value)
    {
        this.value = value;
    }
    public void SetNext(Node<T> next)
    {
        this.next = next;
    }
    //-----------------------------------
    //מחזיר אמת אם יש חוליה הבאה, אחרת מחזיר שקר
    public bool HasNext()
    {
        return (this.next != null);
    }
    //-----------------------------------
    //המרה למחרוזת
    public override string ToString()
    {
        return value + "," + next;
    }

}
