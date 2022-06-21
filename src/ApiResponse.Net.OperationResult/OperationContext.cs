using System;

namespace ApiResponse.Net.OperationResult
{
    public class OperationContext
    {
        public Guid RequestId { get; set; } = Guid.NewGuid();
    }
}
