using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Identity
{
    public interface IIdentityContextLoadService
    {
        public Task LoadByConnection(int connectionId);
    }
}
