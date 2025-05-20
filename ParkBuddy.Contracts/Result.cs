namespace ParkBuddy.Contracts
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        private Result(bool isSuccess, T data, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }

        public static Result<T> Success(T data, string message)
        {
            return new(true, data, message);
        }
        public static Result<T> Failure(string message)
        {
            return new(false, default, message);
        }
    }
}
