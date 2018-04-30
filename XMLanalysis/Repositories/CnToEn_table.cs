using System;
using System.Data.SqlClient;
using OpenData;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using XMLanalysis.Shared;


namespace XMLanalysis
{
    class CnToEn_table : MGenericsDB<CnToEn>
    {
        //连接资料库
        SqlConnection connection    
            = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" 
                + SharedDB.GetDataPath() 
                + @"mDB.mdf" 
                + ";Integrated Security=True");

        //private static int count = 0;

        //取值函数
        public static string getValue(XElement node, string propertyName)
        {
            return node.Element(propertyName)?.Value.Trim();
        }

        //删除函数
        public void DeleteData(string deleteColumn, string deleteName)
        {

        }

        //插入
        public void InsertData(CnToEn item)
        {
            
        }

        //查询
        public List<CnToEn> QueryData(string searchColumn, string searchName)
        {
            connection.Open();//打开数据库
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = string.Format($"SELECT * FROM CnToEn WHERE {searchColumn}= N'{searchName}' ");

            SqlDataReader reader = cmd.ExecuteReader();

            var mFarm = new List<CnToEn>();
            try
            {
                while (reader.Read())
                {
                    var item = new CnToEn
                    {
                        Postcode = reader[1].ToString(),
                        Loc = reader[2].ToString(),
                        Name = reader[3].ToString(),
                        
                        
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

        //Show
        public void ShowData(List<CnToEn> list)
        {
            list.ForEach(item => {
                Console.WriteLine(string.Format($"邮编: {item.Postcode} 英文名: {item.Name} 地址: {item.Loc}"));
            });

        }

        //上传函数
        public void UpdateData(int updateID, CnToEn item)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = string.Format($"UPDATE Farmtran SET Col = '{item.Postcode}', Col2 = '{item.Loc}', 作物名稱 = N'{item.Name}' WHERE ID = {updateID} ");
            cmd.ExecuteNonQuery();
            connection.Close();

            throw new NotImplementedException();
        }


        //读取XML
        public List<CnToEn> Xml_Load()
        {

            XDocument docNew = XDocument.Load(@".\..\..\OpenData\CnToEn.xml");//打開xml位置

            IEnumerable<XElement> nodes = docNew.Element("table").Elements("row");
            var nodeList = new List<CnToEn>();
            nodeList = nodes
                .Select(node => {
                    var item = new CnToEn();
                    item.Postcode = getValue(node, "Col1");
                    item.Loc = getValue(node, "Col2");
                    item.Name = getValue(node, "Col3");
                    return item;
                }).ToList();

            return nodeList;

            
        }
    }
}
