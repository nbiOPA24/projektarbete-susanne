


public class SubjectMenu
{

    public void SubjectM()
    {
        System.Console.WriteLine("Vilken typ av frågor vill du ha?");
        System.Console.WriteLine("1. Fritextfrågor");
        System.Console.WriteLine("2. Flervalsalternativ");
        System.Console.WriteLine("3. Rätt/fel");
        System.Console.WriteLine("4. Avslutar programmet");
        string input = Console.ReadLine();

        switch(input)
        {
            case "1":
            {
                break;
            }
            case "2":
            {
                break;
            }
            case "3":
            {
                break;
            }
            case "4":
            {
                System.Console.WriteLine("------------------------");
                System.Console.WriteLine("Återgår till huvudmenyn.");
                break;
            }
            default:
            {
                System.Console.WriteLine("-------------------------------");
                System.Console.WriteLine("Ogiltig inmatning. Försök igen!");
                break;
            }

        }
    }
 
}

public class Subject
{

}