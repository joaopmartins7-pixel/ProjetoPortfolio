using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPortfolio.Data;
using ProjetoPortfolio.Models;

namespace ProjetoPortfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProjetosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CriarProjeto(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            await _context.SaveChangesAsync();

            return Ok("Projeto criado com sucesso!");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projeto>>> GetProjetos()
        {
            return await _context.Projetos.ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarProjeto(int id, Projeto projeto)
        {
            var projetoAtual = await _context.Projetos.FindAsync(id);

            if (projetoAtual == null)
            {
                return NotFound();
            }

            projetoAtual.Titulo = projeto.Titulo;
            projetoAtual.Descricao = projeto.Descricao;
            projetoAtual.TecnologiaUtilizadas = projeto.TecnologiaUtilizadas;
            projetoAtual.LinkAcesso = projeto.LinkAcesso;
            projetoAtual.ImgVideo = projeto.ImgVideo;
            projetoAtual.AlunoId = projeto.AlunoId;

            await _context.SaveChangesAsync();

            return Ok("Projeto alterado com sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjeto(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);

            if (projeto == null)
            {
                return NotFound();
            }

            _context.Projetos.Remove(projeto);
            await _context.SaveChangesAsync();

            return Ok("Projeto deletado com sucesso!");
        }
    }
}
