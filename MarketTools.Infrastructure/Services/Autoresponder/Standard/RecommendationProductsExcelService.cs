using ClosedXML.Excel;
using MarketTools.Application.Interfaces.Excel;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Services.Autoresponder.Standard
{
    internal class RecommendationProductsExcelService
        : IExcelReader<StandardAutoresponderRecommendationProduct>,
        IExcelWriter<StandardAutoresponderRecommendationProduct>
    {
        public IEnumerable<StandardAutoresponderRecommendationProduct> Read(Stream stream)
        {
            try
            {
                using (IXLWorkbook workbook = new XLWorkbook(stream))
                {

                }
            }
            catch 
            {
                throw new 
            }
        }

        public Stream Read(IEnumerable<StandardAutoresponderRecommendationProduct> data)
        {
            throw new NotImplementedException();
        }
    }
}
