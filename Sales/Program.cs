using System;
using System.Collections.Generic;

/*  
 *  PROBLEM: An online store needs to calculate sales taxed based on an items properties. These include the type (Book, Food, Medical and General)and Imported vs Domestic.
 *  Basic sales tax is applicable at a rate of 10% on general goods. 
 *  Import duty is an additional sales tax applicable on all imported goods at a rate of 5%, with no exemptions.
 *  When items are purchased, user will receive a receipt which lists the name of all the items and their price (including tax), the total cost of the items, 
 *  and the total amounts of sales taxes paid.
 *  
 *  INPUT EXAMPLE:
 *  Input 1:
 *  1 book at 12.49
 *  1 music CD at 14.99
 *  1 chocolate bar at 0.85
 *   
 *  WHAT THIS PROGRAM DOES: This program takes in the list of items as follows: [quantity of item] [name of item] at [price of item] and calculates the total sales tax
 *  and the total amount, along with the list of items and their price with tax.
 *  
 *  PROGRAM ASSUMPTIONS: The quantity of the item is less than 10. The spelling of the item name must be correct, else it prints an error and you would have to re-enter the input.
 *  This also means that if you need to add more/new items (outside the imput1-3 examples) then use Add() to insert new items to the lists avaliable (book, food, medical, general).
 *     
 *  HOW TO RUN: Ctrl + F5
 *   
 *  BUGS (To fix if time avaliable Thursday/Friday): 
 *  This program only calculates correctly if the quantity < 10 and the line format is exactly as [quantity of item] [name of item] at [price of item].
 *  The rounding for Input2 Total Tax is 0.05 off; there might be a rounding error somewhere.
 *   
 *  THINGS THAT WOULD HAVE IMPROVED THE PROGRAM:
 *  Dividing the groups further by Domestic and Imported -> trim the names for "Imported" so that the list didn't have to have (ie.) imported bottle of perfume AND bottle of perfume.
 *  Or just have a structure or database.
 *  It would have been easier to test if the functions weren't static void.
 *  Try not to have too many times in main(), maybe just couple that calls helper functions to do everything.
 *  
 *  Implemented and documented by Ummey Zarin Tashnim.
*/

namespace Sales
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Input: ");

            //All types of goods as different lists
            List<string> general = new List<string>();
            List<string> book = new List<string>(); ;
            List<string> food = new List<string>(); ;
            List<string> medical = new List<string>();

            listOfItems(general, book, food, medical);  //Function call that adds items to the lists

            //Another set of lists to put the output results into, item names and their prices (with tax)
            List<string> itemList = new List<string>();
            List<float> itemPriceWithTax = new List<float>();

            //Variables Declaration
            string line, itemQuantity, itemName = null, itemPrice;
            float totalAmount = 0, totalTax = 0, currTax = 0, currPriceWithTax = 0;

            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                itemQuantity = line.Substring(0, 1);                        //Set item quantity as the first character of the user input
                itemName = getSubstringBetween(line, " ", " at");           //Set item name as the substring between " " and " at"                
                itemPrice = line.Substring(line.LastIndexOf(' ')).Trim();   //Set item price as the last few digits (before ' ' from end) of user input

                //Conversions between different types since everything was a string till now
                int itemQInt = Int16.Parse(itemQuantity);
                float itemPInt = float.Parse(itemPrice);
                float currPrice = itemQInt * itemPInt;

                //Function that does all the tax and price calculations
                allCalculation(ref itemName, ref currPrice, ref currTax, ref currPriceWithTax, ref totalTax, ref totalAmount);

                //only add the item name and price (with tax) to the lists if the item name exists in any of the lists
                if (food.Contains(itemName) | book.Contains(itemName) | medical.Contains(itemName) | general.Contains(itemName))
                {
                    itemList.Add(itemName);
                    itemPriceWithTax.Add(currPriceWithTax);
                }
            }

            //Function that prints the list of items (that the user typed) and their price (with tax)            
            printList(itemList, itemPriceWithTax);
            //Function that returns the string output with the total tax and total price of all items
            string output = printTotalTaxAndAmount(totalTax, totalAmount);
            Console.Write(output);
        }

        //Prints the item list according to user input
        public static void printList(List<string> itemList, List<float> itemPriceWithTax)
        {
            Console.WriteLine("Receipt: ");
            for (int i = 0; i < itemList.Count; ++i)  //Just prints everything in the item name and item price (with tax) lists
            {
                Console.WriteLine(itemList[i].ToString() + ": " + itemPriceWithTax[i].ToString("F"));
            }
        }

        //Function that returns the string output with the total tax and total price of all items
        public static string printTotalTaxAndAmount(float totalTax, float totalAmount)
        {
            totalTax = (float)(Math.Round(totalTax * (float)20.0) / (float)20.0);       //Round the total tax to the nearest 0.05
            totalAmount = (float)(Math.Round(totalAmount * (float)20.0) / (float)20.0); //Round the total price/amount to the nearest 0.05

            return ("\nTotal Tax: " + totalTax.ToString("F") + "\n" + "Total Amount: " + totalAmount.ToString("F") + "\n"); //Returns in #.## format
        }

        //Function that adds items to the lists (general, book, food, medical)
        public static void listOfItems(List<string> general, List<string> book, List<string> food, List<string> medical)
        {
            //These are the names of the items to be tested (according to Inpit 1 - 3)
            book.Add("book");

            general.Add("music CD");
            general.Add("bottle of perfume");
            general.Add("imported bottle of perfume");

            food.Add("chocolate bar");
            food.Add("imported box of chocolates");

            medical.Add("packet of Headache Pills");
        }

        //Function that does all the tax and price calculations
        public static void allCalculation(ref string itemName, ref float currPrice, ref float currTax, ref float currPriceWithTax, ref float totalTax, ref float totalAmount)
        {
            //All the lists needed to check the names of the items
            List<string> general = new List<string>();
            List<string> book = new List<string>(); ;
            List<string> food = new List<string>(); ;
            List<string> medical = new List<string>();

            //Populating the lists
            listOfItems(general, book, food, medical);

            if (itemName.Contains("imported"))  //If the item is Imported good
            {
                if (general.Contains(itemName)) //And it's a general good
                {
                    currTax = currPrice * (float)0.15;  //The sales tax is 15% (10% for general and 5% for imported)
                    currPriceWithTax = currTax + currPrice;
                    totalTax += currTax;
                    totalAmount += currPriceWithTax;
                }
                else if (food.Contains(itemName) | book.Contains(itemName) | medical.Contains(itemName))    //Just checks to make sure item name exists
                {                                                                                           //this helps to make sure spelling is correct too
                    currTax = currPrice * (float)0.05;  //The sales tax is 5% for imported items            
                    currPriceWithTax = currTax + currPrice;
                    totalTax += currTax;
                    totalAmount += currPriceWithTax;
                }
                else
                    Console.WriteLine("ERROR: There is no item with that name. Please try again.");         //Error for item that doesn't exist
            }
            else //Item is Domestic good
            {
                if (general.Contains(itemName))
                {
                    currTax = currPrice * (float)0.10;              //Domestic general good have 10% tax
                    currPriceWithTax = currTax + currPrice;
                    totalTax += currTax;
                    totalAmount += currPriceWithTax;
                }
                else if (food.Contains(itemName) | book.Contains(itemName) | medical.Contains(itemName))
                {
                    currTax = 0;                                    //No tax domestic tax for types other than general
                    currPriceWithTax = currTax + currPrice;
                    totalTax += currTax;                            //Update tax
                    totalAmount += currPriceWithTax;                //Update amount
                }
                else
                    Console.WriteLine("ERROR: There is no item with that name. Please try again.");         //Error for item that doesn't exist
            }
        }

        //Helper function that takes in a string, a starting substring, an ending substring and returns the substring between start and end.
        //Mainly to get the item name -> item name is the substring between " " and " at"
        public static string getSubstringBetween(string line, string substringStart, string substringEnd)
        {
            int Start, End;
            if (line.Contains(substringStart) && line.Contains(substringEnd))
            {
                Start = line.IndexOf(substringStart, 0) + substringStart.Length;
                End = line.IndexOf(substringEnd, Start);
                return line.Substring(Start, End - Start);
            }
            else
                return "";
        }
    }
}
