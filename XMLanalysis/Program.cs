using System;
using OpenData;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XMLanalysis   {
     
    class Program{
        static void Main(string[] args){


            //-------------------------------------------------------------ShengYaood
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
            //-------------------------------------------------------------YuSyuan1208     
            MGenericsDB<Pharmacy_03> mPharmacy_03 = new PharmacyTable_03();
            /*var nodeList = mPharmacy_03.Xml_Load();
            nodeList.ForEach(item =>
            {
                PharmacyTable_03 SqlData;
                SqlData = new PharmacyTable_03();
                SqlData.InsertData(item);
            });*/
            mPharmacy_03.ShowData(mPharmacy_03.QueryData("機構名稱", "和平藥局"));
            var nPharmacy_03 = new Pharmacy_03();
            nPharmacy_03.機構名稱 = "機構名稱";
            nPharmacy_03.機構狀態 = "機構狀態";
            nPharmacy_03.地址 = "地址";
            nPharmacy_03.電話 = "電話";
            mPharmacy_03.UpdateData(1, nPharmacy_03);
            mPharmacy_03.DeleteData("機構名稱", "機構名稱");
            Console.ReadKey();
            
        }                    
     }
}
