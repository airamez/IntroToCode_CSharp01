using System;
using System.Collections.Generic;

namespace OurStore;

public class Order {
    public int ID { get; set; }
    public DateTime Date {get; set;}
    public decimal Total {get;}
    public OrderStatus Status {get; set;}

    private List<OrderProduct> Products;

    public Order(int id) {
        ID = id;
        Date = DateTime.Now;
        Status = OrderStatus.Open;
        Products = new();
    }

    public void UpdateStatus (OrderStatus newStatus) {
        Status = newStatus;
    }

    public void AddProduct(Product product, int quantity) {
        if (Status == OrderStatus.Open) {
            OrderProduct newOrderProduct = new(product,  quantity);
            Products.Add(newOrderProduct);
        }
    }

    public override string ToString()
    {
        return $"Order: [ID: {ID}; Date: {Date}; Total: {Total}; Status:{Status}]";
    }
}

public enum OrderStatus {
    Open,
    Completed,
    Cancelled
}