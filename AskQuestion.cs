using System.Collections.Immutable;
using System.Dynamic;

public abstract class AskQuestion
{    
    public abstract void ProbeQuestion(List<Question> questions);   
}


public class MultiChoiceQuestion : AskQuestion
{
    public override void ProbeQuestion(List<Question> questions)
    {
        var rnd = new Random();
        var selectedQuestion = questions.OrderBy(q => rnd.Next()).Take(5).ToList();
        foreach(var question in selectedQuestion)
        {
            Console.WriteLine($"Fråga: {question.Quest}");
            if(question.Options != null && question.Options.Count > 0)
            {
                for(int i = 0; i < question.Options.Count; i++)
                {
                    Console.WriteLine($"{i +1}. {question.Options[i]}");
                }
                Console.WriteLine("Skriv in siffran framför det rätta svaret");
                if(int.TryParse(Console.ReadLine(), out int userAnswer))
                {
                    if(userAnswer > 0 && userAnswer <= question.Options.Count && question.Options[userAnswer -1].Equals(question.Answer))
                    {
                        Console.WriteLine("Ditt svar var rätt!");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar är {question.Answer}");
                        Console.WriteLine();
                    }

                }

            }
        }
        
    }

}