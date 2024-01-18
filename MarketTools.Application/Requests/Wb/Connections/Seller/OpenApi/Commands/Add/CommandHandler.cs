using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Wb.Connections.Seller.OpenApi.Commands.Add
{
    public class CommandHandler(IUnitOfWork _unitOfWork, IAuthReadHelper _authReadHelper)
        : IRequestHandler<SellerOpenApiAddCommand, MarketplaceConnectionEntity>
    {
        private readonly IRepository<WbSellerOpenApiConnectionEntity> _connectionRepository = _unitOfWork.GetRepository<WbSellerOpenApiConnectionEntity>();

        public async Task<MarketplaceConnectionEntity> Handle(SellerOpenApiAddCommand request, CancellationToken cancellationToken)
        {
            WbSellerOpenApiConnectionEntity newEntity = Create(request);

            await _connectionRepository.AddAsync(newEntity, cancellationToken);
            await _unitOfWork.CommintAsync(cancellationToken);

            return newEntity;
        }

        private WbSellerOpenApiConnectionEntity Create(SellerOpenApiAddCommand request)
        {
            return new WbSellerOpenApiConnectionEntity
            {
                IsActive = true,
                Description = request.Description,
                Name = request.Name,
                Token = request.Token,
                UserId = _authReadHelper.UserId
            };
        }
    }
}
