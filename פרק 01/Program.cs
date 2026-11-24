using System;

// פרק 1: מבוא ליעילות
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

        Example01_CountSteps();
        Example02_ConstantSteps();
        Example03_LinearSearch();
        Example04_FindMax();
        Example05_NestedLoops();
        Example06_SumByFormula();
        Example07_DoublingLoop();
        Example08_BinarySearch();
        Example09_ComparePrograms();
        Example10_GrowthTable();
    }

    // דוגמה 1: ספירת צעדים
    // כדי למדוד יעילות לא מודדים שניות, כי הן תלויות במחשב.
    // סופרים כמה פעולות בסיסיות התוכנית מבצעת. לשם כך מוסיפים מונה.
    // כאן הלולאה רצה מספר פעמים כגודל הקלט, ולכן מספר הצעדים הוא כגודל הקלט.
    static void Example01_CountSteps()
    {
        Console.WriteLine("Example 1: counting steps");
        int size = 10;
        int steps = 0;
        for (int i = 1; i <= size; i++)
        {
            steps++;
        }
        Console.WriteLine("input size = " + size + ", steps = " + steps);
        Console.WriteLine();
    }

    // דוגמה 2: מספר צעדים קבוע
    // יש פעולות שמספר הצעדים שלהן לא תלוי בגודל הקלט.
    // לדוגמה, גישה לאיבר במערך לפי מקום, או החלפה בין שני איברים.
    // גם אם המערך יהיה גדול פי מיליון, מספר הצעדים יישאר זהה.
    static void Example02_ConstantSteps()
    {
        Console.WriteLine("Example 2: constant number of steps");
        int[] arr = new int[] { 5, 8, 2, 9, 1 };
        int temp = arr[0];
        arr[0] = arr[4];
        arr[4] = temp;
        Console.WriteLine("first = " + arr[0] + ", last = " + arr[4]);
        Console.WriteLine();
    }

    // דוגמה 3: חיפוש סדרתי, המקרה הטוב והמקרה הרע
    // החיפוש עובר על האיברים לפי הסדר עד שמוצא את הערך.
    // במקרה הטוב הערך נמצא באיבר הראשון, ויש השוואה אחת.
    // במקרה הרע הערך נמצא באיבר האחרון או לא נמצא כלל, ולכן יש השוואה לכל האיברים.
    static void Example03_LinearSearch()
    {
        Console.WriteLine("Example 3: linear search");
        int[] arr = new int[] { 7, 3, 9, 4, 6, 1, 8, 2 };
        Console.WriteLine("search 7 (best case): comparisons = " + CountSearchSteps(arr, 7));
        Console.WriteLine("search 4 (middle): comparisons = " + CountSearchSteps(arr, 4));
        Console.WriteLine("search 2 (last): comparisons = " + CountSearchSteps(arr, 2));
        Console.WriteLine("search 5 (missing): comparisons = " + CountSearchSteps(arr, 5));
        Console.WriteLine();
    }

    // הפעולה מחזירה כמה השוואות בוצעו עד שהחיפוש הסתיים.
    static int CountSearchSteps(int[] arr, int value)
    {
        int steps = 0;
        int i = 0;
        bool found = false;
        while (i < arr.Length && !found)
        {
            steps++;
            if (arr[i] == value)
            {
                found = true;
            }
            i++;
        }
        return steps;
    }

    // דוגמה 4: מציאת הערך הגדול ביותר
    // כאן אין מקרה טוב ומקרה רע, כי חייבים לבדוק את כל האיברים.
    // מספר ההשוואות תמיד קטן ב-1 ממספר האיברים, בלי קשר לערכים עצמם.
    static void Example04_FindMax()
    {
        Console.WriteLine("Example 4: find max");
        int[] first = new int[] { 9, 1, 2, 3, 4 };
        int[] second = new int[] { 1, 2, 3, 4, 9 };
        Console.WriteLine("max = " + FindMax(first) + ", comparisons = " + (first.Length - 1));
        Console.WriteLine("max = " + FindMax(second) + ", comparisons = " + (second.Length - 1));
        Console.WriteLine();
    }

    static int FindMax(int[] arr)
    {
        int max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }
        return max;
    }

    // דוגמה 5: לולאה בתוך לולאה
    // כשלולאה אחת נמצאת בתוך לולאה אחרת, מספר הצעדים הוא המכפלה של מספרי הסיבובים.
    // אם שתי הלולאות רצות כגודל הקלט, מספר הצעדים הוא ריבוע של גודל הקלט.
    // כשגודל הקלט מוכפל פי 2, מספר הצעדים גדל פי 4.
    static void Example05_NestedLoops()
    {
        Console.WriteLine("Example 5: nested loops");
        int size = 5;
        while (size <= 20)
        {
            int steps = 0;
            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    steps++;
                }
            }
            Console.WriteLine("input size = " + size + ", steps = " + steps);
            size = size * 2;
        }
        Console.WriteLine();
    }

    // דוגמה 6: שני פתרונות לאותה בעיה
    // הבעיה: סכום המספרים מ-1 ועד מספר נתון.
    // פתרון אחד משתמש בלולאה, ומספר הצעדים שלו גדל עם גודל הקלט.
    // פתרון שני משתמש בנוסחה, ומספר הצעדים שלו קבוע.
    // שני הפתרונות נכונים, אבל השני יעיל יותר.
    static void Example06_SumByFormula()
    {
        Console.WriteLine("Example 6: sum by loop and by formula");
        int num = 1000;
        int sum = 0;
        int loopSteps = 0;
        for (int i = 1; i <= num; i++)
        {
            sum = sum + i;
            loopSteps++;
        }
        int formula = num * (num + 1) / 2;
        Console.WriteLine("loop: sum = " + sum + ", steps = " + loopSteps);
        Console.WriteLine("formula: sum = " + formula + ", steps = 1");
        Console.WriteLine();
    }

    // דוגמה 7: לולאה שהמשתנה בה מוכפל
    // כאן המשתנה מוכפל פי 2 בכל סיבוב, ולא עולה ב-1.
    // לכן הוא מגיע לגודל הקלט הרבה יותר מהר, ומספר הצעדים קטן בהרבה.
    // כשגודל הקלט מוכפל פי 2, מספר הצעדים גדל רק ב-1.
    static void Example07_DoublingLoop()
    {
        Console.WriteLine("Example 7: doubling loop");
        int size = 8;
        while (size <= 1024)
        {
            int steps = 0;
            int i = 1;
            while (i < size)
            {
                i = i * 2;
                steps++;
            }
            Console.WriteLine("input size = " + size + ", steps = " + steps);
            size = size * 4;
        }
        Console.WriteLine();
    }

    // דוגמה 8: חיפוש בינארי במערך ממוין
    // בכל צעד בודקים את האיבר שבאמצע, ופוסלים חצי מהאיברים שנשארו.
    // לכן מספר הצעדים קטן בהרבה ממספר הצעדים בחיפוש סדרתי.
    // החיפוש הבינארי עובד רק על מערך ממוין.
    static void Example08_BinarySearch()
    {
        Console.WriteLine("Example 8: binary search");
        int[] arr = new int[1000];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i * 2;
        }
        Console.WriteLine("binary search for 1998: steps = " + CountBinarySteps(arr, 1998));
        Console.WriteLine("linear search for 1998: steps = " + CountSearchSteps(arr, 1998));
        Console.WriteLine("binary search for 1999 (missing): steps = " + CountBinarySteps(arr, 1999));
        Console.WriteLine();
    }

    static int CountBinarySteps(int[] arr, int value)
    {
        int low = 0;
        int high = arr.Length - 1;
        int steps = 0;
        bool found = false;
        while (low <= high && !found)
        {
            steps++;
            int mid = (low + high) / 2;
            if (arr[mid] == value)
            {
                found = true;
            }
            else if (arr[mid] < value)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        return steps;
    }

    // דוגמה 9: השוואה בין שתי תוכניות
    // התוכנית הראשונה בודקת אם יש במערך שני איברים זהים, בעזרת שתי לולאות מקוננות.
    // התוכנית השנייה בודקת אם המערך ממוין, בעזרת לולאה אחת.
    // כשהמערך גדל פי 10, הצעדים של הראשונה גדלים פי 100, ושל השנייה פי 10.
    static void Example09_ComparePrograms()
    {
        Console.WriteLine("Example 9: compare two programs");
        int size = 100;
        while (size <= 1000)
        {
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = i;
            }
            int steps1 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    steps1++;
                }
            }
            int steps2 = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                steps2++;
            }
            Console.WriteLine("size = " + size + ", pairs check = " + steps1 + ", sorted check = " + steps2);
            size = size * 10;
        }
        Console.WriteLine();
    }

    // דוגמה 10: טבלת גידול
    // הטבלה משווה בין כמה סדרי גודל של מספר צעדים כשגודל הקלט גדל.
    // צעדים קבועים: אותו מספר תמיד.
    // צעדים לוגריתמיים: גדלים לאט מאוד.
    // צעדים לינאריים: גדלים כמו גודל הקלט.
    // צעדים ריבועיים: גדלים הרבה יותר מהר.
    static void Example10_GrowthTable()
    {
        Console.WriteLine("Example 10: growth table");
        int size = 16;
        while (size <= 1024)
        {
            int log = 0;
            int p = 1;
            while (p < size)
            {
                p = p * 2;
                log++;
            }
            Console.WriteLine("size = " + size + ": constant = 1, log = " + log + ", linear = " + size + ", quadratic = " + size * size);
            size = size * 4;
        }
        Console.WriteLine();
    }
}
