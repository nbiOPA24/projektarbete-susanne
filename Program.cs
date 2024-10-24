using System.Runtime.CompilerServices;

class Program
{

    public static void Main()
    {
        bool isRunning = true;
        Admin admin = new Admin();

        System.Console.WriteLine("***************************************************************************");
        System.Console.WriteLine("Välkommen till elev-Quiz!");
        System.Console.WriteLine("Detta Quiz hjälper dig att hålla koll på dina kunskaper inom olika ämnen. ");
        System.Console.WriteLine("Välj ett ämne och svara på frågorna. Du får poäng för varje rätt svar.");
        System.Console.WriteLine("När du är klar kan du se vilket betyg dina poäng motsvarar i respektive ämne");
        System.Console.WriteLine("Lycka till!");
        System.Console.WriteLine("*****************************************************************************");

       while(isRunning)
       {
        System.Console.WriteLine();
        System.Console.WriteLine("Välj ett ämne : ");
        System.Console.WriteLine("1. Svenska ");
        System.Console.WriteLine("2. Engelska ");
        System.Console.WriteLine("3. SO ");
        System.Console.WriteLine("4. Matte ");
        System.Console.WriteLine("5. Idrott ");
        System.Console.WriteLine("6. Se dina betyg ");
        System.Console.WriteLine("7. Admin");
        System.Console.WriteLine("8. Avsluta programmet ");
       
        System.Console.WriteLine();
        string choice = Console.ReadLine();

        switch(choice)
        {
            case "1":
            System.Console.WriteLine("Svenska");
            break;

            case "2":
            System.Console.WriteLine("Engelska");
            break;

            case "3":
            System.Console.WriteLine("SO");
            break;

            case "4":
            System.Console.WriteLine("Matte");
            break;

            case "5":
            System.Console.WriteLine("Idrott");
            break;

            case "6":
            System.Console.WriteLine("Se dina betyg");
            break;

            case "7":
            System.Console.WriteLine("Admin");    //Här skapar vi frågor etc. Ska kräva inlogg!        
            admin.CreateNewQuestion();
            break;
        

            case "8":
            System.Console.WriteLine("Tack för idag!");
            isRunning = false;
            break;
        }

       }

        
    }
}