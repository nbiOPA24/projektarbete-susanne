
class Program
{
    static async Task Main()
    {
        string filePath = "questions.json"; 
        
              

        bool isRunning = true;

        Console.WriteLine("***************************************************************************");
        Console.WriteLine("Välkommen till elev-Quiz!");
        Console.WriteLine("Välj det ämne som du vill öva på.");
        Console.WriteLine("När du är klar kan du se vilket betyg dina poäng motsvarar i respektive ämne");
        Console.WriteLine("Lycka till!");
        Console.WriteLine("*****************************************************************************");

        while (isRunning)
        {
            Console.WriteLine();
            Console.WriteLine("Välj ett ämne:");
            Console.WriteLine("1. Svenska");
            Console.WriteLine("2. Engelska");
            Console.WriteLine("3. SO");
            Console.WriteLine("4. Matte");
            Console.WriteLine("5. Idrott ");
            Console.WriteLine("6. Se dina betyg i respektive ämne");
            Console.WriteLine("7. Se samtliga frågor");
            Console.WriteLine("8. Avsluta programmet");
            Console.WriteLine();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Svenska");
                    Console.WriteLine("Svenska");
                    Svenska svenska = new Svenska("Svenska");
                    svenska.ChooseTypeSV();
                    
                    break;
                case "2":
                    Console.WriteLine("Engelska");
                    
                    break;
                case "3":
                    Console.WriteLine("SO");
                    
                    break;
                case "4":
                    Console.WriteLine("Matte");
                    
                    break;
                case "5":
                    Console.WriteLine("Idrott");
                   
                    break;
                case "6":
                    Console.WriteLine("Se dina betyg i respektive ämne");
                   
                    break;
                case "7":
                    Console.WriteLine("Här är alla frågor:");
                   
                   
                    break;
                case "8":
                    Console.WriteLine("Avslutar programmet.");
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Felaktig inmatning");
                    break;
            }
        }
    }
    static void ShowAllQuestions(List<Question> questions)//Ska flyttas till amdin-klassen!!!
    {
        foreach(var question in questions)
        {
            System.Console.WriteLine($"Ämne: {question.Subject}, Fråga: {question.Quest}, Svar: {question.Answer}, Poäng: {question.Points} ");
        }
    }
}