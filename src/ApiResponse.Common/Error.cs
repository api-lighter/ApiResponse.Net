using JetBrains.Annotations;

namespace ApiResponse.Common
{
    /// <summary>
    /// Simple error class
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Error()
        {
            ErrorCode = ErrorCodes.Ok;
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="errorCode">Inner error code</param>
        /// <param name="message">Error message</param>
        public Error(int errorCode, [ItemNotNull] string message)
        {
            ErrorCode = errorCode;
            Message = message;
        }

        /// <summary>
        /// Error code.
        /// Some error codes hardcoded in <see cref="ErrorCodes"/>
        /// </summary>
        public int ErrorCode { get; set; }
        
        /// <summary>
        /// Error message
        /// </summary>
        [NotNull]
        public string? Message { get; set; }
    }
}