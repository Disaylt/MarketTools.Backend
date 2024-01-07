using MarketTools.Application.Interfaces.Excel;

namespace MarketTools.WebApi.Extensions
{
    public static class ExcelExtensions
    {
        public static IEnumerable<T> Read<T>(this IExcelReader<T> excelReader, IFormFile stream) where T : class
        {
            return excelReader.Read(stream.OpenReadStream());
        }
    }
}
