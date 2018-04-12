using System;
using OpenData;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XMLanalysis   {
     
    class Program{
        static void Main(string[] args){

            MGenericsDB<FarmTran> mFarm = new FarmTranTable();
            /*var nodeList = mFarm.Xml_Load();
            nodeList.ForEach(item =>
            {
                mFarm.InsertData(item);
            });*/
            mFarm.ShowData(mFarm.QueryData("作物名稱", "椰子"));
            Console.ReadKey();
        }
          
            
     }
}
