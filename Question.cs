using System.Security.Cryptography.X509Certificates;
using System.IO; //Lägger till för att kunna hantera filinläsning av defaultfrågor

class Question
{   
    public string Subject {get; set;}
    public string Quest {get; set;}
    public string Answer {get; set;}
    public int Points {get; set;}

    public Question(string subject, string quest, string answer, int points)
    {
        Subject = subject;
        Quest = quest;
        Answer = answer;
        Points = points;      
    }
}


class HandleQuestion
{
   public List<Question> questions = new List<Question>();

     public void CreateAndAddQuestion() //Metod som skapar och lägger till frågan i listan över frågor. 

   {

        System.Console.WriteLine("Vilken typ av fråga vill du skapa?");
        System.Console.WriteLine("1. Sant/Falskt");
        System.Console.WriteLine("2. Flervalsfråga");
        System.Console.WriteLine("3. Fritextfråga");
        System.Console.WriteLine("4. Skriv ut en lista med samtliga frågor");
        string input = Console.ReadLine();

               
        switch(input)
        {
            case "1":
            System.Console.WriteLine("Sant/Falskt"); //Lägg till metod för att skapa och lägga till true/false-fråga
            break;
            
            case "2":
            System.Console.WriteLine("Flervalsfråga"); //Lägg till metod för att skapa och lägga till flervals-fråga
            break;

            case "3":
            System.Console.WriteLine("Fritextfråga"); //Lägg till metod för att skapa och lägga till fritext-fråga
            questions.Add(ShortAnswer.CreateShortAnswerQuestion());
            break;

            case "4":
            foreach(var question in questions)
            {
                Console.WriteLine($"Du har skrivit in följande frågor: {question.Subject}, {question.Quest}, {question.Answer}, {question.Points}"); 
            }
            break;

            default:
            System.Console.WriteLine("Ogiltig inmatning");
            break;
        } 
    }
    public static List<Question> LoadQuestions(string filePath) //Metod för att läsa in filen med frågor och spara i listan questions. 
    {
        List<Question> questions = new List<Question>(); 

        foreach(var line in File.ReadLines(filePath))
        {
            var parts = line.Split('|');
            if(parts.Length == 4)
            {
                string subject = parts[0];
                string quest = parts[1];
                string answer = parts[2];
                int points = int.Parse(parts[3]);

                questions.Add(new Question(subject, quest, answer, points));
            }
        }

        return questions;

    }
}


class ShortAnswer : Question
{
    List<ShortAnswer> shortAnswers = new List<ShortAnswer>();
   public ShortAnswer(string subject, string quest, string answer, int points) : base(subject, quest, answer, points) //base - refererar till basklassen
   {}

   public static ShortAnswer CreateShortAnswerQuestion()
   {
        System.Console.WriteLine("-----Skapa en ny fritextfråga-----");
        System.Console.Write("Skriv in vilket ämne som frågan hör till (SV, MA, ENG, SO, Idrott): ");
        string subject = Console.ReadLine();        
        System.Console.Write("Skriv in fråga: ");
        string question = Console.ReadLine();
        System.Console.Write("Skriv in svaret på frågan: ");
        string answer = Console.ReadLine();
        System.Console.WriteLine("Skriv in hur många poäng som frågan är värd: ");
        int points = int.Parse(Console.ReadLine());

        
        return new ShortAnswer(subject, question, answer, points);
   }


}

/*class  MultiChoice : Question
{
    public string CorrectAnswer {get; set;}
    public string WrongAnswer {get; set;}
    
    public MultiChoice(string quest, string answer, int points, string correctAnswer, string wrongAnswer) : base (quest, answer, points)
    {
        CorrectAnswer = correctAnswer;
        WrongAnswer = wrongAnswer; 
    }

}

class TrueFalse :  Question
{
    public string TrueAnswer {get; set;}
    public string FalseAnswer {get; set;}

}*/
