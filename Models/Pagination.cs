using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace WebApp1.Models
{
    public class PaginationViewModel<T>
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public List<T> Data { get; set; }
    }

    public class PaginationHelper<T> where T : class
    {
        public readonly int TotalPages;
        public readonly int PageSize;
        private DbSet<T> dbSet;

        public PaginationHelper(int pageSize, DbSet<T> dbSet)
        {
            this.dbSet = dbSet;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling((double)dbSet.Count() / pageSize);
            if (TotalPages == 0)
            {
                TotalPages = 1;
            }
        }

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

        public PaginationViewModel<T> GetPageIQueryable(int pageNumber, IQueryable<T> query)
        {
            int skip = (pageNumber - 1) * PageSize;
            int totalPages = query.Count() / PageSize;
            if (totalPages == 0) { totalPages = 1; }
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