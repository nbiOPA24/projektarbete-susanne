public class Question
{
    public enum Subject
    {
        Svenska,
        SO,
        NA
    }
    public string Subject {get; set;}
    public string Quest  {get; set;}
    public string CorrectAnswer {get; set;}
    public int Points {get; set;}
    
    public Question(string subject, string quest, string correctAnswer, int points)
    {
        Subject = subject;
        Quest = quest;
        CorrectAnswer = correctAnswer;
        Points = points;
    }

    public static void CreateNewQuestion(List<Question> questions)
    {     

        Console.Write("Skriv in vilket ämne frågan tillhör (SV, NA, SO): ");
        string subject  = Console.ReadLine();
        Console.Write("Skriv in frågan: ");
        string quest = Console.ReadLine();
        Console.Write("Skriv in det rätta svaret: ");
        string correctAnswer = Console.ReadLine();
        Console.Write("Skriv in antal poäng som frågan kan ge: ");
        int points = int.Parse(Console.ReadLine());

        var newQestion = new Question(subject, quest, correctAnswer, points);
        questions.Add(newQestion);
        Console.WriteLine("Frågan har lagts till.");
    }
    public static void AskQuestion(User user, Question question)
    {
        System.Console.WriteLine($"{question.Quest}");
        string userAnswer = Console.ReadLine();

        if(userAnswer.ToLower() == question.CorrectAnswer.ToLower())
        {
            System.Console.WriteLine("Du svarade rätt!");
            if(user.Score.ContainsKey(question.Subject))
            {
                user.Score[question.Subject] += question.Points;
            }
        }
        else
        {
            System.Console.WriteLine($"Svaret var tyvärr fel. Rätt svar är {question.CorrectAnswer}");
        }

    }

}

public class TextQuestion : Question
{
    
}