using OkalaChallenge.Data.Models.InterviewResponse;
using System.Text.Json;

namespace OkalaChallenge.Data.Services
{
    public class TechnicalQuestionsService
    {
        public string GetTechnicalQuestionsResult() {
            var response = new TechnicalQuestions
            {
                Q1 = new Question1
                {
                    TimeSpent = "1 day and half",
                    Improvements = "i'm not sure, maybe more details about the city, for example Area, Population"
                },
                Q2 = new Question2
                {
                    Feature = "upload and download image to the api",
                    CodeDemo = "i can share it via github or source code of project through whats app"
                },
                Q3 = new Question3
                {
                    Answer = "i did not use them but i know i must use profiler tools"
                },
                Q4 = new Question4
                {
                    LastReadOrAttended = "Data structure, Algorithm design and Software Engineering",
                    Learned = @"Data structure: lists, Queue, Arrays, Graph, Tree, Stack, Linked list etc.Algorithm design: design methods like Divide and Conquer or Greedy Method etc."
                },
                Opinion = "i've learned some technical things like tests and OpenWeatherMap website apis because i had no exprience in them before," +
                " its great to see if i dont know something try to learn it."
            };

            
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            return JsonSerializer.Serialize(response, options);
        }
    }
} 