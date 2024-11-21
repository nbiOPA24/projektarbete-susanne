using System.Text.Json; // För JsonSerializer
using System.Text.Json.Serialization; // För avancerade JSON-funktioner, som attribut
using System.IO;
using System.Reflection.Metadata; // För att läsa och skriva filer

//Klassen innehåller en meny för quiz - KLART
//Klassen samordnar alla svar som användaren har gett?

public class HandleQuiz
{
    //Metoden filtrerar listan med frågor utifrån ämne (subject) och returnerar en lista med valt ämne (subject)
    public static List<Question> FilterQuestionsBySubject(List<Question> questions, string subject)
    {
        return questions.FindAll(q => q.Subject == subject);
    }   
    
        
    public static void ChooseQuestionMenu(List<Question> questions, string selectedSubject, User currentUser )
    {
        var subjectQuestions = FilterQuestionsBySubject(questions, selectedSubject);
        
        if(subjectQuestions == null||subjectQuestions.Count == 0)
        {
            Console.WriteLine($"Inga frågor hittades för ämnet {selectedSubject}");
        }
        
        bool isRunning = true;

        while(isRunning)
        {
            Console.WriteLine("---Välj vilken typ av frågor du vill besvara---");
            Console.WriteLine("______________________________________");
            Console.WriteLine("1. Öva med fritextfrågor");
            Console.WriteLine("2. Öva med flervalsfrågor");
            Console.WriteLine("3. Öva på de frågor som du svarat fel på");
            Console.WriteLine("4. Återgå till huvudmenyn");
            Console.WriteLine("_______________________________________________");
            string input = Console.ReadLine();
            List<Question> selectedQuestions;

            switch(input)
            {
                case "1":
                Console.WriteLine("Öva med fritextfrågor");                
          
                break;

                case "2":
                Console.WriteLine("Öva med flervalsfrågor");
                
                break;

                case "3":
                Console.WriteLine("Öva på de frågor där du svarat fel");
                //Question.PracticeWrongAnswers();
                break;

                case "4":
                Console.WriteLine("Återgår till huvumednyn");
                isRunning = false;
                break;

                default:
                Console.WriteLine("Felaktig inmatning.");
                break;
            }
            
        }

    }

}
