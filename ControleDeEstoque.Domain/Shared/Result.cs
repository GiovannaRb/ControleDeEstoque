namespace ControleDeEstoque.Domain.Shared
{
    public class Result
    {
        public bool IsSuccess { get; }
        public string Message { get; }

        protected Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public static Result Success(string message = "")
            => new Result(true, message);

        public static Result Failure(string message)
            => new Result(false, message);
    }

    public class Result<T> : Result
    {
        public T? Value { get; }

        protected Result(bool isSuccess, T? value, string message)
            : base(isSuccess, message)
        {
            Value = value;
        }

        public static Result<T> Success(T value, string message = "")
            => new Result<T>(true, value, message);

        public static new Result<T> Failure(string message)
            => new Result<T>(false, default, message);
    }
}
