using AlunosApp.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlunosApp.Repositories
{
    /// <summary>
    /// Repositório para realizar operações relacionadas aos alunos no banco de dados.
    /// </summary>
    public class AlunoRepository
    {
        #region Atributos Privados

        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDAlunos;Integrated Security=True;";

        #endregion

        #region Métodos

        public void InserirAluno(Aluno aluno)
        {
            // Abrindo uma conexão com o banco de dados usando a string de conexão
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Abrindo uma transação para garantir a consistência dos dados durante a inserção do aluno
                var transaction = connection.BeginTransaction();

                try
                {
                    // Implementação para inserir um aluno no banco de dados
                    connection.Execute("""
                    INSERT INTO ALUNOS(ID, NOME, MATRICULA, DATANASCIMENTO, EMAIL, DATAHORACADASTRO)
                    VALUES(@ID, @NOME, @MATRICULA, @DATANASCIMENTO, @EMAIL, @DATAHORACADASTRO)
                """, new
                    {
                        @ID = aluno.Id,
                        @NOME = aluno.Nome,
                        @MATRICULA = aluno.Matricula,
                        @DATANASCIMENTO = aluno.DataNascimento,
                        @EMAIL = aluno.Email,
                        @DATAHORACADASTRO = aluno.DataHoraCadastro
                    }, transaction);

                    // Commit da transação para confirmar a inserção do aluno no banco de dados
                    transaction.Commit();

                    Console.WriteLine("Aluno inserido com sucesso.");
                }
                catch(Exception e)
                {
                    // Rollback da transação em caso de erro durante a inserção do aluno
                    transaction.Rollback();

                    Console.WriteLine("NÃO foi possível inserir o aluno.");
                }



            }


        }
        #endregion

    }
}
