﻿using MetarDecoder;
using System;
using Vatsim.Vatis.Client.Common;

namespace Vatsim.Vatis.Client.Atis
{
    public class TemperatureMeta : AtisMeta
    {
        public override void Parse(DecodedMetar metar)
        {
            if (metar.AirTemperature != null)
            {
                if (metar.IsInternational && metar.AirTemperature.ActualValue > 0)
                {
                    TextToSpeech = $"Temperature plus {Convert.ToInt32(metar.AirTemperature.ActualValue).NumberToSingular()}";
                }
                else
                {
                    TextToSpeech = $"Temperature {Convert.ToInt32(metar.AirTemperature.ActualValue).NumberToSingular()}";
                }
                Acars = string.Concat((metar.AirTemperature.ActualValue < 0) ? "M" : "", Math.Abs(metar.AirTemperature.ActualValue).ToString("00"));
            }
        }
    }
}
