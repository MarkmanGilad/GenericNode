using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ElectionDay2
{
    public class Product
    {
        public int ProductId;
        public string Name;
        public double Price;
        public double Cost;
        public int Quantity;

        public Product()
        {

        }

        public Product(int productId, string name, double price, double cost, int quantity)
        {
            this.ProductId = productId;
            this.Name = name;
            this.Price = price;
            this.Cost = cost;
            this.Quantity = quantity;
        }
        public int GetProductId() { return this.ProductId; }
        public string GetName() { return this.Name; }
        public double GetPrice() { return this.Price; }
        public double GetCost() { return this.Cost; }
        public int GetQuantity() { return this.Quantity; }
        public void setProductId(int productId) { this.ProductId = productId; }
        public void setName(string name) { this.Name = name; }
        public void SetPrice(double price) { this.Price = price; }
        public void SetCost(double cost) { this.Cost = cost; }
        public void SetQuantity(int quantity) { this.Quantity = quantity; }

        public override string ToString()
        {
            return $"Id: {this.ProductId} Name: {this.Name} Price: {this.Price} cost: {this.Cost} Quantity: {this.Quantity}";
        }

        public static Node<Product> ReadFromTextFile(string fileName)
        {
            TextReader reader = File.OpenText(fileName);
            Node<Product> head = new Node<Product>(new Product());
            Node<Product> tail = head;
            string line;
            do
            {
                line = reader.ReadLine();
                if (!String.IsNullOrEmpty(line))
                {
                    string[] attr = line.Split(',');
                    Product product = new Product(int.Parse(attr[0]), attr[1], double.Parse(attr[2]), double.Parse(attr[3]), int.Parse(attr[4]));
                    tail.SetNext(new Node<Product>(product));
                    tail = tail.GetNext();
                }
            } while (line != null);
            return head.GetNext();
        }

    }
}
