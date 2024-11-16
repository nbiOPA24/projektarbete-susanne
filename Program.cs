

class Program
{
    //LanguageQuestion languageQuestion = new LanguageQuestion(); --> används inte i klassen Program? ta bort?
  
  //Mainmetoden håller meny för de val som användaren gör initialt i programmet - väljer vad hen vill öva på. 
    public static void Main()
    {            
        List<Question> questions = LoadFile.LoadAllQuestions("questions.json");  

        if (questions != null && questions.Count > 0) // Kontrollutskrift för att säkerställa att filinläsningen fungerar
        {
            Console.WriteLine($"Antal frågor inlästa: {questions.Count}");
        }

        else
        {
            Console.WriteLine("Ingen data lästes in från JSON-filen.");
        }

        bool isRunning = true;
        string selectedSubject = ""; //Sätter ett initialvärde för variabeln, då det annars ger kompilator-fel.

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
            System.Console.WriteLine("-------------------------------");
            Console.WriteLine("1. Svenska");
            Console.WriteLine("2. Engelska");
            Console.WriteLine("3. Samhällsorienterande ämnen");
            Console.WriteLine("4. Matte");
            Console.WriteLine("5. Naturkunskap ");
            Console.WriteLine("-------------------------------------- ");
            Console.WriteLine("6. Se vilket betyg dina poäng motsvarar");
            Console.WriteLine("7. Se samtliga frågor");
            Console.WriteLine("8. Avsluta programmet");
            Console.WriteLine();
            string choice = Console.ReadLine();

            //Variabeln sätter subjectQuestions till tomt värde från början. I respektive ämne sätts därefter subject/ämne och möjliggör att rätt frågor laddas från filen. 
            List<Question> subjectQuestions = null;
            
            switch (choice)
            {
                case "1":
                    
                    Console.WriteLine("Svenska");
                    selectedSubject = "SV";
                    subjectQuestions = HandleQuiz.FilterQuestionsBySubject(questions, selectedSubject); //Här bestäms vilka frågor som ska hämtas från filen till listan subjectQuestions
                    break;
                                                     
                
                case "2":
                    Console.WriteLine("EN"); 
                    //Gå direkt för meny för språk-frågor                    
                    continue;

                case "3":
                    Console.WriteLine("Samhällsorienterande ämnen");
                    selectedSubject = "SO"; 
                    subjectQuestions = HandleQuiz.FilterQuestionsBySubject(questions, selectedSubject); 
                    break;

                case "4":
                    Console.WriteLine("Matte");
                    //Gå direkt för meny för Matte-frågor           
                    continue; //Behöver sättas till continue för att jag inte användare mig av ämnen från questions-filen. 

                case "5":
                    Console.WriteLine("Naturkunskap");
                    selectedSubject = "NA"; 
                    subjectQuestions = HandleQuiz.FilterQuestionsBySubject(questions, selectedSubject);
                              
                    break;

                case "6":
                    Console.WriteLine("Se vad dina poäng motsvarar i betyg"); //Logik för att räkna poäng behövs.  EJ PÅBÖRJAT!!!
                                     
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
                    continue;
            }

            if (subjectQuestions != null && subjectQuestions.Count > 0)
                {
                    HandleQuiz.ChooseQuestionMenu(questions, selectedSubject);
                }
                else if (subjectQuestions != null && subjectQuestions.Count == 0)
                {
                    Console.WriteLine("Inga frågor att besvara");
                }
                else
                {
                    Console.WriteLine("Tack för idag!");
                }
            
        }
        
    }
    
 
}