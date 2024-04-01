using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] code = new string[] { "F1", "F2", "F3", "F4", "F5", "F6" };
            string[] menu = new string[] { "Single Patty Hamburger",
                                           "Double Patty Hamberger",
                                           "Chicken Sandwich",
                                           "Egg Sandwich",
                                           "Hotdog Sandwich",
                                           "Exit" };
            decimal[] price = new decimal[] { 30.00m, 40.00m, 50.00m, 60.00m, 70.00m, 0 };


            string new_orderlist = "N";

            do
            {
                Console.Clear();
                string strPrice = "";

                Console.WriteLine("Code".PadRight(5) + "Menu".PadRight(25) + "Price" + "\n");
                for (int i = 0; i < menu.Length; i++)
                {
                    if (price[i] > 0) { strPrice = price[i].ToString(); }
                    else { strPrice = ""; }

                    Console.WriteLine(code[i].PadRight(5) + menu[i].PadRight(25) + strPrice);
                }
                Console.WriteLine("\n");

                //string[] order_list = new string[1];
                List<string> order_list = new List<string>();
                string order;
                int code_index;
                int qty = 0;
                decimal total_price = 0;

                do
                {
                    Console.Write("Enter Menu Code: ");
                    order = Console.ReadLine().ToUpper();

                    code_index = Array.IndexOf(code, order);

                    if (code_index < 0)
                    {
                        Console.WriteLine("Invalid Code !!!");
                    }
                    else
                    {
                        if (order != "F6")
                        {
                            bool validInput = false;
                            do
                            {
                                Console.Write("Enter Quantity: ");
                                try
                                {
                                    qty = Convert.ToInt32(Console.ReadLine());
                                    validInput = true;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Invalid Quantity!!! Try Again Please.");
                                    validInput = false;
                                }
                            } while (!validInput);

                            decimal qty_price = qty * price[code_index];

                            string order_menu = $"{order}  {menu[code_index]}  - ".PadRight(25);
                            string order_qnty = $"{qty}".PadRight(5);
                            string order_price = $"{qty_price}".PadLeft(5);
                            string orderEntry = order_menu + order_qnty + "\t" + order_price;
                            order_list.Add(orderEntry);
                            total_price = total_price + qty_price;

                        }

                    }

                }
                while (order != "F6");
                Console.WriteLine("\n");

                for (int i = 0; i < order_list.Count; i++)
                {
                    Console.WriteLine(order_list[i]);
                }
                Console.WriteLine("\n" + "Total Charge: " + total_price);

                decimal payment = 0;
                decimal change = 0;

                do
                {
                    Console.Write("Enter the payment: ");
                    payment = Convert.ToInt32(Console.ReadLine());

                    if (payment < total_price)
                    {
                        Console.WriteLine("Not enough cash!!! Try Again Please.");
                    }
                }
                while (payment < total_price);

                if (payment >= total_price)
                {
                    change = payment - total_price;
                    Console.WriteLine();
                    Console.WriteLine("Payment: " + payment);
                    Console.WriteLine("Charge : " + total_price);
                    Console.WriteLine("Change : " + change);
                }

                do
                {
                    Console.Write("\nDo you want to place another order? (Y/N): ");
                    new_orderlist = Console.ReadLine().ToUpper();
                }
                while (new_orderlist != "Y" && new_orderlist != "N");


            }
            while (new_orderlist == "Y");

            Console.ReadKey();
        }
    }
}


