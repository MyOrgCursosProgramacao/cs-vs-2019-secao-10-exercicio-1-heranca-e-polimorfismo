using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace src.Entities
{
    sealed class ImportedProduct : Product
    {
        public double CustomsFee { get; private set; }

        public ImportedProduct()
        {
        }

        public ImportedProduct(string name, double price, double customsFee)
            : base(name, price)
        {
            CustomsFee = customsFee;
        }

        public double TotalPrice()
        {
            return base.Price + CustomsFee;
        }

        public override string PriceTag()
        {
            return Name
                + " $ "
                + TotalPrice().ToString("F2", CultureInfo.InvariantCulture)
                + " (Customs fee: $ "
                + CustomsFee.ToString("F2", CultureInfo.InvariantCulture)
                + ")";
        }
    }
}
