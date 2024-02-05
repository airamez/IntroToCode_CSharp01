/*
Create the OurStore Class Diagram and a Demo App
 */

using System;

namespace OurStore;

public class OurStoreApp {
    public static void Main (string[] args) {
        Customer customer1 = new Customer(
            "customer1@noemail.com",
            "Customer One",
            "1234 Street 1, San Diego, CA. 921278"
        );
        Customers customers = new();
        customers.Add(customer1);
        Customer customer2 = customers.Add("customer2@noemail.com", "Customer 2", 
                                           "4321 Street 2, San Diego, CA");
        Console.WriteLine(customer1);
        Console.WriteLine(customer2);

        Customer find1 = customers.FindByEmail("customer1@noemail.com");
        Console.WriteLine(find1);

        Customer find2 = customers.FindByEmail("customer2@noemail.com");
        find2.Address = "4321 Street 2, San Diego, CA. 92189";
        Console.WriteLine(find2);

        Customer find3 = customers.FindByEmail("customer@noemail.com");
        Console.WriteLine(find3);
    }
}