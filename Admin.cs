class Admin
{
    private HandleQuestion handleQuestion = new HandleQuestion(); //Skapar en instans för att kunna hantera frågor från klassen HandleQuestion!
    

    public void CreateNewQuestion() //Ny metod i adminklassen, för att kunna skapa nya frågor
    {
        handleQuestion.CreateAndAddQuestion();
    }

    public void ShowQuestions() //En metod för att kunna se samtliga frågor
    {

    }

}

