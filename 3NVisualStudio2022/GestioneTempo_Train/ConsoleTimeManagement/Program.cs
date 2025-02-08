using TestTimeManagement;
using TimeManagement;
class TestClass
{
    static void Main(string[] args)
    {
        Calendars calendar = new Calendars(15, 2, 1900);
        calendar.AddDay(17);
        int expectedDay = 4;
        int actualDay = calendar.Day;
        


    }
}
