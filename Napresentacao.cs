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
    public class Napresentacao
    {
        //Método inserir
        public static string Inserir(string nome, string descricao)
        {
            Dapresentacao Obj = new CamadaDados.Dapresentacao();
            Obj.Nome = nome;
            Obj.Descricao = descricao;
            return Obj.Inserir(Obj);

        }

        //Método editar
        public static string Editar(int idapresentacao, string nome, string descricao)
        {
            Dapresentacao Obj = new CamadaDados.Dapresentacao();
            Obj.Idapresentacao = idapresentacao;
            Obj.Nome = nome;
            Obj.Descricao = descricao;
            return Obj.Editar(Obj);

        }

        //Método deletar
        public static string Excluir(int idapresentacao)
        {
            Dapresentacao Obj = new CamadaDados.Dapresentacao();
            Obj.Idapresentacao = idapresentacao;
            return Obj.Excluir(Obj);
        }

        //Método Mostrar
        public static DataTable Mostrar()
        {
            return new Dapresentacao().Mostrar();
        }

        //Buscar nome
        public static DataTable BuscarNome(string textobuscar)
        {
            Dapresentacao Obj = new Dapresentacao();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNome(Obj);
        }
    }
}
