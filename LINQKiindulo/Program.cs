using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LINQKiindulo
{
    class Program
    {
        static List<Category> categories;

        static List<Product> products;

        static void Main(string[] args)
        {
            Init();

            Console.ReadKey();
        }

        static void Init()
        {
            using (var catFile = XmlReader.Create(@"..\..\categories.xml"))
            {
                var dcs = new DataContractSerializer(typeof(List<Category>));
                categories = (List<Category>)dcs.ReadObject(catFile);
                foreach (var c in categories)
                {
                    c.Products = new List<Product>();
                }
            }

            using (var prodFile = XmlReader.Create(@"..\..\products.xml"))
            {
                var dcs = new DataContractSerializer(typeof(List<Product>));
                products = (List<Product>)dcs.ReadObject(prodFile);
                foreach (var prod in products)
                {
                    prod.Category = categories.Single(c => c.CategoryID == prod.CategoryID);
                    prod.Category.Products.Add(prod);
                }
            }
        }
    }
}
