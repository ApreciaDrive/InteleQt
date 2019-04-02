using CsvHelper;
using CsvHelper.Configuration.Attributes;
using InteleqtCapture.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InteleqtCapture.helper
{
    public class helper
    {
        List<CSVFormat> list = new List<CSVFormat>();
        public helper()
        {
            using (var reader = new StreamReader("App_Data/Data.csv"))
            using (var csv = new CsvReader(reader))
            {
                list.AddRange(csv.GetRecords<CSVFormat>());
            }

        }
        public List<Models.Product> ReadProducts()
        {
            var products = new List<Models.Product>();


            list.ForEach(line =>
            {
                if (products.Any(p => p.Name == line.ProductName))
                {
                    int index = products.FindIndex(p => p.Name == line.ProductName);
                    if(products[index].Categories.Any(c => c.Name == line.ProductCategory))
                    {
                        var categories = products[index].Categories.ToList();
                        var index2 = categories.FindIndex(c => c.Name == line.ProductCategory);
                        if(!categories[index2].Items.Any(i => i.Name == line.Item))
                        {
                            categories[index2].Items.Add(new Item
                            {
                                Name = line.Item
                            });
                        }
                        products[index].Categories = categories; 
                    }
                    else
                    {
                        products[index].Categories.Add(new Category
                        {
                            Name = line.ProductCategory,
                            Items = new List<Models.Item>
                            {
                                new Models.Item{Name = line.Item}
                            }
                        });
                    }
                }
                else
                {
                    products.Add(new Product
                    {
                        Name = line.ProductName,
                        Categories = new List<Category> {
                             new Category{ Name = line.ProductCategory,Items = new List<Item>
                             {
                                 new Item{ Name = line.Item }
                             }
                             }
                         }
                    });
                }
            });
            
            return products;
        }
    }

    public class CSVFormat
    {
        [Name("PRODUCT")]
        public string ProductName { get; set; }
        [Name("PRODUCT CATEGORY")]
        public string ProductCategory { get; set; }
        [Name("ITEM")]
        public string Item { get; set; }
    }
}
