using System.ComponentModel;

namespace ApiResponse.Net.OperationResult
{
    /// <summary>
    /// Error codes definition
    /// </summary>
    public enum ErrorCode
    {
        [Description("Critical internal error")]
        InternalError = 0x0100,

        [Description("Not found resource")]
        NotFound = 0x0200,

        [Description("Access denied to resources")]
        AccessDenied = 0x0300,

        [Description("Resource is busy")]
        ResourceBusy = 0x0400,

        [Description("Invalid params passed")]
        InvalidParams = 0x0500
    }
}