using System;
using OpenData;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XMLanalysis   {

    class Program
    {
        static void Main(string[] args)
        {


            MGenericsDB<PharmaceuticalFactory> mPF = new PharmaTable();
            var nodeList = mPF.Xml_Load();
            //nodeList.ForEach(item =>
            //{
            //    mPF.InsertData(item);
            //});
            //mPF.ShowData(mPF.QueryData("類別", "西藥製劑廠"));
            var pf = new PharmaceuticalFactory();
            pf.type = "test藥廠";
            pf.name = "高應藥廠";
            mPF.UpdateData(227, pf);
            Console.WriteLine("UPDATE ID:227，類別:test藥廠，名稱:高應藥廠");
            mPF.DeleteData("ID", "1");
            Console.WriteLine("Delete ID:1");
            Console.ReadKey();
        }

    }
}
