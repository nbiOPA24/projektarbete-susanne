
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
class Program
{
    //LanguageQuestion languageQuestion = new LanguageQuestion(); --> används inte i klassen Program? ta bort?
    
  
    public static void Main()
    {            
        List<Question> questions = LoadQuestions.LoadAllQuestions("questions.json");  

        if (questions != null && questions.Count > 0) // Kontrollutskrift för att säkerställa att filinläsningen fungerar
        {
            Console.WriteLine($"Antal frågor inlästa: {questions.Count}");
        }

        else
        {
            Console.WriteLine("Ingen data lästes in från JSON-filen.");
        }

        bool isRunning = true;
        string selectedSubject = "";

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
                    selectedSubject = "SV"; 
                    subjectQuestions = HandleQuestions.FilterQuestionsBySubject(questions, selectedSubject);
                    break;
                                                     
                
                case "2":
                    Console.WriteLine("EN"); 
                    //currentSubject = new Subject("EN");                    
                    break;

                case "3":
                    Console.WriteLine("Samhällsorienterande ämnen");
                    selectedSubject = "SO"; 
                    subjectQuestions = HandleQuestions.FilterQuestionsBySubject(questions, selectedSubject);
                    break;

                case "4":
                    Console.WriteLine("Matte");
                             
                    break;

                case "5":
                    Console.WriteLine("Naturkunskap");
                    selectedSubject = "NA"; 
                    subjectQuestions = HandleQuestions.FilterQuestionsBySubject(questions, selectedSubject);             
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
            
             // Anropar HandleQuestions.HandleQuestionTypeMenu när ämnet har valts
            if (subjectQuestions != null && subjectQuestions.Count > 0)
            {
                HandleQuestions.HandleQuestionTypeMenu(subjectQuestions, selectedSubject);
            }
            else if(subjectQuestions != null && subjectQuestions.Count == 0)
            {
                System.Console.WriteLine("Inga ytterligare frågor att besvara. ");
            }
            else
            {
                Console.WriteLine("Tack för idag!");
            }
                      
        }
    }
 
}