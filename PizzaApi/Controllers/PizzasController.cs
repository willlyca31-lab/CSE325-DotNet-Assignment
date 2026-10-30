
// PizzasController
// Provides REST API endpoints for pizza CRUD operations.

using Microsoft.AspNetCore.Mvc;
using PizzaApi.Models;
using PizzaApi.Services;

namespace PizzaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzasController : ControllerBase
{
    private readonly PizzaService _pizzaService;

    // Inject the pizza service into the controller.
    public PizzasController(PizzaService pizzaService)
    {
        _pizzaService = pizzaService;
    }

    // GET: api/pizzas
    // Retrieve all pizzas.
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll()
    {
        return Ok(_pizzaService.GetAll());
    }

    // GET: api/pizzas/1
    // Retrieve one pizza by ID.
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        Pizza? pizza = _pizzaService.Get(id);

        if (pizza == null)
        {
            return NotFound();
        }

        return Ok(pizza);
    }

    // POST: api/pizzas
    // Create a new pizza.
    [HttpPost]
    public ActionResult<Pizza> Create(Pizza pizza)
    {
        Pizza createdPizza = _pizzaService.Add(pizza);

        return CreatedAtAction(
            nameof(Get),
            new { id = createdPizza.Id },
            createdPizza
        );
    }

    // PUT: api/pizzas/1
    // Update an existing pizza.
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        bool updated = _pizzaService.Update(id, pizza);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/pizzas/1
    // Delete a pizza.
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool deleted = _pizzaService.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
