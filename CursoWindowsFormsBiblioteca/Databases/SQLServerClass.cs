using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CursoWindowsFormsBiblioteca.Databases
{
    public class SQLServerClass
    {
        public string stringConn; //proriedades
        public SqlConnection connDB;

        public SQLServerClass()
        {
            try
            {
                //stringConn = "Data Source=DESKTOP-IJGH1QD;Initial Catalog=ByteBank;Persist Security Info=True;User ID=sa;Password=root";
                stringConn = ConfigurationManager.ConnectionStrings["Fichario"].ConnectionString;
                /*Manter o string de conexão dentro do código é complicado porque quando eu for
                 * ter que passa-lo para a produção, eu vou ter que mudar no código isso, e às 
                 * vezes nem mesmo eu, que sou o desenvolvedor, tenho acesso a essas credenciais.
                 * É interessante que esse string de conexão fique em um arquivo externo, que eu 
                 * possa modificar esse arquivo externo sem a necessidade de ter que mudar o 
                 * código-fonte ou recompilar o sistema. Dentro da pastra bin/debug há uma arquivo com final dll.config onde é permitido
                 fazer a mudança do string externamente ápos esse processo.*/
                connDB = new SqlConnection(stringConn); //faz-se a conexão
                connDB.Open(); //abre a conexão

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable SQLQuery(string SQL)  //metódo para consulta - retorna dados - tabela em memória
        {
            DataTable dt = new DataTable();
            try
            {
                var myCommand = new SqlCommand(SQL, connDB);
                //passa-se um comando para o banco SQL e passa a conexão a ser efetuada para 
                // ser possível a comunicação
                myCommand.CommandTimeout = 0; //esperar o tempo necessário para o banco responder
                var myReader = myCommand.ExecuteReader();
                dt.Load(myReader);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public string SQLCommand(string SQL)
        //caso se queira executar um comando que não retorne dados, tipo DELETE, UPDATE, Insert
        {
            try
            {
                var myCommand = new SqlCommand(SQL, connDB);
                //passa-se um comando para o banco SQL e passa a conexão a ser efetuada para 
                // ser possível a comunicação
                myCommand.CommandTimeout = 0; //esperar o tempo necessário para o banco responder
                var myReader = myCommand.ExecuteReader();
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Close() //para fechar conexão
        {
            connDB.Close();
        }
    }
}
