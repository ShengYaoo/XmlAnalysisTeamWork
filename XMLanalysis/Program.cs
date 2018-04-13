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
            /*var nodeList = mFarm.Xml_Load();
            nodeList.ForEach(item =>
            {
                mPF.InsertData(item);
            });*/
            mPF.ShowData(mPF.QueryData("類別", "椰子"));
            Console.ReadKey();
        }

    }
}
