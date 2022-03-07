using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoWindowsFormsBiblioteca.Databases
{
    public class FicharioSQLServer
    {
        public string mensagem;
        public bool status;
        public string tabela;
        public SQLServerClass db;

        public FicharioSQLServer(string Tabela)
        {
            status = true;
            try
            {
                db = new SQLServerClass();
                tabela = Tabela;
                mensagem = "Conexão com a tabela criada com sucesso";
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com a tabela com erro: " + ex.Message;
            }
        }

        public void Incluir(string Id, string jsonUnit)
        {
            status = true;
            try
            {
                //INSERT INTO CLIENTE (ID, JSON) VALUES ('000001' , '{...}'}

                var SQL = "INSERT INTO " + tabela + " (Id, JSON) VALUES ('" + Id + "', '" + jsonUnit + "')";
                db.SQLCommand(SQL);
                status = true;
                mensagem = "Inclusão não permitida porque o identificador já existe: " + Id;
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }

        }
        public string Buscar(string Id)
        {
            try
            {
                //SELECT ID, JSON FROM CLIENTE WHERE ID = '000001'

                var SQL = "SELECT Id, JSON FROM " + tabela + " WHERE ID = '" + Id + "'";
                var dt = db.SQLQuery(SQL);

                if (dt.Rows.Count > 0)
                {
                    string conteudo = dt.Rows[0]["JSON"].ToString();
                    status = true;
                    mensagem = "Inclusão efetuada com sucesso. Identificador: " + Id;
                    return conteudo;
                }
                else
                {
                    status = false;
                    mensagem = "Identificador não existe: " + Id;
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador: " + ex.Message;
            }
            return "";
        }
        public List<string> BuscarTodos()
        {
            status = true;
            List<string> List = new List<string>();
            try
            {
                //SELECT ID, JSON FROM CLIENTE 

                var SQL = "SELECT Id, JSON FROM " + tabela;
                var dt = db.SQLQuery(SQL);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        string conteudo = dt.Rows[i]["JSON"].ToString();
                        //string conteudo = File.ReadAllText(Arquivos[i]);
                        List.Add(conteudo);
                    }
                    return List;
                }
                else
                {
                    status = false;
                    mensagem = "Identificador não existem na base de dados";
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador: " + ex.Message;
            }
            return List;
        }

        public void Apagar(string Id)
        {
            status = true;
            try
            {
                var SQL = "SELECT Id, JSON FROM " + tabela + " WHERE ID = '" + Id + "'";
                var dt = db.SQLQuery(SQL);

                if (dt.Rows.Count > 0)
                {
                    //DELE FROM CLIENTE WHERE ID = '00010'
                    SQL = "DELETE FROM " + tabela + " WHERE ID = '" + Id + "'";
                    db.SQLCommand(SQL);
                    status = true;
                    mensagem = "Enclusão efetuada com sucesso.Identificador: " + Id;

                }
                else
                {
                    status = true;
                    mensagem = "Identificador não existe: " + Id;
                }

            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador: " + ex.Message;
            }
        }

        public void Alterar(string Id, string jsonUnit)
        {
            status = true;
            try
            {
                var SQL = "SELECT Id, JSON FROM " + tabela + " WHERE ID = '" + Id + "'";
                var dt = db.SQLQuery(SQL);

                // UPDATE CLIENTE SET JSON = '{...}' WHERE ID = '00010'

                if (dt.Rows.Count > 0)
                {
                    SQL = "UPDATE " + tabela + " SET JSON = '" + jsonUnit + "' WHERE ID = '" + Id + "'";
                    db.SQLCommand(SQL);
                    status = true;
                    mensagem = "Alteração efetuada com sucesso. Identificador: " + Id;
                }
                else
                {
                    status = false;
                    mensagem = "Alteração não permitida porque pois o identificador não existe: " + Id;
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }
        }
    }
}
