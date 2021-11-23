using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiResponse.Common
{
    public class ValueResult<T> : Result
    {
        /// <summary>
        /// Result value
        /// </summary>
        public T? Value { get; set; }

        public static ValueResult<T> Ok([ItemCanBeNull] T? value) => new ValueResult<T>
        {
            IsSuccess = true,
            Value = value
        };

        [NotNull]
        public static new ValueResult<T> Fail([ItemNotNull] Error error) => new ValueResult<T> { IsSuccess = false, Error = error };

        public static ValueResult<T> Fail(int errorCode, [ItemNotNull] string message)
        {
            if(StringUtils.StringIsNullOrWhitespace(message))
                throw new ArgumentNullException(nameof(message));

            return new ValueResult<T>
            {
                IsSuccess = false,
                Error = new Error(errorCode, message)
            };
        }
    }
}
