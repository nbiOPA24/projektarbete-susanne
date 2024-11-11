
class Program
{
    LanguageQuestion languageQuestion = new LanguageQuestion();
  
    static async Task Main()
    {
        //string filePath = "questions.json";   
        Mathematics mathematics = new Mathematics();      

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
            Console.WriteLine("6. Se dina betyg i respektive ämne");
            Console.WriteLine("7. Se samtliga frågor");
            Console.WriteLine("8. Avsluta programmet");
            Console.WriteLine();
            string choice = Console.ReadLine();

            Subject currentSubject = null; //Variabeln sätter subject till tomt värde från början. I respektive ämne sätts därefter subject/ämne och möjliggör att rätt frågor laddas från filen. 

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Svenska");
                    currentSubject = new Subject("SV");                    
                    break;

                case "2":
                    Console.WriteLine("EN"); // Här vill jag ha andra typer av frågor - glosträning, ersätta ord i meningar. 
                    currentSubject = new Subject("EN");
                    LanguageQuestion.LanguageQuestionMenu();
                    break;

                case "3":
                    Console.WriteLine("Samhällsorienterande ämnen");
                    currentSubject = new Subject("SO");
                    break;

                case "4":
                    Console.WriteLine("Matte"); //Öva multiplikationstabellen på tid!!!
                    //currentSubject = new Subject("EN"); 
                    mathematics.PracticeMultiplication();            
                    break;

                case "5":
                    Console.WriteLine("Naturkunskap");
                    currentSubject = new Subject("NA");                   
                    break;

                case "6":
                    Console.WriteLine("Se dina betyg i respektive ämne"); //Logik för att räkna poäng behövs.  EJ PÅBÖRJAT!!!                 
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
            await currentSubject.LoadQuestionsAsync("questions.json");
            await currentSubject.ChooseType();
        }
    }
    
}