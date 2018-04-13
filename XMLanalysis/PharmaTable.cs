using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using OpenData;
using System.Xml.Linq;
using System.Linq;

namespace XMLanalysis
{
   
    
        public class PharmaTable : MGenericsDB<PharmaceuticalFactory>
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=mDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            private static int count = 0;

            public static string getValue(XElement node, string propertyName)
            {
                return node.Element(propertyName)?.Value.Trim();
            }


            public List<PharmaceuticalFactory> Xml_Load()
            {

                XDocument docNew = XDocument.Load(@"C:\Users\user\source\repos\XmlAnalysisTeamWork\XMLanalysis\OpenData\PharmaceuticalFactory.xml");
                //Console.WriteLine(docNew.ToString());
                IEnumerable<XElement> nodes = docNew.Element("table").Elements("row");

                var nodeList = new List<PharmaceuticalFactory>();

                nodeList = nodes
                    .Select(node => {
                        var PF = new PharmaceuticalFactory();
                        PF.type = getValue(node, "Col1");
                        PF.name = getValue(node, "Col2");
                        PF.address = getValue(node, "Col3");
                        PF.formulation = getValue(node, "Col4");
                        PF.approved_items = getValue(node, "Col5");
                        PF.GMP = getValue(node, "Col6");
                        PF.GDP = getValue(node, "Col7");
                        PF.note = getValue(node, "Col8");
                        return PF;


                    }).ToList();
                return nodeList;
            }

            public void InsertData(PharmaceuticalFactory item)
            {
                count += 1;
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = string.Format($"insert into Pharma (Id,類別,名稱,地址,核准類型,核定品項,GMP核定作業內容,GDP核定內容,備註) " +
                                                            $"values ('{count}',N'{item.type}',N'{item.name}',N'{item.address}',N'{item.formulation}',N'{item.approved_items}',N'{item.GMP}',N'{item.GDP}',N'{item.note}')");
                cmd.ExecuteNonQuery();
                connection.Close();
            }

            public List<PharmaceuticalFactory> QueryData(string Row, string Name)
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = string.Format($"SELECT * FROM Pharma WHERE {Row}= N'{Name}' ");

                SqlDataReader reader = cmd.ExecuteReader();

                var mPF = new List<PharmaceuticalFactory>();
                try
                {
                    while (reader.Read())
                    {
                        PharmaceuticalFactory PF = new PharmaceuticalFactory
                        {
                            type = reader[1].ToString(),
                            name = reader[1].ToString(),
                            address = reader[1].ToString(),
                            formulation = reader[1].ToString(),
                            approved_items = reader[1].ToString(),
                            GMP = reader[1].ToString(),
                            GDP = reader[1].ToString(),
                            note = reader[1].ToString()
                        };

                        mPF.Add(PF);
                    }
                }
                finally
                {
                    reader.Close();

                }
                connection.Close();
                return mPF;
            }
            public void ShowData(List<PharmaceuticalFactory> list)
            {
                list.ForEach(item => {
                    Console.WriteLine(string.Format($"類別:{item.type} 名稱:{item.name}"));
                });
            }

        }
    
}
