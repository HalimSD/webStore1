using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore.Internal;
using Org.BouncyCastle.Crypto.Agreement.Srp;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.OpenSsl;
using Remotion.Linq.Clauses;
using WebApp1.Models.Database;
using WebApp1.Models.Helper;

namespace WebApp1.Models
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<string[]> CategoryPath { get; set; }
        public PaginationViewModel<Product> Products { get; set; }

        public List<Category> Categories { get; set; }

        // Index 0 = name, Index 1 = id, Index 2 = type
        public List<AttributeFilter> Attributes { get; set; }
        public CategoryFilterModel Filters { get; set; }

        // The fields below are used to display the correct filter options
        public string[] PriceFilterRange { get; set; }
        public string[] QuantityFilterRange { get; set; }
        public bool IsFiltered { get; set; } = false;
    }

    // Model is used to group the filter parameters
    // that is passed to the controller by the form into one model
    public class CategoryFilterModel
    {
        // Model will be expanded as more filter options are added
        public string[] PriceRanges { get; set; }
        public string[] QuantityRanges { get; set; }

        public List<AttributeFilter> AttributeFilters { get; set; }

        public bool HasAttributeFilters
        {
            get
            {
                bool containsFilters = false;
                if (AttributeFilters == null) return false;
                foreach (AttributeFilter attributeFilter in AttributeFilters)
                {
                    if (attributeFilter.Type == "number")
                    {
                        if (attributeFilter.FilterRanges != null)
                        {
                            containsFilters = true;
                        }
                    }
                    if (attributeFilter.Type == "string")
                    {
                        if (!string.IsNullOrWhiteSpace(attributeFilter.FilterValue))
                        {
                            containsFilters = true;
                        }
                    }
                }

                return containsFilters;
            }
        }

        // Used to check if Filter options are empty!
        public bool IsEmpty
        {
            // Check if all fields of this model are null
            get
            {
                bool emptyPrice = PriceRanges == null && QuantityRanges == null;
                bool empty = true;
                if (AttributeFilters != null)
                {
                    foreach (var item in AttributeFilters)
                    {
                        if (item.Type == "string")
                        {
                            if (!string.IsNullOrEmpty(item.FilterValue)) empty = false;
                        }

                        if (item.Type == "number")
                        {
                            {
                                foreach (string range in item.FilterRanges)
                                {
                                    if (range != "false") empty = false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    empty = true;
                }

                return empty && emptyPrice;
            }
        }
    }

    public class AttributeFilter
    {
        public int AttributeId { get; set; }
        public string AttributeName { get; set; }
        public string[] FilterRanges { get; set; }
        public string Type { get; set; }
        public string FilterValue { get; set; }
    }
}