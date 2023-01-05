using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class Dfornecedor
    {
        private int _Id;
        private string _Empresa;
        private string _Setor_Comercial;
        private string _Tipo_Documento;
        private string _Num_Documento;
        private string _Endereco;
        private string _Telefone;
        private string _Email;
        private string _Url;
        private string _TextoBuscar;

        public int Id { get => _Id; set => _Id = value; }
        public string Empresa { get => _Empresa; set => _Empresa = value; }
        public string Setor_Comercial { get => _Setor_Comercial; set => _Setor_Comercial = value; }
        public string Tipo_Documento { get => _Tipo_Documento; set => _Tipo_Documento = value; }
        public string Num_Documento { get => _Num_Documento; set => _Num_Documento = value; }
        public string Endereco { get => _Endereco; set => _Endereco = value; }
        public string Telefone { get => _Telefone; set => _Telefone = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Url { get => _Url; set => _Url = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public Dfornecedor()
        {

        }

        public Dfornecedor(int id, string empresa, string setor_comercial, string tipo_documento, string num_documento, string endereco, string telefone, string email, string url, string textobuscar)
        {
            this.Id = id;
            this.Empresa = empresa;
            this.Setor_Comercial = setor_comercial;
            this.Tipo_Documento = tipo_documento;
            this.Num_Documento = num_documento;
            this.Endereco = endereco;
            this.Telefone = telefone;
            this.Email = email;
            this.Url = url;
            this.TextoBuscar = textobuscar;
        }
        //Método de inserir
        public string Inserir(Dfornecedor Fornecedor)
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
                SqlCmd.CommandText = "spinserir_fornecedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@idfornecedor";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParId);

                SqlParameter ParEmpresa = new SqlParameter();
                ParEmpresa.ParameterName = "@empresa";
                ParEmpresa.SqlDbType = SqlDbType.VarChar;
                ParEmpresa.Size = 50;
                ParEmpresa.Value = Fornecedor.Empresa;
                SqlCmd.Parameters.Add(ParEmpresa);

                SqlParameter ParSetorComercial = new SqlParameter();
                ParSetorComercial.ParameterName = "@setor_comercial";
                ParSetorComercial.SqlDbType = SqlDbType.VarChar;
                ParSetorComercial.Size = 50;
                ParSetorComercial.Value = Fornecedor.Setor_Comercial;
                SqlCmd.Parameters.Add(ParSetorComercial);

                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@tipo_documento";
                ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ParTipoDocumento.Size = 50;
                ParTipoDocumento.Value = Fornecedor.Tipo_Documento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@num_documento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 50;
                ParNumDocumento.Value = Fornecedor.Num_Documento;
                SqlCmd.Parameters.Add(ParNumDocumento);

                SqlParameter ParEndereco = new SqlParameter();
                ParEndereco.ParameterName = "@endereco";
                ParEndereco.SqlDbType = SqlDbType.VarChar;
                ParEndereco.Size = 150;
                ParEndereco.Value = Fornecedor.Endereco;
                SqlCmd.Parameters.Add(ParEndereco);

                SqlParameter ParTelefone = new SqlParameter();
                ParTelefone.ParameterName = "@telefone";
                ParTelefone.SqlDbType = SqlDbType.VarChar;
                ParTelefone.Size = 50;
                ParTelefone.Value = Fornecedor.Telefone;
                SqlCmd.Parameters.Add(ParTelefone);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Fornecedor.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParUrl = new SqlParameter();
                ParUrl.ParameterName = "@url";
                ParUrl.SqlDbType = SqlDbType.VarChar;
                ParUrl.Size = 50;
                ParUrl.Value = Fornecedor.Url;
                SqlCmd.Parameters.Add(ParUrl);

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
        public string Editar(Dfornecedor Fornecedor)
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
                SqlCmd.CommandText = "speditar_fornecedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@idfornecedor";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = Fornecedor.Id;
                SqlCmd.Parameters.Add(ParId);

                SqlParameter ParEmpresa = new SqlParameter();
                ParEmpresa.ParameterName = "@empresa";
                ParEmpresa.SqlDbType = SqlDbType.VarChar;
                ParEmpresa.Size = 50;
                ParEmpresa.Value = Fornecedor.Empresa;
                SqlCmd.Parameters.Add(ParEmpresa);

                SqlParameter ParSetorComercial = new SqlParameter();
                ParSetorComercial.ParameterName = "@setor_comercial";
                ParSetorComercial.SqlDbType = SqlDbType.VarChar;
                ParSetorComercial.Size = 50;
                ParSetorComercial.Value = Fornecedor.Setor_Comercial;
                SqlCmd.Parameters.Add(ParSetorComercial);

                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@tipo_documento";
                ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ParTipoDocumento.Size = 50;
                ParTipoDocumento.Value = Fornecedor.Tipo_Documento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@num_documento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 50;
                ParNumDocumento.Value = Fornecedor.Num_Documento;
                SqlCmd.Parameters.Add(ParNumDocumento);

                SqlParameter ParEndereco = new SqlParameter();
                ParEndereco.ParameterName = "@endereco";
                ParEndereco.SqlDbType = SqlDbType.VarChar;
                ParEndereco.Size = 150;
                ParEndereco.Value = Fornecedor.Endereco;
                SqlCmd.Parameters.Add(ParEndereco);

                SqlParameter ParTelefone = new SqlParameter();
                ParTelefone.ParameterName = "@telefone";
                ParTelefone.SqlDbType = SqlDbType.VarChar;
                ParTelefone.Size = 50;
                ParTelefone.Value = Fornecedor.Telefone;
                SqlCmd.Parameters.Add(ParTelefone);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Fornecedor.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParUrl = new SqlParameter();
                ParUrl.ParameterName = "@url";
                ParUrl.SqlDbType = SqlDbType.VarChar;
                ParUrl.Size = 50;
                ParUrl.Value = Fornecedor.Url;
                SqlCmd.Parameters.Add(ParUrl);

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
        public string Excluir(Dfornecedor Fornecedor)
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
                SqlCmd.CommandText = "spdeletar_fornecedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@idfornecedor";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = Fornecedor.Id;
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
            DataTable DtResultado = new DataTable("fornecedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_fornecedor";
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

        //Método Buscar Empresa
        public DataTable BuscarEmpresa(Dfornecedor Fornecedor)
        {
            DataTable DtResultado = new DataTable("fornecedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_fornecedor_empresa";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Fornecedor.TextoBuscar;
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

        //Método Buscar Documento
        public DataTable BuscarDocumento(Dfornecedor Fornecedor)
        {
            DataTable DtResultado = new DataTable("fornecedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_fornecedor_documento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Fornecedor.TextoBuscar;
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
