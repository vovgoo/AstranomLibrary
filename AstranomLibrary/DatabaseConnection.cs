using System;
using System.Data;
using System.Data.OleDb;

namespace AstranomLibrary
{
    internal class DatabaseConnection
    {
        private static DatabaseConnection instance = null;
        private static readonly object padlock = new object();
        private OleDbConnection connection;

        private DatabaseConnection()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=K:\Для программ\source\repos\AstranomLibrary\AstranomLibrary\Database.accdb";
            connection = new OleDbConnection(connectionString);
        }

        public static DatabaseConnection Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DatabaseConnection();
                    }
                    return instance;
                }
            }
        }

        private void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        private void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public DataTable ExecuteSelectQuery(string query, OleDbParameter[] parameters)
        {
            try
            {
                OleDbCommand command = new OleDbCommand(query, connection);
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка выполенения SELECT запроса.", ex);
            }
        }

        public int ExecuteNonQuery(string query, OleDbParameter[] parameters)
        {
            try
            {
                OleDbCommand command = new OleDbCommand(query, connection);
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                OpenConnection();
                int result = command.ExecuteNonQuery();
                CloseConnection();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка выполнения UPDATE или DELETE запроса.", ex);
            }
        }


        public int ExecuteTransaction(string[] queries, OleDbParameter[][] parameters)
        {
            OpenConnection();
            OleDbTransaction transaction = connection.BeginTransaction();

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.Transaction = transaction;

            try
            {
                int rowsAffected = 0;

                for (int i = 0; i < queries.Length; i++)
                {
                    command.CommandText = queries[i];
                    command.Parameters.Clear();

                    if (parameters != null && parameters[i] != null)
                    {
                        command.Parameters.AddRange(parameters[i]);
                    }

                    rowsAffected += command.ExecuteNonQuery();
                }

                transaction.Commit();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Ошибка выполнения транзакция.", ex);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
