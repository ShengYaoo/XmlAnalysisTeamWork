using System;
using OpenData;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XMLanalysis   {
     
    class Program{
        static void Main(string[] args){

            LoadFarmTran();
            LoadPharma();
        }
        private static void LoadFarmTran() {
            var nodeList = new List<FarmTran>();

            XDocument docNew = XDocument.Load(@"C:\Users\user\Downloads\XMLanalysis-master\XMLanalysis-master\FarmTransData.xml");
            //Console.WriteLine(docNew.ToString());
            IEnumerable<XElement> nodes = docNew.Element("DocumentElement").Elements("row");

            nodeList = nodes
                .Select(node => {
                    var item = new FarmTran();
                    item.transactionDate = getValue(node, "交易日期");
                    item.cropCode = getValue(node, "作物代號");
                    item.cropName = getValue(node, "作物名稱");
                    item.marketCode = getValue(node, "市場代號");
                    item.marketName = getValue(node, "市場名稱");
                    item.priceHigh = getValue(node, "上價");
                    item.priceMid = getValue(node, "中價");
                    item.priceLow = getValue(node, "下價");
                    item.priceAvg = getValue(node, "平均價");
                    item.transactionNum = getValue(node, "交易量");
                    return item;

                }).ToList();

            FarmTranTable mFarm = new FarmTranTable();
            nodeList.ForEach(item =>
            {
                mFarm.InsertData(item);

            });
            Console.ReadKey();
        }
        private static void LoadPharma() {
            XElement element = XElement.Load(@"C:\Users\user\Downloads\XMLanalysis-master\XMLanalysis-master\PharmaceuticalFactoryData.xml");
            List<PharmaceuticalFactory> list = new List<PharmaceuticalFactory>();
            element.Descendants("row").ToList().ForEach(row =>
            {
                PharmaceuticalFactory PF = new PharmaceuticalFactory();
                PF.type = row.Element("Col1").Value;
                PF.name = row.Element("Col2").Value;
                PF.address = row.Element("Col3").Value;
                PF.formulation = row.Element("Col4").Value;
                PF.approved_items = row.Element("Col5").Value;
                PF.GMP = row.Element("Col6").Value;
                PF.GDP = row.Element("Col7").Value;
                PF.note = row.Element("Col8").Value;
                list.Add(PF);
            });
            IEnumerable<XElement> nodes = element.Descendants("row");

            list = nodes
                .Select(node => {
                    PharmaceuticalFactory PF = new PharmaceuticalFactory();
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



            PharmaTable mPhar = new PharmaTable();
            list.ForEach(item =>
            {
                mPhar.InsertData(item);

            });

        }
        private static string getValue(XElement node, string propertyName) {
            return node.Element(propertyName)?.Value.Trim();
        }
       
      
       
    }
}
