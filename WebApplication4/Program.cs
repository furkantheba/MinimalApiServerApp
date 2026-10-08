var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
int idmiz = 0;
var ListOfCars = new List<Car>();
ListOfCars.Add(new Car("Bugatti"));
ListOfCars.Add(new Car("Lambo"));
ListOfCars.Add(new Car("Volkswagen"));


app.MapGet("/ListOfCars", () => Results.Ok(ListOfCars));

app.MapPost("/ListOfCars/arabaAdi", (Verim veri) =>
{
    ListOfCars[veri.Id-1].ArabaAdi = veri.AArabaAdi;
    return Results.Ok("başarılı");
});
app.Run();

public class Car
{
    public string ArabaAdi{ get; set; }

    public Car(string ArabaAdi)
    {
        this.ArabaAdi= ArabaAdi;
    }
    
}


public class Verim
{
    public string AArabaAdi { get; set; }
    public int Id { get; set; }
}