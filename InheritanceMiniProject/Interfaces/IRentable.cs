namespace InheritanceMiniProject
{
    public interface IRentable : IInventoryModel
    {

        void Rent();

        void ReturnRent();

        void PrintItem();

        decimal RentPrice { get; set; }
        

    }


}
