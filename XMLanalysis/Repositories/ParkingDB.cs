using System;
using System.Data.SqlClient;
using System.Collections.Generic;

using OpenData;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using XMLanalysis.Shared;
//http://json2csharp.com/
namespace XMLanalysis

{
    public class ParkingDB : MGenericsDB<桃園公共自行車即時服務資料>
    {
        public static List<桃園公共自行車即時服務資料> cacheList;

        //我不喜歡用SQL啦qq
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + SharedDB.GetDataPath() + @"mDB.mdf" + ";Integrated Security=True");

        private static int count = 0;

        public void InsertData(桃園公共自行車即時服務資料 item)
        {
            cacheList.Add(item);

            count += 1;
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = string.Format($"insert into 桃園公共自行車即時服務資料 (areaId, areaName, parkName, totalSpace, surplusSpace, payGuide, introduction, address, wgsx, wgsy, parkId) " +
                                                        $"values ('{item.areaId}','{item.areaName}',N'{item.parkName}','{item.totalSpace}',N'{item.surplusSpace}','{item.payGuide}','{item.introduction}','{item.wgsx}','{item.wgsy}','{item.parkId}')");
            cmd.ExecuteNonQuery();
            connection.Close();

        }

        public void UpdateData(int updateID, 桃園公共自行車即時服務資料 item)
        {
            cacheList[updateID] = item;
        }

        public List<桃園公共自行車即時服務資料> QueryData(string searchColumn, string searchName)
        {
            connection.Open();
            string cmdtext = $"SELECT * FROM 桃園公共自行車即時服務資料 WHERE {searchColumn}= N'{searchName}' ";
            SqlCommand cmd = new SqlCommand(cmdtext, connection);
            SqlDataReader obj_results = cmd.ExecuteReader();
            List<桃園公共自行車即時服務資料> NodeList = new List<桃園公共自行車即時服務資料>();
            while (obj_results.Read())
            {
                var newitem = new 桃園公共自行車即時服務資料();

                newitem.address = obj_results["address"].ToString();
                newitem.areaId = obj_results["areaId"].ToString();
                newitem.areaName = obj_results["areaName"].ToString();
                newitem.parkName = obj_results["parkName"].ToString();

                newitem.totalSpace = uint.Parse(obj_results["totalSpace"].ToString());

                newitem.surplusSpace = obj_results["surplusSpace"].ToString();

                newitem.payGuide = obj_results["payGuide"].ToString();
                newitem.introduction = obj_results["introduction"].ToString();

                newitem.wgsx = double.Parse(obj_results["wgsX"].ToString());
                newitem.wgsy = double.Parse(obj_results["wgsY"].ToString());
                newitem.parkId = obj_results["parkId"].ToString();

                NodeList.Add(newitem);
            }
            obj_results.Close();
            connection.Close();
            return NodeList;
        }

        public void ShowData(List<桃園公共自行車即時服務資料> list = null)
        {
            if (list == null)
                list = cacheList;

            list.ForEach(data =>
            {
                System.Console.Write(data.areaName + " - ");
                System.Console.Write(data.parkName);
            });

        }

        public void DeleteData(string deleteColumn, string deleteName)
        {
            connection.Open();
            string cmdtext = $"DELETE FROM  dbo.桃園公共自行車即時服務資料 WHERE {deleteColumn}= N'{deleteName}'";
            SqlCommand cmd = new SqlCommand(cmdtext, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public List<桃園公共自行車即時服務資料> Xml_Load()
        {
            //寫作Xml讀做json
            var nodeList = new List<桃園公共自行車即時服務資料>();
            using (var webClient = new System.Net.WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                var json = webClient.DownloadString(@"https://data.tycg.gov.tw/opendata/datalist/datasetMeta/download?id=f4cc0b12-86ac-40f9-8745-885bddc18f79&rid=0daad6e6-0632-44f5-bd25-5e1de1e9146f").ToString();
                // Now parse with JSON.Net

                JObject obj = JsonConvert.DeserializeObject<JObject>(json);

                    JArray array = (JArray)obj["parkingLots"];
                    foreach (JObject obj_results in array)/*走訪JArray(results裡的每一筆JObject(這裡只有一筆)*/
                    {
                        var newitem = new 桃園公共自行車即時服務資料();
                        newitem.address = obj_results["address"].ToString();
                        newitem.areaId = obj_results["areaId"].ToString();
                        newitem.areaName = obj_results["areaName"].ToString();
                        newitem.parkName = obj_results["parkName"].ToString();
                    
                        newitem.totalSpace = uint.Parse(obj_results["totalSpace"].ToString());

                        newitem.surplusSpace = obj_results["surplusSpace"].ToString();

                        newitem.payGuide = obj_results["payGuide"].ToString();
                        newitem.introduction = obj_results["introduction"].ToString();

                        newitem.wgsx = double.Parse(obj_results["wgsX"].ToString());
                        newitem.wgsy = double.Parse(obj_results["wgsY"].ToString());
                        newitem.parkId = obj_results["parkId"].ToString();

                        nodeList.Add(newitem);
                        System.Console.WriteLine(obj_results["parkName"].ToString());
                    }

            }
            cacheList = nodeList;
            return nodeList;
        }


    }
}
