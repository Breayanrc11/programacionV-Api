using Microsoft.AspNetCore.Mvc;
using ProgramacionV.Api.Models;
using ProgramacionV.Api.Repositories;
namespace ProgramacionV.Api.Controllers;
[ApiController]
[Route("api/programas")]
public class ProgramasController : ControllerBase
{
    private readonly ProgramaRepository _repository;
    public ProgramasController(ProgramaRepository repository) { _repository = repository; }
    [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());
    [HttpGet("{id}")] public async Task<IActionResult> GetById(int id) { var p = await _repository.GetByIdAsync(id); return p is null ? NotFound() : Ok(p); }
    [HttpPost] public async Task<IActionResult> Create(ProgramaAcademico programa) => Ok(await _repository.CreateAsync(programa));
    [HttpPut("{id}")] public async Task<IActionResult> Update(int id, ProgramaAcademico programa) { programa.Id = id; return await _repository.UpdateAsync(programa) ? NoContent() : NotFound(); }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) => await _repository.DeleteAsync(id) ? NoContent() : NotFound();
}