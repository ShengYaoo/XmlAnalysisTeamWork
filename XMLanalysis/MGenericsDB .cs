
using System.Collections.Generic;


namespace XMLanalysis
{


    public interface MGenericsDB<T> where T:class{
        List<T> Xml_Load();        
        void InsertData(T item);
        List<T> QueryData(string searchColumn, string searchName);
        void ShowData(List<T> list);

    }
  
   
    

}
