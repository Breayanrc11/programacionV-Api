using Microsoft.AspNetCore.Mvc;
using ProgramacionV.Api.Models;
using ProgramacionV.Api.Repositories;
namespace ProgramacionV.Api.Controllers;
[ApiController]
[Route("api/estudiantes")]
public class EstudiantesController : ControllerBase
{
    private readonly EstudianteRepository _repository;
    public EstudiantesController(EstudianteRepository repository) { _repository = repository; }
    [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync()); //Nueva consulta por nombre
    [HttpGet("{id}")] public async Task<IActionResult> GetById(int id) { var e = await _repository.GetByIdAsync(id); return e is null ? NotFound() : Ok(e); }
    [HttpPost] public async Task<IActionResult> Create(Estudiante estudiante) { estudiante.ProgramaAcademico = null; return Ok(await _repository.CreateAsync(estudiante)); }
    [HttpPut("{id}")] public async Task<IActionResult> Update(int id, Estudiante estudiante) { estudiante.Id = id; return await _repository.UpdateAsync(estudiante) ? NoContent() : NotFound(); }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) => await _repository.DeleteAsync(id) ? NoContent() : NotFound();
}