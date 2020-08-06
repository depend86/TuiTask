using System;
using TuiTask.Common.Services.Settings;

namespace Web.Settings
{
    public class Settings : ISettings
    {
        public int ToursPackSize => 1000;
        public int DefaultPersonCount => 1;
        public TimeSpan MaxWaitTime => TimeSpan.FromSeconds(15);
        public string PreferedProviderName => nameof(TuiTask.StandartProvider);
        public decimal MaxPreferedProviderPriceFactor => 1.05m;
    }
}