using System;
/*
# What is a Queue?
  # A queue is a type of data structure that stores elements in a sequence which is enforced by the operations used.
  # It follows the FIFO (First-In-First-Out) methodology, meaning the data that gets in first, gets out first.
  # The process to add an element into queue is called enqueue, and to remove an element from the queue is called dequeue.
# Key Operations/Properties
  # Enqueue: Add an element to the end of the queue.
  # Dequeue: Remove an element from the front of the queue.
  # Peek/Top: Get the value of the front of the queue without removing it.
  # IsEmpty: Check if the queue is empty.
  # IsFull: Check if the queue is full.
  # Length: Number of elements in the queue.
  # Capacity: Max length of the queue
# Real World Examples of Queues
  # Computer Buffers: Printers use queues to manage printing processes.
  # Call Center Systems: These use queues to hold people calling them in an order.
  # CPU Scheduling: The processes are kept into a queue according to their priority.
  # E-commerce Websites: Customers making purchases follow a queue-like structure to make payments.
  # Queue Services: Scalling system by queueing requests and processing them as fast as possible with load balance
 */
namespace DataStructures.Queue;
public class MyQueue
{
    public string Peek
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public bool IsEmpty
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public bool IsFull
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public int Length
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public int Capacity
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public MyQueue(int? capacity = null)
    {
        throw new NotImplementedException();
    }

    public void Enqueue(string data)
    {
        throw new NotImplementedException();
    }

    public string Dequeue()
    {
        throw new NotImplementedException();
    }
}