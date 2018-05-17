using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using XMLanalysis;

namespace XMLanalysis.OpenData
{
    public class FarmTran: IEqualityComparer<FarmTran>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string transactionDate { get; set; }
        public string cropCode { get; set; }
        public string cropName { get; set; }
        public string marketCode { get; set; }
        public string marketName { get; set; }
        public string priceHigh { get; set; }
        public string priceMid { get; set; }
        public string priceLow { get; set; }
        public string priceAvg { get; set; }
        public string transactionNum { get; set; }

        public bool Equals(FarmTran x, FarmTran y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(FarmTran obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
