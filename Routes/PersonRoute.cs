using Microsoft.EntityFrameworkCore;
using Person.Data;
using Person.Models;

namespace Person.Routes;

public static class PersonRoute
{
    public static void PersonRoutes( this WebApplication app)
    {
        var route = app.MapGroup("person");
        
        route.MapPost("", 
            async (PersonRequest req, PersonContext context) =>
        {
            var person = new PersonModel(req.Name);
            await context.AddAsync(person);
            await context.SaveChangesAsync();
        });

        route.MapGet("", async (PersonContext context) =>
        {
            var person = await context.Person.ToListAsync();
            return Results.Ok(person);
        });
        
        route.MapPut("{id:guid}", async (Guid id, PersonRequest req ,PersonContext context) =>
        {
            var person = await context.Person.FirstOrDefaultAsync(x => x.Id == id);

            if (person== null)
                return Results.NotFound();
            person.ChangeName(req.Name);
            await context.SaveChangesAsync();
            return Results.Ok("create user success");
        });
        
        route.MapDelete("{id:guid}", async (Guid id, PersonContext context) =>
        {
            var person = await context.Person.FirstOrDefaultAsync(x => x.Id == id);
            if (person == null)
                return Results.NotFound();
            context.Remove(person);
            await context.SaveChangesAsync();
            return Results.Ok("remove user success");
        });
    }
}