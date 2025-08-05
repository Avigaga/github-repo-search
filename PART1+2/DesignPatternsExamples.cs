
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternsExamples
{
    // Singleton Pattern - ensures a class has only one instance and provides a global point of access to it.
    public class Singleton
    {
        private static Singleton _instance;
        private static readonly object _lock = new object();

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Singleton();
                    return _instance;
                }
            }
        }

        public void DoSomething()
        {
            Console.WriteLine("Singleton instance method called.");
        }
    }

    // Factory Pattern - creates objects without exposing the instantiation logic to the client.
    public abstract class Animal
    {
        public abstract void Speak();
    }

    public class Dog : Animal
    {
        public override void Speak() => Console.WriteLine("Woof!");
    }

    public class Cat : Animal
    {
        public override void Speak() => Console.WriteLine("Meow!");
    }

    public static class AnimalFactory
    {
        public static Animal CreateAnimal(string type)
        {
            return type switch
            {
                "dog" => new Dog(),
                "cat" => new Cat(),
                _ => throw new ArgumentException("Invalid animal type")
            };
        }
    }

    // Repository Pattern - abstracts data access logic and centralizes it for easier unit testing and maintainability.
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task AddAsync(Product product);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public Task<Product> GetByIdAsync(int id) =>
            Task.FromResult(_products.Find(p => p.Id == id));

        public Task<List<Product>> GetAllAsync() =>
            Task.FromResult(_products);

        public Task AddAsync(Product product)
        {
            _products.Add(product);
            return Task.CompletedTask;
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
