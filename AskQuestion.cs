
using System.Diagnostics;

public abstract class AskQuestion
{    
    public List<Question> points = new List<Question>();
    public static List<Question> WrongAnswers {get; set;} = new List<Question>();
    public abstract void ProbeQuestion(List<Question> questions); 

    public static void PracticeWrongAnswers()
    {
        if(WrongAnswers == null && WrongAnswers.Count == 0)
        {
            Console.WriteLine("Det finns inga frågor att besvara i listan");
            return;
        }
        foreach(var question in WrongAnswers)
        {
            Console.WriteLine(question.Quest);  

            Console.Write("Skriv svaret på frågan: ");
            var userAnswer = Console.ReadLine();

            if(userAnswer == question.Answer)
            {
                Console.WriteLine("Ditt svar var rätt! Bra jobbat!");
                
            }
            else if(userAnswer != null && question.Keywords.Any(keyword => userAnswer.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Ditt svar innehöll ett eller flera nyckelord. Bra jobbat!");
                
            }
            else
            {
                Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar är {question.Answer}");
            }
            
        }
        Console.WriteLine("Inga fler frågor att besvara. Bra jobbat!");
    } 
    
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
                        points.Add(question);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar är {question.Answer}");
                        WrongAnswers.Add(question);
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
                points.Add(question);

            }
            else if(userAnswer != null && question.Keywords.Any(keyword => userAnswer.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Ditt svar innehåller ett eller flera nyckelord, och du får därför rätt på frågan");
                points.Add(question);
            }
            else
            {
                Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar är: {question.Answer}");
                WrongAnswers.Add(question);
            }

            Console.WriteLine();
        }      
    }
}