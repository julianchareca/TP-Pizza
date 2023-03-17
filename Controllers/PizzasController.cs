using Microsoft.AspNetCore.Mvc;
using Pizzas.API.Models;
namespace Pizzas.API.Controllers;
using System;

[ApiController]
[Route("[controller]")]
public class PizzasController : ControllerBase
{
    [HttpGet]
   public IActionResult GetAll(){
    List<Pizzas> lista = BD.ObtenerPizzas();
    return Ok(lista);
   }

   [HttpGet("{id}")]
   public IActionResult GetById(int id){

    if(id < 1){
        return BadRequest();
    }
     Pizzas p = BD.ObtenerPizzas(id);
     if(p == null)
    {
        return NotFound();
    }
    return Ok(p);
   }

    [HttpPost]
    public IActionResult Create(Pizzas p){
        if(p.Nombre == null || p.Nombre == ""){
            return BadRequest();
        }
        BD.InsertarPizzas(p);
        return Ok();
    }

	[HttpPut("{id}")]
    public IActionResult Update(int id, Pizzas pizza)
    {
        if (id < 1)
        {
            return BadRequest();
        }
        if (pizza == null)
        {
            return NotFound();
        }
        BD.UpdateById(pizza);
        return Ok();
    }

    [HttpDelete("{id}")]
   public IActionResult Delete(int id){
    if(id < 1){
        return BadRequest();
    }
    Pizzas p = BD.ObtenerPizzas(id);

    if(p == null) {
        return NotFound();
    }
    BD.EliminarPizzas(id);
    return Ok();
   }
}