using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace WebApp1.Models
{
    // Default page model
    public class PaginationViewModel<T>
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public List<T> Data { get; set; }
    }

    
    /// <summary>
    /// A Helper object for Pagination. Instances of these are used to generate pages with a specified DbSet.
    /// When instantiating, you need to pass the maximum page size and the DbSet that it has to create pages from.
    /// NOTE: It can only generate pages from that specified DbSet!
    /// </summary>
    /// <typeparam name="T">T stands for the model class that is assigned to the DbSet</typeparam>
    public class PaginationHelper<T> where T : class
    {
        // Constants that shouldn't change!
        public readonly int TotalPages;
        public readonly int PageSize;
        private DbSet<T> dbSet;

        // Initialize the class
        public PaginationHelper(int pageSize, DbSet<T> dbSet)
        {
            this.dbSet = dbSet;
            PageSize = pageSize;
            // Bit messy, we need to calculate TotalPages and round it properly into an int
            // Needs further polishing
            TotalPages = (int)Math.Ceiling((double)dbSet.Count() / pageSize);
            // We can never have 0 pages
            if (TotalPages == 0)
            {
                TotalPages = 1;
            }
        }
        
        /// <summary>
        /// Create the specified page using the table data from the DbSet that was specified in constructor
        /// </summary>
        /// <param name="pageNumber">Indicates which page it should generate. DO NOT USE ZERO!</param>
        /// <returns>PaginationViewModel that contains all the data of that page along with page properties</returns>
        public PaginationViewModel<T> GetPage(int pageNumber)
        {
            int skip = (pageNumber - 1) * PageSize;
            PaginationViewModel<T> model = new PaginationViewModel<T>
            {
                PageNumber = pageNumber,
                TotalPages = TotalPages,
                PageSize = PageSize,
                Data = (from i in dbSet select i).Skip(skip).Take(PageSize).ToList()
            };
            return model;
        }

        /// <summary>
        /// Same as GetPage, but instead of using it's own DbSet to generate a IQueryable, a custom one is provided as source.
        /// This is useful for example if you need to create pages with filtered content.
        /// The IQueryable needs to be the same class as defined in this Helper instance
        /// </summary>
        /// <param name="pageNumber">Which page to generate</param>
        /// <param name="query">The custom IQueryable that it needs to use as source</param>
        /// <returns></returns>
        public PaginationViewModel<T> GetPageIQueryable(int pageNumber, IQueryable<T> query)
        {
            // Calculate how many records we need to skip when collecting data
            int skip = (pageNumber - 1) * PageSize;
            // Calculate total amount of pages
            int totalPages = query.Count() / PageSize;
            // There is always atleast 1 page, even with no data
            if (totalPages == 0) { totalPages = 1; }
            // Create the viewModel using the calculated skip and take values
            PaginationViewModel<T> model = new PaginationViewModel<T>
            {
                PageNumber = pageNumber,
                TotalPages = totalPages,
                PageSize = PageSize,
                Data = query.Skip(skip).Take(PageSize).ToList()
            };
            return model;
        }
    }
}