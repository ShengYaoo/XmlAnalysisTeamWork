using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using XMLanalysis;
using System.Xml;
using System.Xml.Linq;

namespace XMLanalysis
{

    
    class PharmacyTable_03 : MGenericsDB<Pharmacy_03>
    {
   /*     SqlConnection conn;
        void ConnectTo()
        {
            var connstringbuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                AttachDBFilename = @"C:\Users\user\Source\Repos\XmlAnalysisTeamWork\XMLanalysis\App_Data\mDB.mdf",
                // connstringbuilder.InitialCatalog = "mDB.mdf";
                IntegratedSecurity = true
            };
            conn = new SqlConnection(connstringbuilder.ToString());
        }
        public PharmacyTable_03()
        {
            ConnectTo();
        }*/
        //public void insert(Pharmacy_03 p)
        //{

        //        string cmdtext = "INSERT INTO dbo.藥局資訊(機構名稱,機構狀態,地址,電話) VALUES(@機構名稱,@機構狀態,@地址,@電話)";
        //        SqlCommand cmd = new SqlCommand(cmdtext, conn);
        //        conn.Open();
        //        cmd.Parameters.AddWithValue("@機構名稱", p.機構名稱);
        //        cmd.Parameters.AddWithValue("@機構狀態", p.機構狀態);
        //        cmd.Parameters.AddWithValue("@地址", p.地址);
        //        cmd.Parameters.AddWithValue("@電話", p.電話);
        //        cmd.ExecuteNonQuery();
        //        conn.Close();

        //}

        public List<Pharmacy_03> Xml_Load()
        {
            var reader = XElement.Load(@".\..\..\OpenData\Pharmacy_03.xml");
            List<Pharmacy_03> NodeList = new List<Pharmacy_03>();
            var nodes = reader.Elements();
            NodeList = nodes
                .Where(x => !x.IsEmpty).ToList()
                .Select(node =>
                {
                    var item = new Pharmacy_03();
                    item.機構名稱 = node.Element("機構名稱")?.Value.Trim();
                    item.機構狀態 = node.Element("機構狀態")?.Value.Trim();
                    item.地址 = node.Element("地址縣市別")?.Value.Trim() +
                    node.Element("地址鄉鎮市區")?.Value.Trim() +
                    node.Element("地址街道巷弄號")?.Value.Trim();
                    item.電話 = node.Element("電話")?.Value.Trim();
                    return item;
                }).ToList();
            return NodeList;
        }

        public void InsertData(Pharmacy_03 item)
        {

            /*
            string cmdtext = "INSERT INTO 藥局資訊(機構名稱,機構狀態,地址,電話) VALUES(@機構名稱,@機構狀態,@地址,@電話)";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);

            conn.Open();
            cmd.Parameters.AddWithValue("@機構名稱", item.機構名稱);
            cmd.Parameters.AddWithValue("@機構狀態", item.機構狀態);
            cmd.Parameters.AddWithValue("@地址", item.地址);
            cmd.Parameters.AddWithValue("@電話", item.電話);
            cmd.ExecuteNonQuery();
            conn.Close();
            */
        }

        public List<Pharmacy_03> QueryData(string searchColumn, string searchName)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(int updateID, Pharmacy_03 item)
        {
            
        }

        public void DeleteData(string deleteColumn, string deletehName)
        {
            throw new NotImplementedException();
        }

        public void ShowData(List<Pharmacy_03> list)
        {
            list.ForEach(group =>
            {
                Console.WriteLine(group.機構名稱);
                Console.WriteLine(group.機構狀態);
                Console.WriteLine(group.地址);
                Console.WriteLine(group.電話);
                Console.WriteLine();
            });
        }
    }
}
