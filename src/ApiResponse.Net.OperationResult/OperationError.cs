using JetBrains.Annotations;

namespace ApiResponse.Net.OperationResult
{
    public class OperationErrorRecord
    {
        public ErrorCode Code { get; set; }
        public string? Message { get; set; }
    }

    public class OperationError
    {
        public OperationErrorRecord[] Records { get; set; } = new OperationErrorRecord[0];
    }
}