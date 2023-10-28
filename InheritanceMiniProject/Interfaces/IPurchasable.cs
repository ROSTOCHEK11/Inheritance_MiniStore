namespace InheritanceMiniProject
{
    public interface IPurchasable : IInventoryModel
    {

        void Purchase();
        void PrintItem();

        decimal Price { get; set; }

    }


}
