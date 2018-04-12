using System;
using System.Data.SqlClient;
using OpenData;
namespace XMLanalysis
{


    interface IGenericsDB<T>{
        void IGenericsDB(T mTable);
        void InsertData(T item);
        void QueryData(string Row, string Name);
    }
    public class MGenericsDB
    {
        

    }
    public class PharmaTable : IGenericsDB<PharmaceuticalFactory>
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=mDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private static int count = 0;
        PharmaceuticalFactory mTable;

        public void IGenericsDB(PharmaceuticalFactory Table)
        {
            mTable = Table;
        }

        public void InsertData(PharmaceuticalFactory item)
        {
            count += 1;

            Console.WriteLine("InsertData Exe");
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = string.Format($"insert into PharmaceuticalFactory (Id,類別,名稱,地址,核准類型,核定品項,GMP核定作業內容,GDP核定內容,備註) " +
                                                        $"values ('{count}',N'{item.type}',N'{item.name}',N'{item.address}',N'{item.formulation}',N'{item.approved_items}',N'{item.GMP}',N'{item.GDP}',N'{item.note}')");
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void QueryData(string Row, string Name)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = string.Format($"SELECT * FROM Pharma WHERE {Row}= N'{Name}' ");

            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    Console.WriteLine("Execute Query");
                    Console.WriteLine(String.Format($"{reader[0]}, {reader[1]}, {reader[2]}, {reader[3]}, {reader[4]}, {reader[5]}"));
                }
            }
            finally
            {
                reader.Close();

            }
            connection.Close();
        }
    }

}
