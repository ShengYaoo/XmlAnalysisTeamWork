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
    public class FarmTranTable : IGenericsDB<FarmTran>
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=mDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private static int count = 0;
        FarmTran mTable;

        public void IGenericsDB(FarmTran Table)
        {
            mTable = Table;
        }

        public void InsertData(FarmTran item)
        {
            count += 1;


            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = string.Format($"insert into Farmtran (Id,交易日期,作物代號,作物名稱,市場代號,市場名稱,上價,中價,下價,平均價,交易量) " +
                                                        $"values ('{count}','{item.transactionDate}','{item.cropCode}',N'{item.cropName}','{item.marketCode}',N'{item.marketName}','{item.priceHigh}','{item.priceMid}','{item.priceLow}','{item.priceAvg}','{item.transactionNum}')");
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void QueryData(string Row, string Name)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = string.Format($"SELECT * FROM FarmTran WHERE {Row}= N'{Name}' ");

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
    public class PharmaTable : IGenericsDB<PharmaceuticalFactory>
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=mDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
            cmd.CommandText = string.Format($"insert into Pharma (Id,type,name,address,formulation,approved_items,GMP,GDP,note) " +
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
