
//Klassen innehåller en meny för quiz - KLART
//Klassen samordnar alla svar som användaren har gett?

using System.Reflection;

public class HandleQuiz
{   
    public static List<Question> FilterQuestionsBySubject(List<Question> questions, string subject)
    {
        return questions.Where(q => q.SubjectType.ToString() == subject).ToList();
    }

    public static void ChooseQuestionMenu(List<Question> questions, string selectedSubject, User currentUser )
    {
        
              
        bool isRunning = true;

        while(isRunning)
        {
            Console.WriteLine("---Välj vilken typ av frågor du vill besvara---");
            Console.WriteLine("______________________________________");
            Console.WriteLine("1. Öva med fritextfrågor");
            Console.WriteLine("2. Öva med flervalsfrågor");
            Console.WriteLine("3. Öva på de frågor som du svarat fel på");
            Console.WriteLine("4. Återgå till huvudmenyn");
            Console.WriteLine("_______________________________________________");
            string input = Console.ReadLine();
            

            switch(input)
            {
                case "1":
                Console.WriteLine("Öva med fritextfrågor");
                var TextQuestion = questions.OfType<TextQuestion>().ToList();
                if(TextQuestion.Count > 0)
                {
                    foreach(var question in TextQuestion)
                    {
                        question.AskQuestion(currentUser);
                    }
                }
                else
                {
                    Console.WriteLine("Inga textfrågor hittades. ");
                }              
                break;

                case "2":
                Console.WriteLine("Öva med flervalsfrågor");
                var MultipleChoiceQuestion = questions.OfType<MultipleChoiceQuestion>().ToList();
                if(MultipleChoiceQuestion.Count > 0)
                {
                    foreach(var question in MultipleChoiceQuestion)
                    {
                        question.AskQuestion(currentUser);
                    }
                }
                break;

                case "3":
                Console.WriteLine("Öva på de frågor där du svarat fel");
                currentUser.PracticeWrongAnswers();
                break;

                case "4":
                Console.WriteLine("Återgår till huvumednyn");
                isRunning = false;
                break;

                default:
                Console.WriteLine("Felaktig inmatning.");
                break;
            }
            
        }

    }
   

}
