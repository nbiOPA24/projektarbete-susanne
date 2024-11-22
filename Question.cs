

public enum Subject  
{
    SV,
    SO,
    NA
}
public abstract class Question
{
    public Subject SubjectType {get; set;} 
    public string Quest  {get; set;}
    public string CorrectAnswer {get; set;}
    public int Points {get; set;}
    
    protected Question(Subject subjectType, string quest, string correctAnswer, int points)
    {
        SubjectType = subjectType;
        Quest = quest;
        CorrectAnswer = correctAnswer;
        Points = points;
    }

    public abstract void AskQuestion(User user);
}

public class TextQuestion : Question
{
    public List<string> Keywords {get; set;} //Lägg till funktionalitet för Keywords!!!
    public TextQuestion(Subject subjectType, string quest, string correctAnswer, int points)
    :base(subjectType, quest, correctAnswer, points) {}

    public override void AskQuestion(User user)
    {
        Console.WriteLine($"Fråga: {Quest}");
        string userAnswer = Console.ReadLine();

        if(userAnswer.ToLower() == CorrectAnswer.ToLower())
        {
            Console.WriteLine("Ditt svar var rätt!");
            if(user == null)
            {
                Console.WriteLine();//Tom rad - poäng sparas inte eftersom användaren inte är inloggad aktör. 
            }

            else if (user != null && user.Score.ContainsKey(SubjectType.ToString()))
            {
                
                user.Score[SubjectType.ToString()] += Points;            }                
            
        }
        else
        {
            Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar är {CorrectAnswer}");

            if(user == null)
            {
                Console.WriteLine(); //Tom rad - frågan sparas inte eftersom användaren inte är inloggad aktör. 
            }
            else if(user != null)
            {
                 user.AddWrongAnswer(this);
            }
           
        }
    }

}

public class MultipleChoiceQuestion : Question
{
    public List<string> Options {get; set;}

    public MultipleChoiceQuestion(Subject subjectType, string quest, List<string> options, string correctAnswer, int points)
    : base(subjectType, quest, correctAnswer, points)
    {
        Options = options;
    }

    public override void AskQuestion(User user)
    {
        Console.WriteLine($"Fråga: {Quest}");
        for(int i = 0; i < Options.Count; i++)
        {
            Console.WriteLine($"{i +1}. {Options[i]}");
        }
        Console.Write("Skriv in det nummer som rätt svar motsvarar: ");
        if(int.TryParse(Console.ReadLine(), out int userAnswer) && userAnswer > 0 && userAnswer <= Options.Count && Options[userAnswer -1].ToLower() == CorrectAnswer.ToLower())
        {
            Console.WriteLine("Ditt svar var rätt!");
            if(user == null)
            {
                Console.WriteLine("");//Tom rad - poäng sparas inte eftersom användaren inte är inloggad aktör. 
            }


            else if (user != null && user.Score.ContainsKey(SubjectType.ToString()))
            {
                user.Score[SubjectType.ToString()] += Points;
            }
        }
        else
        {
            Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar är {CorrectAnswer}");
            if(user == null)
            {
                Console.WriteLine("");//Tom rad - frågan sparas inte eftersom användaren inte är inloggad aktör. 
            }

            else if (user != null)
            {
                user.AddWrongAnswer(this);
            }

            
        }

        

    }
}