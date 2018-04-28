using System;
using System.Data;
using System.Data.SqlClient;
using MarshalStore.Shared;

namespace MarshalStore.Infra.DataContexts
{
    public class MarshalDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public MarshalDataContext() {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }
        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}