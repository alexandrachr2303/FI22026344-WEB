using System.Text;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();

//  Endpoint 

//raíz 
app.MapGet("/", () => Results.Redirect("/swagger"));

//  /include 
app.MapPost("/include/{position:int}", (
    int position,
    [FromQuery] string value,
    [FromBody] TextRequest body,
    [FromHeader(Name = "xml")] bool xml = false) =>
{
    string text = body.Text;

    if (position < 0)
        return Results.BadRequest(new { error = "'position' debe ser 0 o mayor" });
    if (string.IsNullOrWhiteSpace(value))
        return Results.BadRequest(new { error = "'value' no puede estar vacío" });
    if (string.IsNullOrWhiteSpace(text))
        return Results.BadRequest(new { error = "'text' no puede estar vacío" });

    var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
    if (position > words.Count) position = words.Count;
    words.Insert(position, value);

    var result = new ResultDto { Ori = text, New = string.Join(" ", words) };
    return xml ? ToXml(result) : Results.Json(new { ori = result.Ori, @new = result.New });
});

//replace 
app.MapPut("/replace/{length:int}", (
    int length,
    [FromQuery] string value,
    [FromBody] TextRequest body,
    [FromHeader(Name = "xml")] bool xml = false) =>
{
    string text = body.Text;

    if (length <= 0)
        return Results.BadRequest(new { error = "'length' debe ser mayor que 0" });
    if (string.IsNullOrWhiteSpace(value))
        return Results.BadRequest(new { error = "'value' no puede estar vacío" });
    if (string.IsNullOrWhiteSpace(text))
        return Results.BadRequest(new { error = "'text' no puede estar vacío" });

    var replaced = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                       .Select(w => w.Length == length ? value : w);

    var result = new ResultDto { Ori = text, New = string.Join(" ", replaced) };
    return xml ? ToXml(result) : Results.Json(new { ori = result.Ori, @new = result.New });
});

//erase 
app.MapDelete("/erase/{length:int}", (
    int length,
    [FromBody] TextRequest body,
    [FromHeader(Name = "xml")] bool xml = false) =>
{
    string text = body.Text;

    if (length <= 0)
        return Results.BadRequest(new { error = "'length' debe ser mayor que 0" });
    if (string.IsNullOrWhiteSpace(text))
        return Results.BadRequest(new { error = "'text' no puede estar vacío" });

    var filtered = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                       .Where(w => w.Length != length);

    var result = new ResultDto { Ori = text, New = string.Join(" ", filtered) };
    return xml ? ToXml(result) : Results.Json(new { ori = result.Ori, @new = result.New });
});

app.Run();

//Helper XML 
static IResult ToXml(ResultDto dto)
{
    var serializer = new XmlSerializer(typeof(ResultDto), new XmlRootAttribute("Result"));
    var sb = new StringBuilder();
    using var writer = new StringWriter(sb);
    serializer.Serialize(writer, dto);
    return Results.Text(sb.ToString(), "application/xml; charset=utf-8");
}

// DTOs
public class TextRequest
{
    public string Text { get; set; } = "";
}

public class ResultDto
{
    public string Ori { get; set; } = "";
    public string New { get; set; } = "";
}