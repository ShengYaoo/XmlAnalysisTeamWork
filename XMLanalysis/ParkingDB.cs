using System;
using System.Collections.Generic;
using System.Linq;

using OpenData;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

//http://json2csharp.com/
namespace XMLanalysis

{
    public class ParkingDB : MGenericsDB<桃園公共自行車即時服務資料>
    {

        private static int count = 0;

        public void InsertData(桃園公共自行車即時服務資料 item)
        {
            throw new NotImplementedException();
        }

        void UpdateData(int updateID, 桃園公共自行車即時服務資料 item)
        {
            throw new NotImplementedException();
        }
        void DeleteData(string deleteColumn, string deleteName)
        {
            throw new NotImplementedException();
        }


        public List<桃園公共自行車即時服務資料> QueryData(string searchColumn, string searchName)
        {
            throw new NotImplementedException();
        }

        public void ShowData(List<桃園公共自行車即時服務資料> list)
        {
            throw new NotImplementedException();
        }

        public List<桃園公共自行車即時服務資料> Xml_Load()
        {
            var nodeList = new List<桃園公共自行車即時服務資料>();
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(@"https://data.tycg.gov.tw/opendata/datalist/datasetMeta/download?id=f4cc0b12-86ac-40f9-8745-885bddc18f79&rid=0daad6e6-0632-44f5-bd25-5e1de1e9146f");
                // Now parse with JSON.Net

                JObject obj = JsonConvert.DeserializeObject<JObject>(json);

                if (obj["status"].ToString() == "OK")
                {
                    JArray array = (JArray)obj["results"];
                    foreach (JObject obj_results in array)/*走訪JArray(results裡的每一筆JObject(這裡只有一筆)*/
                    {
                        var newitem = new 桃園公共自行車即時服務資料();
                        nodeList.Add(newitem);
                        System.Console.WriteLine(obj_results.ToString());

                    }


                }
            }

            
            

            return nodeList;
        }
    }
}
