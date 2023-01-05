using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CamadaDados;

namespace CamadaNegocio
{
    public class Nfornecedor
    {
        //Método inserir
        public static string Inserir(string empresa, string setor_comercial, string tipo_documento, string num_documento, string endereco, string telefone, string email, string url)
        {
            Dfornecedor Obj = new CamadaDados.Dfornecedor();
            Obj.Empresa = empresa;
            Obj.Setor_Comercial = setor_comercial;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Endereco = endereco;
            Obj.Telefone = telefone;
            Obj.Email = email;
            Obj.Url = url;
            return Obj.Inserir(Obj);

        }

        //Método editar
        public static string Editar(int id, string empresa, string setor_comercial, string tipo_documento, string num_documento, string endereco, string telefone, string email, string url)
        {
            Dfornecedor Obj = new CamadaDados.Dfornecedor();
            Obj.Id = id;
            Obj.Empresa = empresa;
            Obj.Setor_Comercial = setor_comercial;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Endereco = endereco;
            Obj.Telefone = telefone;
            Obj.Email = email;
            Obj.Url = url;
            return Obj.Editar(Obj);

        }

        //Método deletar
        public static string Excluir(int id)
        {
            Dfornecedor Obj = new CamadaDados.Dfornecedor();
            Obj.Id = id;
            return Obj.Excluir(Obj);
        }

        //Método Mostrar
        public static DataTable Mostrar()
        {
            return new Dfornecedor().Mostrar();
        }

        //Buscar empresa
        public static DataTable BuscarEmpresa(string textobuscar)
        {
            Dfornecedor Obj = new Dfornecedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarEmpresa(Obj);
        }
        //Buscar documento
        public static DataTable BuscarDocumento(string textobuscar)
        {
            Dfornecedor Obj = new Dfornecedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarDocumento(Obj);
        }
    }
}
