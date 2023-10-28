using static System.Console;

namespace InheritanceMiniProject
{
    public class PosterModel : InventoryModel, IPurchasable
    {
        public string Size { get; set; }
        public decimal Price { get; set; }
        void IPurchasable.PrintItem()
        {
            WriteLine($"{ProductName}\t|\tSize: {Size}\t\t|\tPrice: {Price}\t|\tQuantity: {Quantity}");
        }
        public void Purchase()
        {
            Quantity -= 1;
            WriteLine($"{ProductName} has been Purchased ");

        }
    }


}
