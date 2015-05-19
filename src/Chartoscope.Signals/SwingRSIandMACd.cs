﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chartoscope.Common;
using Chartoscope.Indicators;

namespace Chartoscope.Signals
{
    //Study about 1-2-3 swing indicator

    //http://forex-strategies-revealed.com/simple/123-rsi-macd
    //Forex trading strategy #4-a (1-2-3, RSI + MACD)
    public class SwingRSIandMACd: SignalBase
    {
        public const string IDENTITY_CODE = "ema_breakthrough";
        private SMA sma = null;

        public SwingRSIandMACd(BarItemType barType)
        {
            this.barType = barType;

            this.identityCode = string.Format("{0}({1})", IDENTITY_CODE, barType.Code);

            sma = new SMA(barType, 30);

            Register(sma);
        }
        
        private bool IsLongSetup(PriceBars priceBar)
        {           
            return sma.Value() < priceBar.LastItem.High && sma.Value() > priceBar.LastItem.Low && priceBar.LastItem.Close > priceBar.LastItem.Open;
        }

        private bool IsShortSetup(PriceBars priceBar)
        {
            return sma.Value() < priceBar.LastItem.High && sma.Value() > priceBar.LastItem.Low && priceBar.LastItem.Close < priceBar.LastItem.Open;
        }

        protected override void OutPosition(PriceBars priceBar, BarItemType barType)
        {
            if (IsLongSetup(priceBar))
            {
                Enter(PositionMode.Long);
            }
            else if (IsShortSetup(priceBar))
            {
                Enter(PositionMode.Short);
            }

        }

        protected override void InPosition(PositionMode position, PriceBars priceBar, BarItemType barType)
        {
            if ((position == PositionMode.Long && IsShortSetup(priceBar))
                || (position == PositionMode.Short && IsLongSetup(priceBar)))
            {
                Exit();
            }
        }
    }
}
