namespace Fundamentals.Utilities.Results
{
    public class Result : IResult
    {
        public bool Success { get; }

        public string Message { get; }
    }
}