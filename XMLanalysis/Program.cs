using System;
using OpenData;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XMLanalysis   {
     
    class Program{
        static void Main(string[] args){

            MGenericsDB<桃園公共自行車即時服務資料> mFarm = new ParkingDB();
            var nodeList = mFarm.Xml_Load();

            Console.ReadKey();
        }
          
            
     }
}
