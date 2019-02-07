using System;
using System.Collections.Generic;
using System.Linq;
using WebApp1.Models.Database;

namespace WebApp1.Models.Helper.Statistics
{
    public class StatisticsHelper
    {
        public enum Range
        {
            All,
            Year = 365,
            SixMonths = 183,
            ThreeMonths = 90,
            Month = 30,
            ThreeWeeks = 21,
            TwoWeeks = 14,
            Week = 7,
        }

        private readonly WebshopContext context;

        public StatisticsHelper(WebshopContext context)
        {
            this.context = context;
        }

        public List<string[]> GetTotalSold(Range range)
        {
            Order[] orders = (from b in context.Order select b).ToArray();
            List<string[]> data = new List<string[]>();
            data.Add(new[] {"X", "Verkochtte Producten"});

            // Each value in array represents sold count for specific day
            // index 0: 0 days ago
            // index 1: 1 days ago
            // etc...
            int[] soldCount = range == Range.All ? new int[CalculateDateRange(orders.Select(o => o.Date).ToArray())] : new int[(int) range];

            foreach (Order order in orders)
            {
                // Figure out which day it should be part off
                // -1 Means it happened outside the date range
                int index = GetIndexFromDateRange(soldCount.Length, order.Date);

                // If it doesn't fall under the chosen date range, purchase will not be included
                // Skip this iteration of the foreach loop
                if (index == -1) continue;

                // Amount of products in this specific order
                int productCount =
                (
                    from bi in context.OrderDetail
                    where bi.OrderId == order.Id
                    select bi.Quantity
                ).Sum();

                soldCount[index] += productCount;
            }

            for (int i = soldCount.Length - 1; i >= 0; i--)
            {
                data.Add(new[] {DateTime.Today.AddDays(i * -1).ToShortDateString(), soldCount[i].ToString()});
            }

            return data;
        }

        public List<string[]> GetCategorySold(Range range)
        {
            Category[] categoryArray = (from ps in context.Category select ps).ToArray();
            List<OrderDetail> orders = (from bi in context.OrderDetail select bi).ToList();
            List<string[]> data = new List<string[]>();
            data.Add(new[] {"Categorieen", "Verkochtte Producten"});

            foreach (Category category in categoryArray)
            {
                int count = 0;
                foreach (OrderDetail order in orders)
                {
                    if (range != Range.All)
                    {
                        DateTime orderDate =
                        (
                            from o in context.Order
                            where o.Id == order.OrderId
                            select o.Date
                        ).FirstOrDefault();
                    
                        // Figure out which day it should be part off
                        // -1 Means it happened outside the date range
                        if (GetIndexFromDateRange((int)range, orderDate) == -1) continue;
                    }
                    
                    string categoryName =
                    (
                        from pw in context.Product
                        from ps in context.Category
                        where pw.Id == order.ProductId &&
                              pw.CategoryId == ps.Id &&
                              ps.Id == category.Id
                        select ps.Naam
                    ).FirstOrDefault();

                    if (categoryName == null) continue;
                    count += order.Quantity;
                }

                data.Add(new[] {category.Naam, count.ToString()});
            }

            return data;
        }

        /// <summary>
        /// Get the index of this date depending on if it is within the date range.
        /// </summary>
        /// <param name="range">The input date range</param>
        /// <param name="date">The date</param>
        /// <returns>Index value. If date is outside range, it will return -1</returns>
        private int GetIndexFromDateRange(int range, DateTime date)
        {
            // Figure out which day it should be part off
            // -1 Means it happened outside the date range
            for (int i = 0; i < range; i++)
            {
                if (i == 0)
                {
                    if (date.ToShortDateString() == DateTime.Today.ToShortDateString()) return 0;
                }
                else
                {
                    if (date.ToShortDateString() == DateTime.Today.AddDays(i * -1).ToShortDateString()) return i;
                }
            }

            return -1;
        }

        private int CalculateDateRange(DateTime[] dates)
        {
            DateTime min = dates.Min();

            int range = (DateTime.Now - min.AddDays(-1)).Days;
            return range;
        }
    }
}