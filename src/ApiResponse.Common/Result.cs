using JetBrains.Annotations;
using System;

namespace ApiResponse.Net.OperationResult
{
    /// <summary>
    /// Operation result
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Indicates that operation was succeeded
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Error object
        /// </summary>
        public Error? Error { get; set; }

        public Result()
        {
        }

        /// <summary>
        /// Creates new instance of "failed" <see cref="Result"/>
        /// </summary>
        /// <param name="error">Error object</param>
        /// <exception cref="ArgumentNullException">Throws if <para>error</para> is null</exception>
        public Result([ItemNotNull] Error error)
        {
            IsSuccess = false;
            Error = error ?? throw new ArgumentNullException(nameof(error));
        }

        public Result(int errorCode, [ItemNotNull] string message)
        {
            if (StringUtils.StringIsNullOrWhitespace(message))
                throw new ArgumentNullException(nameof(message));
            IsSuccess = false;
            Error = new Error(errorCode, message);
        }

        [NotNull]
        public static Result Ok() => new Result()
        {
            IsSuccess = true,
            Error = null
        };

        [NotNull]
        public static Result Fail() => new Result()
        {
            IsSuccess = false,
            Error = new Error(ErrorCodes.InternalError, "Internal error")
        };

        /// <summary>
        /// Creates failed result
        /// </summary>
        /// <param name="error">Error instance</param>
        /// <returns><see cref="Result"/> instance</returns>
        /// <exception cref="ArgumentNullException">if error is null</exception>
        [NotNull]
        public static Result Fail([ItemNotNull] Error error) => new Result(error);
    }
}
