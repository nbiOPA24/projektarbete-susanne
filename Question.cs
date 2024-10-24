class Question
{
   
    string Subject {get; set;}
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

    public static Question MakeQuestion() //En metod som skapar en ny fråga, svar och dess poäng OBS!!! Utöka med while-loop, om man vill lägga till ytterligare frågor!
    {
        System.Console.WriteLine("Vilken typ av fråga vill du skapa?");
        System.Console.WriteLine("1. Sant/Falskt");
        System.Console.WriteLine("2. Flervalsfråga");
        System.Console.WriteLine("3. Fritextfråga");
        string input = Console.ReadLine();

        switch(input)
        {
            case "1":
            System.Console.WriteLine("Sant/Falskt");
            break;
            
            case "2":
            System.Console.WriteLine("Flervalsfråga");
            break;

            case "3":
            System.Console.WriteLine("Fritextfråga");
            break;
        }


        System.Console.WriteLine("Till vilket ämne hör frågan?");
        string subject = Console.ReadLine();
        System.Console.Write("Skriv in frågan: ");
        string question = Console.ReadLine();
        System.Console.Write("Skriv in svaret på frågan: ");
        string answer = Console.ReadLine();
        System.Console.WriteLine("Hur många poäng ska frågan ge?");
        int points = int.Parse(Console.ReadLine());
      

        return new Question(subject, question, answer, points); //Returnerar en instans av ny fråga.      
    }
}

class HandleQuestion
{
   public List<Question> questions = new List<Question>();

   public void AddQuestion(Question question) //Metod som lägger till fråga i listan äver frågor
   {
    questions.Add(question);
   }

   public void CreateAndAddQuestion() //Metod som skapar och lägger till frågan i listan över frågor. 
   {
    Question newQuestion = Question.MakeQuestion(); //Anropar funktionen för att skapa frågor, som finns i klassen Question
   }
}


/*class  MultiChoice : Question
{
    public string RightAnswer {get; set;}
    public string WrongAnswer {get; set;}
    
    public MultiChoice(string quest, string answer, int points, string rightAnswer, string wrongAnswer) : base (quest, answer, points)
    {
        RightAnswer = rightAnswer;
        WrongAnswer = wrongAnswer; 
    }

}

class TrueFalse :  Question
{
    public string TrueAnswer {get; set;}
    public string FalseAnswer {get; set;}

}

class ShortAnswer : Question
{

}*/