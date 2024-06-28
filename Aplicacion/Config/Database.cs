using Microsoft.Data.SqlClient;

namespace Aplicacion.Config
{
    public class Database
    {//4QRXM93
        private string _server= "4QRXM93";
        private string _database= "ControlEstudiantes";
        private string _user= "sa";
        private string _password="@C75cd9ed0";

        public SqlConnection Context;

        public Database()
        {
            Context = new SqlConnection();
            Context.ConnectionString = $"Server={this._server};Database={this._database};User Id={this._user};Password={this._password};Connection Timeout=10;; TrustServerCertificate=True;";
            //Context.ConnectionString = $"Server={this._server};Database={this._database};Integrate Security=True;TrustServerCertificate=True;";
            //Context.ConnectionString = $"Server={this._server};Database={this._database};TrustServerCertificate=True;";
            Context.Open();
        }
    }
}
