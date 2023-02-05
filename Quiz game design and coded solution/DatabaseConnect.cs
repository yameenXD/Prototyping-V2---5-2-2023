using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Quiz_game_design_and_coded_solution
{
    public static class DatabaseConnect
    {
        

        public static DataSet dataConnect(string sql)
        {
            OleDbConnection con = Connect();
            if (con == null)
            {
                MessageBox.Show("Failed to connect to the database.");
                return null;
            }

            OleDbDataAdapter userAdapter = new OleDbDataAdapter(sql, con);

            DataSet dataSet = new DataSet();

            userAdapter.Fill(dataSet, "DATA");

            con.Close();

            return dataSet;
        }

        public static OleDbConnection Connect()
        {
            try
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0; Data Source=dbQuizGame.accdb");
                con.Open();
                return con;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to the database.");
                return null;
            }
        }

        public static void ManipulateData(string sql)
        {
            OleDbConnection con = Connect();
            if (con == null)
            {
                return;
            }

            try
            {
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data inserted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to insert data.");
            }

            con.Close();
        }
    }
}
