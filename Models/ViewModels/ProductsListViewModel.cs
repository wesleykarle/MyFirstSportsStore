using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFirstSportsStore.Models;

namespace MyFirstSportsStore.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
