using System;

// פרק 3: תור
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

        Example01_FirstQueue();
        Example02_HeadAndIsEmpty();
        Example03_EmptyTheQueue();
        Example04_QueueOfStrings();
        Example05_CountAndSum();
        Example06_Max();
        Example07_CopyQueue();
        Example08_FilterQueue();
        Example09_MergeQueues();
        Example10_SupermarketLine();
    }

    // דוגמה 1: תור ראשון
    // תור הוא מבנה נתונים שפועל לפי העיקרון הראשון נכנס ראשון יוצא.
    // ערכים נכנסים בסוף התור, ויוצאים מהתחלתו, כמו אנשים בתור לקופה.
    // פעולת ההכנסה מוסיפה ערך לסוף התור, ופעולת ההוצאה מוציאה ומחזירה את הערך שבהתחלה.
    static void Example01_FirstQueue()
    {
        Console.WriteLine("Example 1: first queue");
        Queue<int> q = new Queue<int>();
        q.Insert(10);
        q.Insert(20);
        q.Insert(30);
        Console.WriteLine(q);
        int x = q.Remove();
        Console.WriteLine("removed " + x);
        Console.WriteLine(q);
        Console.WriteLine();
    }

    // דוגמה 2: ראש התור ובדיקה אם התור ריק
    // פעולת ההצצה בראש התור מחזירה את הערך שבראש התור בלי להוציא אותו.
    // פעולת הבדיקה אם התור ריק מחזירה אמת אם אין בו ערכים.
    // חשוב לבדוק שהתור אינו ריק לפני ההצצה בראש התור, כי על תור ריק היא תגרום לשגיאה.
    static void Example02_HeadAndIsEmpty()
    {
        Console.WriteLine("Example 2: head and IsEmpty");
        Queue<int> q = new Queue<int>();
        Console.WriteLine("is empty? " + q.IsEmpty());
        q.Insert(5);
        q.Insert(6);
        Console.WriteLine("is empty? " + q.IsEmpty());
        if (!q.IsEmpty())
        {
            Console.WriteLine("head = " + q.Head());
        }
        Console.WriteLine(q);
        Console.WriteLine();
    }

    // דוגמה 3: ריקון התור
    // כדי לעבור על כל הערכים בתור מוציאים אותם בלולאה, כל עוד התור אינו ריק.
    // אחרי הלולאה התור ריק, והערכים שהוצאו אינם נשמרים בו.
    static void Example03_EmptyTheQueue()
    {
        Console.WriteLine("Example 3: empty the queue");
        Queue<int> q = new Queue<int>();
        for (int i = 1; i <= 5; i++)
        {
            q.Insert(i * i);
        }
        while (!q.IsEmpty())
        {
            Console.Write(q.Remove() + " ");
        }
        Console.WriteLine();
        Console.WriteLine("is empty? " + q.IsEmpty());
        Console.WriteLine();
    }

    // דוגמה 4: תור של מחרוזות
    // הסוגריים המשולשים בהגדרת התור מאפשרים לבחור את סוג הערכים שבתור.
    // כך אפשר ליצור תור של מספרים שלמים, של מחרוזות, או של כל סוג אחר.
    static void Example04_QueueOfStrings()
    {
        Console.WriteLine("Example 4: queue of strings");
        Queue<string> names = new Queue<string>();
        names.Insert("Dana");
        names.Insert("Avi");
        names.Insert("Noa");
        Console.WriteLine(names);
        Console.WriteLine("first in line: " + names.Remove());
        Console.WriteLine("next in line: " + names.Head());
        Console.WriteLine();
    }

    // דוגמה 5: ספירה וסכום
    // הפעולה סופרת את הערכים שבתור ומחשבת את סכומם.
    // בסוף הפעולה התור ריק, כי הוצאנו ממנו את כל הערכים.
    static void Example05_CountAndSum()
    {
        Console.WriteLine("Example 5: count and sum");
        Queue<int> q = new Queue<int>();
        q.Insert(4);
        q.Insert(9);
        q.Insert(2);
        q.Insert(7);
        int count = 0;
        int sum = 0;
        while (!q.IsEmpty())
        {
            sum = sum + q.Remove();
            count++;
        }
        Console.WriteLine("count = " + count + ", sum = " + sum);
        Console.WriteLine();
    }

    // דוגמה 6: הערך הגדול ביותר בתור
    // כמו במערך, מתחילים מהערך הראשון ומשווים אותו לכל ערך שמוציאים.
    static void Example06_Max()
    {
        Console.WriteLine("Example 6: max in a queue");
        Queue<int> q = new Queue<int>();
        q.Insert(14);
        q.Insert(3);
        q.Insert(27);
        q.Insert(8);
        Console.WriteLine("max = " + MaxOfQueue(q));
        Console.WriteLine();
    }

    // הפעולה מקבלת תור לא ריק, ומחזירה את הערך הגדול ביותר בו. התור נשאר ריק בסוף.
    static int MaxOfQueue(Queue<int> q)
    {
        int max = q.Remove();
        while (!q.IsEmpty())
        {
            int x = q.Remove();
            if (x > max)
            {
                max = x;
            }
        }
        return max;
    }

    // דוגמה 7: העתקת תור בלי לאבד אותו
    // כדי לעבור על תור ולא לאבד את הערכים, מוציאים כל ערך ומכניסים אותו לתור עזר.
    // בסוף מחזירים את הערכים מתור העזר לתור המקורי, באותו סדר.
    static void Example07_CopyQueue()
    {
        Console.WriteLine("Example 7: keep the queue after reading it");
        Queue<int> q = new Queue<int>();
        q.Insert(1);
        q.Insert(2);
        q.Insert(3);
        Console.WriteLine("before: " + q);
        int sum = SumKeep(q);
        Console.WriteLine("sum = " + sum);
        Console.WriteLine("after: " + q);
        Console.WriteLine();
    }

    static int SumKeep(Queue<int> q)
    {
        Queue<int> temp = new Queue<int>();
        int sum = 0;
        while (!q.IsEmpty())
        {
            int x = q.Remove();
            sum = sum + x;
            temp.Insert(x);
        }
        while (!temp.IsEmpty())
        {
            q.Insert(temp.Remove());
        }
        return sum;
    }

    // דוגמה 8: סינון תור
    // יוצרים תור חדש שמכיל רק את הערכים שעומדים בתנאי, כאן הערכים הזוגיים.
    // הסדר היחסי של הערכים נשמר, כי תור משמר את סדר ההכנסה.
    static void Example08_FilterQueue()
    {
        Console.WriteLine("Example 8: filter a queue");
        Queue<int> q = new Queue<int>();
        for (int i = 1; i <= 8; i++)
        {
            q.Insert(i);
        }
        Queue<int> evens = new Queue<int>();
        while (!q.IsEmpty())
        {
            int x = q.Remove();
            if (x % 2 == 0)
            {
                evens.Insert(x);
            }
        }
        Console.WriteLine("evens: " + evens);
        Console.WriteLine();
    }

    // דוגמה 9: מיזוג שני תורים ממוינים
    // שני תורים ממוינים מהקטן לגדול. בונים מהם תור אחד ממוין.
    // בכל צעד משווים את ראשי שני התורים, ומוציאים את הקטן יותר.
    // כשאחד התורים נגמר, מעבירים את כל מה שנשאר בתור השני.
    static void Example09_MergeQueues()
    {
        Console.WriteLine("Example 9: merge two sorted queues");
        Queue<int> a = new Queue<int>();
        a.Insert(1);
        a.Insert(4);
        a.Insert(9);
        Queue<int> b = new Queue<int>();
        b.Insert(2);
        b.Insert(3);
        b.Insert(10);
        b.Insert(12);
        Queue<int> merged = new Queue<int>();
        while (!a.IsEmpty() && !b.IsEmpty())
        {
            if (a.Head() < b.Head())
            {
                merged.Insert(a.Remove());
            }
            else
            {
                merged.Insert(b.Remove());
            }
        }
        while (!a.IsEmpty())
        {
            merged.Insert(a.Remove());
        }
        while (!b.IsEmpty())
        {
            merged.Insert(b.Remove());
        }
        Console.WriteLine(merged);
        Console.WriteLine();
    }

    // דוגמה 10: תור בסופרמרקט
    // תור הוא מבנה טבעי לתיאור המתנה.
    // כל לקוח חדש נכנס לסוף התור, והקופאית משרתת תמיד את הלקוח שבראש התור.
    static void Example10_SupermarketLine()
    {
        Console.WriteLine("Example 10: supermarket line");
        Queue<string> line = new Queue<string>();
        line.Insert("Ron");
        line.Insert("Lior");
        Console.WriteLine("waiting: " + line);
        Console.WriteLine("serving " + line.Remove());
        line.Insert("Maya");
        Console.WriteLine("waiting: " + line);
        while (!line.IsEmpty())
        {
            Console.WriteLine("serving " + line.Remove());
        }
        Console.WriteLine("line is empty");
        Console.WriteLine();
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

public class Queue<T>
{
    private Node<T> first;
    private Node<T> last;

    //-----------------------------------
    //בנאי
    public Queue()
    {
        this.first = null;
        this.last = null;
    }
    //-----------------------------------
    //מוסיף את הערך שנשלח לסוף התור
    public void Insert(T x)
    {
        Node<T> temp = new Node<T>(x);
        if (first == null)
            first = temp;
        else
            last.SetNext(temp);
        last = temp;
    }
    //-----------------------------------
    //מוציא ומחזיר את הערך שבראש התור
    public T Remove()
    {
        if (IsEmpty())
            return default(T);
        T x = first.GetValue();
        first = first.GetNext();
        if (first == null)
            last = null;
        return x;
    }
    //-----------------------------------
    //מחזיר את הערך שבראש התור
    public T Head()
    {
        return first.GetValue();
    }
    //-----------------------------------
    //מחזיר אמת אם התור ריק
    public bool IsEmpty()
    {
        return first == null;
    }
    //-------------------------------------
    //המרה למחרוזת
    public override string ToString()
    {
        if (this.IsEmpty())
            return "[]";
        string temp = first.ToString();
        return "QueueHead[" + temp.Substring(0, temp.Length - 1) + "]";
    }
}
