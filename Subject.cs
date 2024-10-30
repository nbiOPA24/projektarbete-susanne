


public class Subject
{

    public void SubjectMenu()
    {
        System.Console.WriteLine("Vilken typ av frågor vill du ha?");
        System.Console.WriteLine("1. Fritextfrågor");
        System.Console.WriteLine("2. Flervalsalternativ");
        System.Console.WriteLine("3. Rätt/fel");
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
                break;
            }
            default:
            {
                System.Console.WriteLine("Ogiltig inmatning. Försök igen!");
                break;
            }

        }

    }
        


 
}