using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using webapi.Data;

[ApiController]
[Route("api/endwip")]
public class EndWipController : ControllerBase
{
    private readonly IMongoCollection<endWip> _collection;

    public EndWipController(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("WebAppDatabase");
        _collection = database.GetCollection<endWip>("EndWipData");
    }

    [HttpPost]

    public IActionResult PostEndWipValue(ObjectId id, [FromBody] endWip model)
    {
        if (ModelState.IsValid)
        {
            // Set the current timestamp
            model.Timestamp = DateTime.Now;

            // Set the Id property
            model.Id = id;

            // Insert the model into the collection
            _collection.InsertOne(model);

            return Ok(); // Return an HTTP 200 OK response
        }

        return BadRequest(); // Return an HTTP 400 Bad Request response if the model is invalid
    }


}
