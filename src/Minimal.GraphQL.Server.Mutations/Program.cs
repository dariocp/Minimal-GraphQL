var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddMutationConventions(applyToAllMutations: true);

var app = builder.Build();
app.MapGraphQL();
app.UseHttpsRedirection();
app.Run();

public record Song(string Title, Author Author);
public record Author(string Name);

public class Query
{
    public List<Song> GetSongs() => Data.Songs;
}

public class Mutation
{
    public Song? AddSong(string title, string author)
    {
        var song = new Song(title, new Author(author));
        if (!Data.Songs.Contains(song)) Data.Songs.Add(song);
        return song;
    }
}

public class Data
{
    public static List<Song> Songs;

    static Data() => Songs = new()
    {
        new Song("Agradecido", new Author("Rosendo")),
        new Song("El roce de tu cuerpo", new Author("Platero y Tú"))
    };
}