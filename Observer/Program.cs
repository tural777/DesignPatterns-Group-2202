using System;
using System.Collections.Generic;

namespace Observer // Müşahidəçi
{
    // Also known as: Event-Subscriber, Listener


    // Subject   - Publisher 
    // Observers - Subscribers



    // Publisher
    class ProductManager
    {
        private List<Observer> _observers = new List<Observer>();

        public void UpdatePrice()
        {
            // Some hard code
            Notify("Product price changed!");
        }

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        private void Notify(string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(message);
            }
        }
    }



    // Observers
    abstract class Observer
    {
        public abstract void Update(string message);
    }


    class CustomerObserver : Observer
    {
        public override void Update(string message)
        {
            Console.WriteLine($"Message to customer: {message}");
        }
    }

    class EmployeeObserver : Observer
    {
        public override void Update(string message)
        {
            Console.WriteLine($"Message to employee: {message}");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager();

            var customer = new CustomerObserver();
            var employee = new EmployeeObserver();

            productManager.Attach(customer);
            productManager.Attach(employee);

            productManager.UpdatePrice();

            productManager.Detach(employee);
            Console.WriteLine();
            productManager.UpdatePrice();
        }
    }
}