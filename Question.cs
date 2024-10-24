class Question
{
    public string Quest {get; set;}
    public string Answer {get; set;}
    public int Points {get; set;}

    public Question(string quest, string answer, int points)
    {
        Quest = quest;
        Answer = answer;
        Points = points;
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