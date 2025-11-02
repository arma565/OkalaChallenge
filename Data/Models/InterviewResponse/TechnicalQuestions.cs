using System.Text.Json.Serialization;

namespace OkalaChallenge.Data.Models.InterviewResponse
{
    public class TechnicalQuestions
    {
        [JsonPropertyName("1")]
        public Question1 Q1 { get; set; } = new();

        [JsonPropertyName("2")]
        public Question2 Q2 { get; set; } = new();

        [JsonPropertyName("3")]
        public Question3 Q3 { get; set; } = new();

        [JsonPropertyName("4")]
        public Question4 Q4 { get; set; } = new();

        [JsonPropertyName("opinion")]
        public string Opinion { get; set; } = "";
    }

    public class Question1
    {
        public string TimeSpent { get; set; } = "";
        public string Improvements { get; set; } = "";
    }

    public class Question2
    {
        public string Feature { get; set; } = "";
        public string CodeDemo { get; set; } = "";
    }

    public class Question3
    {
        public string Answer { get; set; } = "";
    }

    public class Question4
    {
        public string LastReadOrAttended { get; set; } = "";
        public string Learned { get; set; } = "";
    }
}
