using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace InheritanceMiniProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            List<IRentable> rentables = new List<IRentable>();
            List<IPurchasable> purchasables = new List<IPurchasable>();

            var manga = new MangaModel { ProductName = "Chainsaw Man Manga", NumberOfPages = 123, Quantity = 2, Price = 10 };
            var manga2 = new MangaModel { ProductName = "Demon Slayer Manga", NumberOfPages = 67, Quantity = 1, Price = 8 };

            var figure = new FigureModel { ProductName = "Naruto figure", Height = "15 cm", Quantity = 2, Price = 15 };
            var figure2 = new FigureModel { ProductName = "Luffy figure", Height = "35 cm", Quantity = 2, Price = 40 };

            var poster = new PosterModel { ProductName = "One Piece poster", Size = "50x30 cm", Quantity = 3, Price = 6 };
            var poster2 = new PosterModel { ProductName = "SAO poster", Size = "20x15 cm", Quantity = 2, Price = 6 };
            
            var costume = new CostumeModel { ProductName = "Pirate costume", Material = "100% Cotton", Quantity = 1, Price = 25, RentPrice = 9 };
            var costume2 = new CostumeModel { ProductName = "Goku costume", Material = "60% Cotton, 40% Poliester", Quantity = 2, Price = 23, RentPrice = 9 };

            var animator = new AnimatorModel { ProductName = "Animator - Pikachu", Quantity = 1, RentPrice = 50 };
            var animator2 = new AnimatorModel { ProductName = "Animator - Naruto", Quantity = 1, RentPrice = 50 };


            rentables.Add(costume);
            rentables.Add(costume2);
            rentables.Add(animator);
            rentables.Add(animator2);

            purchasables.Add(manga);
            purchasables.Add(manga2);
            purchasables.Add(figure);
            purchasables.Add(figure2);
            purchasables.Add(poster); 
            purchasables.Add(poster2);
            purchasables.Add(costume);
            purchasables.Add(costume2);

            foreach (var item in purchasables)
            {
                item.PrintItem();
            }



            ReadLine();

        }

    }



    public interface IInventoryModel
    {
        string ProductName { get; set; }
        int Quantity { get; set; }

        //string PrintItem();

    }


    public interface IRentable : IInventoryModel
    {

        void Rent();

        void ReturnRent();

        void PrintItem();

        decimal RentPrice { get; set; }
        

    }

    public interface IPurchasable : IInventoryModel
    {

        void Purchase();
        void PrintItem();

        decimal Price { get; set; }

    }



    public class InventoryModel : IInventoryModel
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }

        //public string PrintItem()
        //{
        //    return $"Product Name: {ProductName}\t|\tQuantity: {Quantity}\t|\t";
        //}
    }


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
            WriteLine("This Manga has been Purchased ");

        }

    }

    public class FigureModel : InventoryModel, IPurchasable
    {
        public string Height { get; set; }
        public decimal Price { get; set; }

        void IPurchasable.PrintItem()
        {
            WriteLine($"{ProductName}\t|\tHeight: {Height}\t|\tPrice: {Price}\t|\tQuantity: {Quantity}");
        }

        public void Purchase()
        {
            Quantity -= 1;
            WriteLine("This Figure has been Purchased ");

        }
    }

    public class PosterModel : InventoryModel, IPurchasable
    {
        public string Size { get; set; }
        public decimal Price { get; set; }
        void IPurchasable.PrintItem()
        {
            WriteLine($"{ProductName}\t|\tSize: {Size}\t|\tPrice: {Price}\t|\tQuantity: {Quantity}");
        }
        public void Purchase()
        {
            Quantity -= 1;
            WriteLine("This Poster has been Purchased ");

        }
    }

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
            WriteLine($"{ProductName}\t|\tMaterial: {Material}\t|\tRent price: {RentPrice}\t|\tQuantity: {Quantity}");
        }

        public void Purchase()
        {
            Quantity -= 1;
            WriteLine("This Costume has been Purchased ");

        }

        public void Rent()
        {
            Quantity -= 1;
            WriteLine("This Costume has been Rented ");
        }

        public void ReturnRent()
        {
            Quantity += 1;
            WriteLine("This Costume has been Returned ");
        }
    }

    public class AnimatorModel : InventoryModel, IRentable
    {
        public decimal RentPrice { get; set; }

        void IRentable.PrintItem()
        {
            WriteLine($"{ProductName}\t|\tRent price: {RentPrice}\t|\tQuantity: {Quantity}");
        }

        public void Rent()
        {
            Quantity -= 1;
            WriteLine("This Animator has been Rented ");
        }

        public void ReturnRent()
        {
            Quantity += 1;
            WriteLine("This Animator has been Returned ");
        }
    }


}
