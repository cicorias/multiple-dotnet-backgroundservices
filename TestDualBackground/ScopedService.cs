﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDualBackground
{
    public interface IScopedProcessingService
    {
        Task DoWorkAsync(CancellationToken stoppingToken);
    }
}
