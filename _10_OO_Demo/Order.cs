using System;

namespace OurStore;

public class Order {
    public int ID { get; set; }
    public DateTime Date {get; set;}
    public decimal Total {get;}
    public OrderStatus Status {get; set;}

    public Order(int id) {
        ID = id;
        Date = DateTime.Now;
        Status = OrderStatus.Open;
    }

    public override string ToString()
    {
        return $"Order: [ID: {ID}; Date: {Date}; Total: {Total}]";
    }
}

public enum OrderStatus {
    Open,
    Completed,
    Cancelled
}