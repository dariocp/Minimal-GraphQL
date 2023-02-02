var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer().AddQueryType<Query>();

var app = builder.Build();
app.MapGraphQL();
app.UseHttpsRedirection();
app.Run();

public record Song(string Title, Author Author);
public record Author(string Name);

public class Query
{
    public List<Song> GetSongs() => new List<Song>
    {
        new Song("Agradecido", new Author("Rosendo")),
        new Song("El roce de tu cuerpo", new Author("Platero y Tú"))
    };
}