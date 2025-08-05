///


/// <summary>
/// SOLID ��� ������� �� ����� ������� ����� ������ ����� ���� �� ��� ����� ����� (OOP):

//S - Single Responsibility Principle(SRP)
//�� ����� ������ ���� ��� ����.
//�����: ����� ������ �� ������� �����, ��� ������ ���� ������ �� �����.

//O - Open/Closed Principle (OCP)
//�� ����� ����� �� ���, �� �� ����� ���.
//�����: ����� ����� ����� ���� ��� ��� ����, ������ ������ �� ��������.

//L - Liskov Substitution Principle (LSP)
//����� ����� ����� ���� ����� ������ ������� ���� ����� �� ����.
//�����: �� Rectangle ��� ����� ����, Square ����� ������ ����� �������� ����.

//I - Interface Segregation Principle (ISP)
//���� ���� ������ ����� ���� ��� ���� ����.
//�����: �� �� ����� ����� ���� IAnimal �� ����� Fly() �� ��� �� ���.

//D - Dependency Inversion Principle (DIP)
//������ ������ ����� ������� (������), �� ��������.
//�����: ����� ����� new EmailSender(), ������ ���� ��� ���� �����������.

//����� �� SRP � ������ ������� ������:
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
//���:

//Report ����� �� ����� �� �����.

//ReportPrinter ����� �� ������ ����.