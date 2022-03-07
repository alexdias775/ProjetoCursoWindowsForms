using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //inicializa-se os acessos a bibliotecas externas
using System.Data; //inicializa-se os acessos a bibliotecas externas

namespace CursoWindowsFormsBiblioteca.Databases
{
    public class LocalDBClass
    {
        public string stringConn; //proriedades
        public SqlConnection connDB;

        public LocalDBClass() //construtor da classe - inicilização da classe.
        {
            try
            {
                stringConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\alexd\\Documents\\Programação\\Alura\\WindowsFormsComCSharp\\ProjParte08\\CursoWindowsFormsBiblioteca\\Databases\\Fichario.mdf;Integrated Security=True";
                connDB = new SqlConnection(stringConn); //faz-se a conexão
                connDB.Open(); //abre a conexão

            }
            catch(Exception ex)
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

        public string SQLCommand (string SQL) 
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
