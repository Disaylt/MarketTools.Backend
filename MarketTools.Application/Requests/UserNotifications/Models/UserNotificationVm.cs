using AutoMapper;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.UserNotifications.Models
{
    public class UserNotificationVm : IHasMap
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool IsRead { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserNotificationEntity, UserNotificationVm>();
        }
    }
}
