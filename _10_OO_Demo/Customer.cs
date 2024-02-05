using System;

namespace OurStore;

public class Customer {
    public string Email { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    public Customer (string email, string name, string address) {
        Email = email;
        Name = name;
        Address = address;
    }

    public override string ToString()
    {
        return $"Customer: [Email:{Email}; Name: {Name}; Address: {Address}]";
    }

    //TODO: Add methods: AddOrder, GetCurrentOpenOrder, FindOderById
}