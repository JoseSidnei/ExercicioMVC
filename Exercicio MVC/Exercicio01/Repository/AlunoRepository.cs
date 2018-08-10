using Exercicio01.Database;
using Exercicio01.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Exercicio01.Repository
{
    public class AlunoRepository
    {
        public List<Aluno> ObterTodos()
        {
            List<Aluno> alunos = new List<Aluno>();
            SqlCommand command = new BancoDados().ObterConexao();

            command.CommandText = "SELECT id, nome, codigo_matricula, nota_1, nota_2, nota_3, frequencia, faltas, format(((nota_1 + nota_2 + nota_3) / 3), '#.00') FROM alunos";
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            foreach (DataRow linha in table.Rows)
            {
                Aluno aluno = new Aluno()
                {
                    Id = Convert.ToInt32(linha[0].ToString()),
                    Nome = linha[1].ToString(),
                    CodigoMatricula = linha[2].ToString(),
                    Nota1 = Convert.ToDouble(linha[3].ToString()),
                    Nota2 = Convert.ToDouble(linha[4].ToString()),
                    Nota3 = Convert.ToDouble(linha[5].ToString()),
                    Frequencia = Convert.ToByte(linha[6].ToString()),
                    Faltas = Convert.ToByte(linha[7].ToString()),
                    Media = linha[8].ToString().Replace(".", ",")
                };
                alunos.Add(aluno);
            }
            return alunos;
        }

        public int Cadastrar(Aluno aluno)
        {
            SqlCommand command = new BancoDados().ObterConexao();

            command.CommandText = @"INSERT INTO 
                alunos(nome, codigo_matricula, nota_1, nota_2, nota_3, frequencia, faltas)
                OUTPUT INSERTED.ID
                VALUES (@NOME, @CODIGO_MATRICULA, @NOTA_1, @NOTA_2, @NOTA_3, @FREQUENCIA, @FALTAS)";
            command.Parameters.AddWithValue("@NOME", aluno.Nome);
            command.Parameters.AddWithValue("@CODIGO_MATRICULA", aluno.CodigoMatricula);
            command.Parameters.AddWithValue("@NOTA_1", aluno.Nota1);
            command.Parameters.AddWithValue("@NOTA_2", aluno.Nota2);
            command.Parameters.AddWithValue("@NOTA_3", aluno.Nota3);
            command.Parameters.AddWithValue("@FREQUENCIA", aluno.Frequencia);
            command.Parameters.AddWithValue("@FALTAS", aluno.Faltas);
            int id = Convert.ToInt32(command.ExecuteScalar().ToString());
            return id;
        }

        public bool Alterar(Aluno aluno)
        {

            SqlCommand command = new BancoDados().ObterConexao();

            command.CommandText = @"UPDATE alunos
            SET nome = @NOME, codigo_matricula = @CODIGO_MATRICULA, nota_1 = @NOTA_1, nota_2 = @NOTA_2, nota_3 = @NOTA_3, frequencia = @FREQUENCIA, faltas = @FALTAS
            WHERE id = @ID";

            command.Parameters.AddWithValue("@NOME", aluno.Nome);
            command.Parameters.AddWithValue("@CODIGO_MATRICULA", aluno.CodigoMatricula);
            command.Parameters.AddWithValue("@NOTA_1", aluno.Nota1);
            command.Parameters.AddWithValue("@NOTA_2", aluno.Nota2);
            command.Parameters.AddWithValue("@NOTA_3", aluno.Nota3);
            command.Parameters.AddWithValue("@FREQUENCIA", aluno.Frequencia);
            command.Parameters.AddWithValue("@FALTAS", aluno.Faltas);
            command.Parameters.AddWithValue("@ID", aluno.Id);
            return command.ExecuteNonQuery() == 1;

        }

        public bool Excluir(int id)
        {
            SqlCommand command = new BancoDados().ObterConexao();

            command.CommandText = @"DELETE FROM alunos WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            return command.ExecuteNonQuery() == 1;
        }

        public Aluno ObterPeloId(int id)
        {
            Aluno aluno = null;

            SqlCommand command = new BancoDados().ObterConexao();

            command.CommandText = @"SELECT nome, codigo_matricula, nota_1, nota_2, nota_3, frequencia, faltas
            FROM alunos 
            WHERE id = @ID";

            command.Parameters.AddWithValue("@ID", id);

            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());

            if (table.Rows.Count == 1)
            {
                aluno = new Aluno();
                aluno.Id = id;
                aluno.Nome = table.Rows[0][0].ToString();
                aluno.CodigoMatricula = table.Rows[0][1].ToString();
                aluno.Nota1 = Convert.ToDouble(table.Rows[0][2].ToString());
                aluno.Nota2 = Convert.ToDouble(table.Rows[0][3].ToString());
                aluno.Nota3 = Convert.ToDouble(table.Rows[0][4].ToString());
                aluno.Frequencia = Convert.ToByte(table.Rows[0][5].ToString());
                aluno.Faltas = Convert.ToByte(table.Rows[0][6].ToString());
            }

            return aluno;
        }
    }
}