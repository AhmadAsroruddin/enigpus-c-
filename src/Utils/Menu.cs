using System;
using enigpus;
using enigpus.Models;
using enigpus.Services.Implementation;

namespace EnigpusInventory.Utils
{
    public static class MenuUtil
    {
        public static string GetMenuChoice()
        {

            Console.WriteLine("Welcome to Enigpus Inventory System");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Search Book by Title");
            Console.WriteLine("3. View All Books");
            Console.WriteLine("4. Remove Book by Code");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine()!;

            return choice!;            
        }
        public static void ClearBuffer()
        {
            Console.ReadLine(); // Consume newline
        }
        public static void Menu()
        {
            string choice;
            bool keepMooving = true;
            InventoryServiceImpl inventoryServiceImpl = new InventoryServiceImpl();


            do{
                choice = GetMenuChoice();
                int year;
              
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Fill the data below : ");
                        Console.WriteLine("Enter Code : ");
                        string code = Console.ReadLine()!;
                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine()!;
                        Console.Write("Enter Publisher: ");
                        string publisher = Console.ReadLine()!;
                        Console.Write("Enter Year: ");
                        while (!int.TryParse(Console.ReadLine(), out year))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid year.");
                            Console.Write("Enter Year: ");
                        }

                        Console.Write("Is the information correct? (yes/no): ");
                        string confirmation = Console.ReadLine().ToLower();

                        if (confirmation == "yes" || confirmation == "y")
                        {
                            BookImpl book = new BookImpl(code, title, publisher, year);
                            inventoryServiceImpl.AddBook(book);
                            Console.WriteLine("Book added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Let's try entering the details again.");
                        }


                        break;
                    case "2":
                        Console.Write("Enter Title to Search: ");
                        string searchTitle = Console.ReadLine()!;
                        var foundedBook = inventoryServiceImpl.SearchBook(searchTitle);
                        if (foundedBook != null)
                        {
                            Console.WriteLine($"Code : {foundedBook.Code}");
                            Console.WriteLine($"Title : {foundedBook.Title}");
                            Console.WriteLine($"Year : {foundedBook.Year}");
                            Console.WriteLine($"Publisher : {foundedBook.Publisher}");
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Book not found.");
                        }
                        break;
                    case "3":
                        int index = 1;
                        if(inventoryServiceImpl.GetAllBooks().Count > 0)
                        {
                            foreach (var b in inventoryServiceImpl.GetAllBooks())
                            {
                                Console.WriteLine("");
                                Console.WriteLine($"Book number {index}");
                                Console.WriteLine($"Code : {b.Code}");
                                Console.WriteLine($"Title : {b.Title}");
                                Console.WriteLine($"Year : {b.Year}");
                                Console.WriteLine($"Publisher : {b.Publisher}");
                                Console.WriteLine("");
                                index++;
                            }
                        } else {
                            Console.WriteLine("No Book Available");
                        }
                        break;
                    case "4":
                        Console.WriteLine("What book do you wanna delete ? write the book's code");
                        string deletedBook = Console.ReadLine()!;
                        inventoryServiceImpl.RemoveBook(deletedBook);

                        break;
                    case "5":
                        Console.WriteLine("Dada");
                        keepMooving =  false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                        break;
                }
                
                
            } while (keepMooving);
        }
    }
}
