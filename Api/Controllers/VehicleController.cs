using Microsoft.AspNetCore.Mvc;
using Abstractions;
using Amazon.DynamoDBv2;
using Domain;
using Amazon.DynamoDBv2.DocumentModel;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleController : ControllerBase
{
    private readonly AmazonDynamoDBClient _client;

    public VehicleController(IDataClientFactory<AmazonDynamoDBClient> factory)
    {
        _client = factory.GetClient();
    }

    [HttpGet("{vin}")]
    public async Task<IActionResult> Get(string vin)
    {
        Table table = Table.LoadTable(_client, "Vehicles");
        Document vehicleDocument = await table.GetItemAsync(vin);

        var vehicle = new Vehicle{
            Vin = vehicleDocument["VIN"],
            Year = vehicleDocument["YearManufactured"],
            Make = vehicleDocument["Make"],
            Model = vehicleDocument["Model"]
        };    

        return Ok(vehicle);

    }

    [HttpPost]
    public async Task<IActionResult> Post(Vehicle vehicle)
    {
        Table table = Table.LoadTable(_client, "Vehicles");

        var vehicleDocument = new Document();
        
        vehicleDocument["VIN"] = vehicle.Vin;
        vehicleDocument["YearManufactured"] = vehicle.Year;
        vehicleDocument["Make"] = vehicle.Make;
        vehicleDocument["Model"] = vehicle.Model;

        await table.PutItemAsync(vehicleDocument);

        return Created("/vehicle/" + vehicle.Vin, vehicle);

    }
}
