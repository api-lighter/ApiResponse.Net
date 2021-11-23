using System;
using JetBrains.Annotations;

namespace ApiResponse.Common
{
    /// <summary>
    /// <see cref="Result"/> extensions
    /// </summary>
    public static class ResultUtils
    {
        public static Result NotFound()
        {
            return new Result
            {
                IsSuccess = false,
                Error = new Error(ErrorCodes.NotFound, "Not found")
            };
        }

        public static Result NotFound([ItemNotNull] string item, [ItemNotNull] string collection)
        {
            if (StringUtils.StringIsNullOrWhitespace(item))
                throw new ArgumentNullException(nameof(item));
            if (StringUtils.StringIsNullOrWhitespace(collection))
                throw new ArgumentNullException(nameof(collection));
            
            return new Result
            {
                IsSuccess = false,
                Error = new Error(ErrorCodes.NotFound, $"Iitem {item} was not found in {collection}")
            };
        }
    }
}