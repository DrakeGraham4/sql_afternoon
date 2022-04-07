using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sql_afternoon.Services;
using sql_afternoon.Models;

namespace gregslist_csharp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{

    private readonly CarsService _cs;

    public CarsController(CarsService cs)
    {
        _cs = cs;
    }

    [HttpGet]
    public ActionResult<List<Car>> Get()
    {
        try
        {
            List<Car> cars = _cs.GetAll();
            return Ok(cars);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Car> GetById(int id)
    {
        try
        {
            Car car = _cs.GetById(id);
            return Ok(car);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public ActionResult<Car> Create([FromBody] Car carData)
    {
        try
        {
            Car car = _cs.Create(carData);
            return Created($"api/cars/{car.Id}", car);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Car> Update(int id, [FromBody] Car carData)
    {
        try
        {
            carData.Id = id;
            Car updated = _cs.Update(carData);
            return Ok(updated);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
        try
        {
            _cs.Delete(id);
            return Ok("Delorted");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }




}