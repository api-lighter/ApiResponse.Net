namespace ApiResponse.Common
{
    public static class StringUtils
    {
        public static bool StringIsNullOrWhitespace(string stringValue)
        {
            return string.IsNullOrEmpty(stringValue) || string.IsNullOrWhiteSpace(stringValue);
        }
    }
}