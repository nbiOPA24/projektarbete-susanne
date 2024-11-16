public class AskQuestions
{
    List<Question> questions = new List<Question>();
    

    public string GetQuestion {get; set;}
    public string GetCorrectAnswer {get; set;}

    public AskQuestions(string getQuestion, string getCorrectAnswer)
    {
        GetQuestion = getQuestion;
        GetCorrectAnswer = getCorrectAnswer;
    }


      
    //Metoden slumpar fram 5 frågor från det av användaren valda ämnet. 
    //De fem rågorna lagras i listan selectedQuestions. 
    //Eftersom alla ämnen har en fråga bör denna metod vara universell. 
    public static void ProbeQuestion(List<Question> questions)
    {
        var rnd = new Random();
        var selectedQuestions = questions.OrderBy(q => rnd.Next()).Take(5).ToList();
        
        foreach(var question in selectedQuestions)
        {
            System.Console.WriteLine("Här skriver vi ut efm slumpade frågor");
            Console.WriteLine($"{question.Quest} ");
        }      
    }

}