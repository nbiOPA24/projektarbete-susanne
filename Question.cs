using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

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








