using System.Collections.Concurrent;

class HandleDifferentQuestions
{
    private List<Question> wrongAnswers = new List<Question>();
    public void ChooseTypeOfQuestionMenu(List<Question> subjectQuestions) //Flyttar meny för att välja fråga till klassen Subjects.   
    {
        while(true)
        {
            Console.WriteLine("Välj typ av fråga:");
            Console.WriteLine("1. Fritextfråga");
            Console.WriteLine("2. Flervalsfråga");
            Console.WriteLine("3. Öva på frågor där du svarat fel");
            Console.WriteLine("4. Återgå till huvudmenyn");
            string input = Console.ReadLine();
            
            if (input == "1")
            {
               var textQuestions = subjectQuestions.Where(q => !(q is MultipleChoiceQuestion)).ToList();
               if(textQuestions.Any())
               {
                    AskQuestion(textQuestions);
               }
               else
               {
                    System.Console.WriteLine("Inga fritextfrågor finns för ämnet");
               }
               
            }

            else if(input == "2")
            {
                var multipleChoiceQuestions = subjectQuestions.OfType<MultipleChoiceQuestion>().ToList();
                if(multipleChoiceQuestions.Any())
                {
                     AskQuestion(multipleChoiceQuestions.Cast<Question>().ToList());
                }
                else
                {
                    System.Console.WriteLine("Inga flervalsfrågor finns för ämnet");
                }
                
            }
                
            else if(input == "3")
            {
                AskQuestion(wrongAnswers);              
            }
            else if(input == "4")
            {
                System.Console.WriteLine("Återgår till huvudmenyn");
                break;
            }
            else
            {
                System.Console.WriteLine("Ogiltig inmatning");
            }
        }        
    } 

    public void AskQuestion(List<Question> questions)// En metod som skriver ut en fråga, oavsett typ av fråga.
    {
       var rnd = new Random(); //En variabel som senare håller en slumpad fråga.
       var selectedQuestions = questions.OrderBy(q => rnd.Next()).Take(10).ToList();

       foreach(var question in selectedQuestions)
       {
            System.Console.WriteLine(question.Quest);

            if(question is MultipleChoiceQuestion msq)
            {
                AskMultipleChoiceQuestion(msq);
            }
            else
            {
                AskTextQuestion(question);
            }
        }
    }
    private void AskMultipleChoiceQuestion(MultipleChoiceQuestion question)
    {
        int optionNum = 1;
        foreach(var option in question.Options)
        {
            System.Console.WriteLine($"{optionNum}. {option}");
            optionNum++;
        }
        System.Console.WriteLine("---Skriv ut siffran framför det rätta svaret---");
        if(int.TryParse(Console.ReadLine(), out int userAnswer) && userAnswer > 0 && userAnswer <= question.Options.Count)
        {
            string selectedOption = question.Options[userAnswer - 1].Trim().TrimEnd('.');
            string correctAnswer = question.Answer.Trim().TrimEnd('.');

            if(selectedOption.Equals(correctAnswer, StringComparison.OrdinalIgnoreCase))
            {
                System.Console.WriteLine("Ditt svar var rätt!");
            }
            else
            {
                System.Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar är {question.Answer}");
                wrongAnswers.Add(question);
            }
        }
    }
    private void AskTextQuestion(Question question)
    {
        System.Console.Write("---Skriv ditt svar---");
        string userAnswer = Console.ReadLine();

        if(userAnswer.Equals(question.Answer.Trim(), StringComparison.OrdinalIgnoreCase))
        {
            System.Console.WriteLine("Ditt svar var rätt!");
        }
        else if(question.Keywords != null && question.Keywords.Any(keyword => userAnswer.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >=0))
        {
            System.Console.WriteLine("Ditt svar innehåller ett eller flera nyckelord. Rätt svar!");
        } 
        else 
        {
            System.Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar är {question.Answer}");
            wrongAnswers.Add(question);
        }            
    }    
}