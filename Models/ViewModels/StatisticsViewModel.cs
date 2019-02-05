using System;
using System.Collections.Generic;
using WebApp1.Models.Helper.Statistics;

namespace WebApp1.Models.ViewModels
{
    public class StatisticsViewModel<T>
    {
        public string[] Ranges => Enum.GetNames(typeof(StatisticsHelper.Range));

        public List<T> Data { get; set; }
    }
}