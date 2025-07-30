using Microsoft.EntityFrameworkCore;
using PacienteConsulta.Models;
using PacienteConsulta.Data;
namespace PacienteConsulta.Routes;

public static class ConsultaRoute
{
    public static void ConsultaRoutes(this WebApplication app)
    {
        var routes = app.MapGroup("consulta");

        routes.MapPost("",
            async (Context db, ConsultaModelDto dto) =>
            {
                var consulta= new ConsultaModel
                {
                    DataConsulta = DateTime.SpecifyKind(dto.DataConsulta, DateTimeKind.Utc),
                    Descricao = dto.Descricao,
                    PacienteId = dto.PacienteId
                };
                db.Consultas.Add(consulta);
                await db.SaveChangesAsync();
                return Results.Ok(consulta);
            });


        routes.MapGet("",
            async (Context db) =>
            {
                var consulta = await db.Consultas.ToListAsync();
                return consulta.Count==0 ? Results.NotFound("Nenhum usuario encontado") : Results.Ok(consulta);
            });
        
        routes.MapGet("{id}",
            async (Guid id, Context db) =>
            {
                var consulta = await db.Consultas.FindAsync(id);
                return consulta is null ? Results.NotFound("Nenhum usuario encontado com esse id") : Results.Ok(consulta);
            });

        routes.MapPut("{id}",
            async (Guid id, Context db, ConsultaModelDto dto) =>
            {
              var consulta = await db.Consultas.FindAsync(id);
              if (consulta is null) return Results.NotFound("Nenhum usuario encontado com esse id");
              consulta.DataConsulta = dto.DataConsulta;
              consulta.Descricao = dto.Descricao;
              consulta.PacienteId = dto.PacienteId;
              await db.SaveChangesAsync();
              return Results.Ok(consulta);
            });

        routes.MapDelete("{id}",
            async (Guid id, Context db) =>
            {
                var consulta = await db.Consultas.FindAsync(id);
                if (consulta is null) return Results.NotFound("Nenhum usuario encontado com esse id");
                db.Consultas.Remove(consulta);
                await db.SaveChangesAsync();
                return Results.Ok("Consulta deletada com sucesso");
            });
    }
}