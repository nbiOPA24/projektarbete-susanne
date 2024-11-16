/*public class HandleQuestions
{
    public static List<Question> wrongAnswer = new List<Question>();
   
    public static void HandleQuestionTypeMenu(List<Question> questions, string selectedSubject)
    {
        bool isRunning = true;     
        
        while(isRunning)
        {
            Console.WriteLine("---Välj vilken typ av fråga som du vill använda---");
            Console.WriteLine("1. Fritextfråga");
            Console.WriteLine("2. Flervalsfråga");
            Console.WriteLine("3. Öva på frågor där du svarat fel");
            Console.WriteLine("4. Återgå till huvudmenyn");
            Console.WriteLine("-------------------------------------------");
            string input = Console.ReadLine();
            
            if (input == "1")
            {
                Console.WriteLine("---Här svarar du med fritext---");
                AskQuestions(questions, "text");
            }

            else if(input == "2")
            {
               Console.WriteLine("---Här svarar du med flervalsalternativ---");
                AskQuestions(questions, "multi");
            }
                
            else if(input == "3")
            {
                Console.WriteLine("---Här övar du på de frågor som där du svarat fel---");
                if(wrongAnswer.Count == 0)
                {
                    System.Console.WriteLine("Inga frågor att svara på!");
                }
                else
                {
                    for(int i = 0; i < wrongAnswer.Count; i++)
                    {
                        //PracticeWrongQuestions();  
                    } 
                }
            }
            else if(input == "4")
            {
                Console.WriteLine("---Återgå till huvudmenyn---");
                break;
            }
            else
            {
                Console.WriteLine("Ogiltig inmatning");
            }
        }        
    } 
   
    /*public static void AskQuestions(List<Question> questions, string questionType)//En metod som används för att ställa frågor till användaren, oavsett typ av fråga
    {
        var rnd = new Random();
        var selectedQuestions = questions.OrderBy(q => rnd.Next()).Take(5).ToList();  //Slumpar fram 5 frågor från json-filen och lägger i variabeln selectedQuestions,. 

        foreach (var question in selectedQuestions) //En loop som körs för varje fråga i variabeln SelectedQuestions.
        {
            System.Console.WriteLine();
            Console.WriteLine($"Fråga: {question.Quest}");

            if (questionType == "multi" && question.Options.Any())
            {
                Console.WriteLine("Alternativ:");
                for (int i = 0; i < question.Options.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {question.Options[i]}");
                }

                // Användaren svarar på flervalsfrågan
                Console.WriteLine("---Ange ditt svar (nummer på alternativ)---");
                string userAnswer = Console.ReadLine();
                if (userAnswer != null && int.TryParse(userAnswer, out int selectedOption) && selectedOption >= 1 && selectedOption <= question.Options.Count)
                {
                    if (question.Options[selectedOption - 1] == question.Answer)
                    {
                        Console.WriteLine("Du svarade rätt!");
                    }
                    else
                    {
                        Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar är {question.Answer}");
                        wrongAnswer.Add(question);
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt svar.");
                }
            }
            else if (questionType == "text")
            {
                Console.Write("Skriv ditt svar:");
                string userAnswer = Console.ReadLine();
                CheckAnswer(question, userAnswer);
            }
        }
    }
    public static void CheckAnswer(Question question, string userAnswer)//En metod som används för att kontrollera om svaret är rätt eller inte
    {
        if (question.Keywords.Any(keyword => userAnswer.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Du svarade rätt!");
        }
        else
        {
            Console.WriteLine($"Ditt svar var tyvärr fel. Rätt svar är {question.Answer}");
        }
    }
    
       
}*/