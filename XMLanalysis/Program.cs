using System;
using OpenData;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XMLanalysis   {
     
    class Program{
        static void Main(string[] args){

    
            LoadPharma();
        }

        private static void LoadPharma() {
            XElement element = XElement.Load(@"D:\gitwork\XmlAnalysisTeamWork\XMLanalysis\bin\Debug\Data.xml");
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
