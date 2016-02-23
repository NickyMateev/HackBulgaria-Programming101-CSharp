using System.Collections.Generic;

namespace VAT_Tax
{
    public class VATTaxCalculator
    {
        private List<CountryVatTax> countryList = new List<CountryVatTax>();

        public VATTaxCalculator(List<CountryVatTax> countryList)
        {
            this.countryList = countryList;
        }
        
        public decimal CalculateTax(decimal price, string countryID)
        {
            decimal tax = decimal.MinValue;     // some default value
            foreach (var country in countryList)
            {
                if (country.CountryID == countryID)
                    tax = price * (1 + country.VATTAX) - price;
            }

            if (tax != decimal.MinValue)
                return tax;
            else
                throw new NotSupportedCountryException("ERROR: Country isn't supported!");
        }

        public decimal CalculateTax(decimal price)
        {
            decimal tax = decimal.MinValue;
            foreach (var country in countryList)
            {
                if (country.IsDefault)
                {
                    tax = price * (1 + country.VATTAX) - price;
                    break;
                }
            }

            if (tax != decimal.MinValue)
                return tax;
            else
                throw new NotSupportedCountryException("ERROR: Default country doesn't exist in the list of countries!");
        }
    }
}