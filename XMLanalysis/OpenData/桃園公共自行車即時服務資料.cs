//https://data.gov.tw/dataset/25940

//json source: https://data.tycg.gov.tw/opendata/datalist/datasetMeta/download?id=f4cc0b12-86ac-40f9-8745-885bddc18f79&rid=0daad6e6-0632-44f5-bd25-5e1de1e9146f
namespace OpenData
{
    public class 桃園公共自行車即時服務資料
    {
        //(地區編碼)
        public string areaId { get; set; }
        //(地區名稱)
        public string areaName { get; set; }
        //(停車場名稱)
        public string parkName { get; set; }
        //(總車位數)
        public uint totalSpace { get; set; }
        //(剩餘車位數)
        public string surplusSpace { get; set; }
        //(計費方式說明)
        public string payGuide { get; set; }
        //(停車場介紹)
        public string introduction { get; set; }
        //(住址)
        public string address { get; set; }
        //(經緯度)
        public double wgsx { get; set; }
        public double wgsy { get; set; }
        //(停車場編碼)
        public string parkId { get; set; }
    }
}
