using System;
using System.Collections.Generic;
using VAT_Tax;

namespace VATTaxCalculatorApp
{
    class VATCalculatorApp
    {
        static void Main()
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

            string userCountry, userPrice;

            Console.Write("Country: ");
            userCountry = Console.ReadLine();
            Console.Write("Product price: ");
            userPrice = Console.ReadLine();
            if (userCountry.Length > 0)
                Console.WriteLine("Additional tax result: {0}\n", calculator.CalculateTax(int.Parse(userPrice), userCountry));
            else
                Console.WriteLine("Additional tax result: {0}\n", calculator.CalculateTax(int.Parse(userPrice)));
        }
    }
}