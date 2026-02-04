using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("TaskA", 5);
        priorityQueue.Enqueue("TaskB", 2);

        // Act
        string result = priorityQueue.Dequeue();

        // Assert
        Assert.AreEqual("TaskA", result); // Highest priority (5) dequeued first
    }

    [TestMethod]
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task1", 10);
        priorityQueue.Enqueue("Task2", 1);
        priorityQueue.Enqueue("Task3", 7);

        string first = priorityQueue.Dequeue();
        string second = priorityQueue.Dequeue();
        string third = priorityQueue.Dequeue();

        Assert.AreEqual("Task1", first);  // 10
        Assert.AreEqual("Task3", second); // 7
        Assert.AreEqual("Task2", third);  // 1
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_EmptyDequeue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue();
    }

    [TestMethod]
    public void TestPriorityQueue_Duplicates()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("TaskX", 3);
        priorityQueue.Enqueue("TaskY", 3);
        priorityQueue.Enqueue("TaskZ", 1);

        string first = priorityQueue.Dequeue();
        string second = priorityQueue.Dequeue();
        string third = priorityQueue.Dequeue();

        Assert.AreEqual("TaskX", first);  // first of highest priority
        Assert.AreEqual("TaskY", second); // second of same priority
        Assert.AreEqual("TaskZ", third);  // lowest priority
    }

    [TestMethod]
    public void TestPriorityQueue_NegativeNumbers()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", -5);
        priorityQueue.Enqueue("Lowest", -10);
        priorityQueue.Enqueue("Zero", 0);

        string first = priorityQueue.Dequeue();
        string second = priorityQueue.Dequeue();
        string third = priorityQueue.Dequeue();

        Assert.AreEqual("Zero", first);   // 0 = highest
        Assert.AreEqual("Low", second);   // -5
        Assert.AreEqual("Lowest", third); // -10
    }

    [TestMethod]
    public void TestPriorityQueue_LargeNumbers()
    {
        var priorityQueue = new PriorityQueue();
        for (int i = 1; i <= 100; i++)
        {
            priorityQueue.Enqueue("Task" + i, i);
        }

        string first = priorityQueue.Dequeue();
        string last = "";
        while (true)
        {
            try
            {
                last = priorityQueue.Dequeue();
            }
            catch (InvalidOperationException)
            {
                break;
            }
        }

        Assert.AreEqual("Task100", first); // largest priority
        Assert.AreEqual("Task1", last);    // smallest priority
    }
}
