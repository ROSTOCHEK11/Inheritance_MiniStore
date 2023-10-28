using static System.Console;

namespace InheritanceMiniProject
{
    public class MangaModel : InventoryModel, IPurchasable
    {
        public int NumberOfPages { get; set; }
        public decimal Price { get; set; }

        void IPurchasable.PrintItem()
        {
            WriteLine($"{ProductName}\t|\tNumber of Pages: {NumberOfPages}\t|\tPrice: {Price}\t|\tQuantity: {Quantity}"); 
        }
        public void Purchase()
        {
            Quantity -= 1;  
            WriteLine($"{ProductName} has been Purchased ");

        }


    }


}
