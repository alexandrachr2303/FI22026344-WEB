using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var list = new List<object>();

app.MapGet("/", () => Results.Redirect("/swagger"));
app.MapPost("/", ([FromHeader] bool xml = false) =>
{
    if (xml)
    {
        var serializer = new XmlSerializer(list.GetType());
        using var stringWriter = new StringWriter();
        serializer.Serialize(stringWriter, list);
        return Results.Text(stringWriter.ToString(), "application/xml");
    }
    return Results.Ok(list);
});
//Numeros Aleatorios
app.MapPut("/", ([FromForm] int quantity, [FromForm] string type) =>
{
    if (quantity <= 0)
        return Results.BadRequest(new { error = "'quantity' must be higher than zero" });

    if (type != "int" && type != "float")
        return Results.BadRequest(new { error = "'type' must be 'int' or 'float'" });

    var rnd = new Random();
    for (int i = 0; i < quantity; i++)
    {
        if (type == "int")
            list.Add(rnd.Next(0, 101));
        else
            list.Add(Math.Round(rnd.NextDouble() * 100, 2));
    }

    return Results.Ok(list);
}).DisableAntiforgery();

//Elimianr
app.MapDelete("/", ([FromForm] int quantity) =>
{
    if (quantity <= 0)
        return Results.BadRequest(new { error = "'quantity' must be higher than zero" });

    if (quantity > list.Count)
        return Results.BadRequest(new { error = $"List has only {list.Count} elements" });

    list.RemoveRange(0, quantity);
    return Results.Ok(list);
}).DisableAntiforgery();

//Patch
app.MapMethods("/", new[] { "PATCH" }, () =>
{
    list.Clear();
    return Results.Ok(list);
});

app.Run();

//https://chatgpt.com/share/68f82c20-a0b0-800c-99f9-fbf8378a7607//