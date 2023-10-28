using static System.Console;

namespace InheritanceMiniProject
{
    public class FigureModel : InventoryModel, IPurchasable
    {
        public string Height { get; set; }
        public decimal Price { get; set; }

        void IPurchasable.PrintItem()
        {
            WriteLine($"{ProductName}\t|\tHeight: {Height}\t\t|\tPrice: {Price}\t|\tQuantity: {Quantity}");
        }

        public void Purchase()
        {
            Quantity -= 1;
            WriteLine($"{ProductName} has been Purchased ");

        }
    }


}
