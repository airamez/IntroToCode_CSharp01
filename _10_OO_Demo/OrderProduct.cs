using System;

namespace OurStore;

public class OrderProduct {
    public Product Product { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public double Total { 
        get {
            return Price * Quantity;
        }
    }

    public OrderProduct (Product product, int quantity) {
        Product = product;
        Quantity = quantity;
        Price = product.Price;
    }

    public override string ToString()
    {
        return $"[ID: {Product.ID}; Description:{Product.Description}; " +
               $"Quantity: {Quantity}; Price: {Price}; Total: {Total}]";
    }

}