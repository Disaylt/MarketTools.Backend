using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Excel;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.RecommendationProducts.Queries.GetExcel
{
    public class QueryHandler(IAuthUnitOfWork _authUnitOfWork,
        IExcelWriter<StandardAutoresponderRecommendationProduct> _excelWriter)
        : IRequestHandler<GetExcelQuery, Stream>
    {
        private readonly IAuthRepository<StandardAutoresponderRecommendationProduct> _repository = _authUnitOfWork.StandardAutoresponderRecommendationProducts;

        public async Task<Stream> Handle(GetExcelQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<StandardAutoresponderRecommendationProduct> entities = await GetEntitiesAsync(request, cancellationToken);

            return _excelWriter.Write(entities);
        }

        private async Task<IEnumerable<StandardAutoresponderRecommendationProduct>> GetEntitiesAsync(GetExcelQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetRangeAsync(x => x.MarketplaceName == request.MarketplaceName, cancellationToken);
        }
    }
}
