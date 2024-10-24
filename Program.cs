using System.Runtime.CompilerServices;

class Program
{

    public static void Main()
    {
        bool isRunning = true;

        System.Console.WriteLine("ElevQuiz");

       while(isRunning)
       {
        System.Console.WriteLine("Välj ett ämne : ");
        System.Console.WriteLine("1. Svenska ");
        System.Console.WriteLine("2. Engelska ");
        System.Console.WriteLine("3. SO ");
        System.Console.WriteLine("4. Matte ");
        System.Console.WriteLine("5. Idrott ");
        System.Console.WriteLine("6. Se dina betyg ");
        System.Console.WriteLine("7. Avsluta programmet ");
        string choice = Console.ReadLine();

        switch(choice)
        {
            case "1":
            System.Console.WriteLine("Svenska");
            break;

            case "2":
            System.Console.WriteLine("Svenska");
            break;

            case "3":
            System.Console.WriteLine("Svenska");
            break;

            case "4":
            System.Console.WriteLine("Svenska");
            break;

            case "5":
            System.Console.WriteLine("Svenska");
            break;

            case "6":
            System.Console.WriteLine("Svenska");
            break;

            case "7":
            System.Console.WriteLine("Tack för idag!");
            isRunning = false;
            break;
        }

       }

        
    }
}