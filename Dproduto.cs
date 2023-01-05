using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class Dproduto
    {
        private int _Id;
        private string _Codigo;
        private string _Nome;
        private string _Descricao;
        private byte[] _Imagem;
        private int _IdCategoria;
        private int _IdApresentacao;
        private string _TextoBuscar;

        public int Id { get => _Id; set => _Id = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nome { get => _Nome; set => _Nome = value; }
        public string Descricao { get => _Descricao; set => _Descricao = value; }
        public byte[] Imagem { get => _Imagem; set => _Imagem = value; }
        public int IdCategoria { get => _IdCategoria; set => _IdCategoria = value; }
        public int IdApresentacao { get => _IdApresentacao; set => _IdApresentacao = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public Dproduto()
        {

        }
        public Dproduto(int id, string codigo, string nome, string descricao, byte[] imagem, int idcategoria, int idapresentacao, string textobuscar)
        {
            this.Id = id;
            this.Codigo = codigo;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Imagem = imagem;
            this.IdCategoria = idcategoria;
            this.IdApresentacao = idapresentacao;
            this.TextoBuscar = textobuscar;
        }

        //Método de inserir
        public string Inserir(Dproduto Produto)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //codigo
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinserir_produto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParId);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Produto.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Produto.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParDescricao = new SqlParameter();
                ParDescricao.ParameterName = "@descricao";
                ParDescricao.SqlDbType = SqlDbType.VarChar;
                ParDescricao.Size = 1024;
                ParDescricao.Value = Produto.Descricao;
                SqlCmd.Parameters.Add(ParDescricao);

                SqlParameter ParImagem = new SqlParameter();
                ParImagem.ParameterName = "@imagem";
                ParImagem.SqlDbType = SqlDbType.Image;
                ParImagem.Value = Produto.Imagem;
                SqlCmd.Parameters.Add(ParImagem);

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Produto.IdCategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParIdApresentacao = new SqlParameter();
                ParIdApresentacao.ParameterName = "@idapresentacao";
                ParIdApresentacao.SqlDbType = SqlDbType.Int;
                ParIdApresentacao.Value = Produto.IdApresentacao;
                SqlCmd.Parameters.Add(ParIdApresentacao);

                //Excutar comando
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Não foi Inserido";

            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return resp;
        }
        //Método editar
        public string Editar(Dproduto Produto)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //codigo
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_produto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = Produto.Id;
                SqlCmd.Parameters.Add(ParId);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Produto.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Produto.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParDescricao = new SqlParameter();
                ParDescricao.ParameterName = "@descricao";
                ParDescricao.SqlDbType = SqlDbType.VarChar;
                ParDescricao.Size = 1024;
                ParDescricao.Value = Produto.Descricao;
                SqlCmd.Parameters.Add(ParDescricao);

                SqlParameter ParImagem = new SqlParameter();
                ParImagem.ParameterName = "@imagem";
                ParImagem.SqlDbType = SqlDbType.Image;
                ParImagem.Value = Produto.Imagem;
                SqlCmd.Parameters.Add(ParImagem);

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Produto.IdCategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParIdApresentacao = new SqlParameter();
                ParIdApresentacao.ParameterName = "@idapresentacao";
                ParIdApresentacao.SqlDbType = SqlDbType.Int;
                ParIdApresentacao.Value = Produto.IdApresentacao;
                SqlCmd.Parameters.Add(ParIdApresentacao);

                //Excutar comando
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Não foi Editado";

            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return resp;
        }
        //Método de excluir
        public string Excluir(Dproduto Produto)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //codigo
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdeletar_produto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = Produto.Id;
                SqlCmd.Parameters.Add(ParId);

                //Excutar comando
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Não foi Excluido";

            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return resp;
        }
        //Método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("produto");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_produto";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDat = new SqlDataAdapter(SqlCmd);
                sqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
        //Método Buscar nome
        public DataTable BuscarNome(Dproduto Produto)
        {
            DataTable DtResultado = new DataTable("produto");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_produto_nome";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Produto.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter sqlDat = new SqlDataAdapter(SqlCmd);
                sqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
    }
}
