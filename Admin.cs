class Adminklass
{
    static void ShowAllQuestions(List<Question> questions)//Ska flyttas till amdin-klassen!!!
    {
        foreach(var question in questions)
        {
            System.Console.WriteLine($"Ämne: {question.Subject}, Fråga: {question.Quest}, Svar: {question.Answer}, Poäng: {question.Points} ");
        }
    }
}