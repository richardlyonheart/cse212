using System.Formats.Asn1;
using System.Runtime.CompilerServices;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: add custoner and serve
        // Expected Result: display customer added
        Console.WriteLine("Test 1");
        var service = new CustomerService(4);
        service.AddNewCustomer();
        service.ServeCustomer();


        // Defect(s) Found: serve custiner was deleting before adding to list

        Console.WriteLine("=================");

        // Test 2
        // Scenario: can i derve more than 1 customer in order
        // Expected Result: show customers in order
        Console.WriteLine("Test 2");
        service = new CustomerService(5);
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine($"before serving order {service}");
        service.ServeCustomer();
        service.ServeCustomer();
        Console.WriteLine($"after serving. {service}");



        // Defect(s) Found: worked as espected

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        Console.WriteLine("-------------------------");
        //test 3
        //scenario if que is full show an error messsage
        //expected result error message
        Console.WriteLine("test 3");
        service = new CustomerService(1);
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine($"{service}");
        //defect found no error message, allowed to add beyond queue

        Console.WriteLine("++++++++++++++++++++++");
        //test 4
        // scenario can I serve a no customer
        //expected result not able to serve a customer that hasnt been created
        Console.WriteLine("test 4");
        service = new CustomerService(1);
        service.ServeCustomer();
        Console.WriteLine($"{service}");
        //defect: error but no message in code to let me know why code failed, added a check in serve customers to ensure there was a queue
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count <= 0)
        {
            Console.WriteLine("No customers");
        }
        else {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}