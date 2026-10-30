
// PizzaService
// Handles the pizza collection and its CRUD operations.

using PizzaApi.Models;

namespace PizzaApi.Services;

public class PizzaService
{
    // Seed data: pizzas available when the API starts.
    private readonly List<Pizza> _pizzas = new()
    {
        new Pizza
        {
            Id = 1,
            Name = "Margherita",
            IsGlutenFree = false
        },

        new Pizza
        {
            Id = 2,
            Name = "Pepperoni",
            IsGlutenFree = false
        },

        new Pizza
        {
            Id = 3,
            Name = "Hawaiian",
            IsGlutenFree = false
        },

        // Additional pizza required by the assignment.
        new Pizza
        {
            Id = 4,
            Name = "Mexican Pizza",
            IsGlutenFree = false
        }
    };

    // Return all pizzas.
    public List<Pizza> GetAll()
    {
        return _pizzas;
    }

    // Return a pizza using its ID.
    public Pizza? Get(int id)
    {
        return _pizzas.FirstOrDefault(p => p.Id == id);
    }

    // Create a new pizza.
    public Pizza Add(Pizza pizza)
    {
        int nextId = _pizzas.Count == 0
            ? 1
            : _pizzas.Max(p => p.Id) + 1;

        pizza.Id = nextId;

        _pizzas.Add(pizza);

        return pizza;
    }

    // Update an existing pizza.
    public bool Update(int id, Pizza updatedPizza)
    {
        Pizza? existingPizza = Get(id);

        if (existingPizza == null)
        {
            return false;
        }

        existingPizza.Name = updatedPizza.Name;
        existingPizza.IsGlutenFree = updatedPizza.IsGlutenFree;

        return true;
    }

    // Delete a pizza using its ID.
    public bool Delete(int id)
    {
        Pizza? pizza = Get(id);

        if (pizza == null)
        {
            return false;
        }

        _pizzas.Remove(pizza);

        return true;
    }
}
