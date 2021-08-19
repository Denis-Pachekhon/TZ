
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TZ
{
    internal class TwoList
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }

        public override string ToString()
        {
            var table = new ConsoleTable();

            table.SetHeaders("Product name", "Category name");

            foreach (var item in Products)
            {
                var categortyName = (from category in Categories
                                    join product in Products
                                    on category.Id equals product.CategoryId
                                    where product.Name == item.Name 
                                    && product.Id == item.Id 
                                    select category.Name).First();

                table.AddRow(item.Name, categortyName);
            }

            return table.ToString();
        }
    }
}
