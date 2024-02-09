using System;
using System.Collections.Generic;
using System.Linq;

namespace OurStore;

public class Customer {
    public string Email { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    private List<Order> orders;

    public Customer (string email, string name, string address) {
        Email = email;
        Name = name;
        Address = address;
        orders = new List<Order>();
    }

    public override string ToString()
    {
        return $"Customer: [Email:{Email}; Name: {Name}; Address: {Address}]";
    }

    //TODO: Add methods: GetCurrentOpenOrder, FindOderById

    public Order AddOrder () {
        if (GetCurrentOpenOrder() != null) {
            throw new Exception("This customer already have an open order");
        }
        Order newOrder = new Order(GetNextOrderId());
        orders.Add(newOrder);
        return newOrder;
    }

    //TODO: Validate with the PM
    // public void AddOrder (Order newOrder) {
    //     orders.Add(newOrder);
    // }

    private int GetNextOrderId()
    {
        if (orders.Count == 0) {
            return 1;
        } else {
            return orders.Last().ID + 1;
        }
    }

    public Order GetCurrentOpenOrder() {
        foreach (Order order in orders)
        {
            if (order.Status == OrderStatus.Open) {
                return order;
            }
        }
        return null;
    }
}