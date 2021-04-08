using System;
using System.Collections.Generic;
using Sales;
using Xunit;

/*
 * NOTE: When running this, make sure to rename program.cs main() to something else (ie. NotMain) because when you run the test cases, 
 * xUnit creates their own main. Which makes it confused as to which main() is the starting point.
 * 
 * PURPOSE: Unit tests to cover the 3 inputs given. There is 3 test cases to check the 3 different inputs and make sure they output correctly.
 * I hope this is what the specs meant by "cover the 3 inputs given"; tracing the program step-by-step with the three inputs.
 * 
 * HOW TESTING WAS DONE: Because most of my functions were void, which meant I couldn' really test them. The only functions I could test 
 * (aka that weren't void) were printTotalTaxAndAmount, which prints the total tax and price of the items. And to do that, I had to manually 
 * trace the user input line by line to get the actual result to compare to the expected. Also, because the process is the same, I only 
 * commented on the first test case.
 * 
 * HOW TO RUN THE TEST CASES: Test -> Test Explorer -> You can choose to run the test cases individually or all of them at once.
 * FOR NEXT TIME: Avoid making functions that doesn't return any types (static void) since it makes testing helper functions difficult.
 * You can't really test void functions for anything other than to make sure they are being called correctly and going through.
 * 
 * Tested and documented by Ummey Zarin Tashnim.
*/
namespace Sales.Tests
{
    public class TestingSalesProgramInputs
    {
        [Fact]
        public void CheckingTotalTaxAndAmountOutput_InputOne()                      //Checks Input1 for the correct output
        {   //Lists to store the final item list and their prices (with tax)
            List<string> itemList = new List<string>();             
            List<float> itemPriceWithTax = new List<float>();

            //LINE ONE of user input - 1 book at 12.49
            string itemOneName = "book";
            float itemOnePrice = 12.49f;
            float currTax = 0, currPriceWithTax = 0, totalTax = 0, totalAmount = 0;
            
            //Do all the tax and prices calculations
            Program.allCalculation(ref itemOneName, ref itemOnePrice, ref currTax, ref currPriceWithTax, ref totalTax, ref totalAmount);

            //Add the results into the lists
            itemList.Add(itemOneName);
            itemPriceWithTax.Add(currPriceWithTax);

            string expectedOne = "\nTotal Tax: 0.00\nTotal Amount: 12.50\n";
            string actualOne = Program.printTotalTaxAndAmount(totalTax, totalAmount);
            Assert.Equal(expectedOne, actualOne);                                       //True - expected and actual are the same

            //LINE TWO of user input - 1 music CD at 14.99
            string itemTwoName = "music CD";
            float itemTwoPrice = 14.99f;

            Program.allCalculation(ref itemTwoName, ref itemTwoPrice, ref currTax, ref currPriceWithTax, ref totalTax, ref totalAmount);

            itemList.Add(itemTwoName);
            itemPriceWithTax.Add(currPriceWithTax);

            string expectedTwo = "\nTotal Tax: 1.50\nTotal Amount: 29.00\n";
            string actualTwo = Program.printTotalTaxAndAmount(totalTax, totalAmount);
            Assert.Equal(expectedTwo, actualTwo);                                       //True - expected and actual are the same

            //LINE THREE of user input - 1 chocolate bar at 0.85
            string itemThreeName = "chocolate bar";
            float itemThreePrice = 0.85f;

            Program.allCalculation(ref itemThreeName, ref itemThreePrice, ref currTax, ref currPriceWithTax, ref totalTax, ref totalAmount);

            itemList.Add(itemOneName);
            itemPriceWithTax.Add(currPriceWithTax);

            string expectedThree = "\nTotal Tax: 1.50\nTotal Amount: 29.85\n";
            string actualThree = Program.printTotalTaxAndAmount(totalTax, totalAmount);
            Assert.Equal(expectedThree, actualThree);                                   //True - expected and actual are the same
        }

        //THIS CASES FAILS - Expected: Total Tax: 7.65 Total Amount: 65.15, Actual: Total Tax: 7.65 Total Amount: 65.10
        //There must be a rounfing error in the program.
        [Fact]
        public void CheckingTotalTaxAndAmountOutput_InputTwo()
        {

            List<string> itemList = new List<string>();
            List<float> itemPriceWithTax = new List<float>();

            //LINE ONE
            string itemOneName = "imported box of chocolates";
            float itemOnePrice = 10.00f;
            float currTax = 0, currPriceWithTax = 0, totalTax = 0, totalAmount = 0;

            Program.allCalculation(ref itemOneName, ref itemOnePrice, ref currTax, ref currPriceWithTax, ref totalTax, ref totalAmount);

            itemList.Add(itemOneName);
            itemPriceWithTax.Add(currPriceWithTax);

            string expectedOne = "\nTotal Tax: 0.50\nTotal Amount: 10.50\n"; 
            string actualOne = Program.printTotalTaxAndAmount(totalTax, totalAmount);
            Assert.Equal(expectedOne, actualOne);                                       

            //LINE TWO
            string itemTwoName = "imported bottle of perfume";
            float itemTwoPrice = 47.50f;

            Program.allCalculation(ref itemTwoName, ref itemTwoPrice, ref currTax, ref currPriceWithTax, ref totalTax, ref totalAmount);

            itemList.Add(itemTwoName);
            itemPriceWithTax.Add(currPriceWithTax);

            string expectedTwo = "\nTotal Tax: 7.65\nTotal Amount: 65.15\n";
            string actualTwo = Program.printTotalTaxAndAmount(totalTax, totalAmount);
            Assert.Equal(expectedTwo, actualTwo);                                       
        }

        [Fact]
        public void CheckingTotalTaxAndAmountOutput_InputThree()
        {

            List<string> itemList = new List<string>();
            List<float> itemPriceWithTax = new List<float>();

            //LINE ONE
            string itemOneName = "imported bottle of perfume";
            float itemOnePrice = 27.99f;
            float currTax = 0, currPriceWithTax = 0, totalTax = 0, totalAmount = 0;

            Program.allCalculation(ref itemOneName, ref itemOnePrice, ref currTax, ref currPriceWithTax, ref totalTax, ref totalAmount);

            itemList.Add(itemOneName);
            itemPriceWithTax.Add(currPriceWithTax);

            string expectedOne = "\nTotal Tax: 4.20\nTotal Amount: 32.20\n";
            string actualOne = Program.printTotalTaxAndAmount(totalTax, totalAmount);
            Assert.Equal(expectedOne, actualOne);                                       

            //LINE TWO
            string itemTwoName = "bottle of perfume";
            float itemTwoPrice = 18.99f;

            Program.allCalculation(ref itemTwoName, ref itemTwoPrice, ref currTax, ref currPriceWithTax, ref totalTax, ref totalAmount);

            itemList.Add(itemTwoName);
            itemPriceWithTax.Add(currPriceWithTax);

            string expectedTwo = "\nTotal Tax: 6.10\nTotal Amount: 53.10\n";
            string actualTwo = Program.printTotalTaxAndAmount(totalTax, totalAmount);
            Assert.Equal(expectedTwo, actualTwo);                                       

            //LINE THREE
            string itemThreeName = "packet of Headache Pills";
            float itemThreePrice = 9.75f;

            Program.allCalculation(ref itemThreeName, ref itemThreePrice, ref currTax, ref currPriceWithTax, ref totalTax, ref totalAmount);

            itemList.Add(itemOneName);
            itemPriceWithTax.Add(currPriceWithTax);

            string expectedThree = "\nTotal Tax: 6.10\nTotal Amount: 62.85\n";
            string actualThree = Program.printTotalTaxAndAmount(totalTax, totalAmount);
            Assert.Equal(expectedThree, actualThree);                                       

            //LINE FOUR
            string itemFourName = "imported box of chocolates";
            float itemFourPrice = 11.25f;

            Program.allCalculation(ref itemFourName, ref itemFourPrice, ref currTax, ref currPriceWithTax, ref totalTax, ref totalAmount);

            itemList.Add(itemOneName);
            itemPriceWithTax.Add(currPriceWithTax);

            string expectedFour = "\nTotal Tax: 6.65\nTotal Amount: 74.65\n";       
            string actualFour = Program.printTotalTaxAndAmount(totalTax, totalAmount);
            Assert.Equal(expectedFour, actualFour);
        }

        //EXTRA TEST CASES - You can ignore these test cases. I only created them to ensure it corrected gets the items names.
        [Fact]
        public void GettingSubstringBetween_FindingCorrectNameOfItem_OneWordName()
        {
            string line = "1 book at 12.49\n";
            string substringStart = " ";
            string substringEnd = " at ";

            String expected = "book";
            string actual = Program.getSubstringBetween(line, substringStart, substringEnd);

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void GettingSubstringBetween_FindingCorrectNameOfItem_MoreThanOneWordName()
        {
            string line = "1 imported bottle of perfume at 27.99\n";
            string substringStart = " ";
            string substringEnd = " at ";

            String expected = "imported bottle of perfume";
            string actual = Program.getSubstringBetween(line, substringStart, substringEnd);

            Assert.Equal(expected, actual);

        }
    }
}
