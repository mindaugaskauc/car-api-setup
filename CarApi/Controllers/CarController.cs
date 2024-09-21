/**
* Author: Mindaugas Kaucikas
* Date: 2024
* Program description: CarController.cs 
*                      Controllers/CarController.cs is a value for ApiController that exposes an endpoint 
*                      for HTTP POST, GET, PUT, and DELETE verbs. These verbs call the corresponding CRUD methods 
*                      on CarService. CarService is injected into the CarController constructor.
*/

using CarApi.Services;
using CarApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarApi.Controllers;


[ApiController]
[Route("[controller]")]
public class CarController : ControllerBase
{
    CarService _service;
    
    public CarController(CarService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Car> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Car> GetById(int id)
    {
        var car = _service.GetById(id);

        if(car is not null)
        {
            return car;
        }
        else
        {
            return NotFound();
        }
    }


    [HttpPost]
    public IActionResult Create(Car newCar)
    {
        var car = _service.Create(newCar);
        return CreatedAtAction(nameof(GetById), new { id = car!.Id }, car);
    }


    [HttpPut("{id}/updateengine")]
    public IActionResult UpdateEngine(int id, int engineId)
    {
        var engineToUpdate = _service.GetById(id);

        if(engineToUpdate is not null)
        {
            _service.UpdateEngine(id, engineId);
            return NoContent();    
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPut("{id}/updategearbox")]
    public IActionResult UpdateGearbox(int id, int gearboxId)
    {
        var gearboxToUpdate = _service.GetById(id);

        if(gearboxToUpdate is not null)
        {
            _service.UpdateGearbox(id, gearboxId);
            return NoContent();    
        }
        else
        {
            return NotFound();
        }
    }

     [HttpPut("{id}/updateseatmaterial")]
    public IActionResult UpdateSeatMaterial(int id, int seatMaterialId)
    {
        var seatMaterialToUpdate = _service.GetById(id);

        if(seatMaterialToUpdate is not null)
        {
            _service.UpdateSeatMaterial(id, seatMaterialId);
            return NoContent();    
        }
        else
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var car = _service.GetById(id);

        if(car is not null)
        {
            _service.DeleteById(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
}