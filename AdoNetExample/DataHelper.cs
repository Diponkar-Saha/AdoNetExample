using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetExample
{
    public class DataHelper
    {
        //Connectionstring.com

        private const string _connectionString = @"Server=DESKTOP-8OIA8DB\SQLEXPRESS;Database=CSharpS;User Id = sa; Password=1234;";
        public DataHelper()
        {

        }

        private SqlCommand CreateSqlCommand(string sql)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(sql, connection);
           

            return sqlCommand;
        }

        public void WriteOperation(String sql)
        {
            using SqlCommand sqlCommand = CreateSqlCommand(sql);


            sqlCommand.ExecuteNonQuery();
        }
        /*
        public void ReadOperation(String sql)
        {
            using SqlCommand sqlCommand = CreateSqlCommand(sql);


            SqlDataReader sqlDataReader= sqlCommand.ExecuteReader();


            while (sqlDataReader.Read())
            {
                int id = (int)sqlDataReader["ID"];
                string name = (string)sqlDataReader["Name"];
                decimal cgpa = (decimal)sqlDataReader["Cgpa"];

                Console.WriteLine($"ID : {id} , Name : {name} , Cgpa : {cgpa}");
            }
        }
        */
        public void InsertData()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = new SqlCommand("insert into Student([name], cgpa, dateofbirth, studentid, isactive) values('monir123', 3.2, '1984-02-02', '5D41FF10-A1E5-4B86-823D-88AEB923B029', 1)", connection);
            sqlCommand.ExecuteNonQuery();
        }

        public void UpdateData()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = new SqlCommand("update Student set name = 'moni',Cgpa = 3.2 where id=1004 ", connection);
            sqlCommand.ExecuteNonQuery();
        }




        public List<Dictionary<string, object>> ReadOperation(string sql)
        {
            using SqlCommand sqlCommand = CreateSqlCommand(sql);
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            while (reader.Read())
            {
                Dictionary<string, object> row = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row.Add(reader.GetName(i), reader.GetValue(i));
                }
                rows.Add(row);
            }

            return rows;
        }

    }
}
