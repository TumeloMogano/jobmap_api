namespace JobMap.API.Utilities.OperationResults
{
    public class OperationResult<T>
    {
        /// Gets or sets a value indicating whether the operation was successful.
        public bool IsSuccess { get; set; }

        /// Gets or sets a message providing details about the operation's outcome.
        /// Defaults to string.Empty.
        public string Message { get; set; } = string.Empty;

        /// Gets or sets the data returned by the operation.
        /// This property is optional and will be null or default if the operation
        /// does not return data or if it failed.
        public T? Data { get; set; }

        /// Initializes a new instance of the class.
        /// Default constructor.
        public OperationResult() { }

        protected OperationResult(bool isSuccess, string message, T? data)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }

        // Static factory methods for creating instances

        /// Creates a successful operation result with data.  
        public static OperationResult<T> Success(T data, string message = "")
        {
            return new OperationResult<T> { IsSuccess = true, Data = data, Message = message };
        }

        /// Creates a successful operation result without specific data (Data will be default).
        public static OperationResult<T> Success(string message = "")
        {
            return new OperationResult<T> { IsSuccess = true, Data = default, Message = message };
        }

        /// Creates a failed operation result.
        public static OperationResult<T> Fail(string message, T? data = default)
        {
            return new OperationResult<T> { IsSuccess = false, Message = message, Data = data };
        }
    }

    /// <summary>
    /// Represents the result of an operation, typically used when no specific data type is returned
    /// or when the data is of type object. This class inherits from <see cref="OperationResult{T}"/>
    /// with T as object.
    /// </summary>
    public class OperationResult : OperationResult<object>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationResult"/> class.
        /// </summary>
        public OperationResult() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationResult"/> class.
        /// </summary>
        /// <param name="isSuccess">Indicates if the operation was successful.</param>
        /// <param name="message">The message associated with the operation.</param>
        /// <param name="data">The data payload (object type), if any.</param>
        protected OperationResult(bool isSuccess, string message, object? data = null)
            : base(isSuccess, message, data) { }


        // Static factory methods for the non-generic OperationResult

        /// <summary>
        /// Creates a successful operation result.
        /// </summary>
        /// <param name="message">An optional success message.</param>
        /// <returns>A new successful <see cref="OperationResult"/> instance.</returns>
        public static OperationResult Success(string message = "")
        {
            return new OperationResult(true, message, null);
        }

        /// <summary>
        /// Creates a successful operation result with data of type object.
        /// </summary>
        /// <param name="data">The data to return (as object).</param>
        /// <param name="message">An optional success message.</param>
        /// <returns>A new successful <see cref="OperationResult"/> instance.</returns>
        public static OperationResult Success(object data, string message = "")
        {
            return new OperationResult(true, message, data);
        }

        /// <summary>
        /// Creates a failed operation result.
        /// </summary>
        /// <param name="message">The failure message.</param>
        /// <returns>A new failed <see cref="OperationResult"/> instance.</returns>
        public static OperationResult Fail(string message)
        {
            return new OperationResult(false, message, null);
        }

        /// <summary>
        /// Creates a failed operation result with data of type object.
        /// </summary>
        /// <param name="message">The failure message.</param>
        /// <param name="data">Optional data to include with the failure (as object).</param>
        /// <returns>A new failed <see cref="OperationResult"/> instance.</returns>
        public static OperationResult Fail(string message, object? data)
        {
            return new OperationResult(false, message, data);
        }

    }
}
