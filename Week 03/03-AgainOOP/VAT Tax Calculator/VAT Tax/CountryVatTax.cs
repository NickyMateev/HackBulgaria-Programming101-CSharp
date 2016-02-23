namespace VAT_Tax
{
    public class CountryVatTax
    {
        private readonly string countryID;
        private readonly decimal VATTax;
        private readonly bool isDefault;

        public CountryVatTax(string countryID, decimal VATTax, bool isDefault)
        {
            this.countryID = countryID;
            this.VATTax = VATTax;
            this.isDefault = isDefault;
        }

        public string CountryID { get { return countryID; } }

        public decimal VATTAX { get { return VATTax; } }

        public bool IsDefault { get { return isDefault; } }

    }
}