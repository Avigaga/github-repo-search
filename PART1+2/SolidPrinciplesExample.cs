///


/// <summary>
/// SOLID הוא אקרונים של חמישה עקרונות תכנות המנחים עיצוב נכון של קוד מונחה עצמים (OOP):

//S - Single Responsibility Principle(SRP)
//כל מחלקה אחראית לדבר אחד בלבד.
//דוגמה: מחלקה שמטפלת רק בלוגיקה עסקית, ולא בשמירה למסד נתונים או הדפסה.

//O - Open/Closed Principle (OCP)
//יש לאפשר הרחבה של קוד, אך לא שינוי שלו.
//דוגמה: במקום לכתוב תנאים בקוד לפי סוג לקוח, להשתמש בירושה או אסטרטגיה.

//L - Liskov Substitution Principle (LSP)
//מחלקה נגזרת יכולה לשמש במקום המחלקה הבסיסית מבלי לשבור את הקוד.
//דוגמה: אם Rectangle היא מחלקת בסיס, Square צריכה להתנהג כראוי כשמחליפה אותה.

//I - Interface Segregation Principle (ISP)
//עדיף הרבה ממשקים קטנים מאשר אחד כללי גדול.
//דוגמה: לא כל מחלקה צריכה לממש IAnimal עם פעולת Fly() אם היא לא עפה.

//D - Dependency Inversion Principle (DIP)
//תלויות צריכות להיות בהפשטות (ממשקים), לא במימושים.
//דוגמה: במקום ליצור new EmailSender(), מקבלים אותו דרך ממשק בקונסטרקטור.

//דוגמה על SRP – עיקרון האחריות היחידה:
/// </summary>
public class Report
{
    public string Title { get; set; }
    public string Content { get; set; }

    public string GenerateReport()
    {
        return $"{Title}\n{Content}";
    }
}

public class ReportPrinter
{
    public void Print(string reportContent)
    {
        Console.WriteLine(reportContent);
    }
}
//כאן:

//Report אחראי רק לייצר את התוכן.

//ReportPrinter אחראי רק להדפיס אותו.