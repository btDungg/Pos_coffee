using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Models
{
    public class StockModel
    {
        public string ImagePath {  get; set; }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Unit { get; set; }

        public int Price { get; set; }

        public int StockNumber { get; set; }
    }
}
