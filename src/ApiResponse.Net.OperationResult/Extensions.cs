using Microsoft.Extensions.DependencyInjection;

namespace ApiResponse.Net.OperationResult
{
    public static class Extensions
    {
        public static OperationResult<T> Success<T>(this T instance)
        {
            return OperationResultBuilder.Success<T>(instance);
        }

        public static OperationResult<T> Success<T>(this T instance, string operationId)
        {
            return OperationResultBuilder.Success<T>(instance, operationId);
        }

        public static OperationResult<T> Failed<T>(this T instance, ErrorCode code)
        {
            return OperationResultBuilder.Failed<T>(code);
        }

        public static OperationResult<T> Failed<T>(this T instance, ErrorCode code, string message)
        {
            return OperationResultBuilder.Failed<T>(code, message);
        }

        public static OperationResult<T> Failed<T>(this T instance, ErrorCode code, string message, string opertationId)
        {
            return OperationResultBuilder.Failed<T>(code, message, opertationId);
        }

        public static OperationResult<T> Failed<T>(this T instance, ErrorCode code, string message, string resourceId, string opertationId)
        {
            return OperationResultBuilder.Failed<T>(code, message, resourceId, opertationId);
        }

        public static OperationResult<T> NotFound<T>(this T instance)
        {
            return OperationResultBuilder.NotFound<T>();
        }

        public static OperationResult<T> NotFound<T>(this T instance, string opertationId)
        {
            return OperationResultBuilder.NotFound<T>(opertationId);
        }

        public static OperationResult<T> NotFound<T>(this T instance, string resourceId, string opertationId)
        {
            return OperationResultBuilder.NotFound<T>(resourceId, opertationId);
        }

        public static OperationResult<T> ResourceAccessDenied<T>(this T instance)
        {
            return OperationResultBuilder.ResourceAccessDenied<T>();
        }

        public static OperationResult<T> ResourceAccessDenied<T>(this T instance, string opertationId)
        {
            return OperationResultBuilder.ResourceAccessDenied<T>(opertationId);
        }

        public static OperationResult<T> ResourceAccessDenied<T>(this T instance, string resourceId, string opertationId)
        {
            return OperationResultBuilder.ResourceAccessDenied<T>(resourceId, opertationId);
        }

        public static OperationResult<T> ResourceBusy<T>(this T instance)
        {
            return OperationResultBuilder.ResourceBusy<T>();
        }

        public static OperationResult<T> ResourceBusy<T>(this T instance, string opertationId)
        {
            return OperationResultBuilder.ResourceBusy<T>(opertationId);
        }

        public static OperationResult<T> ResourceBusy<T>(this T instance, string resourceId, string opertationId)
        {
            return OperationResultBuilder.ResourceBusy<T>(resourceId, opertationId);
        }

        public static IServiceCollection AddOperationContext(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddScoped(provider => new OperationContext());
        }
    }
}
