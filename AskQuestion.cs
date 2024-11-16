using System.Collections.Immutable;
using System.Data.Common;
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
public class FreetextQuestion : AskQuestion
{
    public override void ProbeQuestion(List<Question> questions)
    {
        var rnd = new Random();
        var selectedQuestion = questions.OrderBy(q => rnd.Next()).Take(5).ToList();
        foreach(var question in selectedQuestion)
        {
            Console.WriteLine($"Fråga: {question.Quest}");            
            Console.WriteLine();                

            Console.Write("Skriv svaret på frågan: ");
            string userAnswer = Console.ReadLine();

            if(userAnswer == question.Quest)
            {
                Console.WriteLine("Du svarade rätt!");
            }
            else if(userAnswer != null && question.Keywords.Any(keyword => userAnswer.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Ditt svar innehåller ett eller flera nyckelord, och du får därför rätt på frågan");
            }
            else
            {
                Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar är: {question.Answer}");
            }

            Console.WriteLine();
        }      
    }
}