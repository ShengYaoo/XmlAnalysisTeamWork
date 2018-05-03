using System;
using System.Data.SqlClient;
using OpenData;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using XMLanalysis.Shared;

namespace XMLanalysis.Repositories
{
    public class AQITable : MGenericsDB<AQI_class>
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + SharedDB.GetDataPath() + @"mDB.mdf" + ";Integrated Security=True");


        public void DeleteData(string deleteColumn, string deletehName)
        {
            throw new NotImplementedException();
        }

        public void InsertData(AQI_class item)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = string.Format($"insert into AQI (Country,AQI,PM2.5,Status,PublishTime) " +
                                                        $"values ('{item.County}','{item.AQI}',N'{item.PM2_5}','{item.Status}',N'{item.PublishTime}')");
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public List<AQI_class> QueryData(string searchColumn, string searchName)
        {
            throw new NotImplementedException();
        }

        public void ShowData(List<AQI_class> list)
        {
  
        }

        public void UpdateData(int updateID, AQI_class item)
        {
     
        }

        public List<AQI_class> Xml_Load()
        {

            XDocument docNew = XDocument.Load(@".\..\..\OpenData\AQI.xml");
            //Console.WriteLine(docNew.ToString());
            IEnumerable<XElement> nodes = docNew.Element("AQI").Elements("Data");

            var nodeList = new List<AQI_class>();
            nodeList = nodes
                .Select(node => {
                    var item = new AQI_class();
                    item.AQI = getValue(node, "AQI");
                    item.County = getValue(node, "County");
                    item.PM2_5 = getValue(node, "PM2.5");
                    item.PublishTime = getValue(node, "PublishTime");
                    item.Status = getValue(node, "Status");
                    return item;
                }).ToList();
            return nodeList;
        }
        private static string getValue(XElement node, string v)
        {
            return node.Element(v)?.Value.Trim();
        }
    }
}
