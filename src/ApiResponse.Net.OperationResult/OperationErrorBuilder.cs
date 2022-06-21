using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiResponse.Net.OperationResult
{
    internal static class OperationErrorBuilder
    {
        public const string ResourceDeniedErrorMessage = "Access to resource is denied";
        public const string ResourceBusyErrorMessage = "Resource is busy";
        public const string ResourceNotFoundErrorMessage = "Resource was not found";
        public const string ResourceInternalErrorMessage = "Internal error";

        public static OperationError BuildOperationError(Exception ex)
        {
            return new OperationError
            {
                Records = new[]
                {
                    BuildRecord(ex)
                }
            };
        }

        public static OperationError BuildOperationError(params ErrorCode[] code)
        {
            var operationErrorRecords = code.Select(c => BuildRecord(c));
            return new OperationError
            {
                Records = operationErrorRecords.ToArray()
            };
        }

        public static OperationError BuildOperationError(ErrorCode code, string errorMessage)
        {
            return new OperationError
            {
                Records = new[]
                {
                    BuildRecord(code, errorMessage)
                }
            };
        }

        private static OperationErrorRecord BuildRecord(ErrorCode code)
        {
            switch (code)
            {
                case ErrorCode.AccessDenied:
                    return BuildRecord(code, ResourceDeniedErrorMessage);
                case ErrorCode.ResourceBusy:
                    return BuildRecord(code, ResourceBusyErrorMessage);
                case ErrorCode.NotFound:
                    return BuildRecord(code, ResourceNotFoundErrorMessage);
                default:
                    return BuildRecord(code, ResourceInternalErrorMessage);
            }
        }

        public static OperationErrorRecord BuildRecord(Exception ex)
        {
            return BuildRecord(ErrorCode.InternalError, ex.Message);
        }

        private static OperationErrorRecord BuildRecord(ErrorCode code, string errorMessage)
        {
            if (string.IsNullOrEmpty(errorMessage))
                throw new ArgumentException($"Argument {nameof(errorMessage)} cannot be null or empty");

            return new OperationErrorRecord
            {
                Code = code,
                Message = errorMessage
            };
        }
    }
}
