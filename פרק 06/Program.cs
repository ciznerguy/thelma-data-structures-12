using System;

// פרק 6: עצים בינאריים
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

        Example01_BuildTree();
        Example02_PreOrder();
        Example03_InOrder();
        Example04_PostOrder();
        Example05_CountAndSum();
        Example06_Height();
        Example07_Leaves();
        Example08_Search();
        Example09_SearchTree();
        Example10_LevelOrder();
    }

    // פעולת עזר: בונה את העץ שבדוגמאות. הוא נראה כך:
    //         10
    //        /  \
    //       5    15
    //      / \     \
    //     3   7     20
    static BinNode<int> BuildSample()
    {
        BinNode<int> left = new BinNode<int>(new BinNode<int>(3), 5, new BinNode<int>(7));
        BinNode<int> right = new BinNode<int>(null, 15, new BinNode<int>(20));
        return new BinNode<int>(left, 10, right);
    }

    // דוגמה 1: בניית עץ בינארי
    // חוליה בינארית מכילה ערך ושתי הפניות: לבן השמאלי ולבן הימני.
    // חוליה בלי בנים נקראת עלה, והחוליה העליונה נקראת שורש.
    // עץ מיוצג על ידי משתנה שמצביע על השורש.
    static void Example01_BuildTree()
    {
        Console.WriteLine("Example 1: build a tree");
        BinNode<int> root = BuildSample();
        Console.WriteLine("root = " + root.GetValue());
        Console.WriteLine("left child = " + root.GetLeft().GetValue());
        Console.WriteLine("right child = " + root.GetRight().GetValue());
        Console.WriteLine("has left child of 15? " + root.GetRight().HasLeft());
        Console.WriteLine(root);
        Console.WriteLine();
    }

    // דוגמה 2: סריקה בסדר קדם
    // סריקה היא מעבר על כל הערכים בעץ. בסדר קדם מטפלים קודם בשורש, אחר כך בתת העץ השמאלי,
    // ואחר כך בתת העץ הימני. העץ הוא מבנה רקורסיבי, ולכן גם הסריקה רקורסיבית.
    // תנאי העצירה הוא עץ ריק.
    static void Example02_PreOrder()
    {
        Console.WriteLine("Example 2: pre-order");
        PreOrder(BuildSample());
        Console.WriteLine();
        Console.WriteLine();
    }

    static void PreOrder(BinNode<int> root)
    {
        if (root == null)
        {
            return;
        }
        Console.Write(root.GetValue() + " ");
        PreOrder(root.GetLeft());
        PreOrder(root.GetRight());
    }

    // דוגמה 3: סריקה בסדר תוך
    // קודם תת העץ השמאלי, אחר כך השורש, ואחר כך תת העץ הימני.
    static void Example03_InOrder()
    {
        Console.WriteLine("Example 3: in-order");
        InOrder(BuildSample());
        Console.WriteLine();
        Console.WriteLine();
    }

    static void InOrder(BinNode<int> root)
    {
        if (root == null)
        {
            return;
        }
        InOrder(root.GetLeft());
        Console.Write(root.GetValue() + " ");
        InOrder(root.GetRight());
    }

    // דוגמה 4: סריקה בסדר סוף
    // קודם תת העץ השמאלי, אחר כך תת העץ הימני, ורק בסוף השורש.
    static void Example04_PostOrder()
    {
        Console.WriteLine("Example 4: post-order");
        PostOrder(BuildSample());
        Console.WriteLine();
        Console.WriteLine();
    }

    static void PostOrder(BinNode<int> root)
    {
        if (root == null)
        {
            return;
        }
        PostOrder(root.GetLeft());
        PostOrder(root.GetRight());
        Console.Write(root.GetValue() + " ");
    }

    // דוגמה 5: מספר החוליות וסכום הערכים
    // מספר החוליות בעץ הוא 1 ועוד מספר החוליות בתת העץ השמאלי ובתת העץ הימני.
    // תנאי העצירה: עץ ריק מכיל 0 חוליות.
    static void Example05_CountAndSum()
    {
        Console.WriteLine("Example 5: count and sum");
        BinNode<int> root = BuildSample();
        Console.WriteLine("nodes = " + CountNodes(root));
        Console.WriteLine("sum = " + SumTree(root));
        Console.WriteLine();
    }

    static int CountNodes(BinNode<int> root)
    {
        if (root == null)
        {
            return 0;
        }
        return 1 + CountNodes(root.GetLeft()) + CountNodes(root.GetRight());
    }

    static int SumTree(BinNode<int> root)
    {
        if (root == null)
        {
            return 0;
        }
        return root.GetValue() + SumTree(root.GetLeft()) + SumTree(root.GetRight());
    }

    // דוגמה 6: גובה העץ
    // גובה העץ הוא מספר הרמות שלו. עץ ריק הוא בגובה 0.
    // גובה העץ הוא 1 ועוד הגובה של תת העץ הגבוה יותר מבין שני תתי העצים.
    static void Example06_Height()
    {
        Console.WriteLine("Example 6: height");
        BinNode<int> root = BuildSample();
        Console.WriteLine("height = " + Height(root));
        Console.WriteLine("height of the left subtree = " + Height(root.GetLeft()));
        Console.WriteLine("height of the right subtree = " + Height(root.GetRight()));
        Console.WriteLine();
    }

    static int Height(BinNode<int> root)
    {
        if (root == null)
        {
            return 0;
        }
        int left = Height(root.GetLeft());
        int right = Height(root.GetRight());
        return 1 + Math.Max(left, right);
    }

    // דוגמה 7: ספירת עלים
    // עלה הוא חוליה שאין לה בן שמאלי ואין לה בן ימני.
    static void Example07_Leaves()
    {
        Console.WriteLine("Example 7: leaves");
        Console.WriteLine("leaves = " + CountLeaves(BuildSample()));
        Console.WriteLine();
    }

    static int CountLeaves(BinNode<int> root)
    {
        if (root == null)
        {
            return 0;
        }
        if (!root.HasLeft() && !root.HasRight())
        {
            return 1;
        }
        return CountLeaves(root.GetLeft()) + CountLeaves(root.GetRight());
    }

    // דוגמה 8: חיפוש ערך בעץ בינארי רגיל
    // בעץ רגיל אין סדר בין הערכים, ולכן ייתכן שנצטרך לבדוק את כל החוליות.
    // הערך נמצא אם הוא בשורש, או בתת העץ השמאלי, או בתת העץ הימני.
    static void Example08_Search()
    {
        Console.WriteLine("Example 8: search in a tree");
        BinNode<int> root = BuildSample();
        Console.WriteLine("contains 7? " + Contains(root, 7));
        Console.WriteLine("contains 8? " + Contains(root, 8));
        Console.WriteLine();
    }

    static bool Contains(BinNode<int> root, int value)
    {
        if (root == null)
        {
            return false;
        }
        if (root.GetValue() == value)
        {
            return true;
        }
        return Contains(root.GetLeft(), value) || Contains(root.GetRight(), value);
    }

    // דוגמה 9: עץ חיפוש בינארי
    // בעץ חיפוש כל הערכים בתת העץ השמאלי קטנים משורש העץ, וכל הערכים בתת העץ הימני גדולים ממנו.
    // לכן בחיפוש יודעים לאיזה צד ללכת, ופוסלים חצי מהעץ בכל צעד.
    // סריקה בסדר תוך של עץ חיפוש מדפיסה את הערכים ממוינים.
    static void Example09_SearchTree()
    {
        Console.WriteLine("Example 9: search tree");
        BinNode<int> root = null;
        int[] values = new int[] { 50, 30, 70, 20, 40, 60, 80 };
        for (int i = 0; i < values.Length; i++)
        {
            root = Insert(root, values[i]);
        }
        Console.Write("in-order: ");
        InOrder(root);
        Console.WriteLine();
        Console.WriteLine("steps to find 60 = " + SearchSteps(root, 60));
        Console.WriteLine("steps to find 25 = " + SearchSteps(root, 25));
        Console.WriteLine();
    }

    static BinNode<int> Insert(BinNode<int> root, int value)
    {
        if (root == null)
        {
            return new BinNode<int>(value);
        }
        if (value < root.GetValue())
        {
            root.SetLeft(Insert(root.GetLeft(), value));
        }
        else
        {
            root.SetRight(Insert(root.GetRight(), value));
        }
        return root;
    }

    // הפעולה מחזירה כמה חוליות נבדקו עד שהערך נמצא, או עד שהגענו לעץ ריק.
    static int SearchSteps(BinNode<int> root, int value)
    {
        if (root == null)
        {
            return 0;
        }
        if (root.GetValue() == value)
        {
            return 1;
        }
        if (value < root.GetValue())
        {
            return 1 + SearchSteps(root.GetLeft(), value);
        }
        return 1 + SearchSteps(root.GetRight(), value);
    }

    // דוגמה 10: סריקה לפי רמות
    // סורקים את העץ רמה אחרי רמה, מלמעלה למטה וכל רמה משמאל לימין.
    // משתמשים בתור: מכניסים את השורש, ובכל צעד מוציאים חוליה, מטפלים בה
    // ומכניסים לתור את הבנים שלה. התור שומר את סדר ההגעה של החוליות.
    static void Example10_LevelOrder()
    {
        Console.WriteLine("Example 10: level order");
        BinNode<int> root = BuildSample();
        Queue<BinNode<int>> q = new Queue<BinNode<int>>();
        q.Insert(root);
        while (!q.IsEmpty())
        {
            BinNode<int> node = q.Remove();
            Console.Write(node.GetValue() + " ");
            if (node.HasLeft())
            {
                q.Insert(node.GetLeft());
            }
            if (node.HasRight())
            {
                q.Insert(node.GetRight());
            }
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

public class BinNode<T>
{
    private T value;
    private BinNode<T> left;
    private BinNode<T> right;

    //-----------------------------------
    //בנאים
    public BinNode(T value)
    {
        this.value = value;
        this.left = null;
        this.right = null;
    }
    public BinNode(BinNode<T> left, T value, BinNode<T> right)
    {
        this.value = value;
        this.left = left;
        this.right = right;
    }
    //-----------------------------------
    //פעולות קבלה
    public T GetValue()
    {
        return value;
    }
    public BinNode<T> GetLeft()
    {
        return this.left;
    }
    public BinNode<T> GetRight()
    {
        return this.right;
    }
    //-----------------------------------
    //פעולות עדכון
    public void SetValue(T value)
    {
        this.value = value;
    }
    public void SetLeft(BinNode<T> left)
    {
        this.left = left;
    }

    public void SetRight(BinNode<T> right)
    {
        this.right = right;
    }
    //-----------------------------------
    //מחזיר אמת אם יש חוליה שמאלית, אחרת מחזיר שקר
    public bool HasLeft()
    {
        return (this.left != null);
    }
    //מחזיר אמת אם יש חוליה ימנית, אחרת מחזיר שקר
    public bool HasRight()
    {
        return (this.right != null);
    }
    //-----------------------------------
    //המרה למחרוזת
    public override string ToString()
    {
        return "(" + left + " " + value + " " + right + ")";
    }
}
