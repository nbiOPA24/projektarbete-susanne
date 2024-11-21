using System.Text.Json; // För JsonSerializer
using System.Text.Json.Serialization; // För avancerade JSON-funktioner, som attribut
using System.IO; // För att läsa och skriva filer

//Klassen innehåller en meny för quiz - KLART
//Klassen samordnar alla svar som användaren har gett?
public class LoadFile //Döper om klassen till LoadFile, eftersom jag vill kunna ladda olika typer av frågefiler till mitt program, och LoadfFile är ett mer generiskt namn på 
{    
    public static List<Question> LoadAllQuestions(string filePath) //Metod för inläsning av Json-filen.Ändrar från asynkton till synkron inläsning av filen. Då filen är liten behövs inte någon asynkron inläsning. 
    {
        string jsonText = File.ReadAllText(filePath);
        
       
        var allQuestions = JsonSerializer.Deserialize<List<Question>>(jsonText); // Deserialiserar JSON-texten till en lista av Question-objekt, där de olika json-objekten kan matchas med objekten i klassen Question.       

        return allQuestions;
    }
}

public class HandleQuiz
{
    //Metoden filtrerar listan med frågor utifrån ämne (subject) och returnerar en lista med valt ämne (subject)
    
    public static List<Question> FilterQuestionsBySubject(List<Question> questions, string subject)
    {
        return questions.FindAll(q => q.Subject == subject);
    }   
    
        
    public static void ChooseQuestionMenu(List<Question> questions, string selectedSubject )
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
                selectedQuestions = Question.FilterQuestionsByType(subjectQuestions, QuestionType.Text);
                new TextQuestion().AskQuestion(selectedQuestions);
                break;

                case "2":
                Console.WriteLine("Öva med flervalsfrågor");
                selectedQuestions = Question.FilterQuestionsByType(subjectQuestions, QuestionType.MultipleChoice);
                new MultipleChoiceQuestion().AskQuestion(selectedQuestions);
                break;

                case "3":
                Console.WriteLine("Öva på de frågor där du svarat fel");
                Question.PracticeWrongAnswers();
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
