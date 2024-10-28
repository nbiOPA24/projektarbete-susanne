using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Admin
{
    private readonly HandleDefaultQuestions questionHandler;

    public Admin(string filePath)
    {
        questionHandler = new HandleDefaultQuestions(filePath);
    }
    public async Task DisplayQuestionsAsync()
    {
        List<DefaultQuestion> defaultQuestions = await questionHandler.ReadQuestionsAsync();

        Console.WriteLine("Frågor från JSON-filen:");
        foreach (var q in defaultQuestions)
        {
            Console.WriteLine($"Fråga: {q.Text}, Svar: {q.Answer}, Svårighetsgrad: {q.Difficulty}");
        }
    }

}
