using System;

// פרק 2: רקורסיה
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

        Example01_Countdown();
        Example02_SumToN();
        Example03_Factorial();
        Example04_Power();
        Example05_Fibonacci();
        Example06_SumOfDigits();
        Example07_ArraySum();
        Example08_ArrayMax();
        Example09_EvenOdd();
        Example10_PrintBinary();
    }

    // דוגמה 1: ספירה לאחור, הרקורסיה הראשונה
    // פעולה רקורסיבית היא פעולה שקוראת לעצמה.
    // לכל פעולה רקורסיבית חייבים להיות שני חלקים:
    // תנאי עצירה: המקרה הפשוט ביותר, שבו הפעולה לא קוראת לעצמה יותר.
    // קריאה רקורסיבית: הפעולה קוראת לעצמה עם פרמטר קטן יותר, ובכך מתקרבת לתנאי העצירה.
    // בלי תנאי עצירה הפעולה תקרא לעצמה בלי סוף, והתוכנית תקרוס.
    static void Example01_Countdown()
    {
        Console.WriteLine("Example 1: countdown");
        Countdown(5);
        Console.WriteLine();
        Console.WriteLine();
    }

    // הפעולה מדפיסה את המספרים מהמספר שהתקבל ועד 1.
    static void Countdown(int n)
    {
        if (n == 0)
        {
            return;
        }
        Console.Write(n + " ");
        Countdown(n - 1);
    }

    // דוגמה 2: סכום המספרים מ-1 ועד מספר נתון, ומעקב אחרי הקריאות
    // הרעיון: הסכום עד מספר נתון שווה לאותו מספר ועוד הסכום עד המספר שלפניו.
    // בפעולה יש הדפסה לפני הקריאה הרקורסיבית ואחריה,
    // כדי לראות את סדר הקריאות ואת סדר החזרת הערכים.
    // הקריאות נערמות אחת על השנייה עד תנאי העצירה, ואז הערכים חוזרים בסדר הפוך.
    static void Example02_SumToN()
    {
        Console.WriteLine("Example 2: sum to n with trace");
        int result = SumToN(4);
        Console.WriteLine("result = " + result);
        Console.WriteLine();
    }

    static int SumToN(int n)
    {
        Console.WriteLine("call with n = " + n);
        if (n == 0)
        {
            Console.WriteLine("stop, return 0");
            return 0;
        }
        int rest = SumToN(n - 1);
        int total = n + rest;
        Console.WriteLine("return " + total + " for n = " + n);
        return total;
    }

    // דוגמה 3: עצרת
    // עצרת של מספר היא המכפלה של כל המספרים מ-1 ועד אותו מספר.
    // הרעיון: עצרת של מספר שווה למספר כפול עצרת של המספר שלפניו.
    // תנאי העצירה: עצרת של 0 שווה 1.
    static void Example03_Factorial()
    {
        Console.WriteLine("Example 3: factorial");
        int i = 0;
        while (i <= 6)
        {
            Console.WriteLine(i + "! = " + Factorial(i));
            i++;
        }
        Console.WriteLine();
    }

    static int Factorial(int n)
    {
        if (n == 0)
        {
            return 1;
        }
        return n * Factorial(n - 1);
    }

    // דוגמה 4: חזקה
    // חזקה היא כפל חוזר: בסיס בחזקת מעריך שווה לבסיס כפול הבסיס בחזקת מעריך פחות 1.
    // תנאי העצירה: כל מספר בחזקת 0 שווה 1.
    // שני הפרמטרים נשלחים בכל קריאה, אבל רק המעריך קטן, והבסיס נשאר קבוע.
    static void Example04_Power()
    {
        Console.WriteLine("Example 4: power");
        Console.WriteLine("2 ^ 5 = " + Power(2, 5));
        Console.WriteLine("3 ^ 4 = " + Power(3, 4));
        Console.WriteLine("7 ^ 0 = " + Power(7, 0));
        Console.WriteLine();
    }

    static int Power(int baseNum, int exponent)
    {
        if (exponent == 0)
        {
            return 1;
        }
        return baseNum * Power(baseNum, exponent - 1);
    }

    // דוגמה 5: סדרת פיבונאצ'י, רקורסיה כפולה
    // האיבר הראשון הוא 0, השני הוא 1, וכל איבר אחר הוא סכום שני האיברים שלפניו.
    // כאן הפעולה קוראת לעצמה פעמיים, ולכן מספר הקריאות גדל מהר מאוד.
    // לכן לא כדאי להפעיל אותה על מספרים גדולים.
    static void Example05_Fibonacci()
    {
        Console.WriteLine("Example 5: fibonacci");
        int i = 1;
        while (i <= 10)
        {
            Console.Write(Fibonacci(i) + " ");
            i++;
        }
        Console.WriteLine();
        Console.WriteLine();
    }

    static int Fibonacci(int n)
    {
        if (n == 1)
        {
            return 0;
        }
        if (n == 2)
        {
            return 1;
        }
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    // דוגמה 6: סכום הספרות של מספר שלם
    // אפשר לפרק מספר לספרה האחרונה, בעזרת שארית החלוקה ב-10,
    // ולשאר המספר, בעזרת חלוקה שלמה ב-10.
    // תנאי העצירה: מספר שנשאר ממנו 0 אין לו ספרות.
    static void Example06_SumOfDigits()
    {
        Console.WriteLine("Example 6: sum of digits");
        Console.WriteLine("1234 -> " + SumOfDigits(1234));
        Console.WriteLine("90909 -> " + SumOfDigits(90909));
        Console.WriteLine("7 -> " + SumOfDigits(7));
        Console.WriteLine();
    }

    static int SumOfDigits(int num)
    {
        if (num == 0)
        {
            return 0;
        }
        return num % 10 + SumOfDigits(num / 10);
    }

    // דוגמה 7: סכום איברי מערך
    // כדי לעבור על מערך ברקורסיה מעבירים לפעולה גם את המקום הנוכחי.
    // בכל קריאה המקום גדל ב-1, ותנאי העצירה הוא שהמקום הגיע לסוף המערך.
    // הפרמטרים שמשתנים הם המקום בלבד, והמערך עצמו נשאר זהה בכל הקריאות.
    static void Example07_ArraySum()
    {
        Console.WriteLine("Example 7: array sum");
        int[] numbers = new int[] { 4, 8, 15, 16, 23, 42 };
        Console.WriteLine("sum = " + ArraySum(numbers, 0));
        Console.WriteLine();
    }

    static int ArraySum(int[] arr, int index)
    {
        if (index == arr.Length)
        {
            return 0;
        }
        return arr[index] + ArraySum(arr, index + 1);
    }

    // דוגמה 8: הערך הגדול ביותר במערך
    // מחפשים את הגדול ביותר בשאר המערך, ומשווים אותו לאיבר הנוכחי.
    // תנאי העצירה: כשהגענו לאיבר האחרון, הוא הגדול ביותר בחלק שנשאר.
    static void Example08_ArrayMax()
    {
        Console.WriteLine("Example 8: array max");
        int[] numbers = new int[] { 12, 7, 31, 5, 19 };
        Console.WriteLine("max = " + ArrayMax(numbers, 0));
        Console.WriteLine();
    }

    static int ArrayMax(int[] arr, int index)
    {
        if (index == arr.Length - 1)
        {
            return arr[index];
        }
        int maxOfRest = ArrayMax(arr, index + 1);
        if (arr[index] > maxOfRest)
        {
            return arr[index];
        }
        return maxOfRest;
    }

    // דוגמה 9: רקורסיה הדדית
    // שתי פעולות שקוראות זו לזו, בלי שאף אחת קוראת לעצמה ישירות.
    // מספר הוא זוגי אם המספר שלפניו אי זוגי, ומספר הוא אי זוגי אם המספר שלפניו זוגי.
    // תנאי העצירה: 0 הוא זוגי, ולכן אינו אי זוגי.
    static void Example09_EvenOdd()
    {
        Console.WriteLine("Example 9: mutual recursion");
        Console.WriteLine("is 6 even? " + IsEven(6));
        Console.WriteLine("is 7 even? " + IsEven(7));
        Console.WriteLine("is 7 odd? " + IsOdd(7));
        Console.WriteLine();
    }

    static bool IsEven(int n)
    {
        if (n == 0)
        {
            return true;
        }
        return IsOdd(n - 1);
    }

    static bool IsOdd(int n)
    {
        if (n == 0)
        {
            return false;
        }
        return IsEven(n - 1);
    }

    // דוגמה 10: הדפסת מספר בבסיס שתיים
    // כדי לקבל את הספרות הבינאריות של מספר מחלקים אותו ב-2 שוב ושוב.
    // השארית בכל חלוקה היא ספרה, אבל הספרות מתקבלות מהסוף להתחלה.
    // לכן קודם קוראים לפעולה עבור המנה, ורק אחר כך מדפיסים את השארית.
    // כך ההדפסה מתבצעת בדיוק בסדר ההפוך לסדר החישוב.
    static void Example10_PrintBinary()
    {
        Console.WriteLine("Example 10: binary");
        Console.Write("10 -> ");
        PrintBinary(10);
        Console.WriteLine();
        Console.Write("37 -> ");
        PrintBinary(37);
        Console.WriteLine();
        Console.WriteLine();
    }

    static void PrintBinary(int num)
    {
        if (num >= 2)
        {
            PrintBinary(num / 2);
        }
        Console.Write(num % 2);
    }
}
