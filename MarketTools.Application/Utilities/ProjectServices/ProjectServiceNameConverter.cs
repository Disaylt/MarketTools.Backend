using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.ProjectServices
{
    public static class ProjectServiceNameConverter
    {
        public static string Convert(EnumProjectServices service)
        {
            return service switch
            {
                EnumProjectServices.StandardAutoresponder => "Стандартный автоответчик",
                _ => "Неизвестный сервис"
            };
        }
    }
}
