using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPortfolio.Data;
using ProjetoPortfolio.DTOs;
using ProjetoPortfolio.Models;

namespace ProjetoPortfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AlunosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CriarAluno(Aluno aluno)
        { 
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return Ok("Aluno criado com sucesso!");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlunoTurmaDto>>> GetAlunosTurma()
        {
            var listaAlunos = await _context.Alunos
                .Select(a => new AlunoTurmaDto
                {
                    Nome = a.Nome,
                    NomeTurma = a.Turma.Nome
                }).ToListAsync();

            return Ok(listaAlunos);
        }
    }
}
