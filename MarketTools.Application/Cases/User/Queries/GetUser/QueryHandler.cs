using AutoMapper;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.User.Queries.GetUser
{
    public class QueryHandler(UserManager<AppIdentityUser> _userManager, 
        IAuthReadHelper _authReadHelper,
        IMapper _mapper) 
        : IRequestHandler<GetUserQuery, UserVm>
    {
        public async Task<UserVm> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            AppIdentityUser appIdentityUser = await _userManager.FindByIdAsync(_authReadHelper.UserId) 
                ?? throw new DefaultNotFoundException();

            UserVm userVm = _mapper.Map<UserVm>(appIdentityUser);

            return userVm;
        }
    }
}
