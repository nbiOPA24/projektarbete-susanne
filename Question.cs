
public class Question
{    
    public string? Subject {get; set;}
    public string? Quest {get; set;}
    public string? Answer {get; set;}
    public int Points {get; set;}
    public List<string> Options {get; set;} = new List<string>();
    public List<string> Keywords {get; set;} = new List<string>();
    public static List<Question> WrongAnswers { get; set; } = new List<Question>();

    
    public virtual void AskQuestion()
    {
        Console.WriteLine($"Fråga: {Quest}");        
    }
       
    
    public virtual bool IsAnswerCorrect(string userAnswer)
    {
        if (Options.Any()) 
        {
            if (int.TryParse(userAnswer, out int index))
            {
                return index > 0 && index <= Options.Count && Options[index - 1].Equals(Answer, StringComparison.OrdinalIgnoreCase);
            }
        }
        else 
        {
            return userAnswer.Equals(Answer, StringComparison.OrdinalIgnoreCase) || Keywords.Any(keyword => userAnswer.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }

        return false;
    } 
    public void ProbeQuestion(List<Question>questions)
    {
        var rnd = new Random();
        var selectedQuestions = questions.OrderBy(q => rnd.Next()).Take(5).ToList();

        foreach(var question in selectedQuestions)
        {
            question.AskQuestion();
            string userAnswer = Console.ReadLine();

            if(question.IsAnswerCorrect(userAnswer))
            {
                Console.WriteLine("Ditt svar var rätt!");
            }
            else
            {
                Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar är {question.Answer}");
                WrongAnswers.Add(question);
            }
            System.Console.WriteLine();
        }
    }
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
//Klass som läser in frågor från json-filen samt dess tillhörande options(flervalsfrågor)
public class MultipleChoiceQuestion : Question
{
    public MultipleChoiceQuestion() { }
    public override void AskQuestion()
    {
        Console.WriteLine($"Fråga: {Quest}");
        for(int i = 0; i < Options.Count; i++)
        {
            Console.WriteLine($"{i+1}. {Options[i]}");
        }
        Console.Write("Skriv in siffran för det rätta svaret: ");
    }
    public override bool IsAnswerCorrect(string userAnswer)
    {
        if(int.TryParse(userAnswer, out int index))
        {
            return index > 0 && index <= Options.Count && Options[index -1].Equals(Answer, StringComparison.OrdinalIgnoreCase);
        }
        return false;
    }
}

//Klass som läser in frågor från json-filen sam dess tillhörande Keywords. Keywords gör att användaren kan få rätt även om användaren inte skriver exakt samma mening som i Answer. 
public class TextQuestion : Question
{
    public TextQuestion() { }
    public override void AskQuestion()
    {
        Console.WriteLine($"Fråga: {Quest}");
        Console.Write("Skriv ditt svar: ");
    }
    public override bool IsAnswerCorrect(string userAnswer)
    {
        foreach(var question in WrongAnswers)
        {
            Console.WriteLine(question);

            if(userAnswer == question.Answer)
            {
                Console.WriteLine("Den här gången svarade du rätt. Bra jobbat!");
            }
            else if(userAnswer != null && question.Keywords.Any(keyword => userAnswer.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Ditt svar innehåller ett eller flera nyckelod. Bra jobbat!");
            }
            else
            {
                Console.WriteLine($"Ditt svar var tyvärr fel även denna gång. Rätt svar är {question.Answer}");
                
            }
        }
        Console.WriteLine("Inga fler frågor att besvara. Bra jobbat");
    }

}



