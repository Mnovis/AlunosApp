using System;
using System.Collections.Generic;
using System.Text;

namespace AlunosApp.Entities
{
    public class Aluno
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public string Matricula { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; } = string.Empty;
        public DateTime DataHoraCadastro { get; set; } = DateTime.Now;
    }
}
