using System;
using System.Data.SqlClient;
using OpenData;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

namespace XMLanalysis
{
    public class FarmTranTable : MGenericsDB<FarmTran>
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=mDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private static int count = 0;

        public static string getValue(XElement node, string propertyName)
        {
            return node.Element(propertyName)?.Value.Trim();
        }

        public List<FarmTran> Xml_Load()
        {

            XDocument docNew = XDocument.Load(@".\..\..\..\FarmTransData.xml");
            //Console.WriteLine(docNew.ToString());
            IEnumerable<XElement> nodes = docNew.Element("DocumentElement").Elements("row");

            var nodeList = new List<FarmTran>();

            nodeList = nodes
                .Select(node => {
                    var item = new FarmTran();
                    item.transactionDate = getValue(node, "交易日期");
                    item.cropCode = getValue(node, "作物代號");
                    item.cropName = getValue(node, "作物名稱");
                    item.marketCode = getValue(node, "市場代號");
                    item.marketName = getValue(node, "市場名稱");
                    item.priceHigh = getValue(node, "上價");
                    item.priceMid = getValue(node, "中價");
                    item.priceLow = getValue(node, "下價");
                    item.priceAvg = getValue(node, "平均價");
                    item.transactionNum = getValue(node, "交易量");
                    return item;

                }).ToList();
            return nodeList;
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

        public List<FarmTran> QueryData(string searchColumn, string searchName)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = string.Format($"SELECT * FROM FarmTran WHERE {searchColumn}= N'{searchName}' ");

            SqlDataReader reader = cmd.ExecuteReader();

            var mFarm = new List<FarmTran>();
            try
            {
                while (reader.Read())
                {
                    var item = new FarmTran
                    {
                        transactionDate = reader[1].ToString(),
                        cropCode = reader[2].ToString(),
                        cropName = reader[3].ToString(),
                        marketCode = reader[4].ToString(),
                        marketName = reader[5].ToString(),
                        priceHigh = reader[6].ToString(),
                        priceMid = reader[7].ToString(),
                        priceLow = reader[8].ToString(),
                        priceAvg = reader[9].ToString(),
                        transactionNum = reader[10].ToString()
                    };
                    mFarm.Add(item);


                }
            }
            finally
            {
                reader.Close();

            }
            connection.Close();
            return mFarm;
        }

        public void ShowData(List<FarmTran> list)
        {
            list.ForEach(item => {
                Console.WriteLine(string.Format($"市場名稱:{item.marketName} 作物名稱:{item.cropName}"));
            });
        }
    }
}
