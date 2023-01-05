using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;
using System.Data;

namespace CamadaNegocio
{
    public class Ncategoria
    {
        //Método inserir
        public static string Inserir(string nome, string descricao)
        {
            Dcategoria Obj = new CamadaDados.Dcategoria();
            Obj.Nome = nome;
            Obj.Descricao = descricao;
            return Obj.Inserir(Obj);

        }

        //Método editar
        public static string Editar(int idcategoria, string nome, string descricao)
        {
            Dcategoria Obj = new CamadaDados.Dcategoria();
            Obj.Idcategoria = idcategoria;
            Obj.Nome = nome;
            Obj.Descricao = descricao;
            return Obj.Editar(Obj);

        }

        //Método deletar
        public static string Excluir(int idcategoria)
        {
            Dcategoria Obj = new CamadaDados.Dcategoria();
            Obj.Idcategoria = idcategoria;
            return Obj.Excluir(Obj);
        }

        //Método Mostrar
        public static DataTable Mostrar()
        {
            return new Dcategoria().Mostrar();
        }

        //Buscar nome
        public static DataTable BuscarNome(string textobuscar)
        {
            Dcategoria Obj = new Dcategoria();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNome(Obj);
        }
    }
}

