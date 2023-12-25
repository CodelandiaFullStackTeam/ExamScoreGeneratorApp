using ExamScoreGeneratorApp.Models;

namespace ExamScoreGeneratorApp
{
    public class ResponseResult<T> where T : class,IEntity,new()
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; }
    }

    public class CalculationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public double Data { get; set; }
    }
}
