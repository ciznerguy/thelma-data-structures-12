using System;

// פרק 4: מחסנית
// פרק זה לא נלמד השנה בעקבות המיקוד. החומר מצורף לעיון בלבד.
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

        Example01_FirstStack();
        Example02_TopAndIsEmpty();
        Example03_EmptyTheStack();
        Example04_StackOfStrings();
        Example05_ReverseWord();
        Example06_CountAndSum();
        Example07_CopyStack();
        Example08_Max();
        Example09_Brackets();
        Example10_DecimalToBinary();
    }

    // דוגמה 1: מחסנית ראשונה
    // מחסנית היא מבנה נתונים שפועל לפי העיקרון האחרון נכנס ראשון יוצא.
    // ערכים נכנסים לראש המחסנית וגם יוצאים ממנה, כמו ערימת צלחות.
    // פעולת ההכנסה מוסיפה ערך לראש המחסנית, ופעולת ההוצאה מוציאה ומחזירה את הערך שבראשה.
    static void Example01_FirstStack()
    {
        Console.WriteLine("Example 1: first stack");
        Stack<int> s = new Stack<int>();
        s.Push(10);
        s.Push(20);
        s.Push(30);
        Console.WriteLine(s);
        int x = s.Pop();
        Console.WriteLine("popped " + x);
        Console.WriteLine(s);
        Console.WriteLine();
    }

    // דוגמה 2: ראש המחסנית ובדיקה אם המחסנית ריקה
    // פעולת ההצצה בראש המחסנית מחזירה את הערך שבראשה בלי להוציא אותו.
    // פעולת הבדיקה אם המחסנית ריקה מחזירה אמת אם אין בה ערכים.
    // חשוב לבדוק שהמחסנית אינה ריקה לפני הצצה או הוצאה, כי על מחסנית ריקה הן יגרמו לשגיאה.
    static void Example02_TopAndIsEmpty()
    {
        Console.WriteLine("Example 2: top and IsEmpty");
        Stack<int> s = new Stack<int>();
        Console.WriteLine("is empty? " + s.IsEmpty());
        s.Push(5);
        s.Push(6);
        Console.WriteLine("is empty? " + s.IsEmpty());
        if (!s.IsEmpty())
        {
            Console.WriteLine("top = " + s.Top());
        }
        Console.WriteLine();
    }

    // דוגמה 3: ריקון המחסנית
    // מוציאים ערכים בלולאה כל עוד המחסנית אינה ריקה.
    // הערכים יוצאים בסדר הפוך לסדר שבו הוכנסו.
    static void Example03_EmptyTheStack()
    {
        Console.WriteLine("Example 3: empty the stack");
        Stack<int> s = new Stack<int>();
        for (int i = 1; i <= 5; i++)
        {
            s.Push(i * i);
        }
        while (!s.IsEmpty())
        {
            Console.Write(s.Pop() + " ");
        }
        Console.WriteLine();
        Console.WriteLine();
    }

    // דוגמה 4: מחסנית של מחרוזות
    // המחסנית גנרית, ולכן אפשר ליצור מחסנית של כל סוג ערכים.
    static void Example04_StackOfStrings()
    {
        Console.WriteLine("Example 4: stack of strings");
        Stack<string> pages = new Stack<string>();
        pages.Push("home");
        pages.Push("news");
        pages.Push("sports");
        Console.WriteLine("current page: " + pages.Top());
        pages.Pop();
        Console.WriteLine("after back: " + pages.Top());
        Console.WriteLine();
    }

    // דוגמה 5: היפוך מילה
    // מכניסים למחסנית את התווים של המילה לפי הסדר, ואז מוציאים אותם.
    // התווים יוצאים בסדר הפוך, ולכן מתקבלת המילה הפוכה.
    static void Example05_ReverseWord()
    {
        Console.WriteLine("Example 5: reverse a word");
        string word = "stack";
        Stack<char> s = new Stack<char>();
        for (int i = 0; i < word.Length; i++)
        {
            s.Push(word[i]);
        }
        while (!s.IsEmpty())
        {
            Console.Write(s.Pop());
        }
        Console.WriteLine();
        Console.WriteLine();
    }

    // דוגמה 6: ספירה וסכום
    static void Example06_CountAndSum()
    {
        Console.WriteLine("Example 6: count and sum");
        Stack<int> s = new Stack<int>();
        s.Push(4);
        s.Push(9);
        s.Push(2);
        s.Push(7);
        int count = 0;
        int sum = 0;
        while (!s.IsEmpty())
        {
            sum = sum + s.Pop();
            count++;
        }
        Console.WriteLine("count = " + count + ", sum = " + sum);
        Console.WriteLine();
    }

    // דוגמה 7: העתקת מחסנית בלי לאבד אותה
    // מחסנית עזר הופכת את הסדר, ולכן צריך שתי העברות כדי להחזיר את הסדר המקורי.
    static void Example07_CopyStack()
    {
        Console.WriteLine("Example 7: keep the stack after reading it");
        Stack<int> s = new Stack<int>();
        s.Push(1);
        s.Push(2);
        s.Push(3);
        Console.WriteLine("before: " + s);
        int sum = SumKeep(s);
        Console.WriteLine("sum = " + sum);
        Console.WriteLine("after: " + s);
        Console.WriteLine();
    }

    static int SumKeep(Stack<int> s)
    {
        Stack<int> temp = new Stack<int>();
        int sum = 0;
        while (!s.IsEmpty())
        {
            int x = s.Pop();
            sum = sum + x;
            temp.Push(x);
        }
        while (!temp.IsEmpty())
        {
            s.Push(temp.Pop());
        }
        return sum;
    }

    // דוגמה 8: הערך הגדול ביותר במחסנית
    static void Example08_Max()
    {
        Console.WriteLine("Example 8: max in a stack");
        Stack<int> s = new Stack<int>();
        s.Push(14);
        s.Push(3);
        s.Push(27);
        s.Push(8);
        int max = s.Pop();
        while (!s.IsEmpty())
        {
            int x = s.Pop();
            if (x > max)
            {
                max = x;
            }
        }
        Console.WriteLine("max = " + max);
        Console.WriteLine();
    }

    // דוגמה 9: בדיקת סוגריים תקינים
    // בכל פעם שרואים סוגר פותח, מכניסים אותו למחסנית.
    // בכל פעם שרואים סוגר סוגר, מוציאים סוגר פותח מהמחסנית.
    // הביטוי תקין אם בסוף המחסנית ריקה, ולא ניסינו להוציא מחסנית ריקה.
    static void Example09_Brackets()
    {
        Console.WriteLine("Example 9: balanced brackets");
        Console.WriteLine("(()()) -> " + IsBalanced("(()())"));
        Console.WriteLine("(() -> " + IsBalanced("(()"));
        Console.WriteLine("())( -> " + IsBalanced("())("));
        Console.WriteLine();
    }

    static bool IsBalanced(string text)
    {
        Stack<char> s = new Stack<char>();
        bool ok = true;
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '(')
            {
                s.Push('(');
            }
            else
            {
                if (s.IsEmpty())
                {
                    ok = false;
                }
                else
                {
                    s.Pop();
                }
            }
        }
        return ok && s.IsEmpty();
    }

    // דוגמה 10: המרה למספר בינארי
    // מחלקים את המספר ב-2 שוב ושוב, ומכניסים את השאריות למחסנית.
    // השארית הראשונה היא הספרה האחרונה, ולכן המחסנית מחזירה אותן בסדר הנכון.
    static void Example10_DecimalToBinary()
    {
        Console.WriteLine("Example 10: decimal to binary");
        int num = 37;
        int original = num;
        Stack<int> s = new Stack<int>();
        while (num > 0)
        {
            s.Push(num % 2);
            num = num / 2;
        }
        Console.Write(original + " -> ");
        while (!s.IsEmpty())
        {
            Console.Write(s.Pop());
        }
        Console.WriteLine();
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

public class Stack<T>
{
    private Node<T> head;

    //-----------------------------------
    //בנאי
    public Stack()
    {
        this.head = null;
    }
    //-----------------------------------
    //מוסיף את הערך שנשלח לראש המחסנית
    public void Push(T x)
    {
        Node<T> temp = new Node<T>(x);
        temp.SetNext(head);
        head = temp;
    }
    //-----------------------------------
    //מוציא ומחזיר את הערך שבראש המחסנית
    public T Pop()
    {
        T x = head.GetValue();
        head = head.GetNext();
        return x;
    }
    //-----------------------------------
    //מחזיר את הערך שבראש המחסנית
    public T Top()
    {
        return head.GetValue();
    }
    //-----------------------------------
    //מחזיר אמת אם המחסנית ריקה
    public bool IsEmpty()
    {
        return head == null;
    }
    //-------------------------------------
    //המרה למחרוזת
    public override string ToString()
    {
        if (this.IsEmpty())
            return "[]";
        string temp = head.ToString();
        return "TOP <== " + temp.Substring(0, temp.Length - 1) + "]";
    }
}
