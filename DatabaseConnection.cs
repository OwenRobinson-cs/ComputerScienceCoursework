using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System;


namespace LIbraryDatabaseFormApp
{
    class SQLDBClass
    {
        private SqlConnection _con;
        private SqlDataAdapter _da;
        private DataTable _dt;
        private SqlCommand _cmd;  

        public bool FileOpen;
        public string Error;

        // A constructor that opens a specific file stored in a specific location
        public SQLDBClass()
        {
            FileOpen = true;
            try
            {
                //This is the path name that you may need to change             
                String connectionString = ConfigurationManager.
                _con = new SqlConnection(connectionString);
                _con.Open();
            }
            catch (Exception Ex)
            {
                FileOpen = false;
                Error = "Error: " + Ex.Message;
            }
        }

        // ExQuery is used to execute any SQL SELECT Statements which return a table of answers
        public DataTable ExQuery(string SqlStatement)
        {
            _cmd = new SqlCommand(SqlStatement, _con);
            _cmd.Connection = _con;

            _da = new SqlDataAdapter(_cmd);
            _dt = new DataTable();

            _da.Fill(_dt);
            return _dt;
        }

        // ExNonQuery will execute SQL INSERT, DELETE or UPDATE statements 
        // There is not always obvious evidence that the statement has been executed 
        public void ExNonQuery(string SqlStatement)
        {
            _cmd = new SqlCommand(SqlStatement, _con);
            _cmd.ExecuteNonQuery();
        }

        // ExScalarQuery execute SQL Select statements that return an integer answer e.g. Count
        public int ExScalarQuery(string SqlStatement)
        {
            _cmd = new SqlCommand(SqlStatement, _con);

            string Result = _cmd.ExecuteScalar().ToString();
            int Count = int.Parse(Result);
            return Count;
        }

    }
}
