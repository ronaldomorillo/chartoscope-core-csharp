﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chartoscope.Common
{
    public enum CloseOrderState
    {
        Default,
        TakeProfit,
        StopLoss,
        TrailStop,
        MarginStop,
        ForceClose
    }
}
