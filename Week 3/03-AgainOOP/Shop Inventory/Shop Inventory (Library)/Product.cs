using System.Collections.Generic;
using VAT_Tax;

namespace Shop_Inventory__Library_
{
    public class Product
    {
        private decimal priceBeforeTax;
        private decimal priceAfterTax;
        private string availableCountry;
        private string productName;
        private int quantity;
        private int productID;
        
        public Product(decimal price, string availableCountry, string productName, int quantity, int productID)
        {
            priceBeforeTax = price;
            priceAfterTax = CalculatePriceAfterTax(price, availableCountry);
            this.availableCountry = availableCountry;
            this.productName = productName;
            this.quantity = quantity;
            this.productID = productID;
        }

        public decimal PriceBeforeTax { get { return priceBeforeTax; } }
        public decimal PriceAfterTax { get { return priceAfterTax; } }
        public string AvailableCountry { get { return availableCountry; } }
        public string ProductName { get { return productName; } }
        public int Quantity { get { return quantity; } }
        public int ProductID { get { return productID; } }

        private decimal CalculatePriceAfterTax(decimal price, string country)
        {
            List<CountryVatTax> countryList = new List<CountryVatTax>
            {
                new CountryVatTax("Bulgaria", 0.2M, true),
                new CountryVatTax("Germany", 0.19M, false),
                new CountryVatTax("France", 0.2M, false),
                new CountryVatTax("Finland", 0.24M, false),
                new CountryVatTax("Hungary", 0.27M, false),
                new CountryVatTax("Ireland", 0.23M, false),
                new CountryVatTax("Denmark", 0.25M, false),
                new CountryVatTax("Italy", 0.22M, false),
                new CountryVatTax("Spain", 0.21M, false),
                new CountryVatTax("Sweden", 0.25M, false),
                new CountryVatTax("United Kingdom", 0.20M, false)
            };

            VATTaxCalculator calculator = new VATTaxCalculator(countryList);
            return price + calculator.CalculateTax(price, country);
        }

    }
}