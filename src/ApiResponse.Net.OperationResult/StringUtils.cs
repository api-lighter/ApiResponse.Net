namespace ApiResponse.Net.OperationResult
{
    public static class StringUtils
    {
        public static bool StringIsNullOrWhitespace(string stringValue)
        {
            return string.IsNullOrEmpty(stringValue) || string.IsNullOrWhiteSpace(stringValue);
        }
    }
}