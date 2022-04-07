using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using sql_afternoon.Services;
using sql_afternoon.Models;

namespace sql_afternoon.Controllers;
[ApiController]
[Route("api/[controller]")]
public class HousesController : ControllerBase
{
    private readonly HousesService _hs;

    public HousesController(HousesService hs)
    {
        _hs = hs;
    }

    [HttpGet]
    public ActionResult<List<House>> Get()
    {
        try
        {
            List<House> houses = _hs.GetAll();
            return Ok(houses);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<House> GetById(int id)
    {
        try
        {
            House house = _hs.GetById(id);
            return Ok(house);

        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public ActionResult<House> Create([FromBody] House houseData)
    {
        try
        {
            House house = _hs.Create(houseData);
            return Created($"api/houses/{house.Id}", house);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<House> Update(int id, [FromBody] House houseData)
    {
        try
        {
            houseData.Id = id;
            House updated = _hs.Update(houseData);
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
            _hs.Delete(id);
            return Ok("Deleted House");
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }


}
