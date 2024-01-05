﻿using ClosedXML.Excel;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Excel;
using MarketTools.Domain.Entities;
using MarketTools.Infrastructure.Excel;
using MarketTools.Infrastructure.Services.Autoresponder.Standard.Constants;
using MarketTools.Infrastructure.Services.Autoresponder.Standard.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Services.Autoresponder.Standard
{
    internal class RecommendationProductsExcelConverterService
        : ExcelBase,
        IExcelReader<StandardAutoresponderRecommendationProduct>,
        IExcelWriter<StandardAutoresponderRecommendationProduct>
    {
        public IEnumerable<StandardAutoresponderRecommendationProduct> Read(Stream stream)
        {
            try
            {
                using IXLWorkbook workbook = new XLWorkbook(stream);
                IXLWorksheet xLWorksheet = workbook.Worksheets.First();

                IEnumerable<IXLRow> useRows = xLWorksheet.RowsUsed()
                    .Skip(1);

                return ConvertFrom(useRows);
            }
            catch 
            {
                throw new AppBadRequestException("Не удалось получить данные Excel");
            }
        }

        public Stream Write(IEnumerable<StandardAutoresponderRecommendationProduct> data)
        {
            using IXLWorkbook workbook = new XLWorkbook();

            IEnumerable<ColumnDetailsDto> columnsDetail = RecommendationProductsTableConstant.Value;

            IXLWorksheet xLWorksheet = new ExcelWorkshetBuilder(workbook)
                .AddHeaders(columnsDetail)
                .SetWidth(columnsDetail)
                .SetWrapText(true)
                .Build();

            AddValues(xLWorksheet, data);

            return SaveAs(workbook);
        }

        private void AddValues(IXLWorksheet xLWorksheet, IEnumerable<StandardAutoresponderRecommendationProduct> data)
        {
            int rowPostion = 2;
            foreach (var item in data)
            {
                xLWorksheet.Cell(rowPostion, (int)RecommendationProductsColumns.FeedbackArticle).SetValue(item.FeedbackArticle);
                xLWorksheet.Cell(rowPostion, (int)RecommendationProductsColumns.FeedbackProductName).SetValue(item.FeedbackProductName);
                xLWorksheet.Cell(rowPostion, (int)RecommendationProductsColumns.RecommendationArticle).SetValue(item.RecommendationArticle);
                xLWorksheet.Cell(rowPostion, (int)RecommendationProductsColumns.RecommendationProductName).SetValue(item.RecommendationProductName);

                rowPostion += 1;
            }
        }

        private IEnumerable<StandardAutoresponderRecommendationProduct> ConvertFrom(IEnumerable<IXLRow> useRows)
        {
            return useRows.Select(x =>
            {
                return 
                new StandardAutoresponderRecommendationProduct
                {
                    FeedbackArticle = x.Cell((int)RecommendationProductsColumns.FeedbackArticle).GetText(),
                    FeedbackProductName = x.Cell((int)RecommendationProductsColumns.FeedbackProductName).GetText(),
                    RecommendationArticle = x.Cell((int)RecommendationProductsColumns.RecommendationArticle).GetText(),
                    RecommendationProductName = x.Cell((int)RecommendationProductsColumns.RecommendationProductName).GetText()
                };
            });
        }
    }

    
}