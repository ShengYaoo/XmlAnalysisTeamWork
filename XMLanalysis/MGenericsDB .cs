
using System.Collections.Generic;

namespace XMLanalysis
{


    interface MGenericsDB<T>{
        List<T> Xml_Load();
        void InsertData(T item);
        List<T> QueryData(string Row, string Name);
        void ShowData(List<T> list);
    }
   

}
