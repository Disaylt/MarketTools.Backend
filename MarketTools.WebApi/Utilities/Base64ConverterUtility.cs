namespace MarketTools.WebApi.Utilities
{
    public static class Base64ConverterUtility
    {
        public static string FromStream(Stream stream)
        {
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);

            return Convert.ToBase64String(buffer);
        }
    }
}
