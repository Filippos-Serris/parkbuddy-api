namespace ParkBuddy.Contracts.Common;

/// <summary>
/// A generic class to represent the result of an operation, including success status, message, and data.
/// </summary>
/// <typeparam name="T">The type of data contained in the result.</typeparam>
public sealed class Result<T>
{
    /// <summary>
    /// Gets a value indicating whether indicates whether the operation was successful or not.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Gets a message providing additional information about the result.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Gets the data associated with the result. This can be any type of data relevant to the operation's outcome.
    /// </summary>
    public T Data { get; }

    /// <summary>
    /// Gets a collection of error messages associated with the result.
    /// </summary>
    public IReadOnlyCollection<string> Errors { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{T}"/> class with the specified success status, data, and message.
    /// </summary>
    /// <param name="isSuccess">Success indicator.</param>
    /// <param name="data">Data to be set in the result.</param>
    /// <param name="message">Message to be set in the result.</param>
    /// <param name="errors">Errors to be set in the result.</param>
    private Result(bool isSuccess, T data, string message, IReadOnlyCollection<string> errors)
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
        Errors = errors;
    }

    /// <summary>
    /// Creates a successful result with the specified data and message.
    /// </summary>
    /// <param name="data">The data to be set in the successful result.</param>
    /// <param name="message">The message to be set in the successful result.</param>
    /// <returns>A new instance of <see cref="Result{T}"/> representing a successful operation.</returns>
    public static Result<T> Success(T data, string message)
    {
        return new(true, data, message, Array.Empty<string>());
    }

    /// <summary>
    /// Creates a failure result with the specified message. The data will be set to the default value of type T.
    /// </summary>
    /// <param name="message">The message to be set in the failure result.</param>
    /// <param name="errors">The errors to be set in the failure result.</param>
    /// <returns>A new instance of <see cref="Result{T}"/> representing a failed operation.</returns>
    public static Result<T> Failure(string message, IReadOnlyCollection<string> errors = null)
    {
        return new(false, default, message, errors ?? Array.Empty<string>());
    }

    // to be reviewed
    // public enum ErrorType
    // {
    //     Validation,
    //     NotFound,
    //     Conflict
    // }

}
