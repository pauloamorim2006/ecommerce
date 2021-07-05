using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Filter
{
    public class ProductFilter : PaginationFilter
    {
        public List<Guid> Brands { get; set; }

        public bool FreeShipping { get; set; }

        public PriceType PriceType { get; set; }

        public RatingType RatingType { get; set; }

        public OrderType OrderType { get; set; }
    }
}
