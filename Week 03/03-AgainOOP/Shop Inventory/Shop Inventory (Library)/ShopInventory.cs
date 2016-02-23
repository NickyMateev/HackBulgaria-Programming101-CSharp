using System.Collections.Generic;

namespace Shop_Inventory__Library_
{
    public class ShopInventory
    {
        private List<Product> inventory;

        public ShopInventory(List<Product> listOfProducts)
        {
            inventory = listOfProducts;
        }

        public decimal Audit()
        {
            decimal totalSum = 0;
            foreach (var product in inventory)
            {
                totalSum += product.PriceAfterTax * product.Quantity;
            }
            return totalSum;
        }

        public decimal RequestOrder(Order order)
        {
            decimal orderAmount = 0;

            for (int i = 0; i < order.ListOfIDs.Count; i++)
            {
                for (int j = 0; j < inventory.Count; j++)
                {
                    if (order.ListOfIDs[i] == inventory[j].ProductID)
                    {
                        if (order.ListOfQuantities[i] <= inventory[j].Quantity)
                        {
                            orderAmount += inventory[j].PriceAfterTax * order.ListOfQuantities[i];
                            break;
                        }
                        else
                            throw new NotAvailableInInventoryException("ERROR: Not enough supplies!");
                    }
                    else if (j == inventory.Count - 1)
                        throw new NotAvailableInInventoryException("ERROR: Product doesn't exist in the database!");
                }
            }

            return orderAmount;
        }

    }
}