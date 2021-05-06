# ummey-zarin-tashnim

Please provide a solution to the following problem.

Sales Tax:

An online store needs to calculate sales taxed based on an items properties. These include the type (Book, Food, Medical and General)and  Imported vs Domestic.

Basic sales tax is applicable at a rate of 10% on all goods, except books, food, and medical products that are exempt. Import duty is an additional sales tax applicable on all imported goods at a rate of 5%, with no exemptions.

When I purchase items I receive a receipt which lists the name of all the items and their price (including tax), finishing with the total cost of the items, and the total amounts of sales taxes paid. 

The rounding rules for sales tax are that for a tax rate of n%, a shelf price of p contains (np/100 rounded up to the nearest 0.05) amount of sales tax.

Write an application that prints out the receipt details for these shopping baskets.

Input 1:
* 1 book at 12.49
* 1 music CD at 14.99
* 1 chocolate bar at 0.85

Input 2:
* 1 imported box of chocolates at 10.00
* 1 imported bottle of perfume at 47.50

Input 3:
* 1 imported bottle of perfume at 27.99
* 1 bottle of perfume at 18.99
* 1 packet of Headache Pills at 9.75
* 1 imported box of chocolates at 11.25


Notes:
* You are required to write this in .NET core c#, please download Visual Studio Community and create a project in there.
* Please write unit tests to cover the 3 inputs.
* A UI is not required, but feel free to create one. 
	* The only inputs allowed for the UI is the item and quantity of the item.
	* The UI should not contain inputs for imported, type of item , price or tax rates.
* You can stub API or Database calls if needed, but add comments.
* Breaking down the requirements into stories is a bonus.
