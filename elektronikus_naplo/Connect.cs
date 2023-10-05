using MySql.Data.MySqlClient;

namespace elektronikus_naplo
{
    public class Connect
    {
        public MySqlConnection connection;
        private string Host;
        private string DbName;
        private string UserName;
        private string Password;
        private string ConnectionString;

        public Connect()
        {
            Host = "localhost";
            DbName = "db_elektronikus_naplo";
            UserName = "root";
            Password = "";

            //ConnectionString = "Host="+Host+";Database="+DbName+";User="+UserName+";Password="+Password+";SslMode=none";

            ConnectionString = $"Host={Host};Database={DbName};User={UserName};Password={Password}";

            connection = new MySqlConnection(ConnectionString);

        }

    }
}