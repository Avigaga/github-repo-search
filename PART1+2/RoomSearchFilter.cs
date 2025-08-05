using System;

public enum RoomAvailableOption
{
    All,
    AvailableOnly,
    NotAvailableOnly
}

public class Room
{
    public bool IsAvailable { get; set; }
}

public class RoomSearchFilter
{
    private readonly RoomAvailableOption _enforcedOption;

    public RoomSearchFilter(RoomAvailableOption enforcedOption)
    {
        _enforcedOption = enforcedOption;
    }

    public bool IncludeInFinalResults(Room room)
    {
        bool isAvailable = CheckIfRoomAvailable(room);

        return _enforcedOption switch
        {
            RoomAvailableOption.All => true,
            RoomAvailableOnly => isAvailable,
            RoomAvailableOption.NotAvailableOnly => !isAvailable,
            _ => true
        };
    }

    private bool CheckIfRoomAvailable(Room room)
    {
        // Simulated check logic; assuming IsAvailable is already set on the room
        return room.IsAvailable;
    }
}


///
הבעיה בקוד היא שימוש שגוי ב־switch – במקום להשוות לערכים של ה־enum RoomAvailableOption, הקוד השווה לשם המשתנה enforcedOption, מה שגורם לשגיאת קומפילציה.
בנוסף, יש שגיאה לוגית: כאשר האופציה היא NotAvailableOnly, הפונקציה עדיין מחזירה isAvailable במקום !isAvailable.
ביצעתי רפקטור תוך שימוש ב־switch expression (ב־C# 8 ומעלה) לשיפור קריאות הקוד והוספתי בדיקה הפוכה למקרה של NotAvailableOnly.
    ///