using System;
using OpenData;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XMLanalysis   {
     
    class Program{
        static void Main(string[] args){

            MGenericsDB<FarmTran> mFarm = new FarmTranTable();
            /*
            var nodeList = mFarm.Xml_Load();
            nodeList.ForEach(item =>
            {
                mFarm.InsertData(item);
            });*/
            mFarm.ShowData(mFarm.QueryData("作物名稱", "椰子"));
            var farm = new FarmTran();
            farm.transactionDate = "107.4.13";
            mFarm.UpdateData(1,farm);
            mFarm.ShowData(mFarm.QueryData("交易日期", "107.4.13"));
            Console.ReadKey();
            Console.Clear();
            mFarm.DeleteData("交易日期", "107.4.13");
            mFarm.ShowData(mFarm.QueryData("交易日期", "107.4.13"));
            Console.ReadKey();
        }
          
            
     }
}
