using System.Runtime.CompilerServices;

class Program
{

    public static void Main()
    {
        Ämne ämne = new Ämne();
        bool isRunning = true;

        Admin admin = new Admin();                  

        System.Console.WriteLine("***************************************************************************");
        System.Console.WriteLine("Välkommen till elev-Quiz!");
        System.Console.WriteLine("Detta Quiz hjälper dig att hålla koll på dina kunskaper inom olika ämnen. ");
        System.Console.WriteLine("Välj vilken typ av quiz du vill göra. Därefter väljer du ämne.");
        System.Console.WriteLine("När du är klar kan du se vilket betyg dina poäng motsvarar i respektive ämne");
        System.Console.WriteLine("Lycka till!");
        System.Console.WriteLine("*****************************************************************************");

        while(isRunning)
       {
            System.Console.WriteLine("Välj vilken typ av quiz du vill göra");
            System.Console.WriteLine("1. Svara med fritext");
            System.Console.WriteLine("2. Flervalsalternativ");
            System.Console.WriteLine("3. Sant eller Falskt");
            System.Console.WriteLine("7. Admin");
            System.Console.WriteLine("8. Avsluta programmet.");
            string input = Console.ReadLine();

            switch(input)
            {
                case "1":
                System.Console.WriteLine("Fritext");
                break;

                case "2":
                System.Console.WriteLine("Flervalsalternativ");
                break;

                case "3":
                System.Console.WriteLine("Sant eller falskt");
                break;

                case "4":
                System.Console.WriteLine("Alternativ 4");
                break;

                case "5":
                System.Console.WriteLine("Alternativ 4");
                break;

                case "6":
                System.Console.WriteLine("Se dina betyg");
                break;

                case "7":
                System.Console.WriteLine("Admin");    //Här skapar vi frågor etc. Ska kräva inlogg!  
                admin.Menu();
                break;            

                case "8":
                System.Console.WriteLine("Tack för idag!");
                isRunning = false;
                break;
                
                default:            
                System.Console.WriteLine("Ogiltig inmatning.");
                break;   
            } 

        }
        
    }
}