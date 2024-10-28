using System.Runtime.CompilerServices;

class Program
{

    static async Task Main()
    {
        string filePath = "questions.json";
        bool isRunning = true;

        Admin admin = new Admin(filePath);   
              

        System.Console.WriteLine("***************************************************************************");
        System.Console.WriteLine("Välkommen till elev-Quiz!");
        System.Console.WriteLine("Detta Quiz hjälper dig att hålla koll på dina kunskaper inom olika ämnen. ");
        System.Console.WriteLine("Välj vilken typ av quiz du vill göra. Därefter väljer du ämne.");
        System.Console.WriteLine("När du är klar kan du se vilket betyg dina poäng motsvarar i respektive ämne");
        System.Console.WriteLine("Lycka till!");
        System.Console.WriteLine("*****************************************************************************");

        while(isRunning)
       {
            System.Console.WriteLine();
            System.Console.WriteLine("Välj ett ämne:");
            System.Console.WriteLine("1. Svenska");
            System.Console.WriteLine("2. Engelska");
            System.Console.WriteLine("3. SO");
            System.Console.WriteLine("4. Matte");
            System.Console.WriteLine("5. Idrott ");
            System.Console.WriteLine("6. Se dina betyg i respektive ämne"); 
            System.Console.WriteLine("7. Admin");
            System.Console.WriteLine("8. Avsluta programmet");         
            System.Console.WriteLine();
            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                System.Console.WriteLine("Svenska"); //Härifrån kommer jag vidare till frågor i svenska
                // Anropa metoden för att visa alla frågor
                await admin.DisplayQuestionsAsync();    
                    
                break;

                case "2":
                System.Console.WriteLine("Engelska"); //Härifrån kommer jag vidare till frågor i engelska
                break;

                case "3":
                System.Console.WriteLine("SO"); //Härifrån kommer jag vidare till frågor i SO
                break;

                case "4":
                System.Console.WriteLine("Matte"); //Härifrån kommer jag vidare till frågor i matte
                break;

                case "5":
                System.Console.WriteLine("Idrott"); //Härifrån kommer jag vidare till frågor i idrott
                break;

                case "6":
                System.Console.WriteLine("Se dina betyg i respektive ämne"); //Poäng i respektive ämne omvanldas till "betyg"
                break;

                case "7":
                System.Console.WriteLine("Admin"); //Härifrån skapar jag frågor
                
                break;

                case "8":
                System.Console.WriteLine("Avsluta programmet."); 
                isRunning = false;
                break;

                default:
                System.Console.WriteLine("Felaktig inmatning");
                break;


            } 

        }
        
    }
}