using System.Globalization;

namespace src.Entities
{
    class Product
    {
        public string Name { get; private set; }
        public double Price { get; private set; }

        public Product()
        {

        }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public virtual string PriceTag()
        {
            return Name
                + " $ "
                + Price.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
