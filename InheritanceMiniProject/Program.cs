using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
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
            
            var manga = new MangaModel { ProductName = "Chainsaw Man M.", NumberOfPages = 123, Quantity = 2, Price = 10 };
            var manga2 = new MangaModel { ProductName = "Demon Slayer M.", NumberOfPages = 67, Quantity = 1, Price = 8 };

            var figure = new FigureModel { ProductName = "Naruto figure", Height = "15 cm", Quantity = 2, Price = 15 };
            var figure2 = new FigureModel { ProductName = "Luffy figure", Height = "35 cm", Quantity = 2, Price = 40 };

            var poster = new PosterModel { ProductName = "OnePiece poster", Size = "50x30 cm", Quantity = 3, Price = 6 };
            var poster2 = new PosterModel { ProductName = "SAO poster", Size = "20x15 cm", Quantity = 2, Price = 6 };
            
            var costume = new CostumeModel { ProductName = "Pirate costume", Material = "100% Cotton", Quantity = 1, Price = 25, RentPrice = 9 };
            var costume2 = new CostumeModel { ProductName = "Goku costume", Material = "100% Silk", Quantity = 2, Price = 23, RentPrice = 9 };

            var animator = new AnimatorModel { ProductName = "Animator - Pikachu", Quantity = 1, RentPrice = 50 };
            var animator2 = new AnimatorModel { ProductName = "Animator - Naruto", Quantity = 1, RentPrice = 50 };


            var items = new List<IInventoryModel> { manga, manga2, figure, figure2, poster, poster2, costume, costume2, animator, animator2 };
            List<IRentable> rentables = new List<IRentable>();
            List<IPurchasable> purchasables = new List<IPurchasable>();


            foreach (var item in items)
            {
                if ( (item is IRentable) && (item is IPurchasable) )
                {
                    purchasables.Add(item as IPurchasable);
                    rentables.Add(item as IRentable);
                }
                else if (item is IPurchasable)
                {
                    purchasables.Add(item as IPurchasable);
                }
                else if (item is IRentable)
                {
                    rentables.Add(item as IRentable);
                }
            }


            Write("Hello to my mini Anime Store!\nDo you want to BUY or RENT something ? ( buy / rent ): ");
            string rentalDecision = ReadLine();
            string continueAnswer;
            

            if (rentalDecision.ToLower() == "buy")
            {

                WriteLine("\nHere's some Items to buy :\n\n");

                BuyItems(purchasables);

            }
            else if (rentalDecision.ToLower() == "rent")
            {

                WriteLine("\nHere's some Items to rent :\n\n");


                List<IRentable> rents = new List<IRentable>();

                RentItems(rentables, rents);


                Write("\nDo you want to return something ? ( yes / no ) : ");
                continueAnswer = ReadLine();
                WriteLine();

                if (continueAnswer.ToLower() == "yes")
                {

                    ReturnRentedItems(rents);

                }
                
            }

            WriteLine("\nThank's for visiting us !");

            ReadLine();

        }



        static void BuyItems(List<IPurchasable> purchasables)
        {
            List<IPurchasable> purchases = new List<IPurchasable>();
            string continueAnswer;

            do
            {

                int counter = 1;
                foreach (var item in purchasables)
                {
                    Write($"{counter})\t");
                    item.PrintItem();
                    WriteLine();
                    counter++;
                }

                Write("Which one do you want ? ( Write the number ) : ");
                if (int.TryParse(ReadLine(), out int productChoice) && productChoice >= 1 && productChoice <= purchasables.Count)
                {

                    IPurchasable productChoicePurchase = purchasables[productChoice - 1];

                    if (productChoicePurchase.Quantity > 0)
                    {
                        productChoicePurchase.Purchase();
                        purchases.Add(productChoicePurchase);
                    }
                    else
                    {
                        WriteLine("This product is out of stock");
                    }

                    Write("\nDo you want something else ? ( yes / no ) : ");
                    continueAnswer = ReadLine();
                    Clear();
                }
                else
                {
                    WriteLine("Invalid input, Please enter a valid product number");
                    continueAnswer = "yes"; 
                }


            } while (continueAnswer.ToLower() != "no");

            WriteLine("Products that you bought : \n");
            foreach (var item in purchases)
            {
                WriteLine(item.ProductName);
            }
        }


        static void RentItems(List<IRentable> rentables, List<IRentable> rents)
        {
            
            string continueAnswer;

            do
            {
                int counter = 1;
                foreach (var item in rentables)
                {
                    Write($"{counter})\t");
                    item.PrintItem();
                    WriteLine();
                    counter++;
                }

                Write("Which one do you want to rent? (Write the number): ");
                if (int.TryParse(ReadLine(), out int productChoice) && productChoice >= 1 && productChoice <= rentables.Count)
                {
                    IRentable productChoiceRent = rentables[productChoice - 1];

                    if (productChoiceRent.Quantity > 0)
                    {
                        productChoiceRent.Rent();
                        rents.Add(productChoiceRent);
                    }
                    else
                    {
                        WriteLine("This product is out of stock");
                    }

                    Write("\nDo you want something else? (yes / no): ");
                    continueAnswer = ReadLine();
                    Clear();
                }
                else
                {
                    WriteLine("Invalid input. Please enter a valid product number.");
                    continueAnswer = "yes"; 
                }
            } while (continueAnswer.ToLower() != "no");

            WriteLine("Products that you rented: \n");
            foreach (var item in rents)
            {
                WriteLine(item.ProductName);
            }
        }



        static void ReturnRentedItems(List<IRentable> rents)
        {
            string continueAnswer;

            do
            {
                int counter = 1;
                foreach (var item in rents)
                {
                    Write($"{counter})\t");
                    WriteLine(item.ProductName);
                    WriteLine();
                    counter++;
                }

                Write("\nWhich product do you want to return? (Write the number): ");
                if (int.TryParse(ReadLine(), out int productChoice) && productChoice >= 1 && productChoice <= rents.Count )
                {

 
                    IRentable itemToReturn = rents[productChoice - 1];

                    itemToReturn.ReturnRent();
                    rents.Remove(itemToReturn);

                    if (rents.Count == 0)
                    {
                        
                        WriteLine("\nYou have returned all the items");
                        continueAnswer = "no";

                    }
                    else
                    {
                        
                        WriteLine("\nDo you want to return something else? (yes / no): ");
                        continueAnswer = ReadLine();
                        Clear();

                    }

                }
                else
                {
                    WriteLine("Invalid input. Please enter a valid number");
                    continueAnswer = "yes"; 
                }

            } while (continueAnswer.ToLower() != "no");
        }


    }


}
