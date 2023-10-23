using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create lists to be used in a program
            List<Product> products = new List<Product>();
            List<Address> addresses = new List<Address>();
            List<Storage> storages = new List<Storage>();
            // Default addresses since you can't add new ones in an application
            addresses.AddRange(new Address[] { new Address("Autismo", "530-0021", "Osaka", "3", "43"), new Address("Pomorska", "80-121", "Gdańsk", "2", "1"), new Address("Malinowska", "42-254", "Częstochowa", "1", "1"), new Address("Wielkopolska","30-134","Kraków","9","10"), new Address("Wschodnia","542-321","Kandziowo","20","23")}); // Add default addresses since you can't create any in the application.
            // Loop the interface so the program dosen't end
            for (; ; )
            {
                // Create an interface
                Console.Clear();
                int temp = -2; // Used for many purposes mainly for storing an input value
                bool check = true; // Used for subinterfaces allowing them to loop theirself
                Console.Write("--- ShopManagment ---\n\n1. Storage managment\n2. Products managment\n3. Managment of products in a storage\n4. Exit\n\nYour choice: ");
                int choice = -2;
                try { choice = Convert.ToInt32(Convert.ToChar(Console.ReadKey().KeyChar).ToString()); } catch { choice = -2; }
                switch (choice)
                {
                    // Options for storage
                    case 1: // See storages
                        while (check)
                        { 
                            storageStart:
                            Console.Clear();
                            Console.Write("--- Storage managment ---\n\n1. Check\n2. Create\n3. Remove\n4. Edit\n5. Comeback\n\nYour choice: ");
                            try { choice = Convert.ToInt32(Convert.ToChar(Console.ReadKey().KeyChar).ToString()); } catch { choice = -2; }
                            switch (choice)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.Write("--- Storage managment ---");
                                    if(storages.Count == 0) // If there are not storages avaible dispaly a message and comeback
                                    { 
                                        Console.Write("\n\nThere are no storages avaible.");
                                        Console.ReadKey();
                                        goto storageStart;
                                    }
                                    for(int i = 0; i < storages.Count; i++) {Console.Write($"\n\n{i + 1}.\n   * Address: {storages.ElementAt(i).storageAddress}\n   * Products count: {storages.ElementAt(i).productsStorage.Count}");}
                                    Console.ReadKey();
                                    break;
                                case 2: // Create a storage
                                    storageCreate:
                                    Console.Clear();
                                    if (addresses.Count == 0) // If there are not addresses avaible dispaly a message and comeback
                                    {
                                        Console.Write("--- Storage managment ---\n\nThere are no addresses avaible.");
                                        Console.ReadKey();
                                        goto storageStart;
                                    }
                                    Console.Write("--- Storage managment ---\n\nChoose an available addresses:\n\n");
                                    for (int i = 0; i < addresses.Count; i++){Console.WriteLine($"{i + 1}. {addresses.ElementAt(i)}\n");}
                                    Console.Write("\nType '0' to comeback. Your choice: ");
                                    try { temp = Convert.ToInt32(Convert.ToChar(Console.ReadKey().KeyChar).ToString())-1;} catch { temp = -2; }
                                    if (temp < addresses.Count && temp > -1) // Check if selected address exists
                                    {
                                        storages.Add(new Storage(addresses.ElementAt(temp)));
                                        addresses.RemoveAt(temp);
                                        Console.Clear();
                                        Console.Write("--- Storage managment ---\n\nStorage created successfully.");
                                        Console.ReadKey();
                                    }
                                    else if (temp != -1) { goto storageCreate; } // If user type anything else than 0, loop
                                    break;
                                case 3: // Remove a storage
                                    removeStorage:
                                    Console.Clear();
                                    Console.Write("--- Storage managment ---");
                                    if (storages.Count == 0) // If there are not storages avaible dispaly a message and comeback
                                    {
                                        Console.Write("\n\nThere are no storages avaible.");
                                        Console.ReadKey();
                                        goto storageStart;
                                    }
                                    for (int i = 0; i < storages.Count; i++) { Console.Write($"\n\n{i + 1}.\n   * Address: {storages.ElementAt(i).storageAddress}\n   * Products count: {storages.ElementAt(i).productsStorage.Count}"); }
                                    Console.Write("\n\n\nType '0' to comeback. Your choice: ");
                                    try { temp = Convert.ToInt32(Convert.ToChar(Console.ReadKey().KeyChar).ToString()) - 1; } catch { temp = -2; }
                                    if (temp < storages.Count && temp > -1) // Check if selected storage exists
                                    {
                                        addresses.Add(storages.ElementAt(temp).storageAddress);
                                        storages.RemoveAt(temp);
                                        Console.Clear();
                                        Console.Write("--- Storage managment ---\n\nStorage deleted successfully.");
                                        Console.ReadKey();
                                    }
                                    else if(temp != -1) { goto removeStorage; } // If user types anything else than 0, loop
                                    break;
                                case 4: // Edit an address of a storage
                                    editStorage:
                                    int tempst = -2;
                                    Console.Clear();
                                    Console.Write("--- Storage managment ---\n\n");
                                    if (storages.Count == 0) // If there are not storages avaible dispaly a message and comeback
                                    {
                                        Console.Write("There are no storages avaible.");
                                        Console.ReadKey();
                                        goto storageStart;
                                    }
                                    Console.Write("Choose an available storage:");
                                    for (int i = 0; i < storages.Count; i++) { Console.Write($"\n\n{i + 1}.\n   * Address: {storages.ElementAt(i).storageAddress}\n   * Products count: {storages.ElementAt(i).productsStorage.Count}"); }
                                    Console.Write("\n\n\nType '0' to comeback. Your choice: ");
                                    try { tempst = Convert.ToInt32(Convert.ToChar(Console.ReadKey().KeyChar).ToString()) - 1; } catch { tempst = -2; }
                                    if (tempst < storages.Count && tempst > -1) // Check if selected storage exists
                                    {
                                        confirmEditStorage:
                                        Console.Clear();
                                        Console.Write("--- Storage managment ---\n\nChoose an available replacement address:\n\n");
                                        for (int i = 0; i < addresses.Count; i++) { Console.WriteLine($"{i + 1}. {addresses.ElementAt(i)}\n"); }
                                        Console.Write("\nType '0' to comeback. Your choice: ");
                                        try { temp = Convert.ToInt32(Convert.ToChar(Console.ReadKey().KeyChar).ToString()) - 1; } catch { temp = -2; }
                                        if (temp < addresses.Count && temp > -1) // Check if selected address exists
                                        {
                                            addresses.Add(storages.ElementAt(tempst).storageAddress);
                                            storages.ElementAt(tempst).storageAddress = addresses.ElementAt(temp);
                                            addresses.RemoveAt(temp);
                                            Console.Clear();
                                            Console.Write("--- Storage managment ---\n\nStorage edited successfully.");
                                            Console.ReadKey();
                                        }
                                        else if (temp != -1) { goto confirmEditStorage; } // If user types anything else than 0, loop
                                        else { goto editStorage; }
                                    }
                                    else if (tempst != -1) { goto editStorage; } // If user types anything else than 0, loop
                                    break;
                                case 5: // Comeback
                                    check = false;
                                    break;
                            }
                        }
                        break;
                    // Options for product
                    case 2:
                        while (check) 
                        {
                            productStart:
                            Console.Clear();
                            Console.Write("--- Product managment ---\n\n1. Check\n2. Create\n3. Remove\n4. Edit\n5. Comeback\n\nYour choice: ");
                            try { choice = Convert.ToInt32(Convert.ToChar(Console.ReadKey().KeyChar).ToString()); } catch { choice = -2; }
                            switch (choice)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.Write("--- Product managment ---");
                                    if (products.Count == 0)
                                    {
                                        Console.Write("\n\nThere are no products avaible.");
                                        Console.ReadKey();
                                        goto productStart;
                                    }
                                    for (int i = 0; i < products.Count; i++) { Console.Write($"\n\n{i + 1}.\n   * Name: {products.ElementAt(i).productName}\n   * Company: {products.ElementAt(i).companyName}\n   * Category: {products.ElementAt(i).category}\n   * Code: {products.ElementAt(i).productCode}"); }
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    string[] data = new string[4];
                                    Console.Clear();
                                    Console.Write("--- Product managment ---\n\n* Name: ");
                                    data[0] = Console.ReadLine();
                                    Console.Write("* Company: ");
                                    data[1] = Console.ReadLine();
                                    Console.Write("* Category: ");
                                    data[2] = Console.ReadLine();
                                    Console.Write("* Code: ");
                                    data[3] = Console.ReadLine();
                                    products.Add(new Product(data));
                                    Console.Clear();
                                    Console.Write("--- Product managment ---\n\nProduct created successfully.");
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    deleteProduct:
                                    Console.Clear();
                                    Console.Write("--- Product managment ---");
                                    if (products.Count == 0)
                                    {
                                        Console.Write("\n\nThere are no products avaible.");
                                        Console.ReadKey();
                                        goto productStart;
                                    }
                                    for (int i = 0; i < products.Count; i++) { Console.Write($"\n\n{i + 1}.\n   * Name: {products.ElementAt(i).productName}\n   * Company: {products.ElementAt(i).companyName}\n   * Category: {products.ElementAt(i).category}\n   * Code: {products.ElementAt(i).productCode}"); }
                                    Console.Write("\n\n\nType '0' to comeback. Your choice: ");
                                    try { temp = Convert.ToInt32(Convert.ToChar(Console.ReadKey().KeyChar).ToString()) - 1; } catch { temp = -2; }
                                    if (temp < products.Count && temp > -1) // Check if selected product exists
                                    {
                                        products.RemoveAt(temp);
                                        Console.Clear();
                                        Console.Write("--- Storage managment ---\n\nProduct deleted successfully.");
                                        Console.ReadKey();
                                    }
                                    else if (temp != -1) { goto deleteProduct; } // If user types anything else than 0, loop
                                    break;
                                case 4:
                                    editProduct:
                                    int temppr = -2;
                                    Console.Clear();
                                    Console.Write("--- Product managment ---\n\n");
                                    if (products.Count == 0)
                                    {
                                        Console.Write("There are no products avaible.");
                                        Console.ReadKey();
                                        goto productStart;
                                    }
                                    Console.Write("Choose an available product:");
                                    for (int i = 0; i < products.Count; i++) { Console.Write($"\n\n{i + 1}.\n   * Name: {products.ElementAt(i).productName}\n   * Company: {products.ElementAt(i).companyName}\n   * Category: {products.ElementAt(i).category}\n   * Code: {products.ElementAt(i).productCode}"); }
                                    Console.Write("\n\n\nType '0' to comeback. Your choice: ");
                                    try { temppr = Convert.ToInt32(Convert.ToChar(Console.ReadKey().KeyChar).ToString()) - 1; } catch { temppr = -2; }
                                    if (temppr < products.Count && temppr > -1) // Check if selected product exists
                                    {
                                    chooseProperty:
                                        Console.Clear();
                                        Console.Write("--- Storage managment ---\n\nChoose a product property:\n\n");
                                        Console.Write($"1. Name: {products.ElementAt(temppr).productName}\n2. Company: {products.ElementAt(temppr).companyName}\n3. Category: {products.ElementAt(temppr).category}\n4. Code: {products.ElementAt(temppr).productCode}");
                                        Console.Write("\n\n\nType '0' to comeback. Your choice: ");
                                        try { temp = Convert.ToInt32(Convert.ToChar(Console.ReadKey().KeyChar).ToString()) - 1; } catch { temp = -2; }
                                        if (temp < 5 && temp > -1) // Check if selected property exists
                                        {
                                            Console.Clear();
                                            Console.Write("--- Storage managment ---\n\n");
                                            switch (temp) 
                                            { 
                                                case 0:
                                                    Console.Write("Edit name: ");
                                                    products.ElementAt(temppr).productName = Console.ReadLine();
                                                    break; 
                                                case 1:
                                                    Console.Write("Edit company: ");
                                                    products.ElementAt(temppr).companyName = Console.ReadLine();
                                                    break;
                                                case 2:
                                                    Console.Write("Edit category: ");
                                                    products.ElementAt(temppr).category = Console.ReadLine();
                                                    break;
                                                case 3:
                                                    Console.Write("Edit code: ");
                                                    products.ElementAt(temppr).productCode = Console.ReadLine();
                                                    break;
                                            }
                                            goto chooseProperty;
                                        }
                                        else if (temp != -1) { goto chooseProperty; } // If user types anything else than 0, loop
                                        else { goto editProduct; }
                                    }
                                    else if (temppr != -1) { goto editProduct; } // If user types anything else than 0, loop
                                    break;
                                case 5:
                                    check = false; 
                                    break;
                            }
                        }
                        break;
                    case 3:
                        while (check) 
                        {
                            prodinStart:
                            Console.Clear();
                            Console.Write("--- Product in storage managment ---\n\n1. Check\n2. Add\n3. Remove\n4. Comeback\n\nYour choice: ");
                            try { choice = Convert.ToInt32(Convert.ToChar(Console.ReadKey().KeyChar).ToString()); } catch { choice = -2; }
                            switch (choice) 
                            {
                                case 1:
                                    Console.Clear();
                                    Console.Write("--- Product in storage managment ---");
                                    if (storages.Count == 0) // If there are not storages avaible dispaly a message and comeback
                                    {
                                        Console.Write("There are no storages avaible.");
                                        Console.ReadKey();
                                        goto prodinStart;
                                    }
                                    for (int i = 0; i < storages.Count; i++) 
                                    { 
                                        Console.Write($"\n\n{i + 1}.\n   * Address: {storages.ElementAt(i).storageAddress}");
                                        if (storages[i].productsStorage.Count == 0) { Console.Write("\n   * There are no products in this storage right now."); }
                                        else 
                                        {
                                            Console.Write("\n   * Products:"); 
                                            for (int j = 0; j < storages[i].productsStorage.Count; j++) { Console.Write($"\n     {j + 1}. * Name: {storages.ElementAt(i).productsStorage.ElementAt(j).productName}\n        * Company: {storages.ElementAt(i).productsStorage.ElementAt(j).companyName}\n        * Category: {storages.ElementAt(i).productsStorage.ElementAt(j).category}\n        * Code: {storages.ElementAt(i).productsStorage.ElementAt(j).productCode}\n"); } 
                                        }
                                    }
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    addProductsInStorageStart:
                                    Console.Clear();
                                    Console.Write("--- Product in storage managment ---");
                                    if (storages.Count == 0) // If there are not storages avaible dispaly a message and comeback
                                    {
                                        Console.Write("\n\nThere are no storages avaible.");
                                        Console.ReadKey();
                                        goto prodinStart;
                                    }
                                    else if(products.Count == 0)
                                    {
                                        Console.Write("\n\nThere are no products avaible.");
                                        Console.ReadKey();
                                        goto prodinStart;
                                    }
                                    int tempst = -2;
                                    Console.Write("\n\nChoose an available storage:");
                                    for (int i = 0; i < storages.Count; i++) { Console.Write($"\n\n{i + 1}.\n   * Address: {storages.ElementAt(i).storageAddress}\n   * Products count: {storages.ElementAt(i).productsStorage.Count}"); }
                                    Console.Write("\n\n\nType '0' to comeback. Your choice: ");
                                    try { tempst = Convert.ToInt32(Convert.ToChar(Console.ReadKey().KeyChar).ToString()) - 1; } catch { tempst = -2; }
                                    if (tempst < storages.Count && tempst > -1) // Check if selected storage exists
                                    {
                                        addProductsInStorageProduct:
                                        int temppr = -2;
                                        Console.Clear();
                                        Console.Write("--- Product in storage managment ---");
                                        Console.Write("\n\nChoose an available product:");
                                        for (int i = 0; i < products.Count; i++) {Console.Write($"\n\n{i + 1}.\n   * Name: {products.ElementAt(i).productName}\n   * Company: {products.ElementAt(i).companyName}\n   * Category: {products.ElementAt(i).category}\n   * Code: {products.ElementAt(i).productCode}"); }
                                        Console.Write("\n\n\nType '0' to comeback. Your choice: ");
                                        try { temppr = Convert.ToInt32(Convert.ToChar(Console.ReadKey().KeyChar).ToString()) - 1; } catch { temppr = -2; }
                                        if (temppr < products.Count && temppr > -1) // Check if property property exists
                                        {
                                            storages[tempst].productsStorage.Add(products[temppr]);
                                            Console.Clear();
                                            Console.Write("--- Product in storage managment ---\n\nProduct added to storage successfully.");
                                            Console.ReadKey();
                                        }
                                        else if (temppr != -1) { goto addProductsInStorageProduct; } // If user types anything else than 0, loop
                                        else { goto addProductsInStorageStart; }
                                    }
                                    else if (tempst != -1) { goto addProductsInStorageStart; } // If user types anything else than 0, loop
                                    break;
                                case 3:
                                    removeProductsInStorageStart:
                                    Console.Clear();
                                    Console.Write("--- Product in storage managment ---");
                                    if (storages.Count == 0) // If there are not storages avaible dispaly a message and comeback
                                    {
                                        Console.Write("\n\nThere are no storages avaible.");
                                        Console.ReadKey();
                                        goto prodinStart;
                                    }
                                    else if (products.Count == 0)
                                    {
                                        Console.Write("\n\nThere are no products avaible.");
                                        Console.ReadKey();
                                        goto prodinStart;
                                    }
                                    Console.Write("\n\nChoose an available storage:");
                                    for (int i = 0; i < storages.Count; i++) { Console.Write($"\n\n{i + 1}.\n   * Address: {storages.ElementAt(i).storageAddress}\n   * Products count: {storages.ElementAt(i).productsStorage.Count}"); }
                                    Console.Write("\n\n\nType '0' to comeback. Your choice: ");
                                    try { tempst = Convert.ToInt32(Convert.ToChar(Console.ReadKey().KeyChar).ToString()) - 1; } catch { tempst = -2; }
                                    if (tempst < storages.Count && tempst > -1) // Check if selected storage exists
                                    {
                                        removeProductsInStorageProduct:
                                        if (storages[tempst].productsStorage.Count == 0) 
                                        {
                                            Console.Clear();
                                            Console.Write("--- Product in storage managment ---");
                                            Console.Write("\n\nThere are no products avaible.");
                                            Console.ReadKey();
                                            goto removeProductsInStorageStart;
                                        }
                                        int temppr = -2;
                                        Console.Clear();
                                        Console.Write("--- Product in storage managment ---");
                                        Console.Write("\n\nChoose an available product:");
                                        for (int i = 0; i < storages[tempst].productsStorage.Count; i++) { Console.Write($"\n\n{i + 1}.\n   * Name: {storages[tempst].productsStorage.ElementAt(i).productName}\n   * Company: {storages[tempst].productsStorage.ElementAt(i).companyName}\n   * Category: {storages[tempst].productsStorage.ElementAt(i).category}\n   * Code: {storages[tempst].productsStorage.ElementAt(i).productCode}"); }
                                        Console.Write("\n\n\nType '0' to comeback. Your choice: ");
                                        try { temppr = Convert.ToInt32(Convert.ToChar(Console.ReadKey().KeyChar).ToString()) - 1; } catch { temppr = -2; }
                                        if (temppr < products.Count && temppr > -1) // Check if property property exists
                                        {
                                            storages[tempst].productsStorage.RemoveAt(temppr);
                                            Console.Clear();
                                            Console.Write("--- Product in storage managment ---\n\nProduct deleted from storage successfully.");
                                            Console.ReadKey();
                                        }
                                        else if (temppr != -1) { goto removeProductsInStorageProduct; } // If user types anything else than 0, loop
                                        else { goto removeProductsInStorageStart; }
                                    }
                                    else if (tempst != -1) { goto removeProductsInStorageStart; } // If user types anything else than 0, loop
                                    break;
                                case 4:
                                    check = false; 
                                    break;
                            }
                        }
                        break;
                    case 4:
                        Environment.Exit(0); // Exit the program
                        break;
                }
            }


        }

        // Classes
        class Product
        {
            public string productName;
            public string companyName;
            public string category;
            public string productCode;

            public Product(string[] data)
            {
                productName = data[0];
                companyName = data[1];
                category = data[2];
                productCode = data[3];
            }
        }
        class Storage
        {
            public List<Product> productsStorage = new List<Product>();
            public Address storageAddress;
            public Storage(Address storageAddress){this.storageAddress = storageAddress;}
        }

        class Address
        {
            public string street;
            public string postalCode;
            public string city;
            public string buildingNumber;
            public string localNumber;

            public Address(string street, string postalCode, string city, string buildingNumber, string localNumber)
            {
                this.street = street;
                this.postalCode = postalCode;
                this.city = city;
                this.buildingNumber = buildingNumber;
                this.localNumber = localNumber;
            }

            public override string ToString() {return $"{city} st. {street} {buildingNumber}/{localNumber} {postalCode}";} // Override ToString method for easier use later 
        }
    }
}