namespace ProjetoPortfolio.Models
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string TecnologiaUtilizadas { get; set; }
        public string LinkAcesso { get; set; }
        public string ImgVideo { get; set; }
        public int AlunoId { get; set; }
        public Aluno? Aluno { get; set; }
    }
}
