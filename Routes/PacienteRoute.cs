using Microsoft.EntityFrameworkCore;

namespace PacienteConsulta.Routes;
using PacienteConsulta.Data;
using PacienteConsulta.Models;
public static class PacienteRoute
{
    public static void PacienteRoutes(this WebApplication app)
    {
        var routes = app.MapGroup("paciente");
        routes.MapPost("", 
            async (Context db, PacienteModelDto dto) =>
            {
                var paciente = new PacienteModel
                {
                    Nome = dto.Nome,
                    Idade = dto.Idade,
                    Sexo = dto.Sexo,
                    NumeroDoSUS = dto.NumeroDoSUS
                };
                db.Pacientes.Add(paciente);
                await db.SaveChangesAsync();
                return paciente;
            });

        routes.MapGet("",
            async (Context db) =>
            {
                var paciente = await db.Pacientes.ToListAsync();
                return paciente.Count==0 ? Results.NotFound("Nenhum usuario encontado") : Results.Ok(paciente);
            });
        routes.MapGet("{id}",
            async (Guid id, Context db) =>
            {
                var paciente = await db.Pacientes.FindAsync(id);
                return paciente is null ? Results.NotFound("Nenhum usuario encontado com esse id") : Results.Ok(paciente);
            });

        routes.MapPut("{id}",
            async (Context db,PacienteModelDto dto, Guid id) =>
            {
                 var paciente= await db.Pacientes.FindAsync(id);
                 if (paciente is null) return Results.NotFound("Nenhum usuario encontado com esse id");
                 paciente.Nome = dto.Nome;
                 paciente.Idade = dto.Idade;
                 paciente.Sexo = dto.Sexo;
                 paciente.NumeroDoSUS = dto.NumeroDoSUS;
                 await db.SaveChangesAsync();
                 return Results.Ok(paciente);
            });

        routes.MapDelete("{id}",
            async (Context db, Guid id) =>
            {
             var paciente = await db.Pacientes.FindAsync(id);
             if (paciente is null) return Results.NotFound("Nenhum usuario encontado com esse id");
             db.Pacientes.Remove(paciente);
             await db.SaveChangesAsync();
             return Results.Ok("Paciente deletado com sucesso");
            });
    }
}