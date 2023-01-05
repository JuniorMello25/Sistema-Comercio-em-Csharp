using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CamadaDados;

namespace CamadaNegocio
{
    public class Nfuncionario
    {
        //Método inserir
        public static string Inserir(string nome, string sobrenome, string sexo, DateTime data_nascimento, string num_documento, string endereco, string telefone, string email, string acesso, string usuario, string senha)
        {
            Dfuncionario Obj = new CamadaDados.Dfuncionario();
            Obj.Nome = nome;
            Obj.Sobrenome = sobrenome;
            Obj.Sexo = sexo;
            Obj.DataNascimento = data_nascimento;
            Obj.NumDocumento = num_documento;
            Obj.Endereco = endereco;
            Obj.Telefone = telefone;
            Obj.Email = email;
            Obj.Acesso = acesso;
            Obj.Usuario = usuario;
            Obj.Senha = senha;
            return Obj.Inserir(Obj);

        }

        //Método editar
        public static string Editar(int id, string nome, string sobrenome, string sexo, DateTime data_nascimento, string num_documento, string endereco, string telefone, string email, string acesso, string usuario, string senha)
        {
            Dfuncionario Obj = new CamadaDados.Dfuncionario();
            Obj.Id = id;
            Obj.Nome = nome;
            Obj.Sobrenome = sobrenome;
            Obj.Sexo = sexo;
            Obj.DataNascimento = data_nascimento;
            Obj.NumDocumento = num_documento;
            Obj.Endereco = endereco;
            Obj.Telefone = telefone;
            Obj.Email = email;
            Obj.Acesso = acesso;
            Obj.Usuario = usuario;
            Obj.Senha = senha;
            return Obj.Editar(Obj);

        }

        //Método deletar
        public static string Excluir(int id)
        {
            Dfuncionario Obj = new CamadaDados.Dfuncionario();
            Obj.Id = id;
            return Obj.Excluir(Obj);
        }

        //Método Mostrar
        public static DataTable Mostrar()
        {
            return new Dfuncionario().Mostrar();
        }

        //Buscar nome funcionario
        public static DataTable BuscarNome(string textobuscar)
        {
            Dfuncionario Obj = new Dfuncionario();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNome(Obj);
        }
        //Buscar documento funcionario
        public static DataTable BuscarDocumento(string textobuscar)
        {
            Dfuncionario Obj = new Dfuncionario();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarDocumento(Obj);
        }
        //Login
        public static DataTable Login(string usuario, string senha)
        {
            Dfuncionario Obj = new Dfuncionario();
            Obj.Usuario = usuario;
            Obj.Senha = senha;
            return Obj.Login(Obj);
        }
    }
}

