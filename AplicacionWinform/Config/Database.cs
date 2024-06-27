
using System.Data.SqlClient;

namespace AplicacionWinform.Config
{
    public class Database
    {
        private string _server = "LAPTOP-CJKKEAQ4\\MYSERVER";
        private string _database = "EstudiantesApp";
        private string _user = "sa";
        private string _password = "1234";
    
        public SqlConnection DbContext;

        public Database()
        {
            DbContext = new SqlConnection();
            DbContext.ConnectionString = $"Data source={this._server};Initial Catalog={this._database};User ID={this._user}; PWD={this._password};Connection Timeout=10";
        }

    }
}
