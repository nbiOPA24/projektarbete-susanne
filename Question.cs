using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

public enum QuestionType //Lägger till QuestionType  för att lista olika frågetyper i Jsonfilen eftersom jag inte får det att fungera som tänkt. 
{
    Text,
    MultipleChoice
}
public class Question
{
    
    public string? Subject {get; set;}
    public string? Quest {get; set;}
    public string? Answer {get; set;}
    public int Points {get; set;}
    public List<string> Options {get; set;} = new List<string>();
    public List<string> Keywords {get; set;} = new List<string>();
    public static List<Question> WrongAnswers { get; set; } = new List<Question>();
    [JsonConverter(typeof(QuestionTypeConverter))] 
    public QuestionType Type { get; set; }

    public static List<Question> FilterQuestionsByType(List<Question> questions, QuestionType type)
    {
        return questions.Where(q => q.Type == type).ToList();
    }

    
    public virtual void AskQuestion(User user, List<Question> questions)
    {       
    }
      
    
    public virtual bool IsAnswerCorrect(string userAnswer)
    {
        if (Options.Any()) // Om det är en flervalsfråga
        {
            if (int.TryParse(userAnswer, out int index))
            {
                return index > 0 && index <= Options.Count && Options[index - 1].Equals(Answer, StringComparison.OrdinalIgnoreCase);
            }
        }
        else // Om det är en textfråga
        {
            return userAnswer.Equals(Answer, StringComparison.OrdinalIgnoreCase) || Keywords.Any(keyword => userAnswer.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }

        return false;
    } 
    /*public void ProbeQuestion(List<Question>questions)
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
    }*/
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
public class MultipleChoiceQuestion : Question
{
    public MultipleChoiceQuestion() { }
    public override void AskQuestion(User user, List<Question> questions)
    {
        var filteredQuestions = FilterQuestionsByType(questions, QuestionType.MultipleChoice);
        var selectedQuestions = filteredQuestions.OrderBy(q => Guid.NewGuid()).Take(5).ToList();
        
        foreach(var question in selectedQuestions)
        {
            Console.WriteLine($"Fråga: {question.Quest}");
            for(int i = 0; i < question.Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {question.Options[i]}");
            }
            Console.WriteLine("Skriv in siffran framör det rätta svaret:");
            string userAnswer = Console.ReadLine();

            bool isCorrect = question.IsAnswerCorrect(userAnswer);
            if(isCorrect)
            {
                Console.WriteLine("Du svarade rätt!"); 
                user.Score[question.Subject] += question.Points; //Logik för att lägga till poäng för rätt svar till dictionary
                             
            }
            else
            {
                Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar är {question.Answer}.");
            }
            
        }
    }
    public override bool IsAnswerCorrect(string userAnswer)
    {
        if(int.TryParse(userAnswer, out int index))
        {
            if(index >0 && index <= Options.Count)
            {
                bool isCorrect = Options[index -1].Equals(Answer, StringComparison.OrdinalIgnoreCase);
                if (!isCorrect)
                {
                    WrongAnswers.Add(this);
                }
                
                return isCorrect; 
            }                     
        }
        return false;
        
    }
}

public class TextQuestion : Question
{
    public TextQuestion() { }
    public override void AskQuestion(User user, List<Question> questions)
    {
        var filteredQuestions = FilterQuestionsByType(questions, QuestionType.Text);
        var selectedQuestions = filteredQuestions.OrderBy(q => Guid.NewGuid()).Take(5).ToList();
        {
            foreach(var question in selectedQuestions)
            {
                Console.WriteLine($"Fråga: {question.Quest}");
                Console.Write("Skriv ditt svar: ");
                string userAnswer = Console.ReadLine();

                if (question.IsAnswerCorrect(userAnswer))
                {
                    Console.WriteLine("Ditt svar var rätt!");
                    user.Score[question.Subject] += question.Points;                   
                }
                else
                {
                    Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar är {question.Answer}");
                    WrongAnswers.Add(question);
                }
            }
        }
    }
}



