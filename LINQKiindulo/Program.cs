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

            var productNames = products.Where(p => p.UnitPrice > 10).Select(p => p.Name);

            //foreach (var product in productNames)
            //{
            //    Console.WriteLine(product);
            //}
            //productNames.WriteAll("Term�k nevek");

            //products.WriteAll();

            //var numbers = new List<int> { 2, 3, 4, 5, 6 };
            //var evenNumbers = numbers.Where(n => n % 2 == 0).Where(n => n > 3);
            //var evenList = evenNumbers.ToList();
            //evenList.Add(12);
            //numbers.Add(8);
            //evenList.WriteAll("P�ros lista");
            //evenNumbers.WriteAll("P�ros sz�mok");

            //numbers.Add(10);

            //evenList.WriteAll("P�ros lista 2");
            //evenNumbers.WriteAll("P�ros sz�mok 2");

            var cheapProducts = from p in products
                                where p.Discontinued
                                select p;

            //var cheapProducts = products.Where(p => p.Discontinued).Select(p => p); A Select r�sz term�szetesen elhagyhat�


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
