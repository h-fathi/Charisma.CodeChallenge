using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.CodeChallenge.Application.Products.GetProducts
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public decimal ProfitMargin { get; set; }
    }
}
