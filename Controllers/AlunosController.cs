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
                    Email = a.Email,
                    NomeTurma = a.Turma.Nome
                }).ToListAsync();

            return Ok(listaAlunos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarAluno(int id, Aluno aluno)
        {
            var alunoAtual = await _context.Alunos.FindAsync(id);

            if (alunoAtual == null)
            {
                return NotFound();
            }

            alunoAtual.Nome = aluno.Nome;
            alunoAtual.Cpf = aluno.Cpf;
            alunoAtual.Email = aluno.Email;
            alunoAtual.SobreAluno = aluno.SobreAluno;
            alunoAtual.TecnologiasConhecidas = aluno.TecnologiasConhecidas;
            alunoAtual.HabilidadesCertificados = aluno.HabilidadesCertificados;
            alunoAtual.AreaAtuacaoExperiencia = aluno.AreaAtuacaoExperiencia;
            alunoAtual.FerramentasConhece = aluno.FerramentasConhece;
            alunoAtual.TurmaId = aluno.TurmaId;

            await _context.SaveChangesAsync();

            return Ok("Aluno alterado com sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return Ok("Aluno deletado com sucesso!");
        }
    }
}
