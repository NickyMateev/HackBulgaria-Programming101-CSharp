using System;
using System.Collections.Generic;

namespace Shop_Inventory__Library_
{
    public class Order
    {
        private List<int> IDs;
        private List<int> Quantities;

        public Order(List<int> listOfIDs, List<int> listOfQuantities)
        {
            if (listOfIDs.Count != listOfQuantities.Count)
                throw new ArgumentException("ERROR: List of IDs must be the same length as list of quantities!");

            IDs = listOfIDs;
            Quantities = listOfQuantities;
        }

        public List<int> ListOfIDs { get { return IDs; } } 
        public List<int> ListOfQuantities { get { return Quantities; } }
    }
}