using AlunosApp.Entities;
using AlunosApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlunosApp.Services
{
    /// <summary>
    /// Serviço para realizar operações relacionadas aos alunos.
    /// </summary>
    public class AlunoService
    {
        public void CadastrarAluno()
        {
            // Implementação para inserir um aluno usando o repositório
            var aluno = new Aluno();

            Console.Write("Informe o nome do aluno: ");
            aluno.Nome = Console.ReadLine() ?? string.Empty;

            Console.Write("Informe a matrícula do aluno: ");
            aluno.Matricula = Console.ReadLine() ?? string.Empty;

            Console.Write("informe o email do aluno: ");
            aluno.Email = Console.ReadLine() ?? string.Empty;

            Console.Write("Informe a data de nascimento do aluno: ");
            aluno.DataNascimento = DateTime.Parse(Console.ReadLine() ?? string.Empty);

            // Instanciando a classe do repositório para inserir o aluno no banco de dados.
            var alunoRepository = new AlunoRepository();

            // Chamando o método InserirAluno do repositório para salvar o aluno.
            alunoRepository.InserirAluno(aluno);
        }

    }
}
