using System;

namespace OurStore;

public class Product {
    public int ID { get; set; }
    public string Description { get; set; }
    public double Price {get; set;}

    public Product (int id, string description, double price) {
        ID = id;
        Description = description;
        Price = price;
    }

    public override string ToString()
    {
        return $"Product: [ID: {ID}; Description: {Description}; Price: {Price}]";
    }
}