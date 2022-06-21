namespace ApiResponse.Net.OperationResult
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public OperationError? Error { get; set; }
        public string? Id { get; set; }
    }

    public class OperationResult<T> : OperationResult
    {
        public T? Result { get; set; }
    }
}
