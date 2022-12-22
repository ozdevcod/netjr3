using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;

namespace Appbooks.data
{
    public class DataAccessAdo
    {
        public static string? ConnectionString { get; set; }
        protected DataAccessAdo()
        {

        }

        /// <summary>
        /// SqlConnectionStringBuilder.DataSource = "sqlservername";
        /// SqlConnectionStringBuilder.InitialCatalog = "databasename";
        /// SqlConnectionStringBuilder.IntegratedSecurity = true;
        /// SqlConnectionStringBuilder.TrustServerCertificate = true;
        /// SqlConnectionStringBuilder.PersistSecurityInfo = true;
        /// </summary>
        /// <returns>ConnectionString</returns>
        public static string getConnectionString()
        {

            using IHost host = Host.CreateDefaultBuilder().Build();

            IConfiguration config = host.Services.GetRequiredService<IConfiguration>();

            SqlConnectionStringBuilder conBuilder = new();

            string jsonConnString = "ConnectionString";
            string? ConnectionStringjson = config.GetValue<string>(String.Format("{0}:DefaultConnection", jsonConnString));
            string? DataSource = config.GetValue<string>(String.Format("{0}:{1}", jsonConnString, "Server"));
            string? InitialCatalog = config.GetValue<string>(String.Format("{0}:{1}", jsonConnString, "DataBase"));

            if (string.IsNullOrEmpty(ConnectionStringjson))
            {
                if (DataSource != null && InitialCatalog != null)
                {
                    bool? IntegratedSecurity = config.GetValue<bool>(String.Format("{0}:{1}", jsonConnString, "IntegratedSecurity"));
                    bool? TrustServerCertificate = config.GetValue<bool>(String.Format("{0}:{1}", jsonConnString, "TrustServerCertificate"));
                    bool? PersistSecurityInfo = config.GetValue<bool>(String.Format("{0}:{1}", jsonConnString, "PersistSecurityInfo"));

                    conBuilder.DataSource = DataSource;
                    conBuilder.InitialCatalog = InitialCatalog;
                    conBuilder.IntegratedSecurity = (bool)IntegratedSecurity;
                    conBuilder.TrustServerCertificate = (bool)(TrustServerCertificate);
                    conBuilder.PersistSecurityInfo = (bool)(PersistSecurityInfo);
                    ConnectionString = conBuilder.ConnectionString;
                }
                else
                {
                    return "server or databasename not found";
                }
            }
            else
            {
                ConnectionString = ConnectionStringjson.ToString();
            }

            return ConnectionString.ToString();
        }
    }
}