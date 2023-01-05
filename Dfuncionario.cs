using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class Dfuncionario
    {
        private int _Id;
        private string _Nome;
        private string _Sobrenome;
        private string _Sexo;
        private DateTime _DataNascimento;
        private string _NumDocumento;
        private string _Endereco;
        private string _Telefone;
        private string _Email;
        private string _Acesso;
        private string _Usuario;
        private string _Senha;
        private string _TextoBuscar;

        public int Id { get => _Id; set => _Id = value; }
        public string Nome { get => _Nome; set => _Nome = value; }
        public string Sobrenome { get => _Sobrenome; set => _Sobrenome = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime DataNascimento { get => _DataNascimento; set => _DataNascimento = value; }
        public string NumDocumento { get => _NumDocumento; set => _NumDocumento = value; }
        public string Endereco { get => _Endereco; set => _Endereco = value; }
        public string Telefone { get => _Telefone; set => _Telefone = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Acesso { get => _Acesso; set => _Acesso = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Senha { get => _Senha; set => _Senha = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public Dfuncionario()
        {

        }

        public Dfuncionario(int id, string nome, string sobrenome, string sexo, DateTime datanascimento, string num_documento, string endereco, string telefone, string email, string acesso, string usuario, string senha, string textobuscar)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Sexo = sexo;
            this.DataNascimento = datanascimento;
            this.NumDocumento = num_documento;
            this.Endereco = endereco;
            this.Telefone = telefone;
            this.Email = email;
            this.Acesso = acesso;
            this.Usuario = usuario;
            this.Senha = senha;
            this.TextoBuscar = textobuscar;
        }

        //Método de inserir
        public string Inserir(Dfuncionario Funcionario)
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
                SqlCmd.CommandText = "spinserir_funcionario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@idfuncionario";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParId);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Funcionario.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParSobrenome = new SqlParameter();
                ParSobrenome.ParameterName = "@sobrenome";
                ParSobrenome.SqlDbType = SqlDbType.VarChar;
                ParSobrenome.Size = 50;
                ParSobrenome.Value = Funcionario.Sobrenome;
                SqlCmd.Parameters.Add(ParSobrenome);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 50;
                ParSexo.Value = Funcionario.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParDataNascimento = new SqlParameter();
                ParDataNascimento.ParameterName = "@data_nasc";
                ParDataNascimento.SqlDbType = SqlDbType.Date;
                ParDataNascimento.Size = 50;
                ParDataNascimento.Value = Funcionario.DataNascimento;
                SqlCmd.Parameters.Add(ParDataNascimento);

                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@num_documento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 100;
                ParNumDocumento.Value = Funcionario.NumDocumento;
                SqlCmd.Parameters.Add(ParNumDocumento);

                SqlParameter ParEndereco = new SqlParameter();
                ParEndereco.ParameterName = "@endereco";
                ParEndereco.SqlDbType = SqlDbType.VarChar;
                ParEndereco.Size = 100;
                ParEndereco.Value = Funcionario.Endereco;
                SqlCmd.Parameters.Add(ParEndereco);

                SqlParameter ParTelefone = new SqlParameter();
                ParTelefone.ParameterName = "@telefone";
                ParTelefone.SqlDbType = SqlDbType.VarChar;
                ParTelefone.Size = 50;
                ParTelefone.Value = Funcionario.Telefone;
                SqlCmd.Parameters.Add(ParTelefone);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Funcionario.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParAcesso = new SqlParameter();
                ParAcesso.ParameterName = "@acesso";
                ParAcesso.SqlDbType = SqlDbType.VarChar;
                ParAcesso.Size = 50;
                ParAcesso.Value = Funcionario.Acesso;
                SqlCmd.Parameters.Add(ParAcesso);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 50;
                ParUsuario.Value = Funcionario.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParSenha = new SqlParameter();
                ParSenha.ParameterName = "@senha";
                ParSenha.SqlDbType = SqlDbType.VarChar;
                ParSenha.Size = 50;
                ParSenha.Value = Funcionario.Senha;
                SqlCmd.Parameters.Add(ParSenha);

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
        public string Editar(Dfuncionario Funcionario)
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
                SqlCmd.CommandText = "speditar_funcionario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@idfuncionario";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = Funcionario.Id;
                SqlCmd.Parameters.Add(ParId);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Funcionario.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParSobrenome = new SqlParameter();
                ParSobrenome.ParameterName = "@sobrenome";
                ParSobrenome.SqlDbType = SqlDbType.VarChar;
                ParSobrenome.Size = 50;
                ParSobrenome.Value = Funcionario.Sobrenome;
                SqlCmd.Parameters.Add(ParSobrenome);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 50;
                ParSexo.Value = Funcionario.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParDataNascimento = new SqlParameter();
                ParDataNascimento.ParameterName = "@data_nasc";
                ParDataNascimento.SqlDbType = SqlDbType.Date;
                ParDataNascimento.Size = 50;
                ParDataNascimento.Value = Funcionario.DataNascimento;
                SqlCmd.Parameters.Add(ParDataNascimento);

                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@num_documento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 150;
                ParNumDocumento.Value = Funcionario.NumDocumento;
                SqlCmd.Parameters.Add(ParNumDocumento);

                SqlParameter ParEndereco = new SqlParameter();
                ParEndereco.ParameterName = "@endereco";
                ParEndereco.SqlDbType = SqlDbType.VarChar;
                ParEndereco.Size = 150;
                ParEndereco.Value = Funcionario.Endereco;
                SqlCmd.Parameters.Add(ParEndereco);

                SqlParameter ParTelefone = new SqlParameter();
                ParTelefone.ParameterName = "@telefone";
                ParTelefone.SqlDbType = SqlDbType.VarChar;
                ParTelefone.Size = 50;
                ParTelefone.Value = Funcionario.Telefone;
                SqlCmd.Parameters.Add(ParTelefone);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Funcionario.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParAcesso = new SqlParameter();
                ParAcesso.ParameterName = "@acesso";
                ParAcesso.SqlDbType = SqlDbType.VarChar;
                ParAcesso.Size = 50;
                ParAcesso.Value = Funcionario.Acesso;
                SqlCmd.Parameters.Add(ParAcesso);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 50;
                ParUsuario.Value = Funcionario.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParSenha = new SqlParameter();
                ParSenha.ParameterName = "@senha";
                ParSenha.SqlDbType = SqlDbType.VarChar;
                ParSenha.Size = 50;
                ParSenha.Value = Funcionario.Senha;
                SqlCmd.Parameters.Add(ParSenha);

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
        public string Excluir(Dfuncionario Funcionario)
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
                SqlCmd.CommandText = "spdeletar_funcionario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@idfuncionario";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = Funcionario.Id;
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
            DataTable DtResultado = new DataTable("funcionario");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_funcionario";
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

        //Método Buscar Funcionario Nome
        public DataTable BuscarNome(Dfuncionario Funcionario)
        {
            DataTable DtResultado = new DataTable("funcionario");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_funcionario_nome";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Funcionario.TextoBuscar;
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

        //Método Buscar pelo Documento funcionario
        public DataTable BuscarDocumento(Dfuncionario Funcionario)
        {
            DataTable DtResultado = new DataTable("funcionario");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_funcionario_documento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Funcionario.TextoBuscar;
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
        //Método Login
        public DataTable Login(Dfuncionario Funcionario)
        {
            DataTable DtResultado = new DataTable("funcionario");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "splogin";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 50;
                ParUsuario.Value = Funcionario.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParSenha = new SqlParameter();
                ParSenha.ParameterName = "@senha";
                ParSenha.SqlDbType = SqlDbType.VarChar;
                ParSenha.Size = 50;
                ParSenha.Value = Funcionario.Senha;
                SqlCmd.Parameters.Add(ParSenha);

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

