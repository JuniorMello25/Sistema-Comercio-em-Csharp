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
    public class Nproduto
    {
        //Método inserir
        public static string Inserir(string codigo, string nome, string descricao, byte[] imagem, int idcategoria, int idapresentacao)
        {
            Dproduto Obj = new CamadaDados.Dproduto();
            Obj.Codigo = codigo;
            Obj.Nome = nome;
            Obj.Descricao = descricao;
            Obj.Imagem = imagem;
            Obj.IdCategoria = idcategoria;
            Obj.IdApresentacao = idapresentacao;
            return Obj.Inserir(Obj);

        }

        //Método editar
        public static string Editar(int id, string codigo, string nome, string descricao, byte[] imagem, int idcategoria, int idapresentacao)
        {
            Dproduto Obj = new CamadaDados.Dproduto();
            Obj.Id = id;
            Obj.Codigo = codigo;
            Obj.Nome = nome;
            Obj.Descricao = descricao;
            Obj.Imagem = imagem;
            Obj.IdCategoria = idcategoria;
            Obj.IdApresentacao = idapresentacao;
            return Obj.Editar(Obj);

        }

        //Método deletar
        public static string Excluir(int id)
        {
            Dproduto Obj = new CamadaDados.Dproduto();
            Obj.Id = id;
            return Obj.Excluir(Obj);
        }

        //Método Mostrar
        public static DataTable Mostrar()
        {
            return new Dproduto().Mostrar();
        }

        //Buscar nome
        public static DataTable BuscarNome(string textobuscar)
        {
            Dproduto Obj = new Dproduto();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNome(Obj);
        }
    }
}
