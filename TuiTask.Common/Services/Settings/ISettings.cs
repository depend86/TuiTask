using System;

namespace TuiTask.Common.Services.Settings
{
    public interface ISettings
    {
        /// <summary>
        /// Размер массива туров, который отдает провайдер
        /// </summary>
        int ToursPackSize { get; }
        
        /// <summary>
        /// Количество людей по умолчанию
        /// </summary>
        int DefaultPersonCount { get; }
        
        /// <summary>
        /// Максимальное время ожидания
        /// </summary>
        TimeSpan MaxWaitTime { get; }
        
        /// <summary>
        /// Предпочтительный провайдер
        /// </summary>
        string PreferedProviderName { get; }
        
        /// <summary>
        /// Фактор максимальной разницы цены между предпочительным провайдером и самой низкой ценой
        /// </summary>
        decimal MaxPreferedProviderPriceFactor { get; }
    }
}