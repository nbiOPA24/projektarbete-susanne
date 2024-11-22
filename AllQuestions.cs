public class AllQuestions
{
    public static List<Question> GetQuestions()
{
    return new List<Question>
    {
        new TextQuestion(Subject.SV, "Vad heter Sveriges nationalskald?", "Carl Michael Bellman", 5),
        new TextQuestion(Subject.SV, "Vilken roman av Selma Lagerlöf handlar om Nils Holgerssons resa genom Sverige?", "Nils Holgerssons underbara resa genom Sverige", 5),
        new TextQuestion(Subject.SO, "Vad heter FN:s förkortning för hållbar utveckling?", "SDG", 5),
        new TextQuestion(Subject.SO, "Vad hette den första svenska kvinnan som fick rösträtt?", "Elin Wägner", 5),
        new TextQuestion(Subject.NA, "Vad är den kemiska formeln för vatten?", "H2O", 5),
        new TextQuestion(Subject.NA, "Vilket organ i människokroppen filtrerar blod?", "Njuren", 5),
        new TextQuestion(Subject.NA, "Vad kallas läran om växter?", "Botanik", 5),
        new TextQuestion(Subject.SV, "Vilken genre används för att beskriva berättelser med drakar och magi?", "Fantasy", 5),
        new TextQuestion(Subject.SO, "Vad är Sveriges största sjö?", "Vänern", 5),
        new TextQuestion(Subject.NA, "Vad kallas processen där växter omvandlar koldioxid till syre?", "Fotosyntes", 5),
        new MultipleChoiceQuestion(Subject.SV, "Vad betyder ordet 'metafor'?", 
            new List<string> { "Bokstavligt uttryck", "Bildligt uttryck", "Framställning", "Berättelse" }, "Bildligt uttryck", 5),
        new MultipleChoiceQuestion(Subject.SV, "Vilken svensk poet skrev diktsamlingen 'Frostens barn'?", 
            new List<string> { "Carl Michael Bellman", "Esaias Tegnér", "August Strindberg", "Selma Lagerlöf" }, "Esaias Tegnér", 5),
        new MultipleChoiceQuestion(Subject.SO, "Vilken världsdel ligger Egypten i?", 
            new List<string> { "Asien", "Afrika", "Europa", "Sydamerika" }, "Afrika", 5),
        new MultipleChoiceQuestion(Subject.SO, "Vad är namnet på den gamla kinesiska muren?", 
            new List<string> { "Kinesiska muren", "Silkesvägen", "Himalaya", "Shanghai Tower" }, "Kinesiska muren", 5),
        new MultipleChoiceQuestion(Subject.NA, "Vilket grundämne har den kemiska beteckningen O?", 
            new List<string> { "Kväve", "Syre", "Väte", "Klor" }, "Syre", 5),
        new MultipleChoiceQuestion(Subject.NA, "Vad är den största planeten i solsystemet?", 
            new List<string> { "Mars", "Jupiter", "Saturnus", "Venus" }, "Jupiter", 5),
        new MultipleChoiceQuestion(Subject.SV, "Vilken typ av berättelse är 'Kalevala'?", 
            new List<string> { "Roman", "Saga", "Epos", "Novell" }, "Epos", 5),
        new MultipleChoiceQuestion(Subject.SO, "Vilken religion är störst i Indien?", 
            new List<string> { "Islam", "Buddhism", "Hinduism", "Kristendom" }, "Hinduism", 5),
        new MultipleChoiceQuestion(Subject.NA, "Vad är pH-värdet för rent vatten?", 
            new List<string> { "5", "6", "7", "8" }, "7", 5),
        new MultipleChoiceQuestion(Subject.SO, "Vilket år inträffade franska revolutionen?", 
            new List<string> { "1776", "1789", "1804", "1815" }, "1789", 5)
    };
}


}