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
����� ���� ��� ����� ���� ��switch � ����� ������ ������ �� ��enum RoomAvailableOption, ���� ����� ��� ������ enforcedOption, �� ����� ������ ���������.
�����, �� ����� �����: ���� ������� ��� NotAvailableOnly, �������� ����� ������ isAvailable ����� !isAvailable.
������ ������ ��� ����� ��switch expression (��C# 8 �����) ������ ������ ���� ������� ����� ����� ����� �� NotAvailableOnly.
    ///