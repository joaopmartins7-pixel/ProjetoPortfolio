using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPortfolio.Data;
using ProjetoPortfolio.Models;

namespace ProjetoPortfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TurmasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CriarTurma(Turma turma)
        {
            _context.Turmas.Add(turma);
            await _context.SaveChangesAsync();

            return Ok("Turma criada com sucesso!");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turma>>> GetTurmas()
        {
            return await _context.Turmas.ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarTurma(int id, Turma turma)
        {
            var turmaAtual = await _context.Turmas.FindAsync(id);

            if (turmaAtual == null)
            {
                return NotFound();
            }

            turmaAtual.Nome = turma.Nome;
            turmaAtual.Periodo = turma.Periodo;
            turmaAtual.Professor = turma.Professor;

            await _context.SaveChangesAsync();

            return Ok("Turma alterada com sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurma(int id)
        {
            var turma = await _context.Turmas.FindAsync(id);

            if (turma == null)
            {
                return NotFound();
            }

            _context.Turmas.Remove(turma);
            await _context.SaveChangesAsync();

            return Ok("Turma deletada com sucesso!");
        }
    }
}
