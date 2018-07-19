using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LINQKiindulo
{
    [DataContract(Namespace = "CSharpHalado")]
    public class Product
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int CategoryID { get; set; }

        [DataMember]
        public Category Category { get; set; }

        [DataMember]
        public string QuantityPerUnit { get; set; }

        [DataMember]
        public decimal UnitPrice { get; set; }

        [DataMember]
        public short UnitsInStock { get; set; }

        [DataMember]
        public short UnitsOnOrder { get; set; }

        [DataMember]
        public bool Discontinued { get; set; }

        public override string ToString()
        {
            return $"{Name}: {UnitPrice}";
        }

        public override bool Equals(object obj)
        {
            /*
            Amit eredetileg írtunk hibás mert ha az obj nem Product 
            vagy abból származó osztály példánya
            akkor a castolás kivételt dob
            helyes megoldáshoz még ez az if is kell, 
            mert ez ellenőrzi hogy lehet-e Productra castolni
            ha nem lehet akkor biztos nem egyenlőek
            */
            if (!(obj is Product)) return false;

            Product p = (Product)obj;
            return p.Name == this.Name;
        }
    }
}
