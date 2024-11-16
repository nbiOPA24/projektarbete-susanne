using System.Text.Json;


public class Question
{
    //public string Name {get; set;}
    public string Subject {get; set;}
    public string Quest {get; set;}
    public string Answer {get; set;}
    public int Points {get; set;}
    public List<string> Options {get; set;} = new List<string>();
    public List<string> Keywords {get; set;} = new List<string>();
    
    
}//Klass som innehåller metod för inläsning av Json-filen till programmet samt delar upp json-objekten till motsvarande objekt i klassen Question
public class LoadFile //Döper om klassen till LoadFile, eftersom jag vill kunna ladda olika typer av frågefiler till mitt program, och LoadfFile är ett mer generiskt namn på 
{    
    public static List<Question> LoadAllQuestions(string filePath) //Metod för inläsning av Json-filen.Ändrar från asynkton till synkron inläsning av filen. Då filen är liten behövs inte någon asynkron inläsning. 
    {
        string jsonText = File.ReadAllText(filePath);
        
       
        var allQuestions = JsonSerializer.Deserialize<List<Question>>(jsonText); // Deserialiserar JSON-texten till en lista av Question-objekt, där de olika json-objekten kan matchas med objekten i klassen Question.       

        return allQuestions;
    }
}

//Klass som läser in frågor från json-filen samt dess tillhörande options(flervalsfrågor)
public class MultipleChoiceQuestion : Question
{
    public List<string> Options {get; set;}
    
}
//Klass som läser in frågor från json-filen sam dess tillhörande Keywords. Keywords gör att användaren kan få rätt även om användaren inte skriver exakt samma mening som i Answer. 
public class TextQuestion : Question
{
    public List<string> Keywords {get; set;}

}
//Klass som läser in frågor från json-filen samt dess tillhöraden True/False-alternativ. EJ PÅBÖRJAT!
public class TrueFalseQuestion : Question //Ej påbörjad
{
    public List<string> TrueFalse {get; set;}
}


