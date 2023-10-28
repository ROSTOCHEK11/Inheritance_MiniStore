using static System.Console;

namespace InheritanceMiniProject
{
    public class AnimatorModel : InventoryModel, IRentable
    {
        public decimal RentPrice { get; set; }

        void IRentable.PrintItem()
        {
            WriteLine($"{ProductName}\t|\tRent price: {RentPrice}\t\t|\tQuantity: {Quantity}\t|");
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
