using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restorent
{
    public class CustomerOrder
    {
        private static int StartingId = 1;
        public int Id { get; private set; }
        public string Name { get; set; }
        public int TotalCups { get; set; }

        public CustomerOrder()
        {
            this.Id = GetId();
        }

        private static int GetId()
        {
            return StartingId++;
        }
    }

    class Program
        {
            static void Main(string[] args)
            {
                var queueOfCustomerOrder = new Queue<CustomerOrder>();

                while (true)
                {
                    Console.WriteLine("Simple Tea Ordering App");
                    Console.WriteLine("1. Add customer order");
                    Console.WriteLine("2. View all customer orders");
                    Console.WriteLine("3. View current customer order in preparation");
                    Console.WriteLine("4. Release current customer order");
                    Console.Write("Enter your option:");
                    var opt = Console.ReadLine();

                    switch (opt)
                    {
                        case "1":
                            var custOrder = new CustomerOrder();
                            Console.Write("Enter customer's name:");
                            custOrder.Name = Console.ReadLine();

                            Console.Write("Enter total cups:");
                            custOrder.TotalCups = Convert.ToInt16(Console.ReadLine());
                            queueOfCustomerOrder.Enqueue(custOrder);
                            Console.WriteLine("Customer order added.");

                            break;
                        case "2":
                            if (queueOfCustomerOrder.Count > 0)
                            {
                                foreach (var element in queueOfCustomerOrder)
                                    Console.WriteLine($"{element.Name} has ordered {element.TotalCups} cups. Queue number is {element.Id}");
                            }
                            else
                            {
                                Console.WriteLine("No customer order at the moment.");
                            }
                            break;
                        case "3":
                            if (queueOfCustomerOrder.Count > 0)
                            {
                                Console.WriteLine($"{queueOfCustomerOrder.Peek().Name}'s order is in preparation.");
                            }
                            else
                            {
                                Console.WriteLine("No customer order at the moment.");
                            }
                            break;
                        case "4":
                            if (queueOfCustomerOrder.Count > 0)
                            {
                                Console.WriteLine($"{queueOfCustomerOrder.Peek().Name}'s order released.");
                                queueOfCustomerOrder.Dequeue();
                            }
                            else
                            {
                                Console.WriteLine("No customer order at the moment.");
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                    Console.ReadKey();
                    Console.Clear();
                }

                Console.ReadKey();
            }
        }
    }
