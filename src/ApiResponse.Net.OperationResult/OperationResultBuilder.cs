using System;

namespace ApiResponse.Net.OperationResult
{
    public static class OperationResultBuilder
    {
        public static OperationResult<T> Success<T>(T value)
        {
            return new OperationResult<T>
            {
                Success = true,
                Result = value
            };
        }

        public static OperationResult<T> Success<T>(T value, string operationId)
        {
            if (string.IsNullOrEmpty(operationId))
                throw new ArgumentNullException(nameof(operationId));

            return new OperationResult<T> { Result = value, Id = operationId, Success = true };
        }

        public static OperationResult<T> Failed<T>(ErrorCode code)
        {
            return new OperationResult<T>
            {
                Success = false,
                Error = OperationErrorBuilder.BuildOperationError(code)
            };
        }

        public static OperationResult<T> Failed<T>(ErrorCode code, string message)
        {
            return new OperationResult<T>
            {
                Success = false,
                Error = OperationErrorBuilder.BuildOperationError(code, message)
            };
        }

        public static OperationResult<T> Failed<T>(ErrorCode code, string message, string operationId)
        {
            return new OperationResult<T>
            {
                Success = false,
                Error = OperationErrorBuilder.BuildOperationError(code, message),
                Id = operationId
            };
        }

        public static OperationResult<T> Failed<T>(ErrorCode code, string message, string resourceId, string operationId)
        {
            if (string.IsNullOrEmpty(operationId) && string.IsNullOrEmpty(resourceId))
                throw new ArgumentException($"Arguments {nameof(operationId)} and {nameof(resourceId)} cannot be null or empty");
            if (string.IsNullOrEmpty(operationId))
                throw new ArgumentNullException(nameof(operationId));
            if (string.IsNullOrEmpty(resourceId))
                throw new ArgumentNullException(nameof(resourceId));

            return new OperationResult<T>
            {
                Success = false,
                Error = OperationErrorBuilder.BuildOperationError(code, $"Error for resource - {resourceId}: {message}"),
                Id = operationId
            };
        }

        public static OperationResult<T> NotFound<T>()
        {
            return Failed<T>(ErrorCode.NotFound);
        }

        public static OperationResult<T> NotFound<T>(string operationId)
        {
            return Failed<T>(ErrorCode.NotFound, OperationErrorBuilder.ResourceNotFoundErrorMessage, operationId);
        }

        public static OperationResult<T> NotFound<T>(string resourceId, string operationId)
        {
            return Failed<T>(ErrorCode.NotFound, OperationErrorBuilder.ResourceNotFoundErrorMessage, resourceId, operationId);
        }

        public static OperationResult<T> ResourceBusy<T>()
        {
            return Failed<T>(ErrorCode.ResourceBusy);
        }

        public static OperationResult<T> ResourceBusy<T>(string operationId)
        {
            return Failed<T>(ErrorCode.ResourceBusy, OperationErrorBuilder.ResourceBusyErrorMessage, operationId);
        }

        public static OperationResult<T> ResourceBusy<T>(string resourceId, string operationId)
        {
            return Failed<T>(ErrorCode.ResourceBusy, OperationErrorBuilder.ResourceBusyErrorMessage, resourceId, operationId);
        }

        public static OperationResult<T> ResourceAccessDenied<T>()
        {
            return Failed<T>(ErrorCode.AccessDenied);
        }

        public static OperationResult<T> ResourceAccessDenied<T>(string operationId)
        {
            return Failed<T>(ErrorCode.AccessDenied, OperationErrorBuilder.ResourceDeniedErrorMessage, operationId);
        }

        public static OperationResult<T> ResourceAccessDenied<T>(string resourceId, string operationId)
        {
            return Failed<T>(ErrorCode.AccessDenied, OperationErrorBuilder.ResourceDeniedErrorMessage, resourceId, operationId);
        }
    }
}
