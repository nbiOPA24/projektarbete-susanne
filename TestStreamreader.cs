class TestaStreamReader
{
    public static void TestaSR(HandleQuestion handleQuestion)
    {
        try
        {
            using (StreamReader sr = new StreamReader("HårdkodadeFrågor.txt"))
            {
                string line;

                while ((line =sr.ReadLine()) !=null)
                {
                    var parts =line.Split("|");  

                    if (parts.Length ==4)
                    {
                        string subject = parts[0].Trim();
                        string questionText = parts[1].Trim();
                        string answer = parts[2].Trim();
                        int points = int.Parse(parts[3].Trim());

                        Question newQuestion = new Question(subject, questionText, answer, points);
                        handleQuestion.questions.Add(newQuestion);
                    }               
                }
            }
        }
        
        catch (Exception e)
        {
            System.Console.WriteLine("Filen kunde inte läsas in");
            System.Console.WriteLine(e.Message);
        }
    }

}