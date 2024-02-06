/*
Create the OurStore Class Diagram and a Demo App
 */

using System;

namespace OurStore;

public class OurStoreApp {
    public static void Main (string[] args) {
        Customers customers = new();
        customers.Add("customer1@noemail.com","Customer One",
                      "1234 Street 1, San Diego, CA. 921278");
        customers.Add("customer2@noemail.com", "Customer 2", 
                      "4321 Street 2, San Diego, CA");

        Customer find1 = customers.FindByEmail("customer1@noemail.com");
        Console.WriteLine(find1);

        Customer find2 = customers.FindByEmail("customer2@noemail.com");
        find2.Address = "4321 Street 2, San Diego, CA. 92189";
        Console.WriteLine(find2);

        Customer find3 = customers.FindByEmail("customer@noemail.com");
        Console.WriteLine(find3);

        Product product1 = new(1, "Product 1", 10.50);
        Product product2 = new(2, "Product 2", 20.75);

        Console.WriteLine(product1);
        Console.WriteLine(product2);

        Products products = new();
        products.Add(product1);
        products.Add(product2);
        products.Add(3, "Product 3", 30.30);

        Product prod1 = products.FindById(1);
        Console.WriteLine(prod1);
        Console.WriteLine(products.FindById(2));
        Product prod4 = products.FindById(4);
        Console.WriteLine(prod4);

        customers.Print();
        products.Print();
    }
}