
class Program
{
    //LanguageQuestion languageQuestion = new LanguageQuestion(); --> används inte i klassen Program? ta bort?
  
    public static async Task Main()
    {
            
        string filePath = "questions.json";
        await Question.LoadQuestionsFromFile(filePath);
        HandleDifferentQuestions questionHandler = new HandleDifferentQuestions();       
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
            Console.WriteLine("3. Samhällsorienterande ämnen");
            Console.WriteLine("4. Matte");
            Console.WriteLine("5. Naturkunskap ");
            Console.WriteLine("6. Skriv ut antal frågor");
            Console.WriteLine("7. Se samtliga frågor");
            Console.WriteLine("8. Avsluta programmet");
            Console.WriteLine();
            string choice = Console.ReadLine();

            //Variabeln sätter subject till tomt värde från början. I respektive ämne sätts därefter subject/ämne och möjliggör att rätt frågor laddas från filen. 
            List<Question> subjectQuestions = null;
            
            switch (choice)
            {
                case "1":
                    
                    Console.WriteLine("Svenska");
                    subjectQuestions = Question.AllQuestions.Where(q => q.Subject == "SV").ToList();
                    questionHandler.ChooseTypeOfQuestionMenu(subjectQuestions);                   
                    break;
                
                
                case "2":
                    Console.WriteLine("EN"); 
                    //currentSubject = new Subject("EN");
                    LanguageQuestion.LanguageQuestionMenu();
                    break;

                case "3":
                    Console.WriteLine("Samhällsorienterande ämnen");
                    //currentSubject = new Subject("SO");
                    break;

                case "4":
                    Console.WriteLine("Matte");
                    //currentSubject = new Subject("EN"); 
                    //mathematics.MathMenu();            
                    break;

                case "5":
                    Console.WriteLine("Naturkunskap");
                    //currentSubject = new Subject("NA");                   
                    break;

                case "6":
                    Console.WriteLine("Skriv ut antal frågor"); //Logik för att räkna poäng behövs.  EJ PÅBÖRJAT!!!                 
                    break;

                case "7":
                    Console.WriteLine("Adminklass:");//Här ska man kunna lägga in frågor och ev även kunna se olika elevers poäng!                  
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
    
}