﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardAutoresponder.WorkerService.Interfaces
{
    internal interface IWbFeedbacksHandler
    {
        public Task RunAsync(int connectionId);
    }
}
