using System.Reflection.Metadata.Ecma335;

namespace MyCleanArchitecture.Application.Common.Models
{
    public class Result<T>
    {
        public bool Success { get; private set; }
        public T? Data { get; private set; }
        public IReadOnlyCollection<ErrorResult> Errors { get; private set; }

        public static Result<T> SuccessResult(T data) => new() { Success = true, Data = data };
        public static Result<T> Failure(string error)
        {
            var errors = new List<ErrorResult>
            {
                new ErrorResult
                {
                    ErrorMessage = error
                }
            };

            return new Result<T> { Success = false, Errors = errors };
        }

        public static Result<T> Failure(List<ErrorResult> errors)
        {
            return new Result<T>
            {
                Success = false,
                Errors = errors
            };
        }

        // Защищаем конструктор, чтобы обеспечить использование только через фабричные методы
        protected Result() { }
    }

    public record class ErrorResult
    {
        public string? Key { get; init; }

        public required string ErrorMessage { get; init; }
    }
}