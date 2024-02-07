using StandardAutoresponder.WorkerService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardAutoresponder.WorkerService.Utilities
{
    internal class WbAutoresponderHandler() : IWbAutoresponderHandler
    {
        public async Task RunAsync(int connectionId)
        {
            try
            {

                Console.WriteLine(connectionId);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
