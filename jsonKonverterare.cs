
using System.Text.Json;
using System.Text.Json.Serialization;
//OBS! Koden in denna fil är INTE min utan kopierad rakt från chatGPT pga fick inte json-filen att deserialiseras på rätt sätt,
//och prioriterade att få programmet att funka överhuvudtaget eftr lagt orimligt mycket tid på att själv försöka få det att funka. 


public class QuestionTypeConverter : JsonConverter<QuestionType>
{
    public override QuestionType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string type = reader.GetString();
        
        // Kontrollera om det är fritext eller flerval
        return type switch
        {
            "fritext" => QuestionType.Text,
            "flerval" => QuestionType.MultipleChoice,
            _ => throw new JsonException($"Ogiltig frågetyp: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, QuestionType value, JsonSerializerOptions options)
    {
        string type = value switch
        {
            QuestionType.Text => "fritext",
            QuestionType.MultipleChoice => "flerval",
            _ => throw new JsonException($"Ogiltig frågetyp: {value}")
        };
        writer.WriteStringValue(type);
    }
}

