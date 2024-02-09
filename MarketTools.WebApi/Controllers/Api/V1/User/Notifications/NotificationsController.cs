using AutoMapper;
using MarketTools.Application.Requests.UserNotifications.Commands.ReadAll;
using MarketTools.Application.Requests.UserNotifications.Models;
using MarketTools.Application.Requests.UserNotifications.Queries.Count;
using MarketTools.Application.Requests.UserNotifications.Queries.GetRange;
using MarketTools.Domain.Common;
using MarketTools.WebApi.Models.Api.User.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTools.WebApi.Controllers.Api.V1.User.Notifications
{
    [Route("api/v1/user/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationsController(IMediator _mediator)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetRageAsync([FromQuery] GetRangeNotificationsQueryDto queryHttp)
        {
            GetRangeNotificationsQuery getRangeNotificationsQuery = CreateRequestQuery(queryHttp);
            IEnumerable<UserNotificationVm> notifications = await _mediator.Send(getRangeNotificationsQuery);
            int total = await CountAsync(queryHttp.IsRead);

            PageResult<UserNotificationVm> pageResult = new PageResult<UserNotificationVm>(total, notifications);

            return Ok(pageResult);
        }

        [HttpGet]
        [Route("count")]
        public async Task<IActionResult> RequestCountAsync(bool? isRead)
        {
            int total = await CountAsync(isRead);

            return Ok(new { value = total });
        }

        [HttpPut]
        [Route("read-all")]
        public async Task<IActionResult> ReadAll()
        {
            ReadAllNotificationCommand command = new ReadAllNotificationCommand();
            await _mediator.Send(command);

            return Ok();
        }

        private async Task<int> CountAsync(bool? isRead)
        {
            CountNotificationsQuery query = new CountNotificationsQuery
            {
                IsRead = isRead
            };

            return await _mediator.Send(query);
        }

        private GetRangeNotificationsQuery CreateRequestQuery(GetRangeNotificationsQueryDto queryHttp)
        {
            return new GetRangeNotificationsQuery
            {
                PageRequest = new PageRequest
                {
                    Skip = queryHttp.Skip,
                    Take = queryHttp.Take,
                    OrderType = Domain.Enums.OrderType.Desk
                },
                IsRead = queryHttp.IsRead,
                IsSetReadStatus = true
            };
        }
    }
}
