﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chartoscope.Common
{
    public interface ICacheConfigNavigator
    {
        CacheRow Read(long datafeedHashKey);
    }
}
