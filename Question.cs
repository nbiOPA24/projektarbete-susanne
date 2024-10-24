using System.Security.Cryptography.X509Certificates;

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

            default:
            System.Console.WriteLine("Ogiltig inmatning");
            break;
        } 

        
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
        System.Console.Write("Skriv in vilket ämne som frågan hör till (SV, MA, ENG, SO, Idrott)");
        string subject = Console.ReadLine();        
        System.Console.Write("Skriv in fråga: ");
        string question = Console.ReadLine();
        System.Console.Write("Skriv in svaret på frågan: ");
        string answer = Console.ReadLine();
        System.Console.WriteLine("Skriv in hur många poäng som frågan är värd");
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
