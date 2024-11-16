

//Klassen innehåller en meny för quiz - KLART
//Klassen samordnar alla svar som användaren har gett?
public class HandleQuiz
{
    //Metoden filtrerar listan med frågor utifrån ämne (subject) och returnerar en lista med valt ämne (subject)
    public static List<Question> FilterQuestionsBySubject(List<Question> questions, string subject)
    {
        return questions.FindAll(q => q.Subject == subject);
    }   
        

    public static void ChooseQuestionMenu()
    {
        bool isRunning = true;

        while(isRunning)
        {
            Console.WriteLine("---Välj vilken typ av frågor du vill besvara---");
            System.Console.WriteLine("______________________________________");
            Console.WriteLine("1. Öva med fritextfrågor");
            Console.WriteLine("2. Öva med flervalsfrågor");
            Console.WriteLine("4. Öva på de frågor som du svarat fel på");
            Console.WriteLine("4. Återgå till huvudmenyn");
            Console.WriteLine("_______________________________________________");
            string input = Console.ReadLine();

            switch(input)
            {
                case "1":
                Console.WriteLine("Öva med fritextfrågor");
                break;

                case "2":
                Console.WriteLine("Öva med flervalsfrågor");
                break;

                case "3":
                Console.WriteLine("Öva på de frågor där du svarat fel");
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
