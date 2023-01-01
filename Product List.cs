using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace General_Store
{
    public class Products
    {
        public List<ProductSpecification> Fruits = new List<ProductSpecification>();
        public List<ProductSpecification> Vegetables = new List<ProductSpecification>();
        public List<ProductSpecification> Cosmetics = new List<ProductSpecification>();
        public List<ProductSpecification> Toys = new List<ProductSpecification>();
        public List<ProductSpecification> Gadgets = new List<ProductSpecification>();
        public List<CartSpecification> Cart = new List<CartSpecification>();

        public void GetDetails() {

            #region Fruits
            Fruits.Add(new ProductSpecification { 
                SrNo=1,
                Name="Mango",
                Price=50,
                Quantity="1 Kg"
            });
            Fruits.Add(new ProductSpecification
            {
                SrNo = 2,
                Name = "Apple",
                Price = 80,
                Quantity = "1 Kg"
            });
            Fruits.Add(new ProductSpecification
            {
                SrNo = 3,
                Name = "Papaya",
                Price = 40,
                Quantity = "1 Kg"
            });
            Fruits.Add(new ProductSpecification
            {
                SrNo = 4,
                Name = "Grapes",
                Price = 50,
                Quantity = "1 Kg"
            });
            Fruits.Add(new ProductSpecification
            {
                SrNo = 5,
                Name = "Orange",
                Price = 60,
                Quantity = "1 Kg"
            });
            #endregion

            #region Vegetables
            Vegetables.Add(new ProductSpecification
            {
                SrNo = 1,
                Name = "Tomato",
                Price = 20,
                Quantity = "1 Kg"
            });
            Vegetables.Add(new ProductSpecification
            {
                SrNo = 2,
                Name = "Potato",
                Price = 15,
                Quantity = "1 Kg"
            });
            Vegetables.Add(new ProductSpecification
            {
                SrNo = 3,
                Name = "Capsicum",
                Price = 25,
                Quantity = "1 Kg"
            });
            Vegetables.Add(new ProductSpecification
            {
                SrNo = 4,
                Name = "Carrot",
                Price = 40,
                Quantity = "1 Kg"
            });
            Vegetables.Add(new ProductSpecification
            {
                SrNo = 5,
                Name = "BeetRoot",
                Price = 30,
                Quantity = "1 Kg"
            });
            Vegetables.Add(new ProductSpecification
            {
                SrNo = 6,
                Name = "LadiesFinger",
                Price = 20,
                Quantity = "1 Kg"
            });
            #endregion

            #region Cosmetics
            Cosmetics.Add(new ProductSpecification
            {
                SrNo = 1,
                Name = "Lipstick",
                Price = 99,
                Quantity = "1 Unit"
            });
            Cosmetics.Add(new ProductSpecification
            {
                SrNo = 2,
                Name = "Brusher",
                Price = 330,
                Quantity = "1 Unit"
            });
            Cosmetics.Add(new ProductSpecification
            {
                SrNo = 3,
                Name = "Moisturiser",
                Price = 347,
                Quantity = "1 Unit"
            });
            Cosmetics.Add(new ProductSpecification
            {
                SrNo = 4,
                Name = "Foundation",
                Price = 180,
                Quantity = "1 Unit"
            });
            Cosmetics.Add(new ProductSpecification
            {
                SrNo = 5,
                Name = "Kaajal",
                Price = 260,
                Quantity = "1 Unit"
            });
            Cosmetics.Add(new ProductSpecification
            {
                SrNo = 6,
                Name = "EyeLiner",
                Price = 500,
                Quantity = "1 Unit"
            });
            #endregion

            #region Toys
            Toys.Add(new ProductSpecification
            {
                SrNo = 1,
                Name = "Aeroplane",
                Price = 250,
                Quantity = "1 Unit"
            });
            Toys.Add(new ProductSpecification
            {
                SrNo = 2,
                Name = "HotWheelsCar",
                Price = 200,
                Quantity = "1 Unit"
            });
            Toys.Add(new ProductSpecification
            {
                SrNo = 3,
                Name = "Barbie",
                Price = 350,
                Quantity = "1 Unit"
            });
            Toys.Add(new ProductSpecification
            {
                SrNo = 4,
                Name = "Puzzle",
                Price = 400,
                Quantity = "1 Unit"
            });
            Toys.Add(new ProductSpecification
            {
                SrNo = 5,
                Name = "TedyBear",
                Price = 4000,
                Quantity = "1 Unit"
            });
            Toys.Add(new ProductSpecification
            {
                SrNo = 6,
                Name = "DollHouse",
                Price = 500,
                Quantity = "1 Unit"
            });
            #endregion

            #region Gadgets
            Gadgets.Add(new ProductSpecification
            {
                SrNo = 1,
                Name = "SmartPhone",
                Price = 16000,
                Quantity = "1 Unit"
            });
            Gadgets.Add(new ProductSpecification
            {
                SrNo = 2,
                Name = "EarPodes",
                Price = 5000,
                Quantity = "1 Unit"
            });
            Gadgets.Add(new ProductSpecification
            {
                SrNo = 3,
                Name = "Laptop",
                Price = 60000,
                Quantity = "1 Unit"
            });
            Gadgets.Add(new ProductSpecification
            {
                SrNo = 4,
                Name = "SmartWatch",
                Price = 4000,
                Quantity = "1 Unit"
            });
            Gadgets.Add(new ProductSpecification
            {
                SrNo = 5,
                Name = "Camera",
                Price = 50000,
                Quantity = "1 Unit"
            });
            Gadgets.Add(new ProductSpecification
            {
                SrNo = 6,
                Name = "BluetoothSpeaker",
                Price = 4000,
                Quantity = "1 Unit"
            });
            #endregion

        }

    }


    public class ProductSpecification {
        public int SrNo { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Quantity { get; set; }
    }

    public class CartSpecification
    {
        public int SrNo { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string Quantity { get; set; }
    }

    public class ListtoDataTableConverter
    {
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
