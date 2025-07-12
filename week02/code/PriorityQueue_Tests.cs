using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Adding the data and priority to the back of queue
    // Expected Result: Should return hightest priotiry first (highernumber)
    // Defect(s) Found: was not showing the high priority and skipping the last item in list
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task1", 2);
        priorityQueue.Enqueue("Task2", 5);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Task2", result);
    }

    [TestMethod]
    // Scenario: remove the highest priority first
    // Expected Result: remove task 2
    // Defect(s) Found: not removing tasks 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task1", 3);
        priorityQueue.Enqueue("Task2", 10);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Task2", result);
    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: FIFO with items of eual priority
    // Expected Result: remove task 1 first
    // Defect(s) Found: was still taking task 2 first, removed = from dequeue saying only >
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task1", 4);
        priorityQueue.Enqueue("Task2", 4);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Task1", result);
    }

    [TestMethod]
    // Scenario: empty queue
    // Expected Result: invalid operation exeption
    // Defect(s) Found: 
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() =>
        {
            priorityQueue.Dequeue();
        });
    }

}