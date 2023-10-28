using static System.Console;

namespace InheritanceMiniProject
{
    public class CostumeModel : InventoryModel, IPurchasable, IRentable
    {
        public string Material { get; set; }
        public decimal RentPrice { get; set; }
        public decimal Price { get; set; }

        void IPurchasable.PrintItem()
        {
            WriteLine($"{ProductName}\t|\tMaterial: {Material}\t|\tPrice: {Price}\t|\tQuantity: {Quantity}");
        }

        void IRentable.PrintItem()
        {
            WriteLine($"{ProductName}\t\t|\tMaterial: {Material}\t|\tRent price: {RentPrice}\t|\tQuantity: {Quantity}");
        }

        public void Purchase()
        {
            Quantity -= 1;
            WriteLine($"{ProductName} has been Purchased ");

        }

        public void Rent()
        {
            Quantity -= 1;
            WriteLine($"{ProductName} has been Rented ");
        }

        public void ReturnRent()
        {
            Quantity += 1;
            WriteLine($"{ProductName} has been Returned ");
        }
    }


}
